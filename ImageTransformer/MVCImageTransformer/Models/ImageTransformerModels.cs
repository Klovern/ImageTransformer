using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCImageTransformer.Models
{
    public class ImageTransformerModels
    {
        public string SubscriberEmotes { get; set; }
        public bool UseGlobalEmotes { get; set; }
        public int ColorAccuracy { get; set; }
        public int PixelAccuracy { get; set; }
        public int Scaling { get; set; }
        public HttpPostedFileBase image { get; set; }
    }
}