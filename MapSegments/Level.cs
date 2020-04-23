using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MahJong.LevelMap
{
    [DataContract]
    internal class Level
    {
        #pragma warning disable 0649
        [DataMember]
        internal int FieldHeight;

        [DataMember]
        internal int FieldWidth;

        [DataMember]
        internal int TotalHeight;

        [DataMember]
        internal int StartPointX;

        [DataMember]
        internal int StartPointY;

        [DataMember]
        internal int SecretUpperLeftX;

        [DataMember]
        internal int SecretUpperLeftY;

        [DataMember]
        internal int SecretLowerRightX;

        [DataMember]
        internal int SecretLowerRightY;

        [DataMember]
        internal List<SerializableEnemyObject> EnemyObjects;

        [DataMember]
        internal List<SerializableStructuralObject> StructuralObjects;

        [DataMember]
        internal List<SerializablePipes> Pipes;

        [DataMember]
        internal List<SerializableCoins> Coins;

        [DataMember]
        internal List<SerializableFlags> Flags;
        #pragma warning restore 0649
    }

    [DataContract]
    internal class SerializableEnemyObject
    {
        #pragma warning disable 0649
        [DataMember]
        internal string EnemyType;

        [DataMember]
        internal int LocationX;

        [DataMember]
        internal int LocationY;
        #pragma warning restore 0649
    }

    [DataContract]
    internal class SerializableStructuralObject
    {
        #pragma warning disable 0649
        [DataMember]
        internal string BlockType;

        [DataMember]
        internal bool Hidden;

        [DataMember]
        internal int CoinNumber;

        [DataMember]
        internal string PowerUpItem;

        [DataMember]
        internal int LocationX;

        [DataMember]
        internal int LocationY;
        #pragma warning restore 0649
    }

    [DataContract]
    internal class SerializablePipes
    {
        #pragma warning disable 0649
        [DataMember]
        internal bool Active;

        [DataMember]
        internal int Height;

        [DataMember]
        internal int Width;

        [DataMember]
        internal int LocationX;

        [DataMember]
        internal int LocationY;

        [DataMember]
        internal bool InSecret;

        [DataMember]
        internal int TargetX;

        [DataMember]
        internal int TargetY;

        [DataMember]
        internal bool HasEnemy;
        #pragma warning restore 0649
    }

    [DataContract]
    internal class SerializableCoins
    {
        #pragma warning disable 0649

        [DataMember]
        internal int LocationX;

        [DataMember]
        internal int LocationY;
        #pragma warning restore 0649
    }

    [DataContract]
    internal class SerializableFlags
    {
        #pragma warning disable 0649

        [DataMember]
        internal int LocationX;

        [DataMember]
        internal int LocationY;
        #pragma warning restore 0649
    }


}
