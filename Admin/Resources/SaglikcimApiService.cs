using Data.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Web.Resources
{
    public class SaglikcimApiService 
    {
        public  HttpClient Client = new HttpClient() { 
            Timeout = new TimeSpan(0, 0, 360),
            BaseAddress = new Uri("https://localhost:44318/api/")
        };
        public string  token = "";
        public SaglikcimApiService()
        {
            Client.Timeout = new TimeSpan(0, 0, 360);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.BaseAddress = new Uri("https://localhost:44318/api/");
            var tokensjson = RequestPost<object>("Login/Login", new { eposta = "default@saglikcim.com", password = "214akdaawd351-*52" });
            var gettoken = JsonConvert.DeserializeObject<IDictionary<string, string>>(tokensjson.ToString());
            if (gettoken["title"] != "Unauthorized")
            {
               token = gettoken["token"];
               Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            }
        }
        public T RequestGet<T>(string path) where T : class
        {
            HttpResponseMessage response = Client.GetAsync(path).Result;
            var responseString = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(responseString);
        }
        public T RequestPost<T>(string path, object values = null) where T : class
        {
            try
            {
                string json = JsonConvert.SerializeObject(values, Formatting.Indented);
                var buffer = System.Text.Encoding.UTF8.GetBytes(json);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpResponseMessage response = Client.PostAsync(path, byteContent).Result;
                var responseString = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(responseString);
            }
            catch (Exception ex)
            {
                return null;
            }
         
        }
    }
  
}
