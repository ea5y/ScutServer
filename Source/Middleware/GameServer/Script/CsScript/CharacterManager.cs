using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZyGames.Framework.Common.Serialization;
using ZyGames.Framework.Game.Contract;
using ZyGames.Framework.RPC.Sockets;

namespace GameServer.Script.CsScript
{
    public class CharacterSyncData
    {
    }

    public class CharacterManager
    {
        private static Dictionary<int, CharacterSyncData> _charaDic = new Dictionary<int, CharacterSyncData>();

        public static void AddCharacter(int key, CharacterSyncData value)
        {
            _charaDic.Add(key, value);
        }

        public static void RemoveCharacter(int key)
        {
            _charaDic.Remove(key);
        }

        public static void Send(GameSession[] sessions, int ignoreUserId)
        {
            foreach(var session in sessions)
            {
                if (session.UserId == ignoreUserId)
                    continue;

                
                byte[] data = Encoding.UTF8.GetBytes("This is sent to the client data.");
                session.SendAsync(OpCode.Text, data, 0, data.Length, asyncResult =>
                        {
                            Console.WriteLine("The results of data send:{0}", asyncResult.Result == ResultCode.Success ? "ok" : "fail");
                        }).Wait();
            }
        }
    }
}
