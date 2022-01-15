using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AarquieSolutions.DependencyInjection.ComponentField
{
    public static class ExplicitComponentInjector 
    {
        public static void InitializeDependencies(this MonoBehaviour monoBehaviour)
        {
            ComponentInjector.InjectDependency(monoBehaviour);
        }
    }
}
