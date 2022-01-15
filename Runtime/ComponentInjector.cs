using System;
using System.Reflection;
using UnityEngine;

namespace AarquieSolutions.DependencyInjection.ComponentField
{
    public class ComponentInjector
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void InjectDependenciesForComponents()
        {
            MonoBehaviour[] allMonobehaviour = MonoBehaviour.FindObjectsOfType<MonoBehaviour>();
            foreach (MonoBehaviour monoBehaviour in allMonobehaviour)
            {
                InjectDependency(monoBehaviour);
            }
        }

        public static void InjectDependency(MonoBehaviour monoBehaviour)
        {
            Type type = monoBehaviour.GetType();
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (FieldInfo field in fields)
            {
                if (field.IsDefined(typeof(ComponentInjectorBaseAttribute), false))
                {
                    ComponentInjectorBaseAttribute attribute = field.GetCustomAttribute<ComponentInjectorBaseAttribute>();
                    attribute.SetField(field, monoBehaviour);
                }
            }
        }
    }
}