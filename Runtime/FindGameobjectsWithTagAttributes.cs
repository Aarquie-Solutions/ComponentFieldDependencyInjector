using System;
using System.Reflection;
using UnityEngine;

namespace AarquieSolutions.DependencyInjection.ComponentField
{
    public class FindGameobjectsWithTagAttributes:FindGameobjectWithTagAttribute
    {
        public FindGameobjectsWithTagAttributes(string tag) : base(tag)
        {
            
        }

        protected override void SetFieldInternal(FieldInfo field, MonoBehaviour depender, string tag)
        {
            if (!ValidateField(field, depender))
            {
                return;
            }
            
            DependencyInjectionUtility.FillFieldArrayWithFunction(GameObject.FindGameObjectsWithTag(tag),field, depender);
        }

        protected override bool ValidateField(FieldInfo field, MonoBehaviour depender)
        {
            if (!field.FieldType.IsArray)
            {
                LogWarning("array",depender.GetType().ToString());
                return false;
            }
            else if (!(field.FieldType.GetElementType() == typeof(GameObject)))
            {
                LogWarning("Component", depender.GetType().ToString());
                return false;
            }
            return true;
        }
    }
}