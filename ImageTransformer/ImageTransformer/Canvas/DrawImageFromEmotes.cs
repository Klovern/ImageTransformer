﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using System.IO;

namespace ImageTransformer.Canvas
{
    public static class DrawImageFromEmotes
    {
        // Testversion

        public static byte[] PrintEmoteRGBA(byte[] image)
        {

            string imageUrl = "C:\\Users\\s4d\\Documents\\GitHub\\ImageTransformer\\ImageTransformer\\ImageTransformer\\ImageTransformer\\Media";
            //Deploymentcode 
            /*string imageUrl = $"{System.IO.Directory.GetCurrentDirectory()}\\Media\\tmp2.jpg";
            string directory = $"{System.IO.Directory.GetCurrentDirectory()}\\Media";

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }*/

            System.IO.File.WriteAllBytes(imageUrl, image);
            var emotes = Colormapping.Colormapping.GetEmoteList();

           
            string output = "image.jpg";
            Bitmap bmp = new Bitmap(imageUrl);
            int sizeOperator = 2;
            int colorAccuracy = 10;
            int width = bmp.Width * sizeOperator;
            int height = bmp.Height * sizeOperator;
            int accuracy = 14;
            Bitmap bmpBlank = new Bitmap(width, height);
            // Lock the bitmap's bits.  
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;

            

            // Declare an array to hold the bytes of the bitmap.
            int bytes = bmpData.Stride * bmp.Height;
            byte[] rgbValues = new byte[bytes];
            byte[] r = new byte[bytes / 3];
            byte[] g = new byte[bytes / 3];
            byte[] b = new byte[bytes / 3];

            // Copy the RGB values into the array.
            Marshal.Copy(ptr, rgbValues, 0, bytes);

            int count = 0;
            int stride = bmpData.Stride;

            for (int column = 0; column < bmpData.Height; column += accuracy)
            {
                for (int row = 0; row < bmpData.Width; row += accuracy)
                {

                    var blue = (byte)(rgbValues[(column * stride) + (row * 3)]);
                    var green = (byte)(rgbValues[(column * stride) + (row * 3) + 1]);
                    var red = (byte)(rgbValues[(column * stride) + (row * 3) + 2]);

                    var tmp = new Colormapping.ColormappingModels.ColormappingModels.EmoteMap();
                    for (int i = 1; i < 25; i++)
                    {
                        if (tmp.code != null)
                        {
                            break;
                        }

                        tmp = (Colormapping.ColormappingModels.ColormappingModels.EmoteMap)emotes.Where(x => x.red > red - i * colorAccuracy && x.red < red + i * colorAccuracy).
                            Where(x => x.green > green - i * colorAccuracy && x.green < green + i * colorAccuracy).Where(x => x.blue > blue - i * colorAccuracy && x.blue < blue + i * colorAccuracy).DefaultIfEmpty().First(); ;


                        // Ugly fix
                        if (tmp == null)
                        {
                            tmp = new Colormapping.ColormappingModels.ColormappingModels.EmoteMap();
                        }
                    }

                    Image emote = Image.FromFile(tmp.path);

                    using (Graphics graphicss = Graphics.FromImage(bmpBlank))
                    {
                        graphicss.DrawImage(emote, row * sizeOperator, column * sizeOperator, accuracy * sizeOperator, accuracy * sizeOperator);
                    }

                    emote = null;

                    


                }

                GC.Collect();

            }

            string outputpath = $"C:\\Users\\s4d\\Documents\\GitHub\\ImageTransformer\\ImageTransformer\\ImageTransformer\\ImageTransformer\\Media\\{output}";

            bmpBlank.Save(outputpath, System.Drawing.Imaging.ImageFormat.Jpeg);

            return File.ReadAllBytes(outputpath);
     
        }
    }
}
