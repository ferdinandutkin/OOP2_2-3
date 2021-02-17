using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP2_2
{
   public partial class ValidatingTextBox : TextBox
    {
        protected Type type;

        public object Value
        {
            get => TryChangeType(Text, type, out var res) ? res : null;
            set
            {
                if (TryChangeType(value, typeof(string), out var res1))
                {
                    Text = (string)res1;
                }
            }

        }

        public bool IsValid => CanConvert(Text, type);

        public ValidatingTextBox(Type type)
        {
            this.type = type;
        }
       
        protected override void OnTextChanged(EventArgs e)
        {
            
            ForeColor = IsValid ? Color.Black : Color.Red;
            base.OnTextChanged(e);
        }

      
    }
}
