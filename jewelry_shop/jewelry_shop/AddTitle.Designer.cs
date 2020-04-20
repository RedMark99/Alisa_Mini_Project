namespace jewelry_shop
{
    partial class AddTitle
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
            this.Badd = new System.Windows.Forms.Button();
            this.TBType = new System.Windows.Forms.TextBox();
            this.TBName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Badd
            // 
            this.Badd.BackColor = System.Drawing.Color.White;
            this.Badd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Badd.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.Badd.Location = new System.Drawing.Point(30, 130);
            this.Badd.Margin = new System.Windows.Forms.Padding(4);
            this.Badd.Name = "Badd";
            this.Badd.Size = new System.Drawing.Size(170, 42);
            this.Badd.TabIndex = 0;
            this.Badd.Text = "ДОБАВИТЬ";
            this.Badd.UseVisualStyleBackColor = false;
            this.Badd.Click += new System.EventHandler(this.Badd_Click);
            // 
            // TBType
            // 
            this.TBType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TBType.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.TBType.ForeColor = System.Drawing.Color.Black;
            this.TBType.Location = new System.Drawing.Point(30, 70);
            this.TBType.Margin = new System.Windows.Forms.Padding(4);
            this.TBType.Multiline = true;
            this.TBType.Name = "TBType";
            this.TBType.Size = new System.Drawing.Size(170, 32);
            this.TBType.TabIndex = 2;
            this.TBType.Enter += new System.EventHandler(this.TBType_Enter);
            this.TBType.Leave += new System.EventHandler(this.TBType_Leave);
            // 
            // TBName
            // 
            this.TBName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TBName.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.TBName.ForeColor = System.Drawing.Color.Black;
            this.TBName.Location = new System.Drawing.Point(30, 30);
            this.TBName.Margin = new System.Windows.Forms.Padding(4);
            this.TBName.Multiline = true;
            this.TBName.Name = "TBName";
            this.TBName.Size = new System.Drawing.Size(170, 32);
            this.TBName.TabIndex = 1;
            this.TBName.Enter += new System.EventHandler(this.TBName_Enter);
            this.TBName.Leave += new System.EventHandler(this.TBName_Leave);
            // 
            // AddTitle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(222, 193);
            this.Controls.Add(this.Badd);
            this.Controls.Add(this.TBType);
            this.Controls.Add(this.TBName);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AddTitle";
            this.Text = "ИЗДЕЛИЯ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Badd;
        private System.Windows.Forms.TextBox TBType;
        private System.Windows.Forms.TextBox TBName;
    }
}