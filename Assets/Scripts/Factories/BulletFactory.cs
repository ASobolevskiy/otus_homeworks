using System;
using UnityEngine;

namespace ShootEmUp.Factories
{
    [Serializable]
    public class BulletFactory
    {
        [SerializeField]
        private Bullet bulletPrefab;

        public Bullet CreateBullet(Transform container)
        {
            return UnityEngine.Object.Instantiate(bulletPrefab, container);
        }
    }
}