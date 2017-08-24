using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZyGames.Framework.Model;
using ProtoBuf;

namespace ScutGameServer.Model
{
    [Serializable, ProtoContract]
    [EntityTable(CacheType.Entity, "TestData")]
    public class Users : ShareEntity
    {
        [ProtoMember(1)]
        [EntityField(true)]
        public int UserId { get; set; }

        [ProtoMember(2)]
        [EntityField]
        public string Username { get; set; }

        [ProtoMember(3)]
        [EntityField]
        public string Password { get; set; }
    }
}
