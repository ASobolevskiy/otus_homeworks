using DI;
using GameEngine;
using UnityEngine;
using IServiceProvider = DI.IServiceProvider;

public sealed class SceneContext : MonoBehaviour
{
    [SerializeField]
    private ServiceLocator serviceLocator;

    [SerializeField]
    private MonoBehaviour[] modules;

    private void Awake()
    {
        foreach (var module in modules)
        {
            if (module is IServiceProvider serviceProvider)
            {
                serviceLocator.BindServices(serviceProvider.ProvideServices());
            }
        }
    }

    private void Start()
    {
        for (int i = 0; i < modules.Length; i++)
        {
            if (modules[i] is IInjectProvider tProvider)
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
        
        serviceLocator.GetService<UnitManager>().SetupUnits(FindObjectsOfType<Unit>());
        serviceLocator.GetService<ResourceService>().SetResources(FindObjectsOfType<Resource>());
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
