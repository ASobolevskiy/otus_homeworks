using System;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace ShootEmUp.Installers
{
    public class UiInstaller : BaseInstaller,
        Providers.IGameListenerProvider
    {
        [SerializeField]
        private PauseResumeButtonHandler pauseResumeButtonHandler;

        [SerializeField]
        private PauseResumeButtonStateController pauseResumeButtonStateController;

        public IEnumerable<Listeners.IGameListener> ProvideListeners()
        {
            yield return pauseResumeButtonHandler;
            yield return pauseResumeButtonStateController;
        }
    }
}