using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

namespace SHMetroApp
{
    class splashForm
    {
        private static waitingForm mySplashForm = null;
        private static Thread mySplashThread = null;

        private static void showThread()
        {
            mySplashForm = new waitingForm();
            Application.Run(mySplashForm);
        }

        public bool hasStarted
        {
            get
            {
                if (mySplashForm != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void showSplash()
        {
            if (mySplashThread != null)
                return;

            mySplashThread = new Thread(new ThreadStart(splashForm.showThread));
            mySplashThread.IsBackground = true;
            mySplashThread.SetApartmentState(ApartmentState.STA);
            mySplashThread.Start();
        }

        public void closeSplash()
        {
            if (mySplashThread == null)
                return;
            if (mySplashForm == null)
                return;

            try
            {
                mySplashForm.Invoke(new MethodInvoker(mySplashForm.Close));
            }
            catch (System.Exception ex)
            {   
            }
            mySplashThread = null;
            mySplashForm = null;
        }

        public string message
        {
            set
            {
                if (mySplashForm == null)
                {
                    Trace.WriteLine("???");
                    return;
                }
                mySplashForm.message = value;
            }
            get
            {
                if (mySplashForm == null)
                {
                    throw new InvalidOperationException("Splash Form not on screen! ");
                }
                return mySplashForm.message;
            }
        }
    }
}
