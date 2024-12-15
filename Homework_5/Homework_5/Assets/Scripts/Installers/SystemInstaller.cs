using DI;
using GameEngine;
using UnityEngine;

namespace Installers
{
    public class SystemInstaller : BaseInstaller
    {
        [SerializeField, Service(typeof(UnitManager))]
        private UnitManager unitManager;

        [SerializeField, Service(typeof(ResourceService))]
        private ResourceService resourceService;
    }
}