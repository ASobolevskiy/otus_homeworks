using System;
using UnityEngine;

namespace ShootEmUp
{
    [Serializable]
    public sealed class LevelBackgroundParams
    {
        [SerializeField]
        public float startPositionY;

        [SerializeField]
        public float endPositionY;

        [SerializeField]
        public float movingSpeedY;
    }
}