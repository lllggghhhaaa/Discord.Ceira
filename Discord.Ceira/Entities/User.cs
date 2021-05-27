using Newtonsoft.Json;

namespace Discord.Ceira.Entities
{
    public class User
    {
        [JsonProperty("id")] public string Id;
        [JsonProperty("username")] public string Username;
        [JsonProperty("avatar")] public string AvatarHash;
        [JsonProperty("discriminator")] public string Discriminator;
        [JsonProperty("public_flags")] public int Flags;
        [JsonProperty("bot")] public bool IsBot;
    }
}