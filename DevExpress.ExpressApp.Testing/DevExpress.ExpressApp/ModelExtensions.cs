﻿using System.Reflection;
using DevExpress.ExpressApp.Model;

namespace DevExpress.ExpressApp.Testing.DevExpress.ExpressApp{
    public static class ModelExtensions{
        public static T CreateInstance<T>(this Type type) => (T)CreateInstance(type);

        public static object CreateInstance(this Type type){
            if (type.IsValueType)
                return Activator.CreateInstance(type);

            if (type.GetConstructor(Type.EmptyTypes) != null)
                return Activator.CreateInstance(type);
            throw new InvalidOperationException($"Type {type.FullName} does not have a parameterless constructor.");
        }

        public static object GetPropertyValue(this object obj, string propertyName) 
            => obj.GetType().GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)!.GetValue(obj);

        public static void SetPropertyValue(this object obj, string propertyName, object value) 
            => obj.GetType().GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)!
                .SetValue(obj, value);

        public static IEnumerable<IModelViewLayoutElement> Flatten(this IModelViewLayout viewLayout) 
            => viewLayout.OfType<IModelLayoutGroup>()
                .SelectMany(group => group.SelectManyRecursive(element => element as IEnumerable<IModelViewLayoutElement>));
    }
}