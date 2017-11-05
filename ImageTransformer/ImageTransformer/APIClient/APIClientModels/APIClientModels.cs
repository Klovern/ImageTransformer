using System.Collections.Generic;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;

namespace ImageTransformer.APIClient
{
    public class APIClientModels
    {

        public class FetchGlobalEmotesIdModel
        {
            public int id { get; set; }

            public string code { get; set; }

            public int? emoticon_set { get; set; }

            public string description { get; set; }

        }

        public class FetchGlobalEmotesIdsModelData
        {
            public int id { get; set; }

            public string code { get; set; }

            public int? emoticon_set { get; set; }

            public string description { get; set; }

        }
    }
}