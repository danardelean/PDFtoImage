using Microsoft.Extensions.Logging;
using DeviceRunners.UITesting;
using DeviceRunners.VisualRunners;
using PDFtoImage.Tests;

namespace Tests.Maui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		TestUtils.GetInputStream = (filePath) =>
		{
			filePath = filePath.Replace("Assets/", string.Empty);
#if ANDROID
			filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), filePath);
			return  new FileStream( filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, FileOptions.SequentialScan);
#elif IOS
			filePath = Path.Combine(Environment.CurrentDirectory, filePath);
			return  new FileStream( filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, FileOptions.SequentialScan);
#endif
			return null;
		};
		
		var builder = MauiApp.CreateBuilder();
        builder
        .ConfigureUITesting()
        .UseVisualTestRunner(conf => conf
#if MODE_NON_INTERACTIVE_VISUAL
				.EnableAutoStart(true)
				.AddTcpResultChannel(new TcpResultChannelOptions
				{
					HostNames = ["localhost", "10.0.2.2"],
					Port = 16384,
					Formatter = new TextResultChannelFormatter(),
					Required = false
				})
#endif
            .AddConsoleResultChannel()
            .AddTestAssembly(typeof(PDFtoImage.Tests.TestUtils).Assembly)
            .AddNUnit());

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

