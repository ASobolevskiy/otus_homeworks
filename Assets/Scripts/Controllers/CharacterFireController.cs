using UnityEngine;

namespace ShootEmUp
{
    public class CharacterFireController : MonoBehaviour
    {
        [SerializeField]
        private InputSystem input;
        
        [SerializeField]
        private BulletSystem bulletSystem;

        [SerializeField]
        private BulletConfig bulletConfig;

        [SerializeField]
        private GameObject character;

        private void OnEnable()
        {
            input.OnFire += Fire;
        }

        private void OnDisable()
        {
            input.OnFire -= Fire;
        }

        private void Fire()
        {
            if (character.TryGetComponent(out WeaponComponent weapon))
            {
                bulletSystem.FlyBulletByArgs(new BulletSystem.Args
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