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
        private string _path = "";
        private FileInfo _fileInfo = null;
        private int _width_org = 0;
        private int _height_org = 0;
        private Image _image = null;
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

            textBox_info.Text = Language.WIDTH + ": " + _width_org + " px" +
                Environment.NewLine + Language.HEIGHT + ": " + _height_org + " px";

            label_width.Text = Language.WIDTH;
            label_height.Text = Language.HEIGHT;

            numericUpDown_width.Text = _width_org.ToString();
            numericUpDown_height.Text = _height_org.ToString();

            button_save.Text = Language.SAVE;
            button_saveAs.Text = Language.SAVE_AS;
        }

        private void Form_resize_FormClosed(object sender, FormClosedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            try
            {
                Image newImage = resizeImage(_image, new Size((int)numericUpDown_width.Value, (int)numericUpDown_height.Value));
                _image.Dispose();
                newImage.Save(_path);
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
            string filter = "";
            switch (getMimeType(_image))
            {
                case "image/jpeg":
                    filter = "JPEG (*.jpeg,*.jpg)|*.jpeg;*jpg;";
                    break;
                case "image/png":
                    filter = "PNG (*.png)|*.png;";
                    break;
                case "image/gif":
                    filter = "GIF (*.gif)|*.gif;";
                    break;
                default:
                    filter = Language.ALL_FILES + " (*.*)|*.*";
                    break;
            }
            saveFileDialog_main.Filter = filter;
            DialogResult result = saveFileDialog_main.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    Image newImage = resizeImage(_image, new Size((int)numericUpDown_width.Value, (int)numericUpDown_height.Value));
                    _image.Dispose();
                    MessageBox.Show(getMimeType(_image));
                    newImage.Save(saveFileDialog_main.FileName);
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

        private void numericUpDown_width_ValueChanged(object sender, EventArgs e)
        {
            decimal factor = numericUpDown_width.Value / (decimal)_width_org;
            numericUpDown_height.Value = _height_org * factor;
        }

        private void numericUpDown_width_KeyUp(object sender, KeyEventArgs e)
        {
            numericUpDown_width_ValueChanged(sender, null);
        }

        private void numericUpDown_height_ValueChanged(object sender, EventArgs e)
        {
            decimal factor = numericUpDown_height.Value / (decimal)_height_org;
            numericUpDown_width.Value = _width_org * factor;
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

        //--- PUBLIC ---//

        public Form_resize(string path)
        {
            InitializeComponent();
            this._path = path;
            _fileInfo = new FileInfo(_path);
            saveFileDialog_main.InitialDirectory = _fileInfo.DirectoryName;
            saveFileDialog_main.FileName = _fileInfo.Name;
        }
    }
}
