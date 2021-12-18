using System.Reflection;
using UnityEngine;

namespace AarquieSolutions.DependencyInjection.ComponentField
{
    public class GetComponentInChildrenAttribute:GetComponentAttributeBase
    {
        public override void SetField(FieldInfo field, MonoBehaviour depender)
        {
            if (!field.FieldType.IsSubclassOf(typeof(Component)))
            {
                LogWarning("Component",depender.GetType().ToString());
                return;
            }

            field.SetValue(depender, depender.transform.GetComponentInChildren(field.FieldType));
            
        }
    }
}