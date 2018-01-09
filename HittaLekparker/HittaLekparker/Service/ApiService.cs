using HittaLekparker.Service;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


[assembly: Dependency(typeof(ApiService))]
namespace HittaLekparker.Service
{
   public class ApiService
    {
        HttpClient client;

        public ApiService()
        {
            if(client == null)
            {
                client = new HttpClient();
            }
        }


        public async Task<PlayGround[]> GetPlaygrounds(string text)
        {

            var req = new HttpRequestMessage
            {
                RequestUri = new Uri("http://api.stockholm.se/ServiceGuideService/ServiceUnitTypes/9da341e4-bdc6-4b51-9563-e65ddc2f7434/ServiceUnits/json?apikey=22de2696330b4c2b941c9d25ebcbc2d8&name=" + text),
                Method = HttpMethod.Get
            };

            var response = await client.SendAsync(req);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();

                var parsedData = JsonConvert.DeserializeObject<PlayGround[]>(data);

                //if (parsedData.Length < 1)
                //{
                //    return new PlayGround[] { new PlayGround { Name = "Lekparken finns inte.." } };
                //}
                return parsedData;
            }
            return new PlayGround[0];
        }
       
    }
}
