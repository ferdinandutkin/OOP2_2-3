using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace OOP2_2
{
    class LettersOnlyValidatingTextBox : TextBox
    {
        public bool IsValid => Text.All(char.IsLetter);
       
        protected override void OnTextChanged(EventArgs e)
        {
            ForeColor = IsValid ? Color.Black : Color.Red;
            base.OnTextChanged(e);
        }
    }
}
