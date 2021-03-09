
namespace OOP2_2
{
    partial class FactoryForm<AbstractFactoryType> 
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxClassName = new System.Windows.Forms.ComboBox();
            this.comboBoxMethodName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxClassName = new System.Windows.Forms.GroupBox();
            this.groupBoxMethodName = new System.Windows.Forms.GroupBox();
            this.buttonCreateObject = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBoxClassName.SuspendLayout();
            this.groupBoxMethodName.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxClassName
            // 
            this.comboBoxClassName.FormattingEnabled = true;
            this.comboBoxClassName.Location = new System.Drawing.Point(38, 52);
            this.comboBoxClassName.Name = "comboBoxClassName";
            this.comboBoxClassName.Size = new System.Drawing.Size(121, 24);
            this.comboBoxClassName.TabIndex = 0;
            this.comboBoxClassName.SelectedValueChanged += new System.EventHandler(this.comboBoxClassName_SelectedValueChanged);
            // 
            // comboBoxMethodName
            // 
            this.comboBoxMethodName.FormattingEnabled = true;
            this.comboBoxMethodName.Location = new System.Drawing.Point(36, 52);
            this.comboBoxMethodName.Name = "comboBoxMethodName";
            this.comboBoxMethodName.Size = new System.Drawing.Size(121, 24);
            this.comboBoxMethodName.TabIndex = 1;
            this.comboBoxMethodName.SelectedValueChanged += new System.EventHandler(this.comboBoxMethodName_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Фабрика";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Фабричный метод";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.90217F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.09782F));
            this.tableLayoutPanel1.Controls.Add(this.buttonCreateObject, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBoxClassName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBoxMethodName, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 56);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(991, 323);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // groupBoxClassName
            // 
            this.groupBoxClassName.Controls.Add(this.comboBoxClassName);
            this.groupBoxClassName.Controls.Add(this.label1);
            this.groupBoxClassName.Location = new System.Drawing.Point(3, 3);
            this.groupBoxClassName.Name = "groupBoxClassName";
            this.groupBoxClassName.Size = new System.Drawing.Size(200, 100);
            this.groupBoxClassName.TabIndex = 5;
            this.groupBoxClassName.TabStop = false;
            // 
            // groupBoxMethodName
            // 
            this.groupBoxMethodName.Controls.Add(this.comboBoxMethodName);
            this.groupBoxMethodName.Controls.Add(this.label2);
            this.groupBoxMethodName.Location = new System.Drawing.Point(3, 145);
            this.groupBoxMethodName.Name = "groupBoxMethodName";
            this.groupBoxMethodName.Size = new System.Drawing.Size(200, 100);
            this.groupBoxMethodName.TabIndex = 6;
            this.groupBoxMethodName.TabStop = false;
            // 
            // buttonCreateObject
            // 
            this.buttonCreateObject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCreateObject.Location = new System.Drawing.Point(269, 287);
            this.buttonCreateObject.Name = "buttonCreateObject";
            this.buttonCreateObject.Size = new System.Drawing.Size(719, 33);
            this.buttonCreateObject.TabIndex = 7;
            this.buttonCreateObject.Text = "Создать";
            this.buttonCreateObject.UseVisualStyleBackColor = true;
            this.buttonCreateObject.Click += new System.EventHandler(this.buttonCreateObject_Click);
            // 
            // OOP2_2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 429);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "OOP2_2";
            this.Text = "OOP2_2";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBoxClassName.ResumeLayout(false);
            this.groupBoxClassName.PerformLayout();
            this.groupBoxMethodName.ResumeLayout(false);
            this.groupBoxMethodName.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxClassName;
        private System.Windows.Forms.ComboBox comboBoxMethodName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBoxClassName;
        private System.Windows.Forms.GroupBox groupBoxMethodName;
        private System.Windows.Forms.Button buttonCreateObject;
    }
}