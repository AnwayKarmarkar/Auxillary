using AppLayer.Attributes;
using AppLayer.Ports.Providers;

namespace AppLayer.Modules;
[Module]
public class MachineControlModule {
    private readonly IMachineControlServiceProvider _machineControlServiceProvider;
    public MachineControlModule(IMachineControlServiceProvider machineControlServiceProvider) {
        _machineControlServiceProvider = machineControlServiceProvider;
    }
    public virtual async Task SetVolume(int value) => await _machineControlServiceProvider.SetVolume(value);
}