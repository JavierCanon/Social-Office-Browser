// Copyright (c) 2018 Javier Cañon 
// https://www.javiercanon.com 
// https://www.xn--javiercaon-09a.com
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to
// deal in the Software without restriction, including without limitation the
// rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
// sell copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
// IN THE SOFTWARE.
using CefSharp;
using CefSharp.WinForms;
using log4net;
using SharkErrorReporter;
using SO.Browser.Desktop.Presenters.Handlers;
using SO.Browser.Desktop.Views;
using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SO.Browser.Desktop
{
    public class Program
    {
        private static ILog ilog;
        const bool multiThreadedMessageLoop = true;
        const string userAgentWin10 = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.2526.73 Safari/537.36";

        [STAThread]
        public static int Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("es-419");

            Application.ThreadException += new ExceptionHandler().ApplicationThreadException;
            AppDomain.CurrentDomain.UnhandledException += new ExceptionHandler().DomainUnhandledException;

            InitiateLogging();

            Cef.EnableHighDPISupport();

            //NOTE: Using a simple sub processes uses your existing application executable to spawn instances of the sub process.
            //Features like JSB, EvaluateScriptAsync, custom schemes require the CefSharp.BrowserSubprocess to function
            int exitCode = Cef.ExecuteProcess();

            if (exitCode >= 0)
            {
                return exitCode;
            }


            //var browser = new BrowserForm(multiThreadedMessageLoop);
            //var browser = new SimpleBrowserForm();
            //var browser = new TabulationDemoForm();
            //var browser = new ToolbarFormBrowser();
            FormTabbedMDIBrowser browser = new FormTabbedMDIBrowser();

            IBrowserProcessHandler browserProcessHandler;

            if (multiThreadedMessageLoop)
            {
                browserProcessHandler = new BrowserProcessHandler();
            }
            else
            {
                //Get the current taskScheduler (must be called after the form is created)
                TaskScheduler scheduler = TaskScheduler.FromCurrentSynchronizationContext();
                browserProcessHandler = new WinFormsBrowserProcessHandler(scheduler);
            }

            // cache path
            //To get the location the assembly normally resides on disk or the install directory
            string path = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            string directory = Path.GetDirectoryName(path);
            string localpath = new Uri(directory).LocalPath;
            if (!Directory.Exists(localpath))
            {
                Directory.CreateDirectory(localpath);
            }

            // need to make default/first cache folder
            localpath += "\\cachetab1";
            if (!Directory.Exists(localpath))
            {
                Directory.CreateDirectory(localpath);
            }

            CefSettings cefsetting = new CefSettings
            {
                MultiThreadedMessageLoop = multiThreadedMessageLoop,
                ExternalMessagePump = !multiThreadedMessageLoop,
                AcceptLanguageList = "es-419, es;q=0.8",
                Locale = "es", 
                IgnoreCertificateErrors = true,
                UserAgent = userAgentWin10,
                CachePath = localpath,

            };

#if DEBUG
            cefsetting.LogSeverity = LogSeverity.Verbose;
            LogInfo("Running .exe Debug Version");
#else
            cefsetting.LogSeverity = LogSeverity.Error;
#endif

            Cef.Initialize(cefsetting, true, browserProcessHandler: browserProcessHandler);
            Thread.Sleep(3000); //time to start Cef

            Application.Run(browser);

            LogInfo("shutdown...");

            //Shutdown before your application exists or it will hang.
            Cef.Shutdown();

            // save user settings
            Properties.User.Default.Save();

            // close pending threats
            Environment.Exit(Environment.ExitCode);

            return 0;
        }

        #region Errors


        public class ExceptionHandler
        {

            //er.Config.WebReportUrl = "http://localhost/ExceptionReporter.Demo.WebServer/PHP/ERServer.php?o=2";
            // https://github.com/PandaWood/ExceptionReporter.NET/wiki/Sample-Usage
            public ExceptionReporter reporter = new ExceptionReporter
            {
                Config =
       {
         WebReportUrl ="",
         WebReportUrlTimeout = 60,

         AppName = Path.GetFileName(Application.ExecutablePath),
         CompanyName = "JC Social Media Marketing Digital",
         TitleText = "Reporte de Errores",
         TakeScreenshot = true,
         CompanyPhone ="",
         CompanyEmail ="javier@javiercanon.com",
         CompanyWebUrl ="www.javiercanon.com",
         ContactEmail="javier@javiercanon.com",
         ContactPhone ="+57.3158915090",
         ContactWebUrl ="www.javiercanon.com",
         ShowFullDetail = false,
         ShowLessMoreDetailButton = true,
         ShowContactTab = true,
         ShowButtonIcons = true

       }
            };


            public void ApplicationThreadException(object sender, ThreadExceptionEventArgs e)
            {
                reporter.Show(e.Exception);
                if (!string.IsNullOrEmpty(reporter.Config.WebReportUrl)){
                    if (CheckForInternetConnection())
                        reporter.Send(SharkErrorReporter.Core.ExceptionReportInfo.SendMethod.WebPage, e.Exception);
                }

            }

            public void DomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
            {
                reporter.Show((Exception)e.ExceptionObject);
                if (!string.IsNullOrEmpty(reporter.Config.WebReportUrl))
                {
                    if(CheckForInternetConnection())
                        reporter.Send(SharkErrorReporter.Core.ExceptionReportInfo.SendMethod.WebPage, (Exception)e.ExceptionObject);
                }
            }
        }
        #endregion Errors



        #region Internet
        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://clients3.google.com/generate_204"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        #endregion Internet


        #region Analitycs

        #endregion Analitycs

        #region Common

        static void InitiateLogging()
        {
            log4net.Config.XmlConfigurator.Configure();
            ilog = LogManager.GetLogger("loggerConsole");
            LogInfo(">> starting...");
        }

        static void PrintHelp()
        {
        }

        public static void LogError(string msg)
        {
            System.Console.WriteLine("Error: " + msg);
            Console.WriteLine();
            ilog.Error(msg);
        }

        public static void LogInfo(string msg)
        {
            System.Console.WriteLine("Info: " + msg);
            Console.WriteLine();
            ilog.Info(msg);
        }

        public static void LogDebug(string msg)
        {
#if DEBUG
            Console.WriteLine("Debug: " + msg);
            Console.WriteLine();
            ilog.Debug(msg);
#endif
        }

        #endregion Common

    }
}
