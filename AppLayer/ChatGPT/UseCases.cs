using AppLayer.Attributes;

namespace AppLayer.ChatGPT;

[ApplicationUseCases]
public class UseCases {
    private readonly IStorageProvider _serviceProvider;

    public UseCases(IStorageProvider serviceProvider) {
        _serviceProvider = serviceProvider;
    }

    public async Task<ChatGptResponseModel> SendPrompt(string prompt) => await _serviceProvider.SendPrompt(prompt);
}