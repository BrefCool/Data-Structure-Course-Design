using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.ComponentModel;
using System.Diagnostics;

namespace SHMetroApp
{
    static class Program
    {
        static BackgroundWorker bw = new BackgroundWorker();
        static waitingForm wForm;
        static Form1 mainForm;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bw.DoWork += bw_Dowork;
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
            //在后台执行Form1的初始化
            bw.RunWorkerAsync();

            wForm = new waitingForm("正在导入数据文件...");
            Application.Run(wForm);

            Application.Run(mainForm);
        }

        static void bw_Dowork(object sender, DoWorkEventArgs e)
        {
            mainForm = new Form1();
        }

        static void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (wForm.InvokeRequired)
            {
                wForm.Invoke(new MethodInvoker(wForm.Close));
            }
            else
            {
                wForm.Close();
            }
            Trace.WriteLine("导入完成");
        }
    }
}
