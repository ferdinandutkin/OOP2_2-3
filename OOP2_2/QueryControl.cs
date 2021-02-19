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
    public partial class QueryControl : UserControl
    {
        public override string Text { get => groupBox1.Text; set => groupBox1.Text = value; }
        public QueryControl()
        {
            InitializeComponent();
 
        }

       
    }
}
