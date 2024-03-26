using ShootEmUp.Timers;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class StartButtonInteractionListener : MonoBehaviour
    {
        [SerializeField]
        private Timer timer;

        [SerializeField]
        private Button startButton;

        private void Awake()
        {
            startButton.onClick.AddListener(StartCountDown);
        }

        private void OnDestroy()
        {
            startButton.onClick.RemoveListener(StartCountDown);
        }

        private void StartCountDown()
        {
            timer.StartTimer();
            startButton.onClick.RemoveListener(StartCountDown);
            gameObject.SetActive(false);
        }
    }
}