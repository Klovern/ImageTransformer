﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ImageTransformer.APIClient;
using Newtonsoft.Json.Linq;

namespace ImageTransformer
{
    class Program
    {
        static void Main(string[] args)
        {
            //FillEmotes.FillGlobalEmotesToDisk();

            List<string> channelList = new List<string>() { "dansgaming" };
            FillEmotes.FillSubscriberEmotes(channelList);
            Canvas.DrawImageFromEmotes.PrintEmoteRGBA();



            Console.ReadLine();
        }
    }
}
