using System;
using System.Reflection;
using DI.Attributes;

namespace ShootEmUp.DI
{
    public static class DependencyInjector
    {
        public static void Inject(object target, ServiceLocator serviceLocator)
        {
            Type type = target.GetType();
            MethodInfo[] methods = type.GetMethods(BindingFlags.Instance
                                                   | BindingFlags.Public
                                                   | BindingFlags.NonPublic
                                                   | BindingFlags.FlattenHierarchy);
            for (int i = 0; i < methods.Length; i++)
            {
                MethodInfo method = methods[i];
                if (method.IsDefined(typeof(InjectAttribute)))
                {
                    InvokeConstruct(method, target, serviceLocator);
                }
            }
        }

        private static void InvokeConstruct(MethodInfo method, object target, ServiceLocator serviceLocator)
        {
            ParameterInfo[] parameters = method.GetParameters();
            int count = parameters.Length;
            object[] args = new object[count];
            for (int i = 0; i < count; i++)
            {
                ParameterInfo parameter = parameters[i];
                Type paramType = parameter.ParameterType;
                object service = serviceLocator.GetService(paramType);
                args[i] = service;
            }
            method.Invoke(target, args);
        }
    }
}