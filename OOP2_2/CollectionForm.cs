using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;

using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Collections;

namespace OOP2_2
{
    public partial class CollectionForm : Form
    {


        void ApplySetting()
        {
            var settings = SingletonSettings.GetInstance();

            this.BackColor = settings.BackColor;
            this.ForeColor = settings.FontColor;
            this.Font = new(settings.FontFamily, settings.FontSize);
            this.ClientSize = new Size(settings.FormWidth, settings.FormHeight);

        }

        Type ElementType;

        Type BindingListType => typeof(SortableBindingList<>).MakeGenericType(ElementType);

        Type ListType => typeof(List<>).MakeGenericType(ElementType);


        Type AbstractFactoryType;


        public CollectionForm(Type elementType)
        {
            ElementType = elementType;
            InitializeComponent();
            ApplySetting();
            toolStripSortButton.DropDownItems.AddRange(Reflector.GetAllPublicProperties(ElementType).Select(prop =>
            {
                var button = new ToolStripButton() { Text = prop.Name };
                button.Click += SortSelected;
                return button;
            }).ToArray()); ;



        }

        public CollectionForm(Type elementType, Type abstractFactoryType) : this(elementType) => AbstractFactoryType = abstractFactoryType;




        private void SortSelected(object sender, EventArgs e)
        {


            SortByPropName((sender as ToolStripItem).Text, ListSortDirection.Ascending);
        }

        public DataEntryGridView dataGridView1 { get; set; }


