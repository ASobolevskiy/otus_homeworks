using System;
using System.Collections.Generic;
using ShootEmUp.DI;
using UnityEngine;

namespace ShootEmUp.Installers
{
    public class CharacterInstaller : BaseInstaller,
        Providers.IGameListenerProvider,
        Providers.IServiceProvider
    {
        [SerializeField]
        private GameObject character;

        private readonly CharacterDeathObserver characterDeathObserver = new();
        private readonly CharacterMoveController characterMoveController = new();
        private readonly CharacterFireController characterFireController = new();
        
        public IEnumerable<Listeners.IGameListener> ProvideListeners()
        {
            yield return characterDeathObserver;
            yield return characterMoveController;
            yield return characterFireController;
        }

        public IEnumerable<(Type, object)> ProvideServices()
        {
            yield return (typeof(GameObject), character);
        }
    }
}