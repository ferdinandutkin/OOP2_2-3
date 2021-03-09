using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using OOP2_2;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace OOP2_2
{
    public partial class DataEntryForm : Form
    {


        public object Source { get; private set; }

        public string PropertyPath { get; private set; }


        public DataEntryForm(object source, string propertyPath = "")
        {

            Source = source;
            PropertyPath = propertyPath;

            InitializeComponent();

            foreach (Control control in panel.Controls)
            {
                if (!control.Equals(labelClose))
                {
                    control.MouseDown += Panel1_MouseDown;

                }

            }

            GetText = () => labeText.Text;
            SetText = text => labeText.Text = text;

            Text = PropertyPath;

            AutoSize = true;
            AutoScroll = true;




            Fill();


        }







        void Fill()
        {





            Type objType = Reflector.GetPropertyTypeByPath(Source.GetType(), PropertyPath);




            if (typeof(IList).IsAssignableFrom(objType) && objType != typeof(string))
            {



                object source = Reflector.GetPropertyValueByPath(Source, PropertyPath);


                Type genericType = objType.IsArray ? objType.GetElementType() : objType.GetGenericArguments().First();

                table.ColumnStyles[1].Width = 0;


                Type genericBindingList = (typeof(BindingList<>).MakeGenericType(genericType));
                object bindingList = Activator.CreateInstance(genericBindingList, source);

                var dataEntryGridView = new DataEntryGridView()
                {
                    BorderStyle = BorderStyle.None,
                    BackgroundColor = SystemColors.Control,
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                    Dock = DockStyle.Fill
                };

                if (genericType.IsPrimitive)
                {





                    Type genericListDataSource = (typeof(ListDataSource<>).MakeGenericType(genericType));
                    object listDataSource = Activator.CreateInstance(genericListDataSource, bindingList);

                    dataEntryGridView.DataSource = listDataSource;


                }
                else
                {



                    dataEntryGridView.DataSource = bindingList;


                }
                table.Controls.Add(dataEntryGridView);







                return;
            }




            foreach (var prop in Reflector.GetAllPublicProperties(objType))
            {



                var propertyType = prop.PropertyType;
                var propName = prop.Name;
                var currentPropPath = string.IsNullOrEmpty(PropertyPath) ? propName : $"{PropertyPath}.{propName}";

                Add(propName);


                Control control;


                if (propertyType.IsPrimitive)
                {

                    if (propertyType == typeof(bool))
                    {
                        control = new CheckBox();
                        control.DataBindings.Add(new(nameof(CheckBox.Checked), Source, currentPropPath));
                    }
                    else
                    {
                        control = new ValidatingTextBox(propertyType);
                        control.DataBindings.Add(new(nameof(ValidatingTextBox.Value), Source, currentPropPath));
                    }



                }

                else if (propertyType.IsEnum)
                {
                    control = new ValidatingEnumComboBox(propertyType);
                    control.DataBindings.Add(new(nameof(ValidatingEnumComboBox.Value), Source, currentPropPath));
                }
                else if (propertyType == typeof(DateTime))
                {
                    control = new DateTimePicker();
                    control.DataBindings.Add(new(nameof(DateTimePicker.Value), Source, currentPropPath));


                }
                else if (propertyType == typeof(string))
                {
                    control = new TextBox();
                    control.DataBindings.Add(new Binding(nameof(TextBox.Text), Source, currentPropPath));
                }

                else
                {

                    control = new Button() { Text = "...", Size = new(40, 20) };
                    control.Click += (_, _) => new DataEntryForm(Source, currentPropPath).Show();
                }
                Add(control);



            }




        }


        private Func<string> GetText = () => string.Empty;
        private Action<string> SetText = (_) => { };
        public override string Text
        {
            get => GetText();
            set => SetText(value);
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        public Control this[int row, int col]
        {
            get => table.GetControlFromPosition(col, row);
            set
            {
                table.Controls.Remove(this[col, row]);
                table.Controls.Add(value, col, row);
            }
        }


        private void Label1_Click(object sender, EventArgs e) =>
            Close();

        public void Add(string text) => table.Controls.Add(new Label() { Text = text });

        public void Add(Control control) => table.Controls.Add(control);

        public void Add(string text, Control control)
        {
            table.Controls.Add(new Label() { Text = text });
            table.Controls.Add(control);
        }

        private void Label1_MouseHover(object sender, EventArgs e) => (sender as Label).ForeColor = Color.Coral;

        private void Label1_MouseLeave(object sender, EventArgs e) => (sender as Label).ForeColor = Color.DarkRed;



    }
}
