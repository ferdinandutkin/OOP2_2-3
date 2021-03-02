using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP2_2
{
    public partial class QueryBuiler : Form
    {
        public event EventHandler FindClick;

        IEnumerable<PropertyInfo> queryableProperties;
        public QueryBuiler(IEnumerable<PropertyInfo> queryableProperties)
        {
            this.queryableProperties = queryableProperties;

            InitializeComponent();
            var queryControlListElement = new QueryControlListElement(queryableProperties);
            this.button4.Click += (_, e) => FindClick?.Invoke(this, e);
            queryControlListElement.AndClick += buttonAND_Click;
            queryControlListElement.OrClick += buttonOR_Click;
            queryControlListElement.DeleteClick += buttonDelete_Click;
            this.tableLayoutPanel1.Controls.Add(queryControlListElement, 0, 0);

        }

       
      
        private void RemoveRow(int rowIndex)
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


      

        // ComboBoxItem[] types = { "Полное совпадение", "Подстрока", "Диапазон" };
        Regex RegexFromControl(QueryControlListElement queryControlListElement) //контракт валидный
        {

            var regexType = queryControlListElement.comboBoxRegExType.SelectedItem as QueryControlListElement.ComboBoxItem;

            var regexValue = Regex.Escape(queryControlListElement.textBoxValue.Text);

            var param = queryControlListElement.textBoxParams.Text;


         

            return new(regexType.ToString() switch
            {
                "Полное совпадение" => regexValue,
                "Подстрока" when int.TryParse(param, out int idx) => $"^.{{{idx - 1}}}{regexValue}.*",
                "Подстрока" => $".*{regexValue}.*",
                "Диапазон" when int.TryParse(param, out int idx) => $"^.{{{idx - 1}}}[{regexValue}].*",
                "Диапазон" => $".*[{regexValue}].*",
                _ => ""
            });

         




        }


       Func<object, bool> PredFromControl(QueryControlListElement queryControlListElement)
       {
            return obj =>
            {
                var propName = queryControlListElement.comboBoxProperties.SelectedItem.ToString();
                var input = obj.GetType().GetProperty(propName).GetValue(obj).ToString();
                var regEx = RegexFromControl(queryControlListElement);
                return queryControlListElement.negationCheckBox.Checked ? !regEx.IsMatch(input) : regEx.IsMatch(input);
            };
       }


        Func<object, bool> PredFromList()
        {
            var listElements = GetQueryControlListElements().ToList();


            

            var query = listElements.Select(le =>
            le.IsValid ? 
            (PredFromControl(le), le.Text) :
            (_ => false, "ИЛИ"));

            Func<object, bool> res = _ => true;

            

            foreach (var pair in query)
            {

                var resDeepCopy = new Func<object, bool>(res);
                res = pair.Item2 switch
                {                          
                    "ИЛИ" => obj => resDeepCopy(obj) || pair.Item1(obj),
                    "И" or _ => obj => resDeepCopy(obj) && pair.Item1(obj)
                };

            }
           
            return res;

           
        }


        IEnumerable<QueryControlListElement> GetQueryControlListElements() => tableLayoutPanel1.Controls.OfType<QueryControlListElement>();




        
        public IEnumerable ApplyQuery(IEnumerable target) => target.Cast<object>().Where(PredFromList());
      
 

      

        private void buttonOR_Click(object sender, EventArgs e)
        {
            var owner = sender as QueryControlListElement;
            owner.CurrentState = QueryControlListElement.State.Unactive;
         

            var queryControlListElement = new QueryControlListElement(queryableProperties) { Text = owner.buttonOr.Text };
            queryControlListElement.AndClick += buttonAND_Click;
            queryControlListElement.OrClick += buttonOR_Click;
            queryControlListElement.DeleteClick += buttonDelete_Click;
            tableLayoutPanel1.RowCount++;
            this.tableLayoutPanel1.Controls.Add(queryControlListElement);
        }


        private void buttonAND_Click(object sender, EventArgs e)
        {

            var owner = sender as QueryControlListElement;
            owner.CurrentState = QueryControlListElement.State.Unactive;


            var queryControlListElement = new QueryControlListElement(queryableProperties) { Text = owner.buttonAnd.Text };
            queryControlListElement.AndClick += buttonAND_Click;
            queryControlListElement.OrClick += buttonOR_Click;
            queryControlListElement.DeleteClick += buttonDelete_Click;
            tableLayoutPanel1.RowCount++;
            this.tableLayoutPanel1.Controls.Add(queryControlListElement);



        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

           
            var owner = sender as QueryControlListElement;

           
            var row = tableLayoutPanel1.Controls.GetChildIndex(owner);
            if (row > 0)
            {
                RemoveRow(row);
                if (owner.CurrentState == QueryControlListElement.State.Active)
                {
                    (tableLayoutPanel1.GetControlFromPosition(0, row - 1) as QueryControlListElement).CurrentState = QueryControlListElement.State.Active;
                }
               
            }
  





        }

        
    }
}
