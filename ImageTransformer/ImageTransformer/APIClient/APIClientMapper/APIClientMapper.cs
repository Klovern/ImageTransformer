using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace ImageTransformer.APIClient.APIClientMapper
{
    public static class APIClientMapper
    {
        static List<APIClientModels.FetchGlobalEmotesIdModel> list = new List<APIClientModels.FetchGlobalEmotesIdModel>();

        public static List<APIClientModels.FetchGlobalEmotesIdModel> MapAPIClientIdJson(string data)
        {


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
                            tmp.id = (int)property.Value;
                        }
                        if (property != null && property.Name == "code")
                        {
                            tmp.code = (string)property.Value;
                        }
                        if (property != null && property.Name == "emoticon_set")
                        {
                            tmp.emoticon_set = (int?)property.Value;
                        }
                        if (property != null && property.Name == "description")
                        {
                            tmp.description = (string)property.Value;
                        }

                    }
                    list.Add(tmp);
                }
            }
            return list;
        }

        public static List<APIClientModels.FetchGlobalEmotesIdModel> MapAPISubscriberIdFromJson(string data, List<string> channelNames)
        {

            var o = JObject.Parse(data);

            foreach (JToken child in o.Children())
            {

                foreach (JToken grandChild in child)
                {
                    

                    if (channelNames.Contains(grandChild["channel_name"].ToString()))
                    {
                         foreach(var emote in grandChild["emotes"])
                        {
                            var tmp = new APIClientModels.FetchGlobalEmotesIdModel();

                            tmp.id = (int)emote["id"];
                            tmp.code = emote["code"].ToString();                         
                            tmp.emoticon_set = (int)emote["emoticon_set"];

                            list.Add(tmp);
                            tmp = null;
                            Console.WriteLine(emote);
                        }
                    }

                }
            }

            return list;
        }
    }
}
