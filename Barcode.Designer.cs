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
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(7, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 20);
            this.label9.Text = "Scanning...";
            // 
            // Barcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(314, 200);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Barcode";
            this.Text = "LEGNANO";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Barcode_Closing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label9;
    }
}