using System;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp.Installers
{
    public class GameInstaller : BaseInstaller,
        Providers.IServiceProvider
    {
        [SerializeField]
        private Transform worldTransform;
        
        private readonly GameFinishObserver gameFinishObserver = new();
        public IEnumerable<(Type, object)> ProvideServices()
        {
            yield return (typeof(Transform), worldTransform);
        }
    }
}