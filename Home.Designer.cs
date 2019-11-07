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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.BtnAssembly = new System.Windows.Forms.Button();
            this.btnNonConformity = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblDepartmentCode = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.pictureBoxSettings = new System.Windows.Forms.PictureBox();
            this.lblTableID = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnAssembly
            // 
            this.BtnAssembly.BackColor = System.Drawing.Color.DarkBlue;
            this.BtnAssembly.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.BtnAssembly.ForeColor = System.Drawing.Color.White;
            this.BtnAssembly.Location = new System.Drawing.Point(6, 8);
            this.BtnAssembly.Name = "BtnAssembly";
            this.BtnAssembly.Size = new System.Drawing.Size(294, 63);
            this.BtnAssembly.TabIndex = 8;
            this.BtnAssembly.Text = "ASSEMBLY";
            this.BtnAssembly.Click += new System.EventHandler(this.BtnAssembly_Click);
            // 
            // btnNonConformity
            // 
            this.btnNonConformity.BackColor = System.Drawing.Color.DarkBlue;
            this.btnNonConformity.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnNonConformity.ForeColor = System.Drawing.Color.White;
            this.btnNonConformity.Location = new System.Drawing.Point(6, 79);
            this.btnNonConformity.Name = "btnNonConformity";
            this.btnNonConformity.Size = new System.Drawing.Size(294, 63);
            this.btnNonConformity.TabIndex = 9;
            this.btnNonConformity.Text = "NON CONFORMITY";
            this.btnNonConformity.Click += new System.EventHandler(this.btnNonConformity_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblTime);
            this.panel1.Controls.Add(this.lblDepartmentCode);
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Controls.Add(this.pictureBoxSettings);
            this.panel1.Controls.Add(this.lblTableID);
            this.panel1.Location = new System.Drawing.Point(0, 149);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(306, 30);
            // 
            // lblTime
            // 
            this.lblTime.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblTime.Location = new System.Drawing.Point(241, 6);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(62, 20);
            this.lblTime.Text = "00:00:00";
            // 
            // lblDepartmentCode
            // 
            this.lblDepartmentCode.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblDepartmentCode.Location = new System.Drawing.Point(34, 6);
            this.lblDepartmentCode.Name = "lblDepartmentCode";
            this.lblDepartmentCode.Size = new System.Drawing.Size(60, 20);
            this.lblDepartmentCode.Text = "AE-APW";
            // 
            // lblDate
            // 
            this.lblDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblDate.Location = new System.Drawing.Point(160, 6);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(75, 20);
            this.lblDate.Text = "3/11/2010";
            // 
            // pictureBoxSettings
            // 
            this.pictureBoxSettings.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxSettings.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxSettings.Image")));
            this.pictureBoxSettings.Location = new System.Drawing.Point(3, 2);
            this.pictureBoxSettings.Name = "pictureBoxSettings";
            this.pictureBoxSettings.Size = new System.Drawing.Size(25, 26);
            this.pictureBoxSettings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxSettings.Click += new System.EventHandler(this.pictureBoxSettings_Click);
            // 
            // lblTableID
            // 
            this.lblTableID.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblTableID.Location = new System.Drawing.Point(100, 6);
            this.lblTableID.Name = "lblTableID";
            this.lblTableID.Size = new System.Drawing.Size(58, 20);
            this.lblTableID.Text = "M00045";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(307, 180);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BtnAssembly);
            this.Controls.Add(this.btnNonConformity);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Home";
            this.Text = "LEGNANO";
            this.Load += new System.EventHandler(this.Home_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnAssembly;
        private System.Windows.Forms.Button btnNonConformity;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblDepartmentCode;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.PictureBox pictureBoxSettings;
        private System.Windows.Forms.Label lblTableID;
    }
}