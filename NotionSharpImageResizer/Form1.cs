using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageProcessor;
using ImageProcessor.Imaging;
using ImageProcessor.Imaging.Formats;
using System.IO;
using System.Threading;
using NotionSharpImageResizer;

namespace NotionSharpImageResizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);
        }

        void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        void Form1_DragDrop(object sender, DragEventArgs e)
        {

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            
            foreach (String file in files)
            {
                Console.WriteLine(file);
                try
                {
                    ImageProcessing.Process(file);
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BrowseMultipleButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter =
            "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.GIF;*.JPG;*.JPEG;*.PNG;*.TIFF|" +
            "All files (*.*)|*.*";

            openFileDialog1.Multiselect = true;
            openFileDialog1.Title = "Select Images";

            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                foreach (String file in openFileDialog1.FileNames)
                {
                    Console.WriteLine(file);
                    try
                    {
                        ImageProcessing.Process(file);
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }

                }
            }
        }

        public bool ThumbnailCallback()
        {
            return false;
        }


        private void Convert_Click(object sender, EventArgs e)
        {

        }
    }
}
