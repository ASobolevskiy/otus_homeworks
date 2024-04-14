using System;
using System.Collections.Generic;
using ShootEmUp.DI;
using UnityEngine;

namespace ShootEmUp.Installers
{
    public class LevelInstaller : MonoBehaviour,
        Providers.IGameListenerProvider,
        Providers.IServiceProvider
    {
        [SerializeField]
        private LevelBackground levelBackground;

        [SerializeField]
        private LevelBackgroundParams backgroundParams;

        [Space]
        [SerializeField]
        private LevelBounds levelBounds;

        public IEnumerable<Listeners.IGameListener> ProvideListeners()
        {
            yield return levelBackground;
        }

        public IEnumerable<(Type, object)> ProvideServices()
        {
            yield return (typeof(LevelBackgroundParams), backgroundParams);
            yield return (typeof(LevelBounds), levelBounds);
        }
    }
}