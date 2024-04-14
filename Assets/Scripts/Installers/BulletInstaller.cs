using System;
using System.Collections.Generic;
using ShootEmUp.DI;
using ShootEmUp.Factories;
using UnityEngine;

namespace ShootEmUp.Installers
{
    public class BulletInstaller : BaseInstaller,
        Providers.IGameListenerProvider,
        Providers.IServiceProvider
    {
        [SerializeField]
        private BulletConfig bulletConfig;

        [SerializeField]
        private BulletPool bulletPool;

        [SerializeField]
        private BulletFactory bulletFactory;
        
        private readonly BulletSystem bulletSystem = new();
        
        public IEnumerable<Listeners.IGameListener> ProvideListeners()
        {
            yield return bulletPool;
            yield return bulletSystem;
        }

        public IEnumerable<(Type, object)> ProvideServices()
        {
            yield return (typeof(BulletConfig), bulletConfig);
            yield return (typeof(BulletPool), bulletPool);
            yield return (typeof(BulletSystem), bulletSystem);
            yield return (typeof(BulletFactory), bulletFactory);
        }
    }
}