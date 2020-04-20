namespace jewelry_shop
{
    partial class Export
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
            this.CBTName = new System.Windows.Forms.ComboBox();
            this.CBMName = new System.Windows.Forms.ComboBox();
            this.CBTType = new System.Windows.Forms.ComboBox();
            this.BNight = new System.Windows.Forms.Button();
            this.BImport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CBTName
            // 
            this.CBTName.BackColor = System.Drawing.Color.White;
            this.CBTName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBTName.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CBTName.ForeColor = System.Drawing.Color.Black;
            this.CBTName.FormattingEnabled = true;
            this.CBTName.Location = new System.Drawing.Point(13, 15);
            this.CBTName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CBTName.Name = "CBTName";
            this.CBTName.Size = new System.Drawing.Size(170, 25);
            this.CBTName.TabIndex = 0;
            // 
            // CBMName
            // 
            this.CBMName.BackColor = System.Drawing.Color.White;
            this.CBMName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBMName.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CBMName.ForeColor = System.Drawing.Color.Black;
            this.CBMName.FormattingEnabled = true;
            this.CBMName.Location = new System.Drawing.Point(369, 15);
            this.CBMName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CBMName.Name = "CBMName";
            this.CBMName.Size = new System.Drawing.Size(170, 25);
            this.CBMName.TabIndex = 1;
            // 
            // CBTType
            // 
            this.CBTType.BackColor = System.Drawing.Color.White;
            this.CBTType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBTType.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CBTType.ForeColor = System.Drawing.Color.Black;
            this.CBTType.FormattingEnabled = true;
            this.CBTType.Location = new System.Drawing.Point(191, 15);
            this.CBTType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CBTType.Name = "CBTType";
            this.CBTType.Size = new System.Drawing.Size(170, 25);
            this.CBTType.TabIndex = 1;
            // 
            // BNight
            // 
            this.BNight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BNight.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.BNight.ForeColor = System.Drawing.Color.White;
            this.BNight.Location = new System.Drawing.Point(585, 13);
            this.BNight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BNight.Name = "BNight";
            this.BNight.Size = new System.Drawing.Size(170, 32);
            this.BNight.TabIndex = 4;
            this.BNight.Text = "ЭКСПОРТ";
            this.BNight.UseVisualStyleBackColor = true;
            this.BNight.Click += new System.EventHandler(this.BNight_Click);
            // 
            // BImport
            // 
            this.BImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BImport.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.BImport.ForeColor = System.Drawing.Color.White;
            this.BImport.Location = new System.Drawing.Point(763, 13);
            this.BImport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BImport.Name = "BImport";
            this.BImport.Size = new System.Drawing.Size(170, 32);
            this.BImport.TabIndex = 5;
            this.BImport.Text = "ИМПОРТ";
            this.BImport.UseVisualStyleBackColor = true;
            this.BImport.Click += new System.EventHandler(this.BImport_Click);
            // 
            // Export
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(946, 60);
            this.Controls.Add(this.BImport);
            this.Controls.Add(this.BNight);
            this.Controls.Add(this.CBTType);
            this.Controls.Add(this.CBMName);
            this.Controls.Add(this.CBTName);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Export";
            this.Text = "Export";
            this.Load += new System.EventHandler(this.Export_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox CBTName;
        private System.Windows.Forms.ComboBox CBMName;
        private System.Windows.Forms.ComboBox CBTType;
        private System.Windows.Forms.Button BNight;
        private System.Windows.Forms.Button BImport;
    }
}