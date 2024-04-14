using System.Reflection;
using ShootEmUp.DI;
using ShootEmUp.Providers;
using UnityEngine;

namespace ShootEmUp.Installers
{
    public abstract class BaseInstaller : MonoBehaviour,
        IInjectProvider
    {
        public virtual void Inject(ServiceLocator serviceLocator)
        {
            FieldInfo[] fields = GetType().GetFields(BindingFlags.Instance 
                                                     | BindingFlags.Public 
                                                     | BindingFlags.NonPublic 
                                                     | BindingFlags.DeclaredOnly);
            for (int i = 0; i < fields.Length; i++)
            {
                var target = fields[i].GetValue(this);
                DependencyInjector.Inject(target, serviceLocator);
            }
        }
    }
}