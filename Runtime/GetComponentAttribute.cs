using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace AarquieSolutions.DependencyInjection.ComponentField
{
    public class GetComponentAttribute : GetComponentAttributeBase
    {
        public override void SetField(FieldInfo field, MonoBehaviour depender)
        {
            if (!field.FieldType.IsSubclassOf(typeof(Component)))
            {
                LogWarning("Component",depender.GetType().ToString());
                return;
            }

            field.SetValue(depender, depender.GetComponent(field.FieldType));
        }
    }
}
