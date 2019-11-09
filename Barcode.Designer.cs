namespace Job_Book_Zebra_MK500_Micro_Kiosk
{
    partial class Barcode
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
            this.labelScan = new System.Windows.Forms.Label();
            this.labelPhase = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelScan
            // 
            this.labelScan.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.labelScan.Location = new System.Drawing.Point(100, 95);
            this.labelScan.Name = "labelScan";
            this.labelScan.Size = new System.Drawing.Size(100, 20);
            this.labelScan.Text = "Scanning...";
            // 
            // labelPhase
            // 
            this.labelPhase.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.labelPhase.Location = new System.Drawing.Point(64, 68);
            this.labelPhase.Name = "labelPhase";
            this.labelPhase.Size = new System.Drawing.Size(179, 20);
            this.labelPhase.Text = "Phase : Non Conformity";
            // 
            // Barcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(314, 200);
            this.Controls.Add(this.labelPhase);
            this.Controls.Add(this.labelScan);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Barcode";
            this.Text = "LEGNANO";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Barcode_Closing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelScan;
        private System.Windows.Forms.Label labelPhase;
    }
}