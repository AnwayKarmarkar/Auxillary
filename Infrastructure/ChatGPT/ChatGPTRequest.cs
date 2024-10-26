using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Infrastructure.ChatGPT;

public class ChatGPTRequest {
    [JsonProperty("model")]
    public string Model { get; set; }

    [JsonProperty("messages")]
    public List<Message> Messages { get; set; }

    [JsonProperty("max_tokens")]
    public int MaxTokens { get; set; }

    [JsonProperty("temperature")]
    public double Temperature { get; set; }
}

public class Message {
    [JsonProperty("role")]
    public string Role { get; set; }

    [JsonProperty("content")]
    public string Content { get; set; }
}