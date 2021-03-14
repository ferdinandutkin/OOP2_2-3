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
    public partial class FactoryForm<AbstractFactoryType> : Form
    {

        ArgumentTableControl argumentTable;
        class FactoryMethodSelectionItem
        {
            public MethodInfo FactoryMethod { get; set; }

            public override string ToString() => FactoryMethod.GetCustomAttribute<FactoryMethodAttribute>()?.Name ?? FactoryMethod.Name;

            public FactoryMethodSelectionItem(MethodInfo factoryMethod) => FactoryMethod = factoryMethod;

        }

        class FactoryClassSelectionItem
        {
            public Type FactoryClass { get; set; }

            public override string ToString() => FactoryClass.GetCustomAttribute<FactoryClassAttribute>()?.Name ?? FactoryClass.Name;

            public FactoryClassSelectionItem(Type factoryClass) => FactoryClass = factoryClass;

        }
        public FactoryForm()
        {
            InitializeComponent();

            Text = "FactoryForm";





            comboBoxClassName.Items.AddRange(Reflector.GetSubclasses<AbstractFactoryType>().Select(type => new FactoryClassSelectionItem(type)).ToArray());

            comboBoxMethodName.Items.AddRange(Reflector.GetMethodsWithAttribute<FactoryMethodAttribute>(typeof(AbstractFactoryType)).Select(method => new FactoryMethodSelectionItem(method)).ToArray());

            argumentTable = new ArgumentTableControl();

            tableLayoutPanel1.SetColumn(argumentTable, 1);
            tableLayoutPanel1.SetRowSpan(argumentTable, 2);

            tableLayoutPanel1.Controls.Add(argumentTable);





        }


        public event Action<object, object> ObjectCreated;
        private void buttonCreateObject_Click(object sender, EventArgs e)
        {
            if (comboBoxMethodName.SelectedItem is FactoryMethodSelectionItem factoryMethod && comboBoxClassName.SelectedItem is FactoryClassSelectionItem factoryClass)
            {

                object result = factoryMethod.FactoryMethod.Invoke(Activator.CreateInstance(factoryClass.FactoryClass), argumentTable.Arguments.ToArray());
                ObjectCreated?.Invoke(this, result);
            }

        }

        private void comboBoxMethodName_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBoxMethodName.SelectedItem is FactoryMethodSelectionItem factoryMethod)
            {
                tableLayoutPanel1.Controls.Remove(argumentTable);
                argumentTable = new ArgumentTableControl(factoryMethod.FactoryMethod);

                tableLayoutPanel1.SetColumn(argumentTable, 1);
                tableLayoutPanel1.SetRowSpan(argumentTable, 2);

                tableLayoutPanel1.Controls.Add(argumentTable);

            }
        }

        private void comboBoxClassName_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBoxClassName.SelectedItem is FactoryClassSelectionItem factoryClass)
            {
                comboBoxMethodName.Text = string.Empty;
                comboBoxMethodName.Items.Clear();
                comboBoxMethodName.Items.AddRange(Reflector.GetMethodsWithAttribute<FactoryMethodAttribute>(factoryClass.FactoryClass).Select(method => new FactoryMethodSelectionItem(method)).ToArray());
            }
        }
    }
}
