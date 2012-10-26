using Android.App;
using Android.Content;
using Android.Net;

namespace Microsoft.Phone.Tasks
{
    /// <summary>
    /// Android implementaion of the MarketplaceDetailTask.
    /// </summary>
    public sealed class MarketplaceDetailTask
    {
        // Android package name, eg "com.rovio.angrybirds"
        public string ContentIdentifier { get; set; }

        // Ignored by this implementation
        public MarketplaceContentType ContentType { get; set; }

        public MarketplaceDetailTask()
        {
            // Content Identifier defaults to show the current app
            ContentIdentifier = Application.Context.PackageName;
        }

        public void Show()
        {
            Intent intent = new Intent(Intent.ActionView);
            intent.SetData(Uri.Parse("market://details?id=" + ContentIdentifier));
            intent.SetFlags(ActivityFlags.NewTask);
            Application.Context.StartActivity(intent);
        }
    }
}
