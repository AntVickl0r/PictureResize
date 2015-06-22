using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace PictureResize
{
    public partial class Form_resize : Form
    {
        private Language _language = null;
        private List<Language> _languages = null;
        private string _path = "";
        private FileInfo _fileInfo = null;
        private int _width_org = 0;
        private int _height_org = 0;
        private Image _image = null;
        private Image _newImage = null;
        private long _newFileSize = 0;
        private string _mimeType = "";

        private void Form_resize_Load(object sender, EventArgs e)
        {
            if (!File.Exists(_path))
            {
                //should never happen
                MessageBox.Show("File not found", "Error");
                Process.GetCurrentProcess().Kill();
            }

            try
            {
                _image = Image.FromFile(_path);
                _mimeType = getMimeType(_image);
                pictureBox_main.BackgroundImage = _image;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }

            _width_org = pictureBox_main.BackgroundImage.Width;
            _height_org = pictureBox_main.BackgroundImage.Height;

            translateWords(_language);

        }

        private void Form_resize_FormClosed(object sender, FormClosedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            string newName = _fileInfo.Name;

            DialogResult result = MessageBox.Show(_language.REALLY_OVERWRITE + Environment.NewLine + "(" + _fileInfo.Name + ")", _language.WARNING, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.No)
            {
                newName = _fileInfo.Name.Substring(0, _fileInfo.Name.Length - _fileInfo.Extension.Length)
                    + "_" + numericUpDown_width.Value.ToString() + "x" + numericUpDown_height.Value.ToString()
                    + _fileInfo.Extension;
                result = MessageBox.Show(_language.AUTO_RENAME + Environment.NewLine
                    + "(" + newName + ")", _language.RENAME, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    return;
                }
            }

            try
            {
                Image newImage = resizeImage(_image, new Size((int)numericUpDown_width.Value, (int)numericUpDown_height.Value));
                _image.Dispose();
                switch (_mimeType)
                {
                    case "image/png":
                        newImage.Save(_fileInfo.DirectoryName + "\\" + newName, ImageFormat.Png);
                        break;
                    case "image/gif":
                        newImage.Save(_fileInfo.DirectoryName + "\\" + newName, ImageFormat.Gif);
                        break;
                    case "image/jpeg":
                    default:
                        newImage.Save(_fileInfo.DirectoryName + "\\" + newName, ImageFormat.Jpeg);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
            finally
            {
                Process.GetCurrentProcess().Kill();
            }
        }

        private void button_saveAs_Click(object sender, EventArgs e)
        {
            saveFileDialog_main.Filter = "JPEG (*.jpeg,*.jpg)|*.jpeg;*jpg;|PNG (*.png)|*.png;|GIF (*.gif)|*.gif;";
            DialogResult result = saveFileDialog_main.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    Image newImage = resizeImage(_image, new Size((int)numericUpDown_width.Value, (int)numericUpDown_height.Value));
                    _image.Dispose();

                    switch (saveFileDialog_main.FilterIndex)
                    {
                        case 1:
                            //case "image/jpeg":
                            newImage.Save(saveFileDialog_main.FileName, ImageFormat.Jpeg);
                            break;
                        case 2:
                            //case "image/png":
                            newImage.Save(saveFileDialog_main.FileName, ImageFormat.Png);
                            break;
                        case 3:
                            //case "image/gif":
                            newImage.Save(saveFileDialog_main.FileName, ImageFormat.Gif);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.Source);
                }
                finally
                {
                    Process.GetCurrentProcess().Kill();
                }
            }
        }

        private long calcNewFileSize(Image image)
        {
            long fileSize;
            using (MemoryStream ms = new MemoryStream())
            {
                switch (_mimeType)
                {
                    case "image/png":
                        image.Save(ms, ImageFormat.Png); // save image to stream in PNG format
                        break;
                    case "image/gif":
                        image.Save(ms, ImageFormat.Gif); // save image to stream in GIF format
                        break;
                    case "image/jpeg":
                    default:
                        image.Save(ms, ImageFormat.Jpeg); // save image to stream in Jpeg format
                        break;
                }
                fileSize = ms.Length;
            }
            return fileSize;
        }

        private void writeDownNewFileSize()
        {
            try
            {
                //if (numericUpDown_width.Value >= 2 && numericUpDown_height.Value >= 2)
                //{
                _newImage = resizeImage(_image, new Size((int)numericUpDown_width.Value, (int)numericUpDown_height.Value));
                _newFileSize = calcNewFileSize(_newImage);
                textBox_fileSize.Text = SizeSuffix(_newFileSize);
                //}
            }
            catch
            {
                textBox_fileSize.Text = "error";
            }
        }

        private void numericUpDown_width_ValueChanged(object sender, EventArgs e)
        {
            decimal factor = numericUpDown_width.Value / (decimal)_width_org;
            numericUpDown_height.Value = _height_org * factor;
            writeDownNewFileSize();
        }

        private void numericUpDown_width_KeyUp(object sender, KeyEventArgs e)
        {
            numericUpDown_width_ValueChanged(sender, null);
        }

        private void numericUpDown_height_ValueChanged(object sender, EventArgs e)
        {
            decimal factor = numericUpDown_height.Value / (decimal)_height_org;
            numericUpDown_width.Value = _width_org * factor;
            writeDownNewFileSize();
        }

        private void numericUpDown_height_KeyUp(object sender, KeyEventArgs e)
        {
            numericUpDown_height_ValueChanged(sender, null);
        }

        private Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        private string getMimeType(Image image)
        {
            ImageFormat format = _image.RawFormat;
            ImageCodecInfo codec = ImageCodecInfo.GetImageDecoders().First(c => c.FormatID == format.Guid);
            return codec.MimeType;
        }

        private readonly string[] SizeSuffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
        private string SizeSuffix(Int64 value)
        {
            if (value < 0) { return "-" + SizeSuffix(-value); }
            if (value == 0) { return "0.0 bytes"; }

            int mag = (int)Math.Log(value, 1024);
            decimal adjustedSize = (decimal)value / (1L << (mag * 10));

            return string.Format("{0:n1} {1}", adjustedSize, SizeSuffixes[mag]);
        }

        private void setLanguage(Language language)
        {
            if (!ContextMenuEntry.IsAdmin())
            {
                this.Hide();
                ContextMenuEntry.restartAsAdmin(_path + " " + language.LANGUAGE_NAME);
            }
            else
            {
                _language = language;
                Properties.Settings.Default["language"] = language.LANGUAGE_FILENAME;
                Properties.Settings.Default.Save();
                translateWords(language);
                ContextMenuEntry.reset(language);
                //TODO add second argument to form_main to give chosen language to restarted instance
                //TODO maybe add 'download new languages' button
            }
        }

        private void translateWords(Language language)
        {
            textBox_info.Text = _mimeType +
                Environment.NewLine + language.WIDTH + ": " + _width_org + " px" +
                Environment.NewLine + language.HEIGHT + ": " + _height_org + " px" +
                Environment.NewLine + language.FILESIZE + ": " + SizeSuffix(_fileInfo.Length);

            languageToolStripMenuItem.Text = language.LANGUAGE;

            label_fileSize.Text = language.FILESIZE;
            textBox_fileSize.Text = SizeSuffix(_fileInfo.Length);

            label_width.Text = language.WIDTH;
            label_height.Text = language.HEIGHT;

            numericUpDown_width.Text = _width_org.ToString();
            numericUpDown_height.Text = _height_org.ToString();

            button_save.Text = language.SAVE;
            button_saveAs.Text = language.SAVE_AS;
        }

        private void selectLanguage(object sender, EventArgs e)
        {
            ToolStripItem item = sender as ToolStripItem;

            foreach (Language language in _languages)
            {
                if (language.LANGUAGE_NAME == item.Text)
                {
                    setLanguage(language);
                    break;
                }
            }
        }

        //--- PUBLIC ---//

        public Form_resize(string path, Language language, string langForRestart = "")
        {
            InitializeComponent();
            _language = language;
            _languages = new List<Language>();

            try
            {
                string[] langFilePaths = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "\\lang\\");
                Language tempLang = null;
                ToolStripItem item = null;
                if (langFilePaths.Length == 0)
                {
                    Language.SerializeToXML(tempLang, AppDomain.CurrentDomain.BaseDirectory + "\\lang\\EN.xml");
                    langFilePaths = new string[] { AppDomain.CurrentDomain.BaseDirectory + "\\lang\\EN.xml" };
                }
                foreach (string langFilePath in langFilePaths)
                {
                    tempLang = Language.DeserializeFromXML(langFilePath);
                    _languages.Add(tempLang);
                    item = new ToolStripMenuItem();
                    item.Text = tempLang.LANGUAGE_NAME;
                    //TODO check for duplicate language_name
                    item.Name = tempLang.LANGUAGE_NAME + "ToolStripMenuItem";
                    item.Click += new EventHandler(selectLanguage);
                    languageToolStripMenuItem.DropDownItems.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }

            this._path = path;
            _fileInfo = new FileInfo(_path);
            saveFileDialog_main.InitialDirectory = _fileInfo.DirectoryName;
            saveFileDialog_main.FileName = _fileInfo.Name;

            foreach (ToolStripItem item in languageToolStripMenuItem.DropDownItems)
            {
                if (item.Text == langForRestart)
                {
                    selectLanguage(item, null);
                }
            }
        }
    }
}
