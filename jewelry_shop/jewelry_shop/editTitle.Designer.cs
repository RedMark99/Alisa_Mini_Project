namespace jewelry_shop
{
    partial class editTitle
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
            this.Badd.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Badd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Badd.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.Badd.ForeColor = System.Drawing.Color.White;
            this.Badd.Location = new System.Drawing.Point(30, 130);
            this.Badd.Margin = new System.Windows.Forms.Padding(4);
            this.Badd.Name = "Badd";
            this.Badd.Size = new System.Drawing.Size(170, 32);
            this.Badd.TabIndex = 3;
            this.Badd.Text = "Ок";
            this.Badd.UseVisualStyleBackColor = true;
            this.Badd.Click += new System.EventHandler(this.Badd_Click);
            // 
            // TBType
            // 
            this.TBType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TBType.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.TBType.Location = new System.Drawing.Point(30, 70);
            this.TBType.Margin = new System.Windows.Forms.Padding(4);
            this.TBType.Name = "TBType";
            this.TBType.Size = new System.Drawing.Size(170, 25);
            this.TBType.TabIndex = 5;
            // 
            // TBName
            // 
            this.TBName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TBName.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.TBName.Location = new System.Drawing.Point(30, 30);
            this.TBName.Margin = new System.Windows.Forms.Padding(4);
            this.TBName.Name = "TBName";
            this.TBName.Size = new System.Drawing.Size(170, 25);
            this.TBName.TabIndex = 4;
            // 
            // editTitle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(222, 193);
            this.Controls.Add(this.Badd);
            this.Controls.Add(this.TBType);
            this.Controls.Add(this.TBName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "editTitle";
            this.Text = "ИЗДЕЛИЯ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Badd;
        internal System.Windows.Forms.TextBox TBType;
        internal System.Windows.Forms.TextBox TBName;
    }
}