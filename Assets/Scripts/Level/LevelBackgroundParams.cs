using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed partial class LevelBackground
    {
        [Serializable]
        public sealed class Params
        {
            [SerializeField]
            public float startPositionY;
            
            [SerializeField]
            public float endPositionY;
            
            [SerializeField]
            public float movingSpeedY;
        }
    }
}