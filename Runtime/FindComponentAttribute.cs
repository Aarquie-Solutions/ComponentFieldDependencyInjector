using System.Reflection;
using UnityEngine;

namespace AarquieSolutions.DependencyInjection.ComponentField
{
    public class FindComponentAttribute : ComponentInjectorBaseAttribute
    {
        public override void SetField(FieldInfo field, MonoBehaviour depender)
        {
            SetFieldInternal(field, depender);
        }

        protected virtual void SetFieldInternal(FieldInfo field, MonoBehaviour depender)
        {
            if (!ValidateField(field, depender))
            {
                return;
            }

            field.SetValue(depender, GameObject.FindObjectOfType(field.FieldType, true));
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