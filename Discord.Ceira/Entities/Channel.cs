using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Discord.Ceira.Entities
{
    public class Channel
    {
        [JsonProperty("id")] public string Id;
        [JsonProperty("last_message_id")] public string LastMessageId;
        [JsonProperty("type")] public int Type;
        [JsonProperty("name")] public string Name;
        [JsonProperty("position")] public int Position;

        public Client FClient;

        public void SendMessage(string content)
        {
            string url = $"https://discord.com/api/v8/channels/{Id}/messages";

            Message msg = new Message()
            {
                Content = content
            };

            string json = JsonConvert.SerializeObject(msg);

            HttpContent ctt = new StringContent(json);
            ctt.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
            
            HttpResponseMessage response = FClient.ClientHttp.PostAsync(url, ctt).Result;

            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
        }

        public Message GetMessage(string messageId)
        {
            string url = $"{ApiUrl.Api}{ApiUrl.Channels}/{Id}{ApiUrl.Messages}/{messageId}";

            HttpResponseMessage response = FClient.ClientHttp.GetAsync(url).Result;

            string json = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<Message>(json);
        }
    }
}