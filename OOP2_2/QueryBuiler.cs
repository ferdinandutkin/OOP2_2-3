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
    }
}
