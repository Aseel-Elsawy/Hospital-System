namespace HospitalProject
{
    partial class Tickets
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tickets));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.cliniccombo = new System.Windows.Forms.ComboBox();
            this.codetxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.addrstxt = new System.Windows.Forms.TextBox();
            this.nametxt = new System.Windows.Forms.TextBox();
            this.phonetxt = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.agetxt = new System.Windows.Forms.MaskedTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.agetxt);
            this.groupBox1.Controls.Add(this.date);
            this.groupBox1.Controls.Add(this.cliniccombo);
            this.groupBox1.Controls.Add(this.codetxt);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.button8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.addrstxt);
            this.groupBox1.Controls.Add(this.nametxt);
            this.groupBox1.Controls.Add(this.phonetxt);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(1, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(528, 532);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "New Client";
            // 
            // date
            // 
            this.date.Location = new System.Drawing.Point(99, 404);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(356, 28);
            this.date.TabIndex = 25;
            // 
            // cliniccombo
            // 
            this.cliniccombo.FormattingEnabled = true;
            this.cliniccombo.Location = new System.Drawing.Point(99, 348);
            this.cliniccombo.Margin = new System.Windows.Forms.Padding(4);
            this.cliniccombo.Name = "cliniccombo";
            this.cliniccombo.Size = new System.Drawing.Size(356, 30);
            this.cliniccombo.TabIndex = 24;
            // 
            // codetxt
            // 
            this.codetxt.Location = new System.Drawing.Point(224, 44);
            this.codetxt.Name = "codetxt";
            this.codetxt.Size = new System.Drawing.Size(135, 28);
            this.codetxt.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(86, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 22);
            this.label6.TabIndex = 22;
            this.label6.Text = "Ticket Number:";
            // 
            // button7
            // 
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button7.Location = new System.Drawing.Point(303, 480);
            this.button7.Margin = new System.Windows.Forms.Padding(4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(94, 32);
            this.button7.TabIndex = 13;
            this.button7.Text = "Save";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button8.Location = new System.Drawing.Point(110, 480);
            this.button8.Margin = new System.Windows.Forms.Padding(4);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(94, 32);
            this.button8.TabIndex = 14;
            this.button8.Text = "New";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 286);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 22);
            this.label5.TabIndex = 21;
            this.label5.Text = "Phone:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 348);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 22);
            this.label4.TabIndex = 20;
            this.label4.Text = "Clinic";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 404);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 22);
            this.label3.TabIndex = 19;
            this.label3.Text = "Date:";
            // 
            // addrstxt
            // 
            this.addrstxt.Location = new System.Drawing.Point(99, 221);
            this.addrstxt.Name = "addrstxt";
            this.addrstxt.Size = new System.Drawing.Size(356, 28);
            this.addrstxt.TabIndex = 17;
            // 
            // nametxt
            // 
            this.nametxt.Location = new System.Drawing.Point(99, 98);
            this.nametxt.Name = "nametxt";
            this.nametxt.Size = new System.Drawing.Size(356, 28);
            this.nametxt.TabIndex = 16;
            // 
            // phonetxt
            // 
            this.phonetxt.HidePromptOnLeave = true;
            this.phonetxt.Location = new System.Drawing.Point(99, 286);
            this.phonetxt.Mask = "00000000000";
            this.phonetxt.Name = "phonetxt";
            this.phonetxt.Size = new System.Drawing.Size(356, 28);
            this.phonetxt.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 155);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 22);
            this.label7.TabIndex = 13;
            this.label7.Text = "Age:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 221);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 22);
            this.label2.TabIndex = 8;
            this.label2.Text = "Address:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 22);
            this.label1.TabIndex = 7;
            this.label1.Text = "Name:";
            // 
            // agetxt
            // 
            this.agetxt.HidePromptOnLeave = true;
            this.agetxt.Location = new System.Drawing.Point(99, 155);
            this.agetxt.Mask = "00000000000";
            this.agetxt.Name = "agetxt";
            this.agetxt.Size = new System.Drawing.Size(356, 28);
            this.agetxt.TabIndex = 26;
            // 
            // Tickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(539, 543);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Tickets";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tickets";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Tickets_FormClosed);
            this.Load += new System.EventHandler(this.Tickets_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox addrstxt;
        private System.Windows.Forms.TextBox nametxt;
        private System.Windows.Forms.MaskedTextBox phonetxt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox codetxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker date;
        private System.Windows.Forms.ComboBox cliniccombo;
        public System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox agetxt;
    }
}