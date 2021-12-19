using System;
using System.Reflection;
using UnityEngine;

namespace AarquieSolutions.DependencyInjection.ComponentField
{
    [AttributeUsage(AttributeTargets.Field)]
    public abstract class ComponentInjectorBaseAttribute : Attribute
    {
        public abstract void SetField(FieldInfo field, MonoBehaviour depender);

        private string GetErrorMessage(string targetType, string dependerName)
        {
            return $"{this.GetType().Name} is attached to field that is not a {targetType}. Field is in {dependerName}";
        }

        public void LogWarning(string targetType, string dependerName)
        {
            Debug.LogWarning(GetErrorMessage(targetType,dependerName));
        }
    }
}