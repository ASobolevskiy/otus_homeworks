using ShootEmUp.Timers;
using TMPro;
using UnityEngine;

namespace UI
{
    public class CountDownFieldTextManager : MonoBehaviour
    {
        [SerializeField]
        private Timer timer;

        [SerializeField]
        private GameObject countdownField;

        private void Awake()
        {
            countdownField.SetActive(false);
            timer.OnTimerStarted += HandleTimerStarted;
            timer.OnTimerValueChanged += HandleTimerValueChanged;
        }

        private void OnDestroy()
        {
            timer.OnTimerStarted -= HandleTimerStarted;
            timer.OnTimerValueChanged -= HandleTimerValueChanged;
        }

        private void HandleTimerStarted(float startValue)
        {
            countdownField.SetActive(true);
            if (countdownField.TryGetComponent(out TextMeshProUGUI textMesh))
            {
                var text = startValue <= 0 ? string.Empty : $"{startValue:0}";
                textMesh.text = text;
            }
        }
        private void HandleTimerValueChanged(float timeToDisplay)
        {
            var remainingSeconds = Mathf.FloorToInt(timeToDisplay % 60) + 1;
            if (countdownField.TryGetComponent(out TextMeshProUGUI textMesh))
            {
                var text = remainingSeconds <= 0 ? string.Empty : $"{remainingSeconds:0}";
                textMesh.text = text;
            }
        }
    }
}