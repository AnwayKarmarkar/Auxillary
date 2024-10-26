using AppLayer.Ports.Providers;
using AudioSwitcher.AudioApi.CoreAudio;
using System.Diagnostics;

namespace Infrastructure.Services; 

public class MachineControlService : IMachineControlServiceProvider {
    public async Task SetVolume(int value) {
        var defaultPlaybackDevice = new CoreAudioController().DefaultPlaybackDevice;
        Debug.WriteLine("Current Volume:" + defaultPlaybackDevice.Volume);
        defaultPlaybackDevice.Volume = value;
        Debug.WriteLine("Changed Volume:" + defaultPlaybackDevice.Volume);
    }
}