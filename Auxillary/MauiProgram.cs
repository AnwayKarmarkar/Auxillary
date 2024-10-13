using AppLayer.Attributes;
using Infrastructure;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using System.Reflection;

namespace Auxillary; 

public static class MauiProgram {
    public static MauiApp CreateMauiApp() {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts => {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();
        builder.Services.AddMudServices();
        var _ = typeof(Infrastructure.ChatGPT.ChatGPTStorageProvider);
        //var classLibraryAssembly = Assembly.Load("Infrastructure");
        //builder.Services.AddServicesWithApplicationPort(classLibraryAssembly);

        var applicationAssembly = typeof(ApplicationUseCasesAttribute).Assembly;
        var test = AppDomain.CurrentDomain.GetAssemblies();
        var infrastructureAssembly = AppDomain.CurrentDomain.GetAssemblies().Single(x => x.FullName!.StartsWith("Infrastructure,"));
        foreach (var type in applicationAssembly.GetTypes()) {
            if (type.GetCustomAttributes<ApplicationUseCasesAttribute>().Any()) {
                builder.Services.Add(new ServiceDescriptor(type, type, ServiceLifetime.Transient));
                continue;
            }
            if (type.GetCustomAttributes<ApplicationPortAttribute>().Any()) {
                var port = type;
                var adapter = infrastructureAssembly.GetTypes().Single(x => x.GetInterfaces().Contains(port));
                builder.Services.Add(new ServiceDescriptor(port, adapter, ServiceLifetime.Transient));
            }
        }
#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}