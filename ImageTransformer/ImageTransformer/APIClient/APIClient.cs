using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ImageTransformer.APIClient.APIClientMapper;

namespace ImageTransformer.APIClient
{
    class APIClient
    {
        public HttpClient client = new HttpClient();

        public APIClient()
        {
            this.client = new HttpClient();
            this.client.DefaultRequestHeaders.Accept.Clear();
            this.client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.twitchtv.v5+json"));
            this.client.DefaultRequestHeaders.Add("User-Agent", "ImageTransformer .NET");
        }


        public async Task<string> FetchGlobalEmotes()
        {
            string path = string.Format("https://api.twitch.tv/kraken/chat/emoticons", Config.TwitchAuth.ClientId , 0);
            string emotes = await this.client.GetStringAsync(path);
            Console.WriteLine();
            return emotes;
        }

        public async Task<string> FetchSpecificEmoteFromID(int id, double size)
        {
            string path = string.Format("http://static-cdn.jtvnw.net/emoticons/v1/{0}/{1}", id, size);
            string emotes = await this.client.GetStringAsync(path);
            return emotes;
        }


        public async Task<byte[]> FetchEmoteByteData(int id, double size)
        {
            string path = string.Format("http://static-cdn.jtvnw.net/emoticons/v1/{0}/{1}.0", id, size);
            byte[] emotes = await this.client.GetByteArrayAsync(path);
            return emotes;
        }

        public async Task<string> FetchSubscriberEmoteIDs(int channelId)
        {
            string path = string.Format("https://api.twitch.tv/kraken/chat/emoticons", Config.TwitchAuth.ClientId, 0);
            string emotes = await this.client.GetStringAsync(path);
            return emotes;
        }

        public async Task<List<APIClientModels.FetchGlobalEmotesIdModel>> FetchChannelIdFromString(List<string> channelNames)
        {          
            string path = string.Format("https://twitchemotes.com/api_cache/v3/subscriber.json", Config.TwitchAuth.ClientId, 0);

            string subscriberJson = await this.client.GetStringAsync(path);

            var result = APIClientMapper.APIClientMapper.MapAPISubscriberIdFromJson(subscriberJson, channelNames);

            return result;
        }

        public async Task<string> FetchSubscriberEmotesFromId(List<APIClientModels.FetchSubscriberIds> channelIds)
        {
            string path = string.Format("https://api.twitch.tv/kraken/chat/emoticons", Config.TwitchAuth.ClientId, 0);
            string emotes = await this.client.GetStringAsync(path);
            return emotes;
        }




        /*     Example of request          
        {
            "VaultBoy": {
                "id": 206490,
                "code": "VaultBoy",
                "emoticon_set": 0,
                "description": null
            },
            "QuadDamage": {
                "id": 206494,
                "code": "QuadDamage",
                "emoticon_set": 0,
                "description": null
            }
        }
        */
        public async Task<List<APIClientModels.FetchGlobalEmotesIdModel>> FetchGlobalEmotesIds()
        {
            string path = "https://twitchemotes.com/api_cache/v3/global.json";
            string data = await this.client.GetStringAsync(path);

            List<APIClientModels.FetchGlobalEmotesIdModel> _MappedData = APIClientMapper.APIClientMapper.MapAPIClientIdJson(data);

            return _MappedData;
        }
    }
}
