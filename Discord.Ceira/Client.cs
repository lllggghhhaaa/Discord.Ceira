using System;
using System.IO;
using System.Net.Http;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Discord.Ceira.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Discord.Ceira
{
    public sealed class Client
    {
        public HttpClient ClientHttp;
        
        private readonly string _token;

        public Client(string token, string tokenType = "Bot")
        {
            _token = token;
            
            InitializeClient(tokenType);
        }

        private void InitializeClient(string tokenType)
        {
            ClientHttp = new HttpClient();
            ClientHttp.DefaultRequestHeaders.Add("Authorization", $"{tokenType} {_token}");
        }
        
        public User GetUser(string userId)
        {
            string url = $"{ApiUrl.Api}{ApiUrl.Users}/{userId}";
            HttpResponseMessage response = ClientHttp.GetAsync(url).Result;
            //TODO check exception

            string json = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<User>(json);
        }

        public Channel GetChannel(string channelId)
        {
            string url = $"{ApiUrl.Api}{ApiUrl.Channels}/{channelId}";
            HttpResponseMessage response = ClientHttp.GetAsync(url).Result;
            //TODO check exception
            
            string json = response.Content.ReadAsStringAsync().Result;
            Channel ch = JsonConvert.DeserializeObject<Channel>(json);
            ch.FClient = this;
            return ch;
        }
    }
}