using System.Reflection;
using UnityEngine;

namespace AarquieSolutions.DependencyInjection.ComponentField
{
    public class GetComponentFromParentAttribute:GetComponentAttributeBase
    {
        public override void SetField(FieldInfo field, MonoBehaviour depender)
        {
            if (!field.FieldType.IsSubclassOf(typeof(Component)))
            {
                LogWarning("Component",depender.GetType().ToString());
                return;
            }

            field.SetValue(depender, depender.transform.parent.GetComponent(field.FieldType));
        }
    }
}