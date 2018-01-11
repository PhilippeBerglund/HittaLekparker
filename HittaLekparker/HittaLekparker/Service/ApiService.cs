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
            if (client == null)
            {
                client = new HttpClient();
            }
        }


        public async Task<PlayGround[]> GetPlaygrounds(string name)
        {

            var req = new HttpRequestMessage
            {
                RequestUri = new Uri("http://api.stockholm.se/ServiceGuideService/ServiceUnitTypes/9da341e4-bdc6-4b51-9563-e65ddc2f7434/ServiceUnits/json?apikey=22de2696330b4c2b941c9d25ebcbc2d8&name=" + name),
                Method = HttpMethod.Get
            };

            var response = await client.SendAsync(req);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();

                var parsedData = JsonConvert.DeserializeObject<PlayGround[]>(data);
                return parsedData;
            }
            return new PlayGround[0];
        }


        public async Task<PlayGround[]> GetPlaygroundLocation(string area)
        {

            var req = new HttpRequestMessage
            {
                RequestUri = new Uri("http://api.stockholm.se/ServiceGuideService/ServiceUnitTypes/9da341e4-bdc6-4b51-9563-e65ddc2f7434/ServiceUnits/json?apikey=22de2696330b4c2b941c9d25ebcbc2d8&geographicalarea=" + area),
                Method = HttpMethod.Get
            };

            var response = await client.SendAsync(req);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();

                var parsedData = JsonConvert.DeserializeObject<PlayGround[]>(data);
                return parsedData;
            }
            return new PlayGround[0];
        }

        public async Task<RootobjectDetailedInfo> GetPlaygroundInfo(string id)
        {
            var req = new HttpRequestMessage
            {
                RequestUri = new Uri("http://api.stockholm.se/ServiceGuideService/DetailedServiceUnits/" + id + "/json?apikey=22de2696330b4c2b941c9d25ebcbc2d8"),
                Method = HttpMethod.Get
            };
            var response = await client.SendAsync(req);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();

                try
                {
                    var parsedData = JsonConvert.DeserializeObject<RootobjectDetailedInfo>(data);

                    return parsedData;

                }
                catch (Exception ex)
                {

                }
            }
            return new RootobjectDetailedInfo();
        }


}
}
