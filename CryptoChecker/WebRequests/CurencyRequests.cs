using CryptoChecker.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CryptoChecker.WebRequests
{
    public static class CurencyRequests
    {
        public static List<Currency> GetCurrencies()
        {
            HttpClient client = new HttpClient();
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("http://api.coincap.io/v2/assets");
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");
            //TODO
            HttpResponseMessage response = client.Send(request);

            HttpContent responseContent = response.Content;
            var deserializedJson = JsonConvert.DeserializeObject<CurrencyListEntity>(responseContent.ReadAsStringAsync().Result);

            return deserializedJson.Data;
        }
    }
}