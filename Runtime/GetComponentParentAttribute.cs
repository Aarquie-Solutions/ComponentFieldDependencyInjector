using System.Reflection;
using UnityEngine;

namespace AarquieSolutions.DependencyInjection.ComponentField
{
    public class GetComponentFromParentAttribute:GetComponentAttribute
    {
        public override void SetField(FieldInfo field, MonoBehaviour depender)
        {
           base.SetFieldInternal(field,depender, depender.transform.parent);
        }
    }
}