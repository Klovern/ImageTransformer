using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ImageTransformer.Colormapping
{
    public static class Colormapping
    {
       
        static List<ColormappingModels.ColormappingModels.GlobalEmotesMap> emoteList = new List<ColormappingModels.ColormappingModels.GlobalEmotesMap>();

        public static List<ColormappingModels.ColormappingModels.GlobalEmotesMap> GetEmoteList()
        {
            return emoteList;
        }
        public static void MapEmotesToColor(string path, string code)
        {
            ColormappingModels.ColormappingModels.GlobalEmotesMap tmp = new ColormappingModels.ColormappingModels.GlobalEmotesMap();
            Bitmap bmp = new Bitmap(1, 1);
            Bitmap orig = (Bitmap) Bitmap.FromFile(path);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                // updated: the Interpolation mode needs to be set to 
                // HighQualityBilinear or HighQualityBicubic or this method
                // doesn't work at all.  With either setting, the results are
                // slightly different from the averaging method.
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(orig, new Rectangle(0, 0, 1, 1));
            }
            Color pixel = bmp.GetPixel(0, 0);
            // pixel will contain average values for entire orig Bitmap
            tmp.path = path;
            tmp.code = code;
            tmp.red = pixel.R;
            tmp.green = pixel.G;
            tmp.blue = pixel.B;
            tmp.apacity = pixel.A;
            emoteList.Add(tmp);
        }

    }
}
