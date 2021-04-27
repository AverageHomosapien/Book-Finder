namespace Book_Finder
{
    partial class Form1
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
            this.APIbutton = new System.Windows.Forms.Button();
            this.input = new System.Windows.Forms.TextBox();
            this.output = new System.Windows.Forms.TextBox();
            this.infoBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.radioVolumeID = new System.Windows.Forms.RadioButton();
            this.radioVolumeSearch = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // APIbutton
            // 
            this.APIbutton.AccessibleName = "API";
            this.APIbutton.Location = new System.Drawing.Point(219, 12);
            this.APIbutton.Name = "APIbutton";
            this.APIbutton.Size = new System.Drawing.Size(113, 38);
            this.APIbutton.TabIndex = 0;
            this.APIbutton.Text = "API";
            this.APIbutton.UseVisualStyleBackColor = true;
            this.APIbutton.Click += new System.EventHandler(this.APIbutton_Click);
            // 
            // input
            // 
            this.input.AccessibleName = "input";
            this.input.Location = new System.Drawing.Point(136, 124);
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(420, 20);
            this.input.TabIndex = 2;
            // 
            // output
            // 
            this.output.Location = new System.Drawing.Point(39, 209);
            this.output.Multiline = true;
            this.output.Name = "output";
            this.output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.output.Size = new System.Drawing.Size(517, 231);
            this.output.TabIndex = 7;
            // 
            // infoBox
            // 
            this.infoBox.AccessibleName = "infoBox";
            this.infoBox.Location = new System.Drawing.Point(136, 162);
            this.infoBox.Name = "infoBox";
            this.infoBox.Size = new System.Drawing.Size(420, 20);
            this.infoBox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "HTTP Request:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Input String:";
            // 
            // radioVolumeID
            // 
            this.radioVolumeID.AutoSize = true;
            this.radioVolumeID.Location = new System.Drawing.Point(136, 92);
            this.radioVolumeID.Name = "radioVolumeID";
            this.radioVolumeID.Size = new System.Drawing.Size(74, 17);
            this.radioVolumeID.TabIndex = 10;
            this.radioVolumeID.TabStop = true;
            this.radioVolumeID.Text = "Volume ID";
            this.radioVolumeID.UseVisualStyleBackColor = true;
            // 
            // radioVolumeSearch
            // 
            this.radioVolumeSearch.AutoSize = true;
            this.radioVolumeSearch.Location = new System.Drawing.Point(235, 92);
            this.radioVolumeSearch.Name = "radioVolumeSearch";
            this.radioVolumeSearch.Size = new System.Drawing.Size(97, 17);
            this.radioVolumeSearch.TabIndex = 11;
            this.radioVolumeSearch.TabStop = true;
            this.radioVolumeSearch.Text = "Volume Search";
            this.radioVolumeSearch.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 483);
            this.Controls.Add(this.radioVolumeSearch);
            this.Controls.Add(this.radioVolumeID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.output);
            this.Controls.Add(this.infoBox);
            this.Controls.Add(this.input);
            this.Controls.Add(this.APIbutton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button APIbutton;
        private System.Windows.Forms.TextBox input;
        private System.Windows.Forms.TextBox output;
        private System.Windows.Forms.TextBox infoBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioVolumeID;
        private System.Windows.Forms.RadioButton radioVolumeSearch;
    }
}

