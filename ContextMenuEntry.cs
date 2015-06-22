using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Reflection;
using System.Security.Principal;
using System.Diagnostics;

namespace PictureResize
{
    public static class ContextMenuEntry
    {
        private const string _MenuName = "\\shell\\ResizePicture_CONTEXTMENU";
        private const string _Command = "\\shell\\ResizePicture_CONTEXTMENU\\command";

        private static string[] fileTypes = new string[] { "jpegfile", "pngfile", "giffile" };

        public static void activate(Language language)
        {
            foreach (string fileType in fileTypes)
            {
                RegistryKey regmenu = null;
                RegistryKey regcmd = null;
                try
                {
                    regmenu = Registry.ClassesRoot.CreateSubKey(fileType + _MenuName);
                    if (regmenu != null)
                        regmenu.SetValue("", language.RESIZE_IMAGE);
                    regcmd = Registry.ClassesRoot.CreateSubKey(fileType + _Command);
                    if (regcmd != null)
                        regcmd.SetValue("", System.Reflection.Assembly.GetEntryAssembly().Location + " %1");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.Source);
                }
                finally
                {
                    if (regmenu != null)
                        regmenu.Close();
                    if (regcmd != null)
                        regcmd.Close();
                }
            }
        }

        public static void deactivate()
        {
            foreach (string fileType in fileTypes)
            {
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
                    MessageBox.Show(ex.Message, ex.Source);
                }
            }
        }

        public static void reset(Language language)
        {
            deactivate();
            activate(language);
        }

        public static bool IsAdmin()
        {
            WindowsIdentity id = WindowsIdentity.GetCurrent();
            WindowsPrincipal p = new WindowsPrincipal(id);
            return p.IsInRole(WindowsBuiltInRole.Administrator);
        }

        public static void restartAsAdmin(string args = "")
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.UseShellExecute = true;
            startInfo.WorkingDirectory = Environment.CurrentDirectory;
            startInfo.FileName = Assembly.GetExecutingAssembly().Location;
            startInfo.Arguments = args;
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