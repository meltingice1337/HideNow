using System.Collections.Generic;
using AForge.Video.DirectShow;

namespace HideNow.Core
{
    class WebcamHandler
    {
        public static string[] GetWebcamNames()
        {
            var result = new List<string>();
            var VideoCaptureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo VideoCaptureDevice in VideoCaptureDevices)
            {
                result.Add(VideoCaptureDevice.Name);
            }
            return result.ToArray();
        }
    }
}
