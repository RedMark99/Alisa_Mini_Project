namespace jewelry_shop
{
    partial class AddUser
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
            this.TBLogin = new System.Windows.Forms.TextBox();
            this.TBPassword = new System.Windows.Forms.TextBox();
            this.Badd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TBLogin
            // 
            this.TBLogin.BackColor = System.Drawing.Color.White;
            this.TBLogin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TBLogin.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.TBLogin.ForeColor = System.Drawing.Color.Black;
            this.TBLogin.Location = new System.Drawing.Point(30, 30);
            this.TBLogin.Margin = new System.Windows.Forms.Padding(4);
            this.TBLogin.Multiline = true;
            this.TBLogin.Name = "TBLogin";
            this.TBLogin.Size = new System.Drawing.Size(170, 32);
            this.TBLogin.TabIndex = 0;
            this.TBLogin.Enter += new System.EventHandler(this.TBLogin_Enter);
            this.TBLogin.Leave += new System.EventHandler(this.TBLogin_Leave);
            // 
            // TBPassword
            // 
            this.TBPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TBPassword.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.TBPassword.ForeColor = System.Drawing.Color.Black;
            this.TBPassword.Location = new System.Drawing.Point(30, 70);
            this.TBPassword.Margin = new System.Windows.Forms.Padding(4);
            this.TBPassword.Multiline = true;
            this.TBPassword.Name = "TBPassword";
            this.TBPassword.Size = new System.Drawing.Size(170, 32);
            this.TBPassword.TabIndex = 1;
            this.TBPassword.Enter += new System.EventHandler(this.password_Enter);
            this.TBPassword.Leave += new System.EventHandler(this.TBPassword_Leave);
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
            this.Badd.TabIndex = 2;
            this.Badd.Text = "ДОБАВИТЬ";
            this.Badd.UseVisualStyleBackColor = false;
            this.Badd.Click += new System.EventHandler(this.Badd_Click);
            // 
            // AddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(222, 193);
            this.Controls.Add(this.Badd);
            this.Controls.Add(this.TBPassword);
            this.Controls.Add(this.TBLogin);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AddUser";
            this.Text = "ПОЛЬЗОВАТЕЛЬ";
            this.Load += new System.EventHandler(this.AddUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TBLogin;
        private System.Windows.Forms.TextBox TBPassword;
        private System.Windows.Forms.Button Badd;
    }
}