using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Discord.Ceira.Entities
{
    public class Webhook
    {
        [JsonProperty("content")] public string Content = String.Empty;
        [JsonProperty("username")] public string Username;
        [JsonProperty("avatar_url")] public string AvatarUrl;
        [JsonProperty("tts")] public bool IsTts;

        public Client FClient;
        public string Url;

        public Webhook(Client fClient, string url)
        {
            FClient = fClient;
            Url = url;
        }
        
        public string Send()
        {
            HttpContent ctt = new StringContent(ToString());
            ctt.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
            
            HttpResponseMessage response = FClient.ClientHttp.PostAsync(Url, ctt).Result;
            
            return response.Content.ReadAsStringAsync().Result;
        }
        
        public string Send(string content)
        {
            Content = content;

            return Send();
        }

        public string Send(string content, string avatarUrl)
        {
            AvatarUrl = avatarUrl;

            return Send(content);
        }
        
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}