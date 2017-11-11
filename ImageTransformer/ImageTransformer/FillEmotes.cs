using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ImageTransformer
{
    public static class FillEmotes
    {

        public static void FillGlobalEmotesToDisk()
        {
            string path =
                "C:\\Users\\s4d\\Documents\\GitHub\\ImageTransformer\\ImageTransformer\\ImageTransformer\\ImageTransformer\\Emotes\\Global";
            var APIClient = new APIClient.APIClient();
            var result = Task.Run(async () => { return await APIClient.FetchGlobalEmotesIds(); }).Result;

            foreach (var emote in result)
            {
                var binary = Task.Run(async () => { return await APIClient.FetchEmoteByteData(emote.id, 1.0); }).Result;

                var _path = FileStreams.FileStreams.WriteToDisk(binary, path, emote.code, "png");

                Colormapping.Colormapping.MapEmotesToColor(_path, emote.code);
            }

            Canvas.DrawColors.CreateEmoteRgbaChart(Colormapping.Colormapping.GetEmoteList());

        

        }

        public static void FillSubscriberEmotes(List<string> channelNames)
        {
            string path =
                "C:\\Users\\s4d\\Documents\\GitHub\\ImageTransformer\\ImageTransformer\\ImageTransformer\\ImageTransformer\\Emotes\\Global";
            var APIClient = new APIClient.APIClient();

           
         
            var result = Task.Run(async () => { return await APIClient.FetchChannelIdFromString(channelNames); }).Result;


            foreach (var emote in result)
            {
                var binary = Task.Run(async () => { return await APIClient.FetchEmoteByteData(emote.id, 1.0); }).Result;

                var _path = FileStreams.FileStreams.WriteToDisk(binary, path, emote.code, "png");

                Colormapping.Colormapping.MapEmotesToColor(_path, emote.code);
            }

            Canvas.DrawColors.CreateEmoteRgbaChart(Colormapping.Colormapping.GetEmoteList());

            /*
                        foreach (var emote in result)
                        {
                            var binary = Task.Run(async () => { return await APIClient.FetchEmoteByteData(emote.id, 1.0); }).Result;

                            var _path = FileStreams.FileStreams.WriteToDisk(binary, path, emote.code, "png");

                            Colormapping.Colormapping.MapEmotesToColor(_path, emote.code);
                        }

                        
                        */


        }

    }
}
