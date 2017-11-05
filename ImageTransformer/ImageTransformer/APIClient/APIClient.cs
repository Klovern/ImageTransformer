using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
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
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            this.client.DefaultRequestHeaders.Add("User-Agent", "ImageTransformer .NET");
        }


        public async Task<string> FetchGlobalEmotes()
        {
            string path = "https://api.twitch.tv/kraken/chat/emoticon_images";
            return await this.client.GetStringAsync(path);
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
        public async Task<APIClientModels.FetchGlobalEmotesIdModel> FetchGlobalEmotesIds()
        {
            string path = "https://twitchemotes.com/api_cache/v3/global.json";
            string data = await this.client.GetStringAsync(path);

            APIClientModels.FetchGlobalEmotesIdModel _MappedData = APIClientMapper.APIClientMapper.MapAPIClientIdJson(data);

            return _MappedData;
        }
    }
}
