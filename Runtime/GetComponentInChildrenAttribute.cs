using System.Reflection;
using UnityEngine;

namespace AarquieSolutions.DependencyInjection.ComponentField
{
    public class GetComponentInChildrenAttribute:GetComponentAttribute
    {
        protected override void SetFieldInternal(FieldInfo field, MonoBehaviour depender, Transform targetTransform)
        {
            if (!ValidateField(field, depender))
            {
                return;
            }
            
            field.SetValue(depender, depender.GetComponentInChildren(field.FieldType));
        }
    }
}