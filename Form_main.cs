using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Principal;
using System.Reflection;

using Microsoft.Win32;

using System.Diagnostics;

namespace PictureResize
{
    public partial class Form_main : Form
    {
        private const string _MenuName = "\\shell\\ResizePicture_CONTEXTMENU";
        private const string _Command = "\\shell\\ResizePicture_CONTEXTMENU\\command";

        private bool _active = false;
        private bool _initiated = false;

        private void button_activate_Click(object sender, EventArgs e)
        {
            if (_initiated)
            {
                if (!IsAdmin())
                {
                    this.Hide();
                    restartAsAdmin();
                }
                else
                {
                    string[] fileTypes = new string[] { "jpegfile", "pngfile", "giffile" };

                    foreach (string fileType in fileTypes)
                    {
                        if (!_active)
                        {
                            button_activate.BackgroundImage = Properties.Resources.Button_green;

                            RegistryKey regmenu = null;
                            RegistryKey regcmd = null;
                            try
                            {
                                regmenu = Registry.ClassesRoot.CreateSubKey(fileType + _MenuName);
                                if (regmenu != null)
                                    regmenu.SetValue("", Language.RESIZE_IMAGE);
                                regcmd = Registry.ClassesRoot.CreateSubKey(fileType + _Command);
                                if (regcmd != null)
                                    regcmd.SetValue("", System.Reflection.Assembly.GetEntryAssembly().Location + " %1");

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(this, ex.ToString());
                            }
                            finally
                            {
                                if (regmenu != null)
                                    regmenu.Close();
                                if (regcmd != null)
                                    regcmd.Close();
                            }
                        }
                        else
                        {
                            button_activate.BackgroundImage = Properties.Resources.Button_red;

                            try
                            {
                                RegistryKey reg = Registry.ClassesRoot.OpenSubKey(fileType + _Command);
                                if (reg != null)
                                {
                                    reg.Close();
                                    Registry.ClassesRoot.DeleteSubKey(fileType + _Command);
                                }
                                reg = Registry.ClassesRoot.OpenSubKey(fileType + _MenuName);
                                if (reg != null)
                                {
                                    reg.Close();
                                    Registry.ClassesRoot.DeleteSubKey(fileType + _MenuName);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(this, ex.ToString());
                            }
                        }
                    }
                    _active = !_active;
                }
            }
        }

        //---PUBLIC---//

        public Form_main(string[] args = null)
        {
            InitializeComponent();

            _initiated = true;

            if (args != null && args.Length > 0)
            {
                Form_resize form_resize = new Form_resize(args[0]);
                form_resize.Show();
            }
            else
            {

                if (!IsAdmin())
                {
                    this.Hide();
                    restartAsAdmin();
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


        public static bool IsAdmin()
        {
            WindowsIdentity id = WindowsIdentity.GetCurrent();
            WindowsPrincipal p = new WindowsPrincipal(id);
            return p.IsInRole(WindowsBuiltInRole.Administrator);
        }

        public static void restartAsAdmin()
        {

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.UseShellExecute = true;
            startInfo.WorkingDirectory = Environment.CurrentDirectory;
            startInfo.FileName = Assembly.GetExecutingAssembly().Location;
            startInfo.Verb = "runas";
            try
            {
                Process p = Process.Start(startInfo);
                Process.GetCurrentProcess().Kill();
            }
            catch
            {
                Process.GetCurrentProcess().Kill();
            }


        }
    }
}
