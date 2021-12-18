using System;
using System.Reflection;
using UnityEngine;

namespace AarquieSolutions.DependencyInjection.ComponentField
{
    public class GetComponentsInChildrenAttribute:GetComponentAttributeBase
    {
        public override void SetField(FieldInfo field, MonoBehaviour depender)
        {
            if (!field.FieldType.IsArray)
            {
                LogWarning("array",depender.GetType().ToString());
                return;
            }

            Type type = field.FieldType.GetElementType();
            Component[] componentsInChildren = depender.transform.GetComponentsInChildren(field.FieldType.GetElementType());
            Array filledArray = Array.CreateInstance(type, componentsInChildren.Length);
            Array.Copy(componentsInChildren, filledArray, componentsInChildren.Length);
            field.SetValue(depender, filledArray);
        }
    }
}