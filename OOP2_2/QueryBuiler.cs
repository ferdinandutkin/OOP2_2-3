using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP2_2
{
    public partial class QueryBuiler : Form
    {
        public QueryBuiler(Type queryableType)
        {
            InitializeComponent();
            this.Controls.Add(new QueryControl());
           
        }

        private void queryControl1_Load(object sender, EventArgs e)
        {

        }

      
        public  void RemoveRow(int rowIndex)
            {
                if (rowIndex >= tableLayoutPanel1.RowCount)
                {
                    return;
                }

               
                for (int i = 0; i < tableLayoutPanel1.ColumnCount; i++)
                {
                    var control = tableLayoutPanel1.GetControlFromPosition(i, rowIndex);
                    tableLayoutPanel1.Controls.Remove(control);
                }

                
                for (int i = rowIndex + 1; i < tableLayoutPanel1.RowCount; i++)
                {
                    for (int j = 0; j < tableLayoutPanel1.ColumnCount; j++)
                    {
                        var control = tableLayoutPanel1.GetControlFromPosition(j, i);
                        if (control is not null)
                        {
                            tableLayoutPanel1.SetRow(control, i - 1);
                        }
                    }
                }

                var removeStyle = tableLayoutPanel1.RowCount - 1;

                if (tableLayoutPanel1.RowStyles.Count > removeStyle)
                    tableLayoutPanel1.RowStyles.RemoveAt(removeStyle);

                tableLayoutPanel1.RowCount--;
            }


        void MoveControls(int currentRow)
        {
            var gb  = tableLayoutPanel1.GetControlFromPosition( 1, currentRow);
            tableLayoutPanel1.SetRow(gb, currentRow + 1);

        }
 
        private void buttonANDOR_Click(object sender, EventArgs e)
        {
             
            var button = sender as Button;

            int currentRow = tableLayoutPanel1.GetRow(button.Parent);

            tableLayoutPanel1.RowCount++;
            
            tableLayoutPanel1.Controls.Add(new QueryControl() { Text = button.Text }, 0, currentRow + 1);
  
        
   

            MoveControls(currentRow);
           
        }
    }
}
