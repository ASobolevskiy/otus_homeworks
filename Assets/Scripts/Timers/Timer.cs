using System;
using UnityEngine;

namespace ShootEmUp.Timers
{
    public class Timer : MonoBehaviour
    {
        public event Action<float> OnTimerStarted;
        public event Action<float> OnTimerValueChanged;
        public event Action OnTimerElapsed;

        [SerializeField]
        private float timeInterval = 3;

        private bool isTimerCounting = false;
        private float time;

        private void Awake()
        {
            time = timeInterval;
        }

        private void Update()
        {
            if (!isTimerCounting)
                return;
            if (time > 0)
            {
                time -= Time.deltaTime;
                OnTimerValueChanged?.Invoke(time);
            }
            else
            {
                time = timeInterval;
                isTimerCounting = false;
                OnTimerElapsed?.Invoke();
                Debug.Log("Time is up!");
            }
        }

        public void StartTimer()
        {
            isTimerCounting = true;
            OnTimerStarted?.Invoke(timeInterval);
        }
    }
}