using UnityEngine;

namespace ShootEmUp
{
    public class CharacterMoveController : MonoBehaviour,
        Listeners.IGameStartListener,
        Listeners.IGameFinishListener
    {
        [SerializeField]
        private InputSystem input;

        [SerializeField]
        private GameObject character;

        public void OnGameStarted()
        {
            input.OnMove += SetDirection;
        }

        public void OnGameFinished()
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