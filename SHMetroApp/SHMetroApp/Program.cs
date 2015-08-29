using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SHMetroApp
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            splashForm Splash = new splashForm();
            Splash.showSplash();
            while (Splash.hasStarted)
            {
                Splash.message = "正在导入数据文件...";
            }
            
            Form1 mainForm = new Form1();

            Splash.closeSplash();
            Application.Run(mainForm);

            
        }
    }
}
