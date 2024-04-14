using DI.Attributes;
using UnityEngine;

namespace ShootEmUp
{
    public class CharacterMoveController :
        Listeners.IGameStartListener,
        Listeners.IGameFinishListener
    {
        private InputSystem input;
        private GameObject character;

        [Inject]
        public void Construct(InputSystem inputSystem, GameObject character)
        {
            input = inputSystem;
            this.character = character;
        }

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