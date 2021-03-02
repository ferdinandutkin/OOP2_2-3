
namespace OOP2_2
{
    partial class QueryControlListElement
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonOr = new System.Windows.Forms.Button();
            this.buttonAnd = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxProperties
            // 
            this.comboBoxProperties.Size = new System.Drawing.Size(160, 24);
            // 
            // comboBoxRegExType
            // 
            this.comboBoxRegExType.Size = new System.Drawing.Size(160, 24);
            // 
            // textBoxValue
            // 
           
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonOr);
            this.groupBox2.Controls.Add(this.buttonAnd);
            this.groupBox2.Controls.Add(this.buttonDelete);
            this.groupBox2.Location = new System.Drawing.Point(763, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(142, 139);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            // 
            // buttonOr
            // 
            this.buttonOr.Location = new System.Drawing.Point(34, 91);
            this.buttonOr.Name = "buttonOr";
            this.buttonOr.Size = new System.Drawing.Size(84, 23);
            this.buttonOr.TabIndex = 2;
            this.buttonOr.Text = "ИЛИ";
            this.buttonOr.UseVisualStyleBackColor = true;
            // 
            // buttonAnd
            // 
            this.buttonAnd.Location = new System.Drawing.Point(34, 62);
            this.buttonAnd.Name = "buttonAnd";
            this.buttonAnd.Size = new System.Drawing.Size(84, 23);
            this.buttonAnd.TabIndex = 1;
            this.buttonAnd.Text = "И";
            this.buttonAnd.UseVisualStyleBackColor = true;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(34, 33);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(84, 23);
            this.buttonDelete.TabIndex = 0;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = true;
            // 
            // QueryControlListElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Name = "QueryControlListElement";
            this.Size = new System.Drawing.Size(915, 150);
            this.Controls.SetChildIndex(this.comboBoxProperties, 0);
            this.Controls.SetChildIndex(this.comboBoxRegExType, 0);
            this.Controls.SetChildIndex(this.negationCheckBox, 0);
            this.Controls.SetChildIndex(this.textBoxValue, 0);
            this.Controls.SetChildIndex(this.textBoxParams, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.Button buttonOr;
        public System.Windows.Forms.Button buttonAnd;
        public System.Windows.Forms.Button buttonDelete;
    }
}
