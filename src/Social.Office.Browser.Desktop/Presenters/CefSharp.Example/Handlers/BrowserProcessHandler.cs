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
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using CefSharp.SchemeHandler;

namespace CefSharp.Example.Handlers
{
    public class BrowserProcessHandler : IBrowserProcessHandler
    {
        /// <summary>
        /// The maximum number of milliseconds we're willing to wait between calls to OnScheduleMessagePumpWork().
        /// </summary>
        protected const int MaxTimerDelay = 1000 / 30;  // 30fps

        void IBrowserProcessHandler.OnContextInitialized()
        {
            //The Global CookieManager has been initialized, you can now set cookies
            var cookieManager = Cef.GetGlobalCookieManager();
            cookieManager.SetStoragePath("cookies", true);
            cookieManager.SetSupportedSchemes(new string[] { "custom" });
            /*
            if (cookieManager.SetCookie("custom://cefsharp/home.html", new Cookie
            {
                Name = "CefSharpTestCookie",
                Value = "ILikeCookies",
                Expires = DateTime.Now.AddDays(1)
            }))
            {
                cookieManager.VisitUrlCookiesAsync("custom://cefsharp/home.html", false).ContinueWith(previous =>
                {
                    if (previous.Status == TaskStatus.RanToCompletion)
                    {
                        var cookies = previous.Result;

                        foreach (var cookie in cookies)
                        {
                            Debug.WriteLine("CookieName:" + cookie.Name);
                        }
                    }
                    else
                    {
                        Debug.WriteLine("No Cookies found");
                    }
                });

                cookieManager.VisitAllCookiesAsync().ContinueWith(t =>
                {
                    if (t.Status == TaskStatus.RanToCompletion)
                    {
                        var cookies = t.Result;

                        foreach (var cookie in cookies)
                        {
                            Debug.WriteLine("CookieName:" + cookie.Name);
                        }
                    }
                    else
                    {
                        Debug.WriteLine("No Cookies found");
                    }
                });
            }
            */

            //The Request Context has been initialized, you can now set preferences, like proxy server settings
            //Dispose of context when finished - preferable not to keep a reference if possible.
            using (var context = Cef.GetGlobalRequestContext())
            {
                string errorMessage;
                //You can set most preferences using a `.` notation rather than having to create a complex set of dictionaries.
                //The default is true, you can change to false to disable
                context.SetPreference("webkit.webprefs.plugins_enabled", true, out errorMessage);

                //It's possible to register a scheme handler for the default http and https schemes
                //In this example we register the FolderSchemeHandlerFactory for https://cefsharp.example
                //Best to include the domain name, so only requests for that domain are forwarded to your scheme handler
                //It is possible to intercept all requests for a scheme, including the built in http/https ones, be very careful doing this!
                /* var folderSchemeHandlerExample = new FolderSchemeHandlerFactory(rootFolder: @"..\..\..\..\CefSharp.Example\Resources",
                                                                        hostName: "cefsharp.example", //Optional param no hostname checking if null
                                                                        defaultPage: "home.html"); //Optional param will default to index.html

                context.RegisterSchemeHandlerFactory("https", "cefsharp.example", folderSchemeHandlerExample);
                */
            }
        }

        void IBrowserProcessHandler.OnScheduleMessagePumpWork(long delay)
        {
            //If the delay is greater than the Maximum then use MaxTimerDelay
            //instead - we do this to achieve a minimum number of FPS
            if (delay > MaxTimerDelay)
            {
                delay = MaxTimerDelay;
            }
            OnScheduleMessagePumpWork((int)delay);
        }

        protected virtual void OnScheduleMessagePumpWork(int delay)
        {
            //TODO: Schedule work on the UI thread - call Cef.DoMessageLoopWork
        }

        public virtual void Dispose()
        {

        }
    }
}
