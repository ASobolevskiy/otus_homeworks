using System;
using System.Collections.Generic;

namespace ShootEmUp.Providers
{
    public interface IServiceProvider
    {
        IEnumerable<(Type, object)> ProvideServices();
    }
}