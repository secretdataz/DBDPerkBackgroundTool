namespace PerkBackgroundTool
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.DbdPathTextBox = new System.Windows.Forms.TextBox();
            this.dbdPathBrowseButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.LoadProfileButton = new System.Windows.Forms.Button();
            this.SaveProfileButton = new System.Windows.Forms.Button();
            this.LoadLastProfileButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.templatePathBrowseButton = new System.Windows.Forms.Button();
            this.templatePathTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.ProgressLabel = new System.Windows.Forms.Label();
            this.PreviewBtn = new System.Windows.Forms.Button();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // DbdPathTextBox
            // 
            this.DbdPathTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.DbdPathTextBox.Location = new System.Drawing.Point(92, 12);
            this.DbdPathTextBox.Multiline = true;
            this.DbdPathTextBox.Name = "DbdPathTextBox";
            this.DbdPathTextBox.ReadOnly = true;
            this.DbdPathTextBox.Size = new System.Drawing.Size(269, 26);
            this.DbdPathTextBox.TabIndex = 0;
            // 
            // dbdPathBrowseButton
            // 
            this.dbdPathBrowseButton.Location = new System.Drawing.Point(372, 12);
            this.dbdPathBrowseButton.Name = "dbdPathBrowseButton";
            this.dbdPathBrowseButton.Size = new System.Drawing.Size(73, 26);
            this.dbdPathBrowseButton.TabIndex = 1;
            this.dbdPathBrowseButton.Text = "Browse";
            this.dbdPathBrowseButton.UseVisualStyleBackColor = true;
            this.dbdPathBrowseButton.Click += new System.EventHandler(this.BrowseBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "DBD Path: ";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(7, 76);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(438, 373);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellValueChanged);
            // 
            // ApplyButton
            // 
            this.ApplyButton.Enabled = false;
            this.ApplyButton.Location = new System.Drawing.Point(7, 468);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(79, 43);
            this.ApplyButton.TabIndex = 4;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // LoadProfileButton
            // 
            this.LoadProfileButton.Location = new System.Drawing.Point(92, 468);
            this.LoadProfileButton.Name = "LoadProfileButton";
            this.LoadProfileButton.Size = new System.Drawing.Size(79, 43);
            this.LoadProfileButton.TabIndex = 5;
            this.LoadProfileButton.Text = "Load Profile";
            this.LoadProfileButton.UseVisualStyleBackColor = true;
            this.LoadProfileButton.Click += new System.EventHandler(this.LoadProfileButton_Click);
            // 
            // SaveProfileButton
            // 
            this.SaveProfileButton.Location = new System.Drawing.Point(177, 468);
            this.SaveProfileButton.Name = "SaveProfileButton";
            this.SaveProfileButton.Size = new System.Drawing.Size(79, 43);
            this.SaveProfileButton.TabIndex = 6;
            this.SaveProfileButton.Text = "Save Profile";
            this.SaveProfileButton.UseVisualStyleBackColor = true;
            this.SaveProfileButton.Click += new System.EventHandler(this.SaveProfileButton_Click);
            // 
            // LoadLastProfileButton
            // 
            this.LoadLastProfileButton.Location = new System.Drawing.Point(262, 468);
            this.LoadLastProfileButton.Name = "LoadLastProfileButton";
            this.LoadLastProfileButton.Size = new System.Drawing.Size(79, 43);
            this.LoadLastProfileButton.TabIndex = 7;
            this.LoadLastProfileButton.Text = "Last Profile";
            this.LoadLastProfileButton.UseVisualStyleBackColor = true;
            this.LoadLastProfileButton.Click += new System.EventHandler(this.LoadLastProfileButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Template Path: ";
            // 
            // templatePathBrowseButton
            // 
            this.templatePathBrowseButton.Location = new System.Drawing.Point(372, 44);
            this.templatePathBrowseButton.Name = "templatePathBrowseButton";
            this.templatePathBrowseButton.Size = new System.Drawing.Size(73, 26);
            this.templatePathBrowseButton.TabIndex = 9;
            this.templatePathBrowseButton.Text = "Browse";
            this.templatePathBrowseButton.UseVisualStyleBackColor = true;
            this.templatePathBrowseButton.Click += new System.EventHandler(this.TemplatePathBrowseButton_Click);
            // 
            // templatePathTextBox
            // 
            this.templatePathTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.templatePathTextBox.Location = new System.Drawing.Point(92, 44);
            this.templatePathTextBox.Multiline = true;
            this.templatePathTextBox.Name = "templatePathTextBox";
            this.templatePathTextBox.ReadOnly = true;
            this.templatePathTextBox.Size = new System.Drawing.Size(269, 26);
            this.templatePathTextBox.TabIndex = 8;
            this.templatePathTextBox.Text = "_TEMPLATE.png";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 452);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(344, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Press enter after selecting your last perk to make sure it\'s really selected";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(109, 517);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(336, 27);
            this.progressBar1.TabIndex = 13;
            // 
            // ProgressLabel
            // 
            this.ProgressLabel.AutoSize = true;
            this.ProgressLabel.Location = new System.Drawing.Point(4, 524);
            this.ProgressLabel.Name = "ProgressLabel";
            this.ProgressLabel.Size = new System.Drawing.Size(71, 13);
            this.ProgressLabel.TabIndex = 14;
            this.ProgressLabel.Text = "Progress: 0/0";
            // 
            // PreviewBtn
            // 
            this.PreviewBtn.Enabled = false;
            this.PreviewBtn.Location = new System.Drawing.Point(347, 468);
            this.PreviewBtn.Name = "PreviewBtn";
            this.PreviewBtn.Size = new System.Drawing.Size(98, 43);
            this.PreviewBtn.TabIndex = 15;
            this.PreviewBtn.Text = "Show Preview";
            this.PreviewBtn.UseVisualStyleBackColor = true;
            this.PreviewBtn.Click += new System.EventHandler(this.PreviewBtn_Click);
            // 
            // VersionLabel
            // 
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.Location = new System.Drawing.Point(4, 548);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(186, 13);
            this.VersionLabel.TabIndex = 16;
            this.VersionLabel.Text = "Version: Unknown, Commit: Unknown";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 567);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(435, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Report issues at: github.com/secretdataz/DBDPerkBackgroundTool             By: /u" +
    "/iCynon";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 589);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.PreviewBtn);
            this.Controls.Add(this.ProgressLabel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.templatePathBrowseButton);
            this.Controls.Add(this.templatePathTextBox);
            this.Controls.Add(this.LoadLastProfileButton);
            this.Controls.Add(this.SaveProfileButton);
            this.Controls.Add(this.LoadProfileButton);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dbdPathBrowseButton);
            this.Controls.Add(this.DbdPathTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Perk Background Tool";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox DbdPathTextBox;
        private System.Windows.Forms.Button dbdPathBrowseButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.Button LoadProfileButton;
        private System.Windows.Forms.Button SaveProfileButton;
        private System.Windows.Forms.Button LoadLastProfileButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button templatePathBrowseButton;
        private System.Windows.Forms.TextBox templatePathTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label ProgressLabel;
        private System.Windows.Forms.Button PreviewBtn;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.Label label4;
    }
}

