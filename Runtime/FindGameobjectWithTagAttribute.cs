using System.Reflection;
using UnityEngine;

namespace AarquieSolutions.DependencyInjection.ComponentField
{
    public class FindGameobjectWithTagAttribute : ComponentInjectorBaseAttribute
    {
        protected readonly string tag;

        public FindGameobjectWithTagAttribute(string tag)
        {
            this.tag = tag;
        }

        public override void SetField(FieldInfo field, MonoBehaviour depender)
        {
            SetFieldInternal(field, depender, tag);
        }

        protected virtual void SetFieldInternal(FieldInfo field, MonoBehaviour depender, string tag)
        {
            if (!ValidateField(field, depender))
            {
                return;
            }

            field.SetValue(depender, GameObject.FindWithTag(tag));
        }

        protected virtual bool ValidateField(FieldInfo field, MonoBehaviour depender)
        {
            if (!(field.FieldType == typeof(GameObject)))
            {
                LogWarning("Gameobject", depender.GetType().ToString());
                return false;
            }

            return true;
        }
    }
}