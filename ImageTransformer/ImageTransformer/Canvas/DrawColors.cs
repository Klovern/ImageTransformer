using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ImageTransformer.Colormapping.ColormappingModels;

namespace ImageTransformer.Canvas
{
    public class DrawColors
    {

        public static void CreateEmoteRgbaChart(List<ColormappingModels.EmoteMap> emotesMap)
        {

            var _emoteList = emotesMap.OrderBy(x => x.red).ThenBy(x => x.green).ThenBy(x => x.blue)
                .ThenBy(x => x.alpha).ToArray();

            Bitmap bmp = new Bitmap(_emoteList.Count() * 2, 200);

            using (Graphics graph = Graphics.FromImage(bmp))
            {
                for (int n = 0; n < _emoteList.Count(); n++)
                {

                    graph.FillRectangle(new SolidBrush(Color.FromArgb(_emoteList[n].alpha, (byte)_emoteList[n].red, (byte)_emoteList[n].green, (byte)_emoteList[n].blue)), n * 2, 0, 2, 200);
                }
            }

            if (File.Exists("emote-rgba.jpeg"))
            {
                File.Delete("emote-rgba.jpeg");
            }
            bmp.Save("emote-rgba.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }
}

