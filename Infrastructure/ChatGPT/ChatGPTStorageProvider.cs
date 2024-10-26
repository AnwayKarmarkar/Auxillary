using AppLayer.ChatGPT;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;

namespace Infrastructure.ChatGPT;

public class ChatGPTStorageProvider : IStorageProvider {
    //private readonly IHttpClientFactory _httpClientFactory;

    //public ChatGPTStorageProvider(IHttpClientFactory httpClientFactory) {
    //    _httpClientFactory = httpClientFactory;
    //}

    public async Task<ChatGptResponseModel> SendPrompt(string prompt) {
        using var client = new HttpClient();

        var request = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/chat/completions");

        var requestBody = new ChatGPTRequest {
            Model = "gpt-3.5-turbo",
            Messages = new List<Message> {
                new() {
                    Role = "system",
                    Content =
                        "You are a smart assistant called Auxillary. " +
                        "If the user input is a system command, like 'set volume', 'open browser', or 'shut down the PC', identify it as a command and prefix the response with SysCmd: . " +
                        "and remove the period from the end. " +
                        "Otherwise, treat the input as a general question. " +
                        "When setting volume use 'Set volume to [value]."
                },
                new() {
                    Role = "user",
                    Content = prompt
                }
            },
            MaxTokens = 100,
            Temperature = 0.2
        };
        var data = JsonConvert.SerializeObject(requestBody);

        request.Headers.Add("Authorization",
            "Bearer key");
        var content = new StringContent(data, Encoding.UTF8, "application/json");
        //var content = new StringContent(data);
        request.Content = content;
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        var test = await response.Content.ReadAsStringAsync();
        var responseObject = JsonConvert.DeserializeObject<ChatGptResponseModel>(test);

        return responseObject ?? new ChatGptResponseModel();
    }
}