using System.Net.Http;
using Discord.Ceira.Entities;
using Newtonsoft.Json;

namespace Discord.Ceira
{
    public sealed class Client
    {
        public HttpClient ClientHttp;
        
        private readonly string _token;

        /// <summary>
        /// Initialize the client
        /// </summary>
        /// <param name="token">token of discord client</param>
        /// <param name="tokenType">type of discord client (default = bot)</param>
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
        
        /// <summary>
        /// Get user by id from Rest API
        /// </summary>
        /// <param name="userId">id of user</param>
        /// <returns>User class</returns>
        public User GetUser(string userId)
        {
            string url = $"{ApiUrl.Api}{ApiUrl.Users}/{userId}";
            HttpResponseMessage response = ClientHttp.GetAsync(url).Result;
            //TODO check exception

            string json = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<User>(json);
        }

        /// <summary>
        /// Get channel by id from Rest API 
        /// </summary>
        /// <param name="channelId">id of channel</param>
        /// <returns>Channel class</returns>
        public Channel GetChannel(string channelId)
        {
            string url = $"{ApiUrl.Api}{ApiUrl.Channels}/{channelId}";
            HttpResponseMessage response = ClientHttp.GetAsync(url).Result;
            //TODO check exception
            
            string json = response.Content.ReadAsStringAsync().Result;
            Channel ch = JsonConvert.DeserializeObject<Channel>(json);
            ch!.FClient = this;
            return ch;
        }
    }
}