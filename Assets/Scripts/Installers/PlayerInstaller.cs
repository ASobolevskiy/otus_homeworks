using System;
using System.Collections.Generic;

namespace ShootEmUp.Installers
{
    public class PlayerInstaller : BaseInstaller,
        Providers.IGameListenerProvider,
        Providers.IServiceProvider
    {
        private readonly InputSystem inputSystem = new();
        public IEnumerable<Listeners.IGameListener> ProvideListeners()
        {
            yield return inputSystem;
        }

        public IEnumerable<(Type, object)> ProvideServices()
        {
            yield return (typeof(InputSystem), inputSystem);
        }
    }
}