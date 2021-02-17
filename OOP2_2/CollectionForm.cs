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
        public IEnumerable<PropertyInfo> GetSerializableProperties(Type type) =>
          type.GetProperties().Where(p => p.GetSetMethod() is not null && p.GetGetMethod() is not null);


        public IEnumerable<PropertyInfo> GetNestedSerializableProperties(Type type) =>
            GetSerializableProperties(type)
            .Where(prop => !prop.PropertyType.IsPrimitive && !prop.PropertyType.IsEnum &&
            prop.PropertyType != typeof(DateTime) && prop.PropertyType != typeof(string));

        Type ElementType;

        Type BindingListType => typeof(SortableBindingList<>).MakeGenericType(ElementType);

        Type ListType => typeof(List<>).MakeGenericType(ElementType);


        public CollectionForm(Type elementType)
        {
            ElementType = elementType;
            InitializeComponent();
            toolStripSortButton.DropDownItems.AddRange(GetSerializableProperties(ElementType).Select(prop => {
                var button = new ToolStripButton() { Text = prop.Name };
                button.Click += SortSelected;
                return button;
                }).ToArray());;

        }

        private void SortSelected(object sender, EventArgs e)
        {
            
       
            SortByPropName((sender as ToolStripItem).Text, ListSortDirection.Ascending);
        }

        public DataEntryGridView dataGridView1 { get; set; }





 





        IList List
        {
            get;
            set;
        }

    
        IBindingList ListedCollection
        {
            get => dataGridView1.DataSource as IBindingList;
            set => dataGridView1.DataSource = value;

        }
        private void button1_Click(object sender, EventArgs e) => openFileDialog1.ShowDialog();
       

        private void CollectionForm_Load(object sender, EventArgs e)
        {


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

            bindingNavigatorAddNewItem.Click += (_, _) => OpenLastCreated();
            bindingNavigatorAddNewItem.Click += NavigatorMovementHandler;
           

            bindingNavigatorDeleteItem.Click += ButtonDelete_Click;
            bindingNavigatorDeleteItem.Click += NavigatorMovementHandler; 


            bindingNavigatorMoveFirstItem.Click += NavigatorMovementHandler;
            bindingNavigatorMoveLastItem.Click += NavigatorMovementHandler;

            bindingNavigatorMoveNextItem.Click += NavigatorMovementHandler;
            bindingNavigatorMovePreviousItem.Click += NavigatorMovementHandler;





            tableLayoutPanel1.SetRowSpan(dataGridView1, 3);
            tableLayoutPanel1.Controls.Add(dataGridView1, 1, 0);

            
        }


        public void NavigatorMovementHandler(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            int newPos = int.Parse(bindingNavigatorPositionItem.Text) - 1;
            if (newPos >= 0 && dataGridView1.Rows[newPos] is not null)
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
            OpenLastCreated();
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                if (row.DataBoundItem is not null)
                {
                    dataGridView1.Rows.Remove(row);

                }


            }

        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Тумаш Станислав Спаситепожалуйста");
        }

        public static PropertyDescriptor GetPropertyDescriptor(PropertyInfo propertyInfo) =>
              TypeDescriptor.GetProperties(propertyInfo.DeclaringType)[propertyInfo.Name];
      

        private void toolStripButton2_ButtonClick(object sender, EventArgs e)
        {
            var propInfo = ElementType.GetProperty("Name");
            var descriptor = GetPropertyDescriptor(propInfo);
            ListedCollection.ApplySort(descriptor, ListSortDirection.Ascending);
           
            
          
          
        }

        private void SortByPropName(string name, ListSortDirection sortDirection)
        {
            var propInfo = ElementType.GetProperty(name);
            var descriptor = GetPropertyDescriptor(propInfo);
            ListedCollection.ApplySort(descriptor, sortDirection);
        }

       
    }
}
