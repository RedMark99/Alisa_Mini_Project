namespace jewelry_shop
{
    partial class AddMaterial
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
            this.TBName = new System.Windows.Forms.TextBox();
            this.TBPrice = new System.Windows.Forms.TextBox();
            this.Badd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TBName
            // 
            this.TBName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TBName.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TBName.Location = new System.Drawing.Point(30, 30);
            this.TBName.Margin = new System.Windows.Forms.Padding(4);
            this.TBName.Multiline = true;
            this.TBName.Name = "TBName";
            this.TBName.Size = new System.Drawing.Size(170, 32);
            this.TBName.TabIndex = 1;
            this.TBName.TextChanged += new System.EventHandler(this.TBName_TextChanged);
            this.TBName.Enter += new System.EventHandler(this.TBName_Enter);
            this.TBName.Leave += new System.EventHandler(this.TBName_Leave);
            // 
            // TBPrice
            // 
            this.TBPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TBPrice.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TBPrice.ForeColor = System.Drawing.Color.Black;
            this.TBPrice.Location = new System.Drawing.Point(30, 70);
            this.TBPrice.Margin = new System.Windows.Forms.Padding(4);
            this.TBPrice.Multiline = true;
            this.TBPrice.Name = "TBPrice";
            this.TBPrice.Size = new System.Drawing.Size(170, 32);
            this.TBPrice.TabIndex = 2;
            this.TBPrice.TextChanged += new System.EventHandler(this.TBPrice_TextChanged);
            this.TBPrice.Enter += new System.EventHandler(this.TBPrice_Enter);
            this.TBPrice.Leave += new System.EventHandler(this.TBPrice_Leave);
            // 
            // Badd
            // 
            this.Badd.BackColor = System.Drawing.Color.White;
            this.Badd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Badd.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.Badd.ForeColor = System.Drawing.Color.Black;
            this.Badd.Location = new System.Drawing.Point(30, 130);
            this.Badd.Margin = new System.Windows.Forms.Padding(4);
            this.Badd.Name = "Badd";
            this.Badd.Size = new System.Drawing.Size(170, 42);
            this.Badd.TabIndex = 0;
            this.Badd.Text = "ДОБАВИТЬ";
            this.Badd.UseVisualStyleBackColor = false;
            this.Badd.Click += new System.EventHandler(this.Badd_Click);
            // 
            // AddMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(222, 193);
            this.Controls.Add(this.Badd);
            this.Controls.Add(this.TBPrice);
            this.Controls.Add(this.TBName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AddMaterial";
            this.Text = "МАТЕРИАЛЫ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TBName;
        private System.Windows.Forms.TextBox TBPrice;
        private System.Windows.Forms.Button Badd;
    }
}