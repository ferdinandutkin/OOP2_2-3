using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP2_2
{
    public partial class QueryControlListElement : QueryControl
    {
        

        public event EventHandler OrClick;

        public event EventHandler AndClick;

        public event EventHandler DeleteClick;

        public enum State { Active, Unactive}

        State currentState = State.Active;
        public State CurrentState
        {
            get => currentState;
            set
            {
                if (value == currentState) {
                    return;
                }
                else if (value == State.Unactive)
                {
                    buttonAnd.Visible = false;
                    buttonOr.Visible = false;
                }
                else if (value == State.Active)
                {
                    buttonAnd.Visible = true;
                    buttonOr.Visible = true;
                }
                currentState = value;
            }

        }
        
        public class ComboBoxItem
        {
            public string Value { get; set; }
            public ComboBoxItem(string value) => Value = value;
            public  static implicit operator ComboBoxItem(string s) => new ComboBoxItem(s);
            public override string ToString() => Value;

        

        }


        public bool IsValid => comboBoxProperties.SelectedItem is ComboBoxItem && comboBoxRegExType.SelectedItem is ComboBoxItem;
        public QueryControlListElement(IEnumerable<PropertyInfo> queryableProperties)
        {



            InitializeComponent();

            ComboBoxItem[] types = { "Полное совпадение", "Подстрока", "Диапазон" };
            this.comboBoxRegExType.Items.AddRange(types);

            this.comboBoxProperties.Items.AddRange(queryableProperties.Select(prop => new ComboBoxItem(prop.Name)).ToArray());

            buttonAnd.Click += (_, e) => AndClick?.Invoke(this, e);

            buttonOr.Click += (_, e) => OrClick?.Invoke(this, e);

            buttonDelete.Click += (_, e) => DeleteClick?.Invoke(this, e);



        }

        
    }
}
