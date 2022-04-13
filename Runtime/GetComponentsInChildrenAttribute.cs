using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.UIElements;

namespace AarquieSolutions.DependencyInjection.ComponentField
{
    public class GetComponentsInChildrenAttribute:GetComponentInChildrenAttribute
    {
        
        protected override void SetFieldInternal(FieldInfo field, MonoBehaviour depender, Transform targetTransform)
        {
            if (!ValidateField(field, depender))
            {
                return;
            }
            
            Type type = field.FieldType.GetElementType();
            DependencyInjectionUtility.FillFieldArrayWithFunction(targetTransform.GetComponentsInChildren(type, true), field, depender);
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