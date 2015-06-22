namespace PictureResize
{
    partial class Form_resize
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_resize));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_info = new System.Windows.Forms.TextBox();
            this.label_width = new System.Windows.Forms.Label();
            this.label_height = new System.Windows.Forms.Label();
            this.button_saveAs = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.saveFileDialog_main = new System.Windows.Forms.SaveFileDialog();
            this.numericUpDown_width = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_height = new System.Windows.Forms.NumericUpDown();
            this.pictureBox_main = new System.Windows.Forms.PictureBox();
            this.label_fileSize = new System.Windows.Forms.Label();
            this.textBox_fileSize = new System.Windows.Forms.TextBox();
            this.menuStrip_main = new System.Windows.Forms.MenuStrip();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_main)).BeginInit();
            this.menuStrip_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_info);
            this.groupBox1.Location = new System.Drawing.Point(12, 153);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(160, 88);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Info";
            // 
            // textBox_info
            // 
            this.textBox_info.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_info.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_info.Location = new System.Drawing.Point(6, 19);
            this.textBox_info.Multiline = true;
            this.textBox_info.Name = "textBox_info";
            this.textBox_info.ReadOnly = true;
            this.textBox_info.Size = new System.Drawing.Size(148, 60);
            this.textBox_info.TabIndex = 0;
            this.textBox_info.TabStop = false;
            this.textBox_info.Text = "Image/JPEG\r\nWidth:\r\nHeight:\r\nFile size:";
            // 
            // label_width
            // 
            this.label_width.AutoSize = true;
            this.label_width.Location = new System.Drawing.Point(15, 250);
            this.label_width.Name = "label_width";
            this.label_width.Size = new System.Drawing.Size(38, 13);
            this.label_width.TabIndex = 4;
            this.label_width.Text = "Width:";
            // 
            // label_height
            // 
            this.label_height.AutoSize = true;
            this.label_height.Location = new System.Drawing.Point(15, 276);
            this.label_height.Name = "label_height";
            this.label_height.Size = new System.Drawing.Size(41, 13);
            this.label_height.TabIndex = 5;
            this.label_height.Text = "Height:";
            // 
            // button_saveAs
            // 
            this.button_saveAs.Location = new System.Drawing.Point(12, 356);
            this.button_saveAs.Name = "button_saveAs";
            this.button_saveAs.Size = new System.Drawing.Size(160, 25);
            this.button_saveAs.TabIndex = 3;
            this.button_saveAs.Text = "save as...";
            this.button_saveAs.UseVisualStyleBackColor = true;
            this.button_saveAs.Click += new System.EventHandler(this.button_saveAs_Click);
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(12, 325);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(160, 25);
            this.button_save.TabIndex = 2;
            this.button_save.Text = "save";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // numericUpDown_width
            // 
            this.numericUpDown_width.Location = new System.Drawing.Point(95, 248);
            this.numericUpDown_width.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numericUpDown_width.Name = "numericUpDown_width";
            this.numericUpDown_width.Size = new System.Drawing.Size(77, 20);
            this.numericUpDown_width.TabIndex = 0;
            this.numericUpDown_width.ValueChanged += new System.EventHandler(this.numericUpDown_width_ValueChanged);
            this.numericUpDown_width.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numericUpDown_width_KeyUp);
            // 
            // numericUpDown_height
            // 
            this.numericUpDown_height.Location = new System.Drawing.Point(95, 274);
            this.numericUpDown_height.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numericUpDown_height.Name = "numericUpDown_height";
            this.numericUpDown_height.Size = new System.Drawing.Size(77, 20);
            this.numericUpDown_height.TabIndex = 1;
            this.numericUpDown_height.ValueChanged += new System.EventHandler(this.numericUpDown_height_ValueChanged);
            this.numericUpDown_height.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numericUpDown_height_KeyUp);
            // 
            // pictureBox_main
            // 
            this.pictureBox_main.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox_main.Location = new System.Drawing.Point(12, 27);
            this.pictureBox_main.Name = "pictureBox_main";
            this.pictureBox_main.Size = new System.Drawing.Size(160, 120);
            this.pictureBox_main.TabIndex = 0;
            this.pictureBox_main.TabStop = false;
            // 
            // label_fileSize
            // 
            this.label_fileSize.AutoSize = true;
            this.label_fileSize.Location = new System.Drawing.Point(15, 302);
            this.label_fileSize.Name = "label_fileSize";
            this.label_fileSize.Size = new System.Drawing.Size(47, 13);
            this.label_fileSize.TabIndex = 7;
            this.label_fileSize.Text = "File size:";
            // 
            // textBox_fileSize
            // 
            this.textBox_fileSize.Location = new System.Drawing.Point(95, 299);
            this.textBox_fileSize.Name = "textBox_fileSize";
            this.textBox_fileSize.ReadOnly = true;
            this.textBox_fileSize.Size = new System.Drawing.Size(77, 20);
            this.textBox_fileSize.TabIndex = 8;
            // 
            // menuStrip_main
            // 
            this.menuStrip_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languageToolStripMenuItem});
            this.menuStrip_main.Location = new System.Drawing.Point(0, 0);
            this.menuStrip_main.Name = "menuStrip_main";
            this.menuStrip_main.Size = new System.Drawing.Size(184, 24);
            this.menuStrip_main.TabIndex = 9;
            this.menuStrip_main.Text = "menuStrip1";
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.languageToolStripMenuItem.Text = "Language";
            // 
            // Form_resize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 393);
            this.Controls.Add(this.textBox_fileSize);
            this.Controls.Add(this.label_fileSize);
            this.Controls.Add(this.numericUpDown_height);
            this.Controls.Add(this.numericUpDown_width);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.button_saveAs);
            this.Controls.Add(this.label_height);
            this.Controls.Add(this.label_width);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox_main);
            this.Controls.Add(this.menuStrip_main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip_main;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_resize";
            this.Text = "PictureResize";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_resize_FormClosed);
            this.Load += new System.EventHandler(this.Form_resize_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_main)).EndInit();
            this.menuStrip_main.ResumeLayout(false);
            this.menuStrip_main.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_main;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_info;
        private System.Windows.Forms.Label label_width;
        private System.Windows.Forms.Label label_height;
        private System.Windows.Forms.Button button_saveAs;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.SaveFileDialog saveFileDialog_main;
        private System.Windows.Forms.NumericUpDown numericUpDown_width;
        private System.Windows.Forms.NumericUpDown numericUpDown_height;
        private System.Windows.Forms.Label label_fileSize;
        private System.Windows.Forms.TextBox textBox_fileSize;
        private System.Windows.Forms.MenuStrip menuStrip_main;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
    }
}