namespace jewelry_shop
{
    partial class editMaterial
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
            this.BEditmaterial = new System.Windows.Forms.Button();
            this.TBPrice = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BEditmaterial
            // 
            this.BEditmaterial.BackColor = System.Drawing.Color.Black;
            this.BEditmaterial.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BEditmaterial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BEditmaterial.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.BEditmaterial.ForeColor = System.Drawing.Color.White;
            this.BEditmaterial.Location = new System.Drawing.Point(16, 62);
            this.BEditmaterial.Margin = new System.Windows.Forms.Padding(4);
            this.BEditmaterial.Name = "BEditmaterial";
            this.BEditmaterial.Size = new System.Drawing.Size(170, 32);
            this.BEditmaterial.TabIndex = 3;
            this.BEditmaterial.Text = "Ок";
            this.BEditmaterial.UseVisualStyleBackColor = false;
            this.BEditmaterial.Click += new System.EventHandler(this.BEditmaterial_Click);
            // 
            // TBPrice
            // 
            this.TBPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TBPrice.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.TBPrice.ForeColor = System.Drawing.Color.Black;
            this.TBPrice.Location = new System.Drawing.Point(16, 16);
            this.TBPrice.Margin = new System.Windows.Forms.Padding(4);
            this.TBPrice.Multiline = true;
            this.TBPrice.Name = "TBPrice";
            this.TBPrice.Size = new System.Drawing.Size(170, 32);
            this.TBPrice.TabIndex = 5;
            this.TBPrice.TextChanged += new System.EventHandler(this.TBPrice_TextChanged);
            // 
            // editMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(202, 107);
            this.Controls.Add(this.BEditmaterial);
            this.Controls.Add(this.TBPrice);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "editMaterial";
            this.Text = "МАТЕРИАЛ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BEditmaterial;
        internal System.Windows.Forms.TextBox TBPrice;
    }
}