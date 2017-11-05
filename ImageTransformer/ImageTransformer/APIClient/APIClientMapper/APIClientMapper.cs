﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace ImageTransformer.APIClient.APIClientMapper
{
    public class APIClientMapper
    {

         public static APIClientModels.FetchGlobalEmotesIdModel MapAPIClientIdJson(string data)
        {

            List<APIClientModels.FetchGlobalEmotesIdModel> list = new List<APIClientModels.FetchGlobalEmotesIdModel>();
       
            var o = JObject.Parse(data);

            foreach (JToken child in o.Children())
            {
                foreach (JToken grandChild in child)
                {
                    var tmp = new APIClientModels.FetchGlobalEmotesIdModel();

                    foreach (JToken grandGrandChild in grandChild)
                    {
                        var property = grandGrandChild as JProperty;

                        if (property != null && property.Name == "id")
                        {
                            
                        }
                    }
                }
            }   
            return null;
        }

    }
}