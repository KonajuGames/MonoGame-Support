using Android.App;
using Android.Content;
using Android.Net;

namespace Microsoft.Phone.Tasks
{
    /// <summary>
    /// Android implementaion of the MarketplaceReviewTask.
    /// </summary>
    public sealed class MarketplaceReviewTask
    {
        public void Show()
        {
            Intent intent = new Intent(Intent.ActionView);
            intent.SetData(Uri.Parse("market://details?id=" + Application.Context.PackageName));
            intent.SetFlags(ActivityFlags.NewTask);
            Application.Context.StartActivity(intent);
        }
    }
}
