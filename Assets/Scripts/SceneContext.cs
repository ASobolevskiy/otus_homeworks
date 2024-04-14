using System;
using SceneLoaders;
using ShootEmUp.DI;
using UnityEngine;

namespace ShootEmUp
{
    public class SceneContext : MonoBehaviour
    {
        [SerializeField]
        private ServiceLocator serviceLocator;
        
        [Space]
        [SerializeField]
        private MonoBehaviour[] modules;

        private GameManager gameManager;
        
        private readonly SceneLoader sceneLoader = new();

        private void Awake()
        {
            gameManager = GetComponent<GameManager>();
            
            for (int i = 0; i < modules.Length; i++)
            {
                if (modules[i] is Providers.IGameListenerProvider listenersProvider)
                {
                    gameManager.AddGameListeners(listenersProvider.ProvideListeners());
                }
                if (modules[i] is Providers.IServiceProvider tProvider)
                {
                    serviceLocator.BindServices(tProvider.ProvideServices());
                }
            }
            
            var listeners = GetComponentsInChildren<Listeners.IGameListener>();
            gameManager.AddGameListeners(listeners);

            serviceLocator.BindService(typeof(GameManager), gameManager);
            serviceLocator.BindService(typeof(SceneLoader), sceneLoader);
        }

        private void Start()
        {
            for (int i = 0; i < modules.Length; i++)
            {
                if (modules[i] is Providers.IInjectProvider tProvider)
                {
                    tProvider.Inject(serviceLocator);
                }
            }

            GameObject[] rootGameObjects = gameObject.scene.GetRootGameObjects();
            for (int i = 0; i < rootGameObjects.Length; i++)
            {
                GameObject target = rootGameObjects[i];
                StartInjection(target.transform);
            }

            gameManager.HandleStart();
        }

        private void StartInjection(Transform targetTransform)
        {
            MonoBehaviour[] targets = targetTransform.GetComponents<MonoBehaviour>();
            for (int i = 0; i < targets.Length; i++)
            {
                DependencyInjector.Inject(targets[i], serviceLocator);
            }

            foreach (Transform child in targetTransform)
            {
                StartInjection(child);
            }
        }
    }
}