using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageProcessor;
using ImageProcessor.Imaging;
using ImageProcessor.Imaging.Formats;
using System.Drawing;
using System.IO;

namespace NotionSharpImageResizer
{
    public static class ImageProcessing
    {
        public static void Process(String file)
        {
            string fileBaseName = Path.GetFileName(file);
            string tempFolderNotionSharpImageResizer = (Path.GetTempPath() + "NotionSharpImageResizer");
            System.IO.Directory.CreateDirectory(tempFolderNotionSharpImageResizer);
            tempFolderNotionSharpImageResizer = (tempFolderNotionSharpImageResizer + "\\");

            string file2 = (tempFolderNotionSharpImageResizer + fileBaseName + "_temp.jpg");
            string file3 = (file + "_NotionSharpImageResizer.jpg");

            byte[] photoBytes = File.ReadAllBytes(file);

            // Format is automatically detected though can be changed.
            ISupportedImageFormat format = new JpegFormat { Quality = 90 };
            Size sizeX = new Size(654, 0);
            Size sizeY = new Size(0, 368);
            Size sizeFinal = new Size(654, 368);

            ResizeMode resizeMode = ResizeMode.Max;
            AnchorPosition anchorPosition = AnchorPosition.Top;

            ResizeLayer resizelayer = new ResizeLayer(sizeX, resizeMode, anchorPosition);


            using (MemoryStream inStream = new MemoryStream(photoBytes))
            {
                using (MemoryStream outStream = new MemoryStream())
                {
                    // Initialize the ImageFactory using the overload to preserve EXIF metadata.
                    using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
                    {

                        // Load, resize, set the format and quality and save an image.
                        imageFactory.Load(inStream)
                                    .Format(format)
                                    .Resize(resizelayer)
                                    .Save(outStream);

                        imageFactory.Save(file2);

                    }
                    outStream.Close();
                }
                inStream.Close();
            }


            byte[] photoBytes2 = File.ReadAllBytes(file2);

            System.Drawing.Image img = System.Drawing.Image.FromFile(file2);
            Rectangle rectangle = new Rectangle(0, (img.Height / 4), 654, 368);
            ImageLayer imageLayer = new ImageLayer();
            imageLayer.Image = System.Drawing.Image.FromFile(file);
            imageLayer.Size = new Size(0, 368);
            imageLayer.Opacity = 100;

            ImageProcessor.Imaging.GaussianLayer gauLay = new ImageProcessor.Imaging.GaussianLayer();
            gauLay.Sigma = 5;
            gauLay.Threshold = 5;
            gauLay.Size = 20;

            using (MemoryStream inStream = new MemoryStream(photoBytes2))
            {
                using (MemoryStream outStream = new MemoryStream())
                {
                    // Initialize the ImageFactory using the overload to preserve EXIF metadata.
                    using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
                    {

                        // Load, resize, set the format and quality and save an image.
                        imageFactory.Load(inStream)
                                    .Format(format)
                                    .Crop(rectangle)
                                    .GaussianBlur(gauLay)
                                    .Overlay(imageLayer)
                                    .Save(outStream);
                        imageFactory.Save(file3);
                    }
                    outStream.Close();
                }
                inStream.Close();
            }
        }
    }

    public static class DeleteTempFiles
    {
        public static void deleteFiles()
        {
            string tempFolderNotionSharpImageResizer = (Path.GetTempPath() + "NotionSharpImageResizer");
            System.IO.DirectoryInfo directoryInfo = new DirectoryInfo(tempFolderNotionSharpImageResizer);

            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                file.Delete(); 
            }

            Directory.Delete(tempFolderNotionSharpImageResizer, true);
        }

        public static void deleteFolder()
        {
            string tempFolderNotionSharpImageResizer = (Path.GetTempPath() + "NotionSharpImageResizer");
            Directory.Delete(tempFolderNotionSharpImageResizer, true);
             
        }

    }


    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                DeleteTempFiles.deleteFolder();
            }
            catch
            {
                //do nothing
            }

            Application.Run(new Form1());

            try
            {
                System.Threading.Thread.Sleep(5000);
                DeleteTempFiles.deleteFiles();
            }
            catch
            {
                //do nothing
            }



        }
    }
}
