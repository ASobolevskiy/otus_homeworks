using System;
using JetBrains.Annotations;

namespace DI
{
    [MeansImplicitUse, AttributeUsage(AttributeTargets.Method)]
    public sealed class InjectAttribute : Attribute
    {
    }
}