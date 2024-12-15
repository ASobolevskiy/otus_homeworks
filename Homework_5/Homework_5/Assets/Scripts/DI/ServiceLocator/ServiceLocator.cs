using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DI
{
    public class ServiceLocator : MonoBehaviour
    {
        [ShowInInspector, ReadOnly]
        private readonly Dictionary<Type, List<object>> services = new();

        public T GetService<T>() where T : class
        {
            var serviceList = services[typeof(T)].Cast<T>();
            return services[typeof(T)][0] as T;
        }

        public object GetService(Type type)
        {
            var servicesList = services[type];
            return servicesList[0];
        }
        
        public object[] GetServiceList(Type type)
        {
            return services[type].ToArray();
        }

        public void BindService(Type type, object service)
        {
            if (services.Keys.Contains(type))
            {
                services[type].Add(service);
            }
            else
            {
                services.Add(type, new List<object>{service});
            }
        }

        public void BindServices(IEnumerable<(Type, object)> services)
        {
            foreach (var (type, service) in services)
            {
                BindService(type, service);
            }
        }
    }
}