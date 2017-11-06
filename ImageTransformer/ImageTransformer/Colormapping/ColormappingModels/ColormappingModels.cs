using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageTransformer.Colormapping.ColormappingModels
{
    public class ColormappingModels
    {
        public  class EmoteMap
        {
            public  string path { get; set; }
            public  string code { get; set; }
            public  int red { get; set; }
            public  int green { get; set; }
            public  int blue { get; set; }
            public  int alpha { get; set; }
        }
    }
}
