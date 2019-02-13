using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace tomticket_api
{
    public static class HttpHandler
    {
        private static readonly HttpClient http = new HttpClient();

        public static JObject PostResponse(MultipartFormDataContent content, string endpoint)
        {
            var response = http.PostAsync(endpoint, content);
            return JObject.Parse(response.Result.Content.ReadAsStringAsync().Result);
        }

        public static JObject GetResponse(string endpoint)
        {
            var response = http.GetAsync(endpoint);
            var result = JObject.Parse(response.Result.Content.ReadAsStringAsync().Result);

            return result;
        }

        public static MultipartFormDataContent BuildMultiPartForm(params MultipartFormItem[] items)
        {
            MultipartFormDataContent data = new MultipartFormDataContent();
            foreach (var item in items)
            {
                data.Add(item.Content, item.Name);
            }

            return data;
        }
    }
}
