using AppLayer.Attributes;
using AppLayer.Modules;

namespace AppLayer.ChatGPT;

[ApplicationUseCases]
public class UseCases {
    private readonly IStorageProvider _serviceProvider;
    private readonly MachineControlModule _machineControlModule;

    public UseCases(IStorageProvider serviceProvider, MachineControlModule machineControlModule) {
        _serviceProvider = serviceProvider;
        _machineControlModule = machineControlModule;
    }

    public async Task<ChatGptResponseModel> SendPrompt(string prompt) => await _serviceProvider.SendPrompt(prompt);
    public async Task SetVolume(int value) => await  _machineControlModule.SetVolume(value);
}