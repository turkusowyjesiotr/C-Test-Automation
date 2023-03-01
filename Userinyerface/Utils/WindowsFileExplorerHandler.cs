using System;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace Userinyerface.Utils
{
    public static class WindowsFileExplorerHandler
    {
        public static void UploadImage()
        {
            /*
             For some reason when using Chrome, the SendKeys method omitted hard drive name (C in my case)
             and when using Firefox, it didn't. Thread.Sleep() fixes this issue, because it gives more time
             for file explorer to appear.
             */
            string pathToImage = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources\\avatar.png");
            Thread.Sleep(200);
            SendKeys.SendWait(pathToImage);
            SendKeys.SendWait(@"{Enter}");
            SendKeys.SendWait(@"{Enter}");
        }          
    }
}
