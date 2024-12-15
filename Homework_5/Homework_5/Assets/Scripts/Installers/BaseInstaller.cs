using System;
using System.Collections.Generic;
using System.Reflection;
using DI;
using UnityEngine;
using IServiceProvider = DI.IServiceProvider;

namespace Installers
{
    public class BaseInstaller : MonoBehaviour, IServiceProvider, IInjectProvider
    {
        public IEnumerable<(Type, object)> ProvideServices()
        {
            FieldInfo[] fields = GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);
            foreach (var t in fields)
            {
                var attribute = t.GetCustomAttribute<ServiceAttribute>();
                if (attribute == null) 
                    continue;
                var type = attribute.Contract;
                var service = t.GetValue(this);
                yield return (type, service);
            }
        }

        public virtual void Inject(ServiceLocator serviceLocator)
        {
            FieldInfo[] fields = GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);
            for (int i = 0; i < fields.Length; i++)
            {
                var target = fields[i].GetValue(this);
                DependencyInjector.Inject(target, serviceLocator);
            }
        }
    }
}