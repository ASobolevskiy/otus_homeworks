using System.Collections.Generic;

namespace ShootEmUp.Providers
{
    public interface IGameListenerProvider
    {
        IEnumerable<Listeners.IGameListener> ProvideListeners();
    }
}