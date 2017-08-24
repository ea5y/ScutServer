using ProtoBuf;
using System;
using ZyGames.Framework.Model;

namespace ScutGameServer.Model
{
    [Serializable, ProtoContract]
    [EntityTable( CacheType.Dictionary, "TestData")]
    public class GameUser : BaseEntity
    {
        [ProtoMember(1)]
        [EntityField(true, IsIdentity = true)]
        public int Index { get; set; }

        [ProtoMember(2)]
        [EntityField]
        public int UserId { get; set; }

        [ProtoMember(3)]
        [EntityField]
        public string NickName { get; set; }

        [ProtoMember(4)]
        [EntityField]
        public int Hp { get; set; }

        [ProtoMember(5)]
        [EntityField]
        public float PosX { get; set; }

        [ProtoMember(6)]
        [EntityField]
        public float PosY { get; set; }

        [ProtoMember(7)]
        [EntityField]
        public float PosZ { get; set; }

        protected override int GetIdentityId()
        {
            return UserId;
        }
    }
}
