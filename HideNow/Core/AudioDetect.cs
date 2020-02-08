using NAudio.Wave;
using System.Diagnostics;
using System.Drawing;

namespace HideNow.Core
{
    class AudioDetect
    {
        public double DetectionThreshold;
        public delegate void AudioDetectedHandler();
        public event AudioDetectedHandler AudioDetected;

        private WaveIn waveIn;

        public AudioDetect(int deviceNumber, int detectionThreshold = 400)
        {
            this.DetectionThreshold = detectionThreshold;
            waveIn = new WaveIn();
            waveIn.DeviceNumber = deviceNumber;
            waveIn.DataAvailable += WaveIn_DataAvailable; ; ;
            int sampleRate = 8000; // 8 kHz
            int channels = 1; // mono
            waveIn.WaveFormat = new WaveFormat(sampleRate, channels);
        }

        private void WaveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            for (int index = 0; index < e.BytesRecorded; index += 2)
            {
                short sample = (short)((e.Buffer[index + 1] << 8) |
                                        e.Buffer[index + 0]);
                float sample32 = sample / 32768f;
                if (sample > DetectionThreshold)
                {
                    AudioDetected?.Invoke();
                }
            }
        }

        public void Start()
        {
            waveIn.StartRecording();
        }

        public void Stop()
        {
            waveIn.StopRecording();
        }
    }
}
