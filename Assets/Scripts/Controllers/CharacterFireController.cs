using DI.Attributes;
using UnityEngine;

namespace ShootEmUp
{
    public class CharacterFireController :
        Listeners.IGameStartListener,
        Listeners.IGameFinishListener
    {
        private BulletSystem bulletSystem;
        private BulletConfig bulletConfig;
        private GameObject character;
        private InputSystem input;

        [Inject]
        public void Construct(InputSystem inputSystem, GameObject character, BulletConfig bulletConfig, BulletSystem bulletSystem)
        {
            input = inputSystem;
            this.character = character;
            this.bulletConfig = bulletConfig;
            this.bulletSystem = bulletSystem;
        }

        public void OnGameStarted()
        {
            input.OnFire += Fire;
        }

        public void OnGameFinished()
        {
            input.OnFire -= Fire;
        }

        private void Fire()
        {
            if (character.TryGetComponent(out WeaponComponent weapon))
            {
                bulletSystem.FlyBulletByArgs(new BulletArgs
                {
                    isPlayer = true,
                    physicsLayer = (int)bulletConfig.physicsLayer,
                    color = bulletConfig.color,
                    damage = bulletConfig.damage,
                    position = weapon.Position,
                    velocity = weapon.Rotation * Vector3.up * bulletConfig.speed
                });
            }
        }
    }
}