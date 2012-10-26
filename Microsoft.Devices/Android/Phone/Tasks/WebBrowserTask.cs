using Android.App;
using Android.Content;

namespace Microsoft.Phone.Tasks
{
    /// <summary>
    /// Android implementation of the WebBroswerTask
    /// </summary>
    public sealed class WebBrowserTask
    {
        // Uri for target web site
        public System.Uri Uri { get; set; }

        public void Show()
        {
            Intent intent = new Intent(Intent.ActionView);
            intent.SetData(Android.Net.Uri.Parse(Uri.OriginalString));
            intent.SetFlags(ActivityFlags.NewTask);
            Application.Context.StartActivity(intent);
        }
    }
}