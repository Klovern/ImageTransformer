using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace ImageTransformer.Canvas
{
    public static class DrawImageFromEmotes
    {
        // Testversion

        public static void PrintEmoteRGBA()
        {
            var emotes = Colormapping.Colormapping.GetEmoteList();

            string imageUrl = "C:\\Users\\s4d\\Documents\\GitHub\\ImageTransformer\\ImageTransformer\\ImageTransformer\\ImageTransformer\\Media\\Donald2.jpg";
            string output = "DonaldTrump.jpg";
            Bitmap bmp = new Bitmap(imageUrl);
            Bitmap bmp2 = new Bitmap(imageUrl);
            // Lock the bitmap's bits.  
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;

            int accuracy = 10;
            float sizeOperator = 1 ;
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
                    Console.WriteLine($"COLUMN {column} ROW {row}");
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

                        tmp = (Colormapping.ColormappingModels.ColormappingModels.EmoteMap)emotes.Where(x => x.red > red - i * 10 && x.red < red + i * 10).
                            Where(x => x.green > green - i * 10 && x.green < green + i * 10).Where(x => x.blue > blue - i * 10 && x.blue < blue + i * 10).DefaultIfEmpty().First(); ;
                       

                        // Ugly fix
                        if(tmp == null)
                        {
                            tmp = new Colormapping.ColormappingModels.ColormappingModels.EmoteMap();
                        }
                    }

                    Image emote = Image.FromFile(tmp.path);
                    
                    using (Graphics graphicss = Graphics.FromImage(bmp2))
                    {
                        graphicss.DrawImage(emote, row, column, accuracy * sizeOperator, accuracy* sizeOperator);
                    }
                   // Console.WriteLine(tmp.code);
                    
                }
                
            }

            bmp2.Save(output, System.Drawing.Imaging.ImageFormat.Jpeg);
            Console.WriteLine("Saved");
        }
    }
}
