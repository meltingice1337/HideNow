using System.Drawing;
using AForge.Video.DirectShow;
using AForge.Video;
using AForge.Vision.Motion;

namespace HideNow.Core
{
    class MotionDetect
    {
        public double DetectionThreshold = 0.02496;
        public delegate void MotionDetectedHandler();
        public event MotionDetectedHandler MotionDetected;

        private FilterInfoCollection VideoCaptureDevices;
        private MotionDetector Detector;
        private VideoCaptureDevice FinalVideo;

        public MotionDetect(int webcamID)
        {
            VideoCaptureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            FinalVideo = new VideoCaptureDevice(VideoCaptureDevices[webcamID].MonikerString);
            var motionProcessor = new MotionAreaHighlighting();
            Detector = new MotionDetector(new SimpleBackgroundModelingDetector(), motionProcessor);
            FinalVideo.NewFrame += FinalVideo_NewFrame;
        }

        private void FinalVideo_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (Detector.ProcessFrame((Bitmap)eventArgs.Frame.Clone()) > DetectionThreshold)
                MotionDetected?.Invoke();
        }

        public void Start()
        {
            if (!FinalVideo.IsRunning)
                FinalVideo.Start();
        }

        public void Stop()
        {
            if (FinalVideo.IsRunning)
                FinalVideo.Stop();
        }
    }
}
