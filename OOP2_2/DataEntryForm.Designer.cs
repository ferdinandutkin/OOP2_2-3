
using System.Windows.Forms;

namespace OOP2_2
{
    public partial class DataEntryForm : Form
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.labeText = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.labelClose = new System.Windows.Forms.Label();
            this.table = new System.Windows.Forms.TableLayoutPanel();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // labeText
            // 
            this.labeText.AutoSize = true;
            this.labeText.Location = new System.Drawing.Point(13, 4);
            this.labeText.Name = "labeText";
            this.labeText.Size = new System.Drawing.Size(45, 17);
            this.labeText.TabIndex = 0;
            this.labeText.Text = "Name";
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel.Controls.Add(this.labeText);
            this.panel.Controls.Add(this.labelClose);
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Margin = new System.Windows.Forms.Padding(0);
            this.panel.Name = "panel";
            this.panel.DataBindings.Add(new(nameof(Panel.Width), this, nameof(this.Width)));
            this.panel.Height = 30;
            this.panel.TabIndex = 0;
            this.panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseDown);
            // 
            // labelClose
            // 
            this.labelClose.AutoSize = true;
            this.labelClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelClose.ForeColor = System.Drawing.Color.DarkRed;
            this.labelClose.Location = new System.Drawing.Point(797, 0);
            this.labelClose.Margin = new System.Windows.Forms.Padding(0);
            this.labelClose.Name = "labelClose";
            this.labelClose.Size = new System.Drawing.Size(20, 20);
            this.labelClose.TabIndex = 0;
            this.labelClose.Text = "X";
            this.labelClose.Click += new System.EventHandler(this.Label1_Click);
            this.labelClose.MouseLeave += new System.EventHandler(this.Label1_MouseLeave);
            this.labelClose.MouseHover += new System.EventHandler(this.Label1_MouseHover);
            // 
            // table
            // 
            this.table.AutoScroll = true;
            this.table.ColumnCount = 2;
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table.Location = new System.Drawing.Point(0, 29);
            this.table.Margin = new System.Windows.Forms.Padding(0);
            this.table.Name = "table";
            this.table.RowCount = 1;
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.table.Size = new System.Drawing.Size(827, 446);
            this.table.TabIndex = 1;
            // 
            // DataEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 450);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.table);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DataEntryForm";
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label labelClose;
        private System.Windows.Forms.Label labeText;
        public System.Windows.Forms.TableLayoutPanel table;
    }
}

