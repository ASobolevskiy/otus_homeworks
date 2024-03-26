using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterDeathObserver : MonoBehaviour,
        Listeners.IGameStartListener,
        Listeners.IGameFinishListener
    {
        [SerializeField] 
        private GameObject character; 
        
        [SerializeField] 
        private GameManager gameManager;

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