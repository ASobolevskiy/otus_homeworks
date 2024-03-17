using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterDeathObserver : MonoBehaviour
    {
        [SerializeField] 
        private GameObject character; 
        
        [SerializeField] 
        private GameManager gameManager;

        private void OnEnable()
        {
            character.GetComponent<HitPointsComponent>().OnHpEmpty += OnCharacterDeath;
        }

        private void OnDisable()
        {
            character.GetComponent<HitPointsComponent>().OnHpEmpty -= OnCharacterDeath;
        }

        private void OnCharacterDeath(GameObject _) => gameManager.FinishGame();
    }
}