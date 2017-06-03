using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Diagnostics;
using AutoUpdaterDotNET;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace TankiTools
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Process.GetProcessesByName(Path.GetFileNameWithoutExtension(
                Assembly.GetEntryAssembly().Location)).Count() > 1)
            {
                Shutdown();
            }
            else
            {
                RuntimeHelpers.RunClassConstructor(typeof(SettingsManager).TypeHandle);
                RuntimeHelpers.RunClassConstructor(typeof(L18n).TypeHandle);
                RuntimeHelpers.RunClassConstructor(typeof(MediaHistoryManager).TypeHandle);
                
                if (SettingsManager.autoupdate)
                {
                    switch (SettingsManager.lang)
                    {
                        case "ru":
                            AutoUpdater.CurrentCulture = CultureInfo.CreateSpecificCulture("ru-RU");
                            break;
                        default:
                            AutoUpdater.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");
                            break;
                    }
                    AutoUpdater.Start(@"http://217.71.139.74/~user119/Povshedny_test/version.xml");
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                MainWindow MainWindow = new MainWindow();
                Application.Run(MainWindow);
                
                if (SettingsManager.autostart)
                {
                    MainWindow.WindowState = FormWindowState.Minimized;
                    MainWindow.ShowInTaskbar = false;
                    MainWindow.Hide();
                }
                SettingsManager.SetGlobalHotkeys(false);
            }
        }

        public static void Shutdown()
        {
            //SettingsManager.UnsetGlobalHotkeys();
            Environment.Exit(0);
            Application.ExitThread();
            Application.Exit();
        }
    }
}
