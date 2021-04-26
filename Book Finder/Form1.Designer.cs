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
            this.infoBox = new System.Windows.Forms.TextBox();
            this.output = new System.Windows.Forms.TextBox();
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
            this.APIbutton.Click += new System.EventHandler(this.APIbutton_Click);
            // 
            // input
            // 
            this.input.AccessibleName = "input";
            this.input.Location = new System.Drawing.Point(95, 117);
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(365, 20);
            this.input.TabIndex = 2;
            this.input.Text = "s1gVAAAAYAAK";
            // 
            // infoBox
            // 
            this.infoBox.AccessibleName = "infoBox";
            this.infoBox.Location = new System.Drawing.Point(95, 165);
            this.infoBox.Name = "infoBox";
            this.infoBox.Size = new System.Drawing.Size(365, 20);
            this.infoBox.TabIndex = 6;
            // 
            // output
            // 
            this.output.Location = new System.Drawing.Point(95, 209);
            this.output.Multiline = true;
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(365, 200);
            this.output.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 483);
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
        private System.Windows.Forms.TextBox infoBox;
        private System.Windows.Forms.TextBox output;
    }
}

