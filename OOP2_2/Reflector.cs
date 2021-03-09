using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_2
{
    public static class Reflector
    {

        public static IEnumerable<MethodInfo> GetMethodsWithAttribute<T, AttributeType>() where AttributeType : Attribute
            => typeof(T).GetMethods().Where(method => method.GetCustomAttribute<AttributeType>() is not null);


        public static IEnumerable<MethodInfo> GetMethodsWithAttribute<AttributeType>(Type type) where AttributeType : Attribute
           => type.GetMethods().Where(method => method.GetCustomAttribute<AttributeType>() is not null);

        public static IEnumerable<Type> GetSubclasses<BaseType>()
            => AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly => assembly.GetTypes()).Where(
                type => type is { IsClass: true, IsAbstract: false } && type.GetConstructor(Type.EmptyTypes) is not null && type.IsSubclassOf(typeof(BaseType)));



        public static object GetPropertyValueByPath(object source, string path)
        {

            if (path is null) throw new ArgumentNullException(nameof(path));

            if (path == "") return source;

            Type currentType = source.GetType();
            foreach (var prop in path.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries))
            {
                PropertyInfo propInfo = currentType.GetProperty(prop);
                if (propInfo is not null)
                {
                    source = propInfo.GetValue(source, null);
                    currentType = propInfo.PropertyType;
                }
                else throw new ArgumentException(nameof(path));
            }
            return source;
        }

        public static Type GetPropertyTypeByPath(Type sourceType, string path)
        {
            if (path is null) throw new ArgumentNullException(nameof(path));

            if (path == "") return sourceType;

            Type currentType = sourceType;

            foreach (string pathEl in path.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries))
            {
                currentType = currentType.GetProperty(pathEl).PropertyType;
            }


            return currentType;
        }


        public static IEnumerable<PropertyInfo> GetAllPublicProperties(Type type) =>
             type.GetProperties().Where(p => p.GetSetMethod() is not null && p.GetGetMethod() is not null);
    }
}
