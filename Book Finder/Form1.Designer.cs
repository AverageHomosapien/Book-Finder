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
            this.output = new System.Windows.Forms.TextBox();
            this.input = new System.Windows.Forms.TextBox();
            this.infoBox = new System.Windows.Forms.TextBox();
            this.simpleAPI = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // APIbutton
            // 
            this.APIbutton.AccessibleName = "API";
            this.APIbutton.Location = new System.Drawing.Point(243, 77);
            this.APIbutton.Name = "APIbutton";
            this.APIbutton.Size = new System.Drawing.Size(75, 23);
            this.APIbutton.TabIndex = 0;
            this.APIbutton.Text = "API";
            this.APIbutton.UseVisualStyleBackColor = true;
            this.APIbutton.Click += new System.EventHandler(this.APIbutton_click);
            // 
            // output
            // 
            this.output.AccessibleName = "output";
            this.output.Location = new System.Drawing.Point(95, 238);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(365, 20);
            this.output.TabIndex = 1;
            // 
            // input
            // 
            this.input.AccessibleName = "output";
            this.input.Location = new System.Drawing.Point(95, 117);
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(365, 20);
            this.input.TabIndex = 2;
            // 
            // infoBox
            // 
            this.infoBox.AccessibleName = "output";
            this.infoBox.Location = new System.Drawing.Point(95, 175);
            this.infoBox.Name = "infoBox";
            this.infoBox.Size = new System.Drawing.Size(365, 20);
            this.infoBox.TabIndex = 3;
            // 
            // simpleAPI
            // 
            this.simpleAPI.AccessibleName = "API";
            this.simpleAPI.Location = new System.Drawing.Point(243, 32);
            this.simpleAPI.Name = "simpleAPI";
            this.simpleAPI.Size = new System.Drawing.Size(75, 23);
            this.simpleAPI.TabIndex = 4;
            this.simpleAPI.Text = "API";
            this.simpleAPI.UseVisualStyleBackColor = true;
            this.simpleAPI.Click += new System.EventHandler(this.simpleAPI_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 483);
            this.Controls.Add(this.simpleAPI);
            this.Controls.Add(this.infoBox);
            this.Controls.Add(this.input);
            this.Controls.Add(this.output);
            this.Controls.Add(this.APIbutton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button APIbutton;
        private System.Windows.Forms.TextBox output;
        private System.Windows.Forms.TextBox input;
        private System.Windows.Forms.TextBox infoBox;
        private System.Windows.Forms.Button simpleAPI;
    }
}

