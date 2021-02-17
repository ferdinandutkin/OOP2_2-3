
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP2_2
{
    
    public class RowComparer : System.Collections.IComparer
    {
        private int sortOrderModifier = 1;
        private IComparer valueComparer;
        string colName;

        private object GetCellValue(DataGridViewRow row)
        {
            foreach (DataGridViewCell cell in row.Cells)
            {
                if (cell.OwningColumn.Name == colName)
                {
                    return cell.Value;
                }
            }
            return null;
        }
        public RowComparer(string colName, Comparison<object> valueComparer, SortOrder sortOrder = SortOrder.Ascending) :
            this(colName, Comparer<object>.Create(valueComparer), sortOrder)
        { }



        public RowComparer(string colName, IComparer valueComparer, SortOrder sortOrder = SortOrder.Ascending)
        {
            this.colName = colName;
            this.valueComparer = valueComparer;

            if (sortOrder == SortOrder.Descending)
            {
                sortOrderModifier = -1;
            }
            else if (sortOrder == SortOrder.Ascending)
            {
                sortOrderModifier = 1;
            }
        }

        public int Compare(object r1, object r2)
        {
            var row1 = r1 as DataGridViewRow;
            var row2 = r2 as DataGridViewRow;

            // Try to sort based on the Last Name column.
            int CompareResult = System.String.Compare(
                row1.Cells[1].Value.ToString(),
                row2.Cells[1].Value.ToString());


            object val1 = GetCellValue(row1);

            object val2 = GetCellValue(row2);

            return valueComparer.Compare(val1, val2) * sortOrderModifier;


          
         
        }
    }
}
