using GameServer.CsScript;
using GameServer.CsScript.CommunicationDataStruct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZyGames.Framework.Game.Contract;

namespace GameServer.Script.CsScript.Cast
{
    public class CastSyncPlayerState : ICast
    {
        private GameSession _session;
        private SyncStateData _data;
        
        public CastSyncPlayerState(GameSession session, SyncStateData data)
        {
            _session = session;
            _data = data;
        }

        public void Send()
        {
            CharacterManager.SyncState(_session, _data);
        }
    }
}
