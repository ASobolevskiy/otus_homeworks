using System;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp.DI
{
    public class ServiceLocator : MonoBehaviour
    {
        private readonly Dictionary<Type, object> services = new();

        public T GetService<T>() where T : class
        {
            return services[typeof(T)] as T;
        }

        public object GetService(Type type)
        {
            return services[type];
        }

        public void BindService(Type type, object service)
        {
            services.Add(type, service);
        }

        internal void BindServices(IEnumerable<(Type, object)> services)
        {
            foreach (var (type, service) in services)
            {
                BindService(type, service);
            }
        }
    }
}