using UnityEngine;

namespace ShootEmUp
{
    public class CharacterMoveController : MonoBehaviour
    {
        [SerializeField]
        private InputSystem input;

        [SerializeField]
        private GameObject character;

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
            if (character.TryGetComponent(out MoveComponentBase moveComponent))
            {
                moveComponent.SetDirection(direction);
            }
        }
    }
}