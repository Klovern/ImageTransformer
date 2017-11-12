using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static MVCImageTransformer.Models.ImageTransformerModels;

namespace MVCImageTransformer.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(MVCImageTransformer.Models.ImageTransformerModels upload)
        {

            if (upload.SubscriberEmotes != null)
            {
                ImageTransformer.FillEmotes.FillSubscriberEmotes(upload.SubscriberEmotes.Split(' ').ToList());
            }

            if (upload.UseGlobalEmotes)
            {
                ImageTransformer.FillEmotes.FillGlobalEmotesToDisk();
            }


            var file = upload.image;

            if (file != null && upload.image.ContentLength > 0)
            {
                byte[] fileData = null;
                using (var binaryReader = new BinaryReader(upload.image.InputStream))
                {
                    fileData = binaryReader.ReadBytes(upload.image.ContentLength);
                }
                var bytes = ImageTransformer.Canvas.DrawImageFromEmotes.PrintEmoteRGBA(fileData);

                return File(bytes, "image/jpeg");

            }


            return null;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}