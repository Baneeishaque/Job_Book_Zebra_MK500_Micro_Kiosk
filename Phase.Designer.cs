namespace Job_Book_Zebra_MK500_Micro_Kiosk
{
    partial class Phase
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
            this.textBoxCoreNumber = new System.Windows.Forms.TextBox();
            this.textBoxJobNumber = new System.Windows.Forms.TextBox();
            this.textBoxOperatorBadgeID = new System.Windows.Forms.TextBox();
            this.buttonContinue = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxTableID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxCoreNumber
            // 
            this.textBoxCoreNumber.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.textBoxCoreNumber.Location = new System.Drawing.Point(133, 66);
            this.textBoxCoreNumber.Name = "textBoxCoreNumber";
            this.textBoxCoreNumber.Size = new System.Drawing.Size(174, 22);
            this.textBoxCoreNumber.TabIndex = 76;
            this.textBoxCoreNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCoreNumber_KeyPress);
            // 
            // textBoxJobNumber
            // 
            this.textBoxJobNumber.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.textBoxJobNumber.Location = new System.Drawing.Point(133, 38);
            this.textBoxJobNumber.Name = "textBoxJobNumber";
            this.textBoxJobNumber.Size = new System.Drawing.Size(174, 22);
            this.textBoxJobNumber.TabIndex = 75;
            this.textBoxJobNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxJobNumber_KeyPress);
            // 
            // textBoxOperatorBadgeID
            // 
            this.textBoxOperatorBadgeID.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.textBoxOperatorBadgeID.Location = new System.Drawing.Point(133, 7);
            this.textBoxOperatorBadgeID.Name = "textBoxOperatorBadgeID";
            this.textBoxOperatorBadgeID.Size = new System.Drawing.Size(174, 22);
            this.textBoxOperatorBadgeID.TabIndex = 74;
            this.textBoxOperatorBadgeID.Text = "DI-1125225";
            // 
            // buttonContinue
            // 
            this.buttonContinue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonContinue.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.buttonContinue.ForeColor = System.Drawing.Color.White;
            this.buttonContinue.Location = new System.Drawing.Point(232, 127);
            this.buttonContinue.Name = "buttonContinue";
            this.buttonContinue.Size = new System.Drawing.Size(75, 37);
            this.buttonContinue.TabIndex = 73;
            this.buttonContinue.Text = "Continue";
            this.buttonContinue.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.Red;
            this.buttonBack.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.buttonBack.ForeColor = System.Drawing.Color.White;
            this.buttonBack.Location = new System.Drawing.Point(7, 127);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(81, 37);
            this.buttonBack.TabIndex = 72;
            this.buttonBack.Text = "Back";
            this.buttonBack.Click += new System.EventHandler(this.button8_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(7, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 20);
            this.label5.Text = "Operator Badge Id";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(7, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 20);
            this.label8.Text = "Job No";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(7, 66);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 20);
            this.label9.Text = "Core No";
            // 
            // textBoxTableID
            // 
            this.textBoxTableID.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.textBoxTableID.Location = new System.Drawing.Point(133, 96);
            this.textBoxTableID.Name = "textBoxTableID";
            this.textBoxTableID.Size = new System.Drawing.Size(174, 22);
            this.textBoxTableID.TabIndex = 81;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(7, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.Text = "Table ID";
            // 
            // Phase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(315, 171);
            this.Controls.Add(this.textBoxTableID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxCoreNumber);
            this.Controls.Add(this.textBoxJobNumber);
            this.Controls.Add(this.textBoxOperatorBadgeID);
            this.Controls.Add(this.buttonContinue);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Phase";
            this.Text = "LEGNANO";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxCoreNumber;
        private System.Windows.Forms.TextBox textBoxJobNumber;
        private System.Windows.Forms.TextBox textBoxOperatorBadgeID;
        private System.Windows.Forms.Button buttonContinue;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxTableID;
        private System.Windows.Forms.Label label1;
    }
}