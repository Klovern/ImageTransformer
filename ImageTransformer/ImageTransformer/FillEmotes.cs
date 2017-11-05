using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                FileStreams.FileStreams.WriteToDisk(binary, path, emote.code, "png");
            }


        }
    }
}
