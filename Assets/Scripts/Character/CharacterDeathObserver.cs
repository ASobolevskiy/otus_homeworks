using DI.Attributes;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterDeathObserver :
        Listeners.IGameStartListener,
        Listeners.IGameFinishListener
    {
        private GameObject character;
        private GameManager gameManager;

        [Inject]
        public void Construct(GameObject character, GameManager gameManager)
        {
            this.character = character;
            this.gameManager = gameManager;
        }

        public void OnGameStarted()
        {
            if (character.TryGetComponent(out HitPointsComponent hpComponent))
            {
                hpComponent.OnHpEmpty += OnCharacterDeath;
            }
        }

        public void OnGameFinished()
        {
            if (character.TryGetComponent(out HitPointsComponent hpComponent))
            {
                hpComponent.OnHpEmpty -= OnCharacterDeath;
            }
        }

        private void OnCharacterDeath(GameObject _) => gameManager.HandleFinish();
    }
}