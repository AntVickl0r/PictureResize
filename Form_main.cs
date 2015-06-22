using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;

namespace PictureResize
{
    public partial class Form_main : Form
    {
        private const string _MenuName = "\\shell\\ResizePicture_CONTEXTMENU";
        private const string _Command = "\\shell\\ResizePicture_CONTEXTMENU\\command";

        private Language _language = null;

        private bool _active = false;
        private bool _initiated = false;

        private void button_activate_Click(object sender, EventArgs e)
        {
            if (_initiated)
            {
                if (!ContextMenuEntry.IsAdmin())
                {
                    this.Hide();
                    ContextMenuEntry.restartAsAdmin();
                }
                else
                {
                    if (!_active)
                    {
                        button_activate.BackgroundImage = Properties.Resources.Button_green;

                        ContextMenuEntry.activate(_language);
                    }
                    else
                    {
                        button_activate.BackgroundImage = Properties.Resources.Button_red;

                        ContextMenuEntry.deactivate();

                    }
                    _active = !_active;
                }
            }
        }

        //---PUBLIC---//

        public Form_main(string[] args = null)
        {
            //args = new string[] { "C:\\Users\\Michael\\Pictures\\TEST\\filesize\\nature-258140.jpg" };

            InitializeComponent();

            try
            {
                _language = Language.DeserializeFromXML(AppDomain.CurrentDomain.BaseDirectory
                    + "\\lang\\" + Properties.Settings.Default["language"] + ".xml");
            }
            catch
            {
                MessageBox.Show("Failed to load language file", "Error");
                _language = new Language();
                if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\lang\\EN.xml"))
                {
                    Language.SerializeToXML(_language, AppDomain.CurrentDomain.BaseDirectory + "\\lang\\EN.xml");
                }
                Properties.Settings.Default["language"] = "EN";
            }

            _initiated = true;

            if (args != null && args.Length > 1)
            {
                Form_resize form_resize = new Form_resize(args[0], _language, args[1]);
                form_resize.Show();
            }
            else if (args != null && args.Length > 0)
            {
                Form_resize form_resize = new Form_resize(args[0], _language);
                form_resize.Show();
            }
            else
            {

                if (!ContextMenuEntry.IsAdmin())
                {
                    this.Hide();
                    ContextMenuEntry.restartAsAdmin();
                }
                else
                {
                    this.ShowInTaskbar = true;
                    this.WindowState = FormWindowState.Normal;
                    //
                    RegistryKey jpeg = Registry.ClassesRoot.OpenSubKey("jpegfile" + _Command);
                    if (jpeg != null)
                    {
                        jpeg.Close();
                        _active = true;
                        button_activate.BackgroundImage = Properties.Resources.Button_green;
                    }
                }
            }
        }
    }
}
