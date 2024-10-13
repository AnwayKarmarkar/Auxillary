using AppLayer.ChatGPT;

namespace Infrastructure.ChatGPT; 

public class ChatGPTStorageProvider : IStorageProvider {
    public async Task<ChatGptResponseModel> SendPrompt(string prompt) {
        return new ChatGptResponseModel();
    }
}