﻿using System;
using System.IO;
using System.Linq;
using System.Text;
using WebCam_Capture;
using System.Collections.Generic;



namespace WinFormCharpWebCam
{
    //Design by Pongsakorn Poosankam
    class WebCam
    {
        private WebCamCapture webcam;
        private System.Windows.Forms.PictureBox _FrameImage;
        private int FrameNumber = 30;
        public void InitializeWebCam(ref System.Windows.Forms.PictureBox ImageControl)
        {

            try
            {
                webcam = new WebCamCapture();
                webcam.FrameNumber = ((ulong)(0ul));
                webcam.TimeToCapture_milliseconds = FrameNumber;
                webcam.ImageCaptured += new WebCamCapture.WebCamEventHandler(webcam_ImageCaptured);
                _FrameImage = ImageControl;

            }
            catch (Exception _ex)
            {
                string mess = _ex.Message;
                Console.WriteLine("Error Message:" + mess);
            }
            
        }

        void webcam_ImageCaptured(object source, WebcamEventArgs e)
        {
            _FrameImage.Image = e.WebCamImage;
        }

        public void Start()
        {
            webcam.TimeToCapture_milliseconds = FrameNumber;
            webcam.Start(0);
        }

        public void Stop()
        {
            webcam.Stop();
        }

        public void Continue()
        {
            // change the capture time frame
            webcam.TimeToCapture_milliseconds = FrameNumber;

            // resume the video capture from the stop
            webcam.Start(this.webcam.FrameNumber);
        }

        public void ResolutionSetting()
        {
            webcam.Config();
        }

        public void AdvanceSetting()
        {
            webcam.Config2();
        }

    }
}
