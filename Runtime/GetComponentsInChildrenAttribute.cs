using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.UIElements;

namespace AarquieSolutions.DependencyInjection.ComponentField
{
    public class GetComponentsInChildrenAttribute:GetComponentAttribute
    {
        
        protected override void SetFieldInternal(FieldInfo field, MonoBehaviour depender, Transform targetTransform)
        {
            Type type = field.FieldType.GetElementType();
            Component[] componentsInChildren = targetTransform.GetComponentsInChildren(field.FieldType.GetElementType());
            Array filledArray = Array.CreateInstance(type, componentsInChildren.Length);
            Array.Copy(componentsInChildren, filledArray, componentsInChildren.Length);
            field.SetValue(depender, filledArray);
        }

        protected override bool ValidateField(FieldInfo field, MonoBehaviour depender)
        {
            if (!field.FieldType.IsArray)
            {
                LogWarning("array",depender.GetType().ToString());
                return false;
            }
            else if (!field.FieldType.GetElementType().IsSubclassOf(typeof(Component)))
            {
                LogWarning("Component", depender.GetType().ToString());
                return false;
            }
            return true;
        }
    }
}