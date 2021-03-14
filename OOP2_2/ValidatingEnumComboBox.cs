using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP2_2
{
    class ValidatingEnumComboBox : ComboBox
    {
        private Type type;



        private string[] names;


        public object Value
        {
            get => Enum.IsDefined(type, Text) ? Enum.Parse(type, Text) : null;

            set
            {
                if (Enum.IsDefined(type, value))
                {
                    Text = Enum.GetName(type, value);
                }

            }

        }

        bool IsValid => names.Contains(Text);

        public ValidatingEnumComboBox(Type type)
        {
            if (!type.IsEnum)
                throw new ArgumentException($"Аргумент должен быть перечислением: {nameof(type)}");
            this.type = type;
            names = Enum.GetNames(type);
            Items.AddRange(names);
        }


        protected override void OnTextChanged(EventArgs e)
        {
            ForeColor = IsValid ? Color.Black : Color.Red;
            base.OnTextChanged(e);
        }






    }
}
