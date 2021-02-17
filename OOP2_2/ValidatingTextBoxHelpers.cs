using System;
 

namespace OOP2_2
{
    public partial class ValidatingTextBox
    {
    
        private bool CanConvert(string value, Type type) =>
           typeof(string) == type || TryChangeType(value, type, out _);

    
        private bool TryChangeType(string value, Type type, out object val)
        {
            try
            {
                val = Convert.ChangeType(value, type);
                return true;
            }
            catch (Exception)
            {
                val = default;
                return false;
            }
        }

        private bool TryChangeType(object value, Type type, out object val)
        {
            try
            {
                val = Convert.ChangeType(value, type);
                return true;
            }
            catch (Exception)
            {
                val = default;
                return false;
            }
        }

    }
}
