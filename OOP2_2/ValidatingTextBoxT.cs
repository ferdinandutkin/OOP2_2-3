using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_2
{
    class ValidatingTextBox<T> : ValidatingTextBox
    {
        public ValidatingTextBox() : base(typeof(T))
        {

        }

        public new T Value
        {
            get => (T)base.Value;
            set => base.Value = value;
        }
    }
}
