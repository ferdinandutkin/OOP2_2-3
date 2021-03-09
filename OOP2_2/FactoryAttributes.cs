using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_2
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class FactoryClassAttribute : Attribute
    {
        public FactoryClassAttribute(string name) => Name = name;

        public string Name { get; private set; } //имя фабрики
    }


    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class FactoryMethodAttribute : Attribute
    {
        public string Name { get; set; } //имя метода
        public FactoryMethodAttribute()
        {

        }
    }
}
