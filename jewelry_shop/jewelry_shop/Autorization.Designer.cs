namespace jewelry_shop
{
    partial class Autorization
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
            this.LoginTB = new System.Windows.Forms.TextBox();
            this.PasswordTB = new System.Windows.Forms.TextBox();
            this.BAuto = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LoginTB
            // 
            this.LoginTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LoginTB.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.LoginTB.ForeColor = System.Drawing.Color.Black;
            this.LoginTB.Location = new System.Drawing.Point(30, 30);
            this.LoginTB.Margin = new System.Windows.Forms.Padding(4);
            this.LoginTB.Multiline = true;
            this.LoginTB.Name = "LoginTB";
            this.LoginTB.Size = new System.Drawing.Size(170, 32);
            this.LoginTB.TabIndex = 0;
            this.LoginTB.Enter += new System.EventHandler(this.LoginTB_Enter);
            this.LoginTB.Leave += new System.EventHandler(this.LoginTB_Leave);
            // 
            // PasswordTB
            // 
            this.PasswordTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PasswordTB.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.PasswordTB.ForeColor = System.Drawing.Color.Black;
            this.PasswordTB.Location = new System.Drawing.Point(30, 70);
            this.PasswordTB.Margin = new System.Windows.Forms.Padding(4);
            this.PasswordTB.Multiline = true;
            this.PasswordTB.Name = "PasswordTB";
            this.PasswordTB.PasswordChar = '*';
            this.PasswordTB.Size = new System.Drawing.Size(170, 32);
            this.PasswordTB.TabIndex = 1;
            this.PasswordTB.TextChanged += new System.EventHandler(this.PasswordTB_TextChanged);
            this.PasswordTB.Enter += new System.EventHandler(this.PasswordTB_Enter);
            this.PasswordTB.Leave += new System.EventHandler(this.PasswordTB_Leave);
            // 
            // BAuto
            // 
            this.BAuto.BackColor = System.Drawing.Color.White;
            this.BAuto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BAuto.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.BAuto.Location = new System.Drawing.Point(30, 130);
            this.BAuto.Margin = new System.Windows.Forms.Padding(4);
            this.BAuto.Name = "BAuto";
            this.BAuto.Size = new System.Drawing.Size(170, 42);
            this.BAuto.TabIndex = 2;
            this.BAuto.Text = "ВОЙТИ";
            this.BAuto.UseVisualStyleBackColor = false;
            this.BAuto.Click += new System.EventHandler(this.BAuto_Click);
            // 
            // Autorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(222, 193);
            this.Controls.Add(this.BAuto);
            this.Controls.Add(this.PasswordTB);
            this.Controls.Add(this.LoginTB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Autorization";
            this.Text = "АВТОРИЗАЦИЯ";
            this.Load += new System.EventHandler(this.Autorization_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox LoginTB;
        private System.Windows.Forms.TextBox PasswordTB;
        private System.Windows.Forms.Button BAuto;
    }
}