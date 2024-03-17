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
            this.character.GetComponent<HitPointsComponent>().OnHpEmpty += this.OnCharacterDeath;
        }

        private void OnDisable()
        {
            this.character.GetComponent<HitPointsComponent>().OnHpEmpty -= this.OnCharacterDeath;
        }

        private void OnCharacterDeath(GameObject _) => this.gameManager.FinishGame();
    }
}