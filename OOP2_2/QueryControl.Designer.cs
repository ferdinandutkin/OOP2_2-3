
namespace OOP2_2
{
    partial class QueryControl
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxProperties = new System.Windows.Forms.ComboBox();
            this.comboBoxRegExType = new System.Windows.Forms.ComboBox();
            this.negationCheckBox = new System.Windows.Forms.CheckBox();
            this.textBoxValue = new System.Windows.Forms.TextBox();
            this.textBoxParams = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // comboBoxProperties
            // 
            this.comboBoxProperties.FormattingEnabled = true;
            this.comboBoxProperties.Location = new System.Drawing.Point(21, 59);
            this.comboBoxProperties.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxProperties.Name = "comboBoxProperties";
            this.comboBoxProperties.Size = new System.Drawing.Size(160, 24);
            this.comboBoxProperties.TabIndex = 2;
            // 
            // comboBoxRegExType
            // 
            this.comboBoxRegExType.FormattingEnabled = true;
            this.comboBoxRegExType.Location = new System.Drawing.Point(205, 59);
            this.comboBoxRegExType.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxRegExType.Name = "comboBoxRegExType";
            this.comboBoxRegExType.Size = new System.Drawing.Size(160, 24);
            this.comboBoxRegExType.TabIndex = 3;
            // 
            // negationCheckBox
            // 
            this.negationCheckBox.AutoSize = true;
            this.negationCheckBox.Location = new System.Drawing.Point(21, 21);
            this.negationCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.negationCheckBox.Name = "negationCheckBox";
            this.negationCheckBox.Size = new System.Drawing.Size(104, 21);
            this.negationCheckBox.TabIndex = 4;
            this.negationCheckBox.Text = "Отрицание";
            this.negationCheckBox.UseVisualStyleBackColor = true;
            // 
            // textBoxValue
            // 
            this.textBoxValue.Location = new System.Drawing.Point(393, 59);
            this.textBoxValue.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxValue.Name = "textBoxValue";
            this.textBoxValue.Size = new System.Drawing.Size(132, 22);
            this.textBoxValue.TabIndex = 5;
            // 
            // textBoxParams
            // 
            this.textBoxParams.Location = new System.Drawing.Point(551, 59);
            this.textBoxParams.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxParams.Name = "textBoxParams";
            this.textBoxParams.Size = new System.Drawing.Size(132, 22);
            this.textBoxParams.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(743, 140);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // QueryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxParams);
            this.Controls.Add(this.textBoxValue);
            this.Controls.Add(this.negationCheckBox);
            this.Controls.Add(this.comboBoxRegExType);
            this.Controls.Add(this.comboBoxProperties);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "QueryControl";
            this.Size = new System.Drawing.Size(751, 150);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.ComboBox comboBoxProperties;
        public System.Windows.Forms.ComboBox comboBoxRegExType;
        public System.Windows.Forms.CheckBox negationCheckBox;
        public System.Windows.Forms.TextBox textBoxValue;
        public System.Windows.Forms.TextBox textBoxParams;
    }
}
