using Newtonsoft.Json;

namespace Discord.Ceira.Entities
{
    public class Message
    {
        [JsonProperty("id")] public string Id;
        [JsonProperty("type")] public int Type;
        [JsonProperty("content")] public string Content;
        [JsonProperty("channel_id")] public string ChannelId;
        [JsonProperty("author")] public User Author;
        [JsonProperty("pinned")] public bool Pinned;
        [JsonProperty("mention_everyone")] public bool MentionEveryone;
        [JsonProperty("tts")] public bool IsTts;
    }
}