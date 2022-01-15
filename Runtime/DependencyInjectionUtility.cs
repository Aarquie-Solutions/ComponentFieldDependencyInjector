using System;
using System.Reflection;
using UnityEngine;

namespace AarquieSolutions.DependencyInjection.ComponentField
{
    public class DependencyInjectionUtility
    {
        public static void FillFieldArrayWithFunction<T>(T[] arrayWithData, FieldInfo field, MonoBehaviour depender)
        {
            Type type = field.FieldType.GetElementType();
            Array arrayToFill = (T[]) Array.CreateInstance(type, arrayWithData.Length);
            Array.Copy(arrayWithData,arrayToFill,arrayWithData.Length);
            field.SetValue(depender, arrayToFill);
        }
    }

}