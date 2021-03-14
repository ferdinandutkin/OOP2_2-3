using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace OOP2_2
{

    public partial class DataEntryGridView : DataGridView
    {
        public event Action<DataGridView, DataGridViewCellEventArgs> CellButtonClick;



        public IEnumerable<PropertyInfo> GetNestedSerializableProperties(Type type) =>
            Reflector.GetAllPublicProperties(type)
            .Where(prop => IsNestedSerializableType(prop.PropertyType));


        private static bool IsNestedSerializableType(Type type) => type is not null
&& !type.IsPrimitive && !type.IsEnum &&
            type != typeof(DateTime) && type != typeof(string);



        public DataEntryGridView()
        {
            BackgroundColor = SystemColors.Control;
            CellButtonClick += (_, args) =>
            {
                var path = Columns[args.ColumnIndex].DataPropertyName;

                new DataEntryForm(Rows[args.RowIndex].DataBoundItem, path).Show();


            };
        }





        protected override void OnCellClick(DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 &&
                e.RowIndex < RowCount - 1 &&
                e.ColumnIndex > -1 &&
                Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                CellButtonClick?.Invoke(this, e);
            base.OnCellClick(e);


        }


        protected override void OnDataError(bool displayErrorDialogIfNoHandler, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Error happened " + e.Context.ToString());

            if (e.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show("Commit error");
            }
            if (e.Context == DataGridViewDataErrorContexts.CurrentCellChange)
            {
                MessageBox.Show("Cell change");
            }
            if (e.Context == DataGridViewDataErrorContexts.Parsing)
            {
                MessageBox.Show("parsing error");
            }
            if (e.Context == DataGridViewDataErrorContexts.LeaveControl)
            {
                MessageBox.Show("leave control error");
            }

            if ((e.Exception) is ConstraintException)
            {

                Rows[e.RowIndex].ErrorText = "an error";
                Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "an error";

                e.ThrowException = false;
            }
        }


        protected override void OnDataBindingComplete(DataGridViewBindingCompleteEventArgs e)
        {
            var type = DataSource.GetType().GetGenericArguments().First();

            foreach (var name in Reflector.GetAllPublicProperties(type).Select(p => p.Name).Except(Columns.Cast<DataGridViewColumn>().Select(c => c.DataPropertyName)))
            {
                Columns.Add(new DataGridViewButtonColumn()
                {

                    HeaderText = name,
                    Text = "...",
                    UseColumnTextForButtonValue = true,
                    DataPropertyName = name
                });
            }



        }
        protected override void OnColumnAdded(DataGridViewColumnEventArgs e)
        {


            if (e.Column is not DataGridViewButtonColumn && IsNestedSerializableType(e.Column.ValueType))
            {

                Columns.RemoveAt(e.Column.Index);
                Columns.Insert(e.Column.Index, new DataGridViewButtonColumn()
                {
                    HeaderText = e.Column.HeaderText,
                    Text = "...",
                    UseColumnTextForButtonValue = true,
                    DataPropertyName = e.Column.DataPropertyName

                });



            }
            else
            {
                base.OnColumnAdded(e);
            }

        }


    }


}
