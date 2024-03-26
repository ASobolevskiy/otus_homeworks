using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed partial class LevelBackground : MonoBehaviour,
        Listeners.IFixedUpdateListener
    {
        private float startPositionY;
        private float endPositionY;
        private float movingSpeedY;
        private float positionX;
        private float positionZ;
        private Transform myTransform;

        [SerializeField]
        private GameManager gameManager;
        
        [SerializeField]
        private Params parameters;

        private void Awake()
        {
            startPositionY = parameters.startPositionY;
            endPositionY = parameters.endPositionY;
            movingSpeedY = parameters.movingSpeedY;
            myTransform = transform;
            var position = myTransform.position;
            positionX = position.x;
            positionZ = position.z;
            gameManager.AddGameListener(this);
        }

        private void OnDestroy()
        {
            gameManager.RemoveGameListener(this);
        }

        public void OnFixedUpdate(float fixedDeltaTime)
        {
            if (myTransform.position.y <= endPositionY)
            {
                myTransform.position = new Vector3(
                    positionX,
                    startPositionY,
                    positionZ
                );
            }

            myTransform.position -= new Vector3(
                positionX,
                movingSpeedY * fixedDeltaTime,
                positionZ
            );
        }
    }
}