using System;
using Android;
using Android.Content;
using Android.OS;
using Android.App;

namespace Microsoft.Devices
{
    public class VibrateController
    {
        #region Statics
        static VibrateController _instance;
        public static VibrateController Default
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new VibrateController();
                }
                return _instance;
            }
        }
        #endregion

        public void Start(TimeSpan duration)
        {
            if (duration.TotalSeconds > 5.0 || duration.TotalSeconds < 0.0)
                throw new ArgumentOutOfRangeException("duration", duration, "duration must be between 0 and 5 seconds");

            var vibrator = (Vibrator)Application.Context.GetSystemService(Context.VibratorService);
            vibrator.Vibrate((long)duration.TotalMilliseconds);
        }

        public void Stop()
        {
            var vibrator = (Vibrator)Application.Context.GetSystemService(Context.VibratorService);
            vibrator.Cancel();
        }
    }
}
