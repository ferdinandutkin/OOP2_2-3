using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP2_2
{
    public partial class ArgumentTableControl : TableLayoutPanel
    {




        public object[] Arguments => (Proxy as IDictionary<string, object>).Values.ToArray();

        private MethodInfo method;

        public ArgumentTableControl()
        {

        }
        public ArgumentTableControl(MethodInfo method)
        {
            this.method = method;

            InitializeComponent();


            Fill();
        }



        public void Add(string text) => Controls.Add(new Label() { Text = text });

        public void Add(Control control) => Controls.Add(control);

        public void Add(string text, Control control)
        {
            Controls.Add(new Label() { Text = text });
            Controls.Add(control);
        }



        private dynamic Proxy { get; set; } = new ExpandoObject();




        private void BindExpandoField(Control targetControl, string targetPropertyName, dynamic expandoObject, string sourcePropertyName)
        {
            var IDict = (IDictionary<string, object>)expandoObject;
            var bind = new Binding(targetPropertyName, expandoObject, null);
            bind.Format += (o, c) => c.Value = IDict[sourcePropertyName];
            bind.Parse += (o, c) => IDict[sourcePropertyName] = c.Value;
            targetControl.DataBindings.Add(bind);
        }
        void Fill()
        {

            foreach (var param in method.GetParameters())
            {



                IDictionary<string, object> proxyDictionary = Proxy;

                var paramType = param.ParameterType;
                var paramName = param.Name;




                proxyDictionary[paramName] = paramType == typeof(string) ? string.Empty : Activator.CreateInstance(paramType);


                Add(paramName);


                Control control;


                if (paramType.IsPrimitive)
                {

                    if (paramType == typeof(bool))
                    {
                        control = new CheckBox();
                        BindExpandoField(control, nameof(CheckBox.Checked), Proxy, paramName);
                    }
                    else
                    {
                        control = new ValidatingTextBox(paramType);
                        BindExpandoField(control, nameof(ValidatingTextBox.Value), Proxy, paramName);

                    }

                }

                else if (paramType.IsEnum)
                {
                    control = new ValidatingEnumComboBox(paramType);
                    BindExpandoField(control, nameof(ValidatingEnumComboBox.Value), Proxy, paramName);

                }
                else if (paramType == typeof(DateTime))
                {
                    control = new DateTimePicker();
                    BindExpandoField(control, nameof(DateTimePicker.Value), Proxy, paramName);

                }
                else if (paramType == typeof(string))
                {
                    control = new TextBox();
                    BindExpandoField(control, nameof(TextBox.Text), Proxy, paramName);


                }

                else
                {

                    control = new Button() { Text = "...", Size = new(40, 20) };
                    control.Click += (_, _) => new DataEntryForm(proxyDictionary[paramName]).Show();
                }

                Add(control);

            }

        }
    }
}
