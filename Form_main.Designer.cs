namespace PictureResize
{
    partial class Form_main
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_main));
            this.button_activate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_activate
            // 
            this.button_activate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_activate.BackgroundImage = global::PictureResize.Properties.Resources.Button_red;
            this.button_activate.Location = new System.Drawing.Point(12, 12);
            this.button_activate.Name = "button_activate";
            this.button_activate.Size = new System.Drawing.Size(128, 128);
            this.button_activate.TabIndex = 1;
            this.button_activate.UseVisualStyleBackColor = true;
            this.button_activate.Click += new System.EventHandler(this.button_activate_Click);
            // 
            // Form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(152, 152);
            this.Controls.Add(this.button_activate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_main";
            this.ShowInTaskbar = false;
            this.Text = "PictureResize";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_activate;

    }
}

