using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace AarquieSolutions.DependencyInjection.ComponentField
{
    public class GetComponentAttribute : ComponentInjectorBaseAttribute
    {
        public override void SetField(FieldInfo field, MonoBehaviour depender)
        {
            SetFieldInternal(field, depender, depender.transform);
        }

        protected virtual void SetFieldInternal(FieldInfo field, MonoBehaviour depender, Transform targetTransform)
        {
            if (!ValidateField(field, depender))
            {
                return;
            }

            field.SetValue(depender, targetTransform.GetComponent(field.FieldType));
        }

        protected virtual bool ValidateField(FieldInfo field, MonoBehaviour depender)
        {
            if (!field.FieldType.IsSubclassOf(typeof(Component)))
            {
                LogWarning("Component", depender.GetType().ToString());
                return false;
            }

            return true;
        }
    }
}
