using AppLayer.Attributes;

namespace AppLayer.Ports.Providers;
[ApplicationPort]
public interface IMachineControlServiceProvider {
    public Task SetVolume(int value);
}