using System;
using JetBrains.Annotations;

namespace DI.Attributes
{
    [MeansImplicitUse]
    [AttributeUsage(AttributeTargets.Method)]
    public class InjectAttribute : Attribute
    {
        
    }
}