        void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Z)
            {
                Undo();
                e.SuppressKeyPress = true;
            }
        }








        public IList List
        {
            get;
            set;
        }


        Stack<IList> Buffer = new();

        IBindingList ListedCollection
        {
            get => dataGridView1.DataSource as IBindingList;
            set => dataGridView1.DataSource = value;

        }

        void SaveCurrentState()
        {
            Buffer.Push(ListedCollection.ToListOfType(ElementType));
        }
        void Undo()
        {

            if (Buffer.Count == 2)
            {
                Buffer.Pop();

                ListedCollection = Activator.CreateInstance(BindingListType, Buffer.Peek()) as IBindingList;

                statusBar.Text = "Возврат к исходному";

            }
            else if (Buffer.Count > 2)
            {
                Buffer.Pop();

                ListedCollection = Activator.CreateInstance(BindingListType, Buffer.Peek()) as IBindingList;

                statusBar.Text = "Отмена последнего действия";

            }
            else if (Buffer.Count == 1)
            {
                ListedCollection = Activator.CreateInstance(BindingListType, Buffer.Peek()) as IBindingList;

                statusBar.Text = "Попытка отмены последнего действия";

            }

            //     statusBar.Text += " " + Buffer.Count.ToString();

            bindingNavigator1.BindingSource = null;
            bindingNavigator1.BindingSource = new BindingSource(ListedCollection, "");



        }
        private void button1_Click(object sender, EventArgs e) => openFileDialog1.ShowDialog();


        private void CollectionForm_Load(object sender, EventArgs e)
        {


            buttonCreateFromFactory.Enabled = AbstractFactoryType is not null;

            dataGridView1 = new DataEntryGridView()
            {
                Dock = DockStyle.Fill,

                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };




            var genericList = Activator.CreateInstance(ListType);


            List = genericList as IList;
            List.Add(Activator.CreateInstance(ElementType));

            var genericBindingList = Activator.CreateInstance(BindingListType, genericList);
            ListedCollection = genericBindingList as IBindingList;





            bindingNavigator1.BindingSource = new BindingSource(ListedCollection, "");

            bindingNavigatorAddNewItem.Click += CreateHandler;
            bindingNavigatorAddNewItem.Click += NavigatorMovementHandler;


            bindingNavigatorDeleteItem.Click += DeleteHandler;
            bindingNavigatorDeleteItem.Click += NavigatorMovementHandler;


            bindingNavigatorMoveFirstItem.Click += NavigatorMovementHandler;
            bindingNavigatorMoveLastItem.Click += NavigatorMovementHandler;

            bindingNavigatorMoveNextItem.Click += NavigatorMovementHandler;
            bindingNavigatorMovePreviousItem.Click += NavigatorMovementHandler;



            SaveCurrentState();

            tableLayoutPanel1.SetRowSpan(dataGridView1, 4);
            tableLayoutPanel1.Controls.Add(dataGridView1, 1, 0);


        }



        public void NavigatorMovementHandler(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            int newPos = int.Parse(bindingNavigatorPositionItem.Text) - 1;
            if (newPos >= 0 && dataGridView1.Rows.Count > newPos && dataGridView1.Rows[newPos] is not null)
            {
                dataGridView1.Rows[newPos].Selected = true;
            }

        }
        private async void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

            using var file = File.CreateText(saveFileDialog1.FileName);

            await Task.Run(() => new JsonSerializer().Serialize(file, ListedCollection));

        }

        private async void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            using var file = File.OpenText(openFileDialog1.FileName);

            var res = await Task.Run(() => new JsonSerializer().Deserialize(file, typeof(List<Program.Person>)));

            ListedCollection = new SortableBindingList<Program.Person>(res as List<Program.Person>);
        }

        private void toolStripButton2_Click(object sender, EventArgs e) => saveFileDialog1.ShowDialog();



        private void ButtonOpen_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                if (row?.DataBoundItem is null)
                    continue;
                else
                {

                    new DataEntryForm(row.DataBoundItem).Show();
                }

            }


        }

        void OpenLastCreated()
        {
            if (ListedCollection.Count > 0)
            {
                var def = new DataEntryForm(ListedCollection[ListedCollection.Count - 1]);

                def.FormClosed += (_, _) => dataGridView1.Refresh();
                def.Show();
            }

        }




        private void ButtonCreate_Click(object sender, EventArgs e)
        {

            ListedCollection.AddNew();
            CreateHandler(sender, e);
        }


        private void CreateHandler(object sender, EventArgs e)
        {

            statusBar.Text = "Добавлен новый элемент";
            OpenLastCreated();
            SaveCurrentState();


        }

        private void DeleteHandler(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                if (row.DataBoundItem is not null)
                {
                    dataGridView1.Rows.Remove(row);

                }


            }
            statusBar.Text = "Удален элемент";

            SaveCurrentState();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Тумаш Станислав Спаситепожалуйста");
        }

        public static PropertyDescriptor GetPropertyDescriptor(PropertyInfo propertyInfo) =>
              TypeDescriptor.GetProperties(propertyInfo.DeclaringType)[propertyInfo.Name];






        private void SortByPropName(string name, ListSortDirection sortDirection)
        {
            var propInfo = ElementType.GetProperty(name);
            var descriptor = GetPropertyDescriptor(propInfo);
            ListedCollection.ApplySort(descriptor, sortDirection);

        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var queryBuilder = new QueryBuiler(Reflector.GetAllPublicProperties(ElementType));
            queryBuilder.FindClick += (_, _) =>
            {
                // MessageBox.Show(queryBuilder.ApplyQuery(ListedCollection).ToListOfType(ElementType).Count.ToString());

                var cf = new CollectionForm(ElementType);
                cf.Show();

                cf.ListedCollection = Activator.CreateInstance(BindingListType, queryBuilder.ApplyQuery(ListedCollection).ToListOfType(ElementType)) as IBindingList;


            };

            queryBuilder.Show();

        }


        private void ObjectCreationHandler(object sender, object obj) => ListedCollection.Add(obj);

        private void buttonCreateFromFactory_Click(object sender, EventArgs e)
        {
            Type factoryFormType = typeof(FactoryForm<>).MakeGenericType(AbstractFactoryType);

            var creationEvet = factoryFormType.GetEvent("ObjectCreated");


            Form factoryForm = Activator.CreateInstance(factoryFormType) as Form;


            Delegate handler = Delegate.CreateDelegate(creationEvet.EventHandlerType, this, nameof(ObjectCreationHandler));
            creationEvet.AddEventHandler(factoryForm, handler);
            factoryForm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e) => toolStripStatusLabel1.Text = DateTime.Now.ToString("G");


    }
}
