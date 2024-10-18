using Android.App;
using Android.Content.PM;
using Android.OS;

namespace Tests.Maui;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override async void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        
        //Copy assets to internal storage
        foreach (var asset in assets)
        {
            try
            {
                var outputPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), asset);
                if (!File.Exists(outputPath))
                {
                    var assetStream = ApplicationContext.Assets.Open(asset);
                    var outputStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write);
                    assetStream.CopyTo(outputStream);
                    outputStream.Close();
                }
              
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }

    private string[] assets =
    {
        "DummyImage.png",
        "hundesteuer-anmeldung.pdf",
        "SocialPreview.pdf",
        "SocialPreview with password 123456 (AES-128).pdf",
        "SocialPreview with password 123456 (AES-256).pdf",
        "SocialPreview with password 123456 (AES-256; metadata encrypted).pdf",
        "SocialPreview with password 123456 (RC4-40).pdf",
        "SocialPreview with password 123456 (RC4-128).pdf",
        "Wikimedia_Commons_web.pdf"
    };
   
}

