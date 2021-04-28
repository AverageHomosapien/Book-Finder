﻿namespace Book_Finder
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
            this.maxResults = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.searchComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.resultsListBox = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.allResultsBox = new System.Windows.Forms.Button();
            this.noneResultsBox = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.maxResults)).BeginInit();
            this.SuspendLayout();
            // 
            // APIbutton
            // 
            this.APIbutton.AccessibleName = "Query API";
            this.APIbutton.Location = new System.Drawing.Point(128, 11);
            this.APIbutton.Name = "APIbutton";
            this.APIbutton.Size = new System.Drawing.Size(113, 40);
            this.APIbutton.TabIndex = 0;
            this.APIbutton.Text = "Query API";
            this.APIbutton.UseVisualStyleBackColor = true;
            this.APIbutton.Click += new System.EventHandler(this.APIbutton_Click);
            // 
            // input
            // 
            this.input.AccessibleName = "input";
            this.input.Location = new System.Drawing.Point(128, 70);
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(408, 20);
            this.input.TabIndex = 2;
            // 
            // output
            // 
            this.output.Location = new System.Drawing.Point(39, 153);
            this.output.Multiline = true;
            this.output.Name = "output";
            this.output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.output.Size = new System.Drawing.Size(497, 281);
            this.output.TabIndex = 7;
            // 
            // infoBox
            // 
            this.infoBox.AccessibleName = "infoBox";
            this.infoBox.Location = new System.Drawing.Point(128, 108);
            this.infoBox.Name = "infoBox";
            this.infoBox.Size = new System.Drawing.Size(408, 20);
            this.infoBox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "HTTP Request:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Input String:";
            // 
            // radioVolumeID
            // 
            this.radioVolumeID.AutoSize = true;
            this.radioVolumeID.Location = new System.Drawing.Point(270, 12);
            this.radioVolumeID.Name = "radioVolumeID";
            this.radioVolumeID.Size = new System.Drawing.Size(69, 17);
            this.radioVolumeID.TabIndex = 10;
            this.radioVolumeID.TabStop = true;
            this.radioVolumeID.Text = "Select ID";
            this.radioVolumeID.UseVisualStyleBackColor = true;
            this.radioVolumeID.CheckedChanged += new System.EventHandler(this.radioVolumeID_CheckedChanged);
            // 
            // radioVolumeSearch
            // 
            this.radioVolumeSearch.AutoSize = true;
            this.radioVolumeSearch.Location = new System.Drawing.Point(270, 35);
            this.radioVolumeSearch.Name = "radioVolumeSearch";
            this.radioVolumeSearch.Size = new System.Drawing.Size(59, 17);
            this.radioVolumeSearch.TabIndex = 11;
            this.radioVolumeSearch.TabStop = true;
            this.radioVolumeSearch.Text = "Search";
            this.radioVolumeSearch.UseVisualStyleBackColor = true;
            this.radioVolumeSearch.CheckedChanged += new System.EventHandler(this.radioVolumeSearch_CheckedChanged);
            // 
            // maxResults
            // 
            this.maxResults.Location = new System.Drawing.Point(465, 31);
            this.maxResults.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.maxResults.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxResults.Name = "maxResults";
            this.maxResults.Size = new System.Drawing.Size(71, 20);
            this.maxResults.TabIndex = 12;
            this.maxResults.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(462, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Max Results:";
            // 
            // searchComboBox
            // 
            this.searchComboBox.FormattingEnabled = true;
            this.searchComboBox.Location = new System.Drawing.Point(372, 31);
            this.searchComboBox.Name = "searchComboBox";
            this.searchComboBox.Size = new System.Drawing.Size(71, 21);
            this.searchComboBox.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(369, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Search for:";
            // 
            // resultsListBox
            // 
            this.resultsListBox.FormattingEnabled = true;
            this.resultsListBox.Location = new System.Drawing.Point(557, 70);
            this.resultsListBox.Name = "resultsListBox";
            this.resultsListBox.Size = new System.Drawing.Size(139, 304);
            this.resultsListBox.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(554, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Results to Show:";
            // 
            // allResultsBox
            // 
            this.allResultsBox.Location = new System.Drawing.Point(557, 380);
            this.allResultsBox.Name = "allResultsBox";
            this.allResultsBox.Size = new System.Drawing.Size(139, 23);
            this.allResultsBox.TabIndex = 18;
            this.allResultsBox.Text = "Select all Results";
            this.allResultsBox.UseVisualStyleBackColor = true;
            this.allResultsBox.Click += new System.EventHandler(this.allResultsBox_Click);
            // 
            // noneResultsBox
            // 
            this.noneResultsBox.Location = new System.Drawing.Point(557, 409);
            this.noneResultsBox.Name = "noneResultsBox";
            this.noneResultsBox.Size = new System.Drawing.Size(139, 23);
            this.noneResultsBox.TabIndex = 19;
            this.noneResultsBox.Text = "Deselect all Results";
            this.noneResultsBox.UseVisualStyleBackColor = true;
            this.noneResultsBox.Click += new System.EventHandler(this.noneResultsBox_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 447);
            this.Controls.Add(this.noneResultsBox);
            this.Controls.Add(this.allResultsBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.resultsListBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.searchComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.maxResults);
            this.Controls.Add(this.radioVolumeSearch);
            this.Controls.Add(this.radioVolumeID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.output);
            this.Controls.Add(this.infoBox);
            this.Controls.Add(this.input);
            this.Controls.Add(this.APIbutton);
            this.Name = "Form1";
            this.Text = "Search Form";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.maxResults)).EndInit();
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
        private System.Windows.Forms.NumericUpDown maxResults;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox searchComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox resultsListBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button allResultsBox;
        private System.Windows.Forms.Button noneResultsBox;
    }
}

