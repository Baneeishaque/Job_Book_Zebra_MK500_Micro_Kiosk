namespace Job_Book_Zebra_MK500_Micro_Kiosk
{
    partial class Home
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
            this.buttonAssembly = new System.Windows.Forms.Button();
            this.buttonNonConformity = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonAssembly
            // 
            this.buttonAssembly.BackColor = System.Drawing.Color.DarkBlue;
            this.buttonAssembly.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.buttonAssembly.ForeColor = System.Drawing.Color.White;
            this.buttonAssembly.Location = new System.Drawing.Point(6, 8);
            this.buttonAssembly.Name = "buttonAssembly";
            this.buttonAssembly.Size = new System.Drawing.Size(294, 63);
            this.buttonAssembly.TabIndex = 8;
            this.buttonAssembly.Text = "ASSEMBLY";
            this.buttonAssembly.Click += new System.EventHandler(this.BtnAssembly_Click);
            // 
            // buttonNonConformity
            // 
            this.buttonNonConformity.BackColor = System.Drawing.Color.DarkBlue;
            this.buttonNonConformity.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.buttonNonConformity.ForeColor = System.Drawing.Color.White;
            this.buttonNonConformity.Location = new System.Drawing.Point(6, 79);
            this.buttonNonConformity.Name = "buttonNonConformity";
            this.buttonNonConformity.Size = new System.Drawing.Size(294, 63);
            this.buttonNonConformity.TabIndex = 9;
            this.buttonNonConformity.Text = "NON CONFORMITY";
            this.buttonNonConformity.Click += new System.EventHandler(this.btnNonConformity_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(307, 149);
            this.Controls.Add(this.buttonAssembly);
            this.Controls.Add(this.buttonNonConformity);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Home";
            this.Text = "LEGNANO";
            this.Load += new System.EventHandler(this.Home_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAssembly;
        private System.Windows.Forms.Button buttonNonConformity;
    }
}