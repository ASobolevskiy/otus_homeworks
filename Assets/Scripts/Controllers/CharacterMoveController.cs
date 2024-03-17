using UnityEngine;

namespace ShootEmUp
{
    public class CharacterMoveController : MonoBehaviour
    {
        [SerializeField]
        private InputSystem input;

        [SerializeField]
        private GameObject character;

        private Vector2 direction;

        private void OnEnable()
        {
            input.OnMove += SetDirection;
        }

        private void OnDisable()
        {
            input.OnMove -= SetDirection;
        }
        
        private void SetDirection(Vector2 direction)
        {
            this.direction = direction;
        }

        private void FixedUpdate()
        {
            if (character.TryGetComponent(out MoveComponentBase moveComponent))
            {
                moveComponent.SetDirection(direction);
            }
        }
    }
}