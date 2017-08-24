using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZyGames.Framework.Cache.Generic;
using ZyGames.Framework.Game.Contract;
using ScutGameServer.Model;
using Newtonsoft.Json;
using ZyGames.Framework.Game.Service;
using ZyGames.Framework.Net;

namespace GameServer.CsScript.Action
{
    public class LoginData
    {
        public string Username;
        public string Password;
    }

    public class Action1002 : BaseStruct
    {
        private LoginData _loginData;
        private GameUser _gameUser;

        public Action1002(ActionGetter actionGetter) : base(ActionID.Login, actionGetter)
        {
        }

        public override bool TakeAction()
        {
            var usersCache = new ShareCacheStruct<Users>();
            var user = usersCache.Find(u => u.Username == _loginData.Username );
            if(user == null)
            {
                var gameuser = new GameUser() { UserId = (int)usersCache.GetNextNo(), NickName = _loginData.Username, Hp = 100 };
                new PersonalCacheStruct<GameUser>().Add(gameuser);

                user = new Users();
                user.UserId = gameuser.UserId;
                user.Username = _loginData.Username;
                user.Password = _loginData.Password;
                usersCache.Add(user);

                _gameUser = gameuser;
            }
            else
            {
                var gameuserCache = new PersonalCacheStruct<GameUser>();
                _gameUser = gameuserCache.Find(user.UserId.ToString(), gu => gu.UserId == user.UserId);
            }
            return true;
        }

        public override bool GetUrlElement()
        {
            string str = string.Empty;
            if(httpGet.GetString("data", ref str))
            {
                _loginData = JsonConvert.DeserializeObject<LoginData>(str);
            }
            return true;
        }

        public override void BuildPacket()
        {
            PushIntoStack( JsonConvert.SerializeObject(_gameUser));
        }
    }
}
