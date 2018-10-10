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
using System.Collections.Generic;
using System.Windows.Forms;
using CefSharp;
using CefSharp.Structs;
using CefSharp.WinForms;
using CefSharp.WinForms.Internals;

namespace SO.Browser.Desktop.Presenters.Handlers
{
    public class DisplayHandler : IDisplayHandler
    {
        private Control parent;
        private Form fullScreenForm;

        void IDisplayHandler.OnAddressChanged(IWebBrowser browserControl, AddressChangedEventArgs addressChangedArgs)
        {

        }

        bool IDisplayHandler.OnAutoResize(IWebBrowser browserControl, IBrowser browser, Size newSize)
        {
            return false;
        }

        void IDisplayHandler.OnTitleChanged(IWebBrowser browserControl, TitleChangedEventArgs titleChangedArgs)
        {

        }

        void IDisplayHandler.OnFaviconUrlChange(IWebBrowser browserControl, IBrowser browser, IList<string> urls)
        {

        }

        void IDisplayHandler.OnFullscreenModeChange(IWebBrowser browserControl, IBrowser browser, bool fullscreen)
        {
            var chromiumWebBrowser = (ChromiumWebBrowser)browserControl;

            chromiumWebBrowser.InvokeOnUiThreadIfRequired(() =>
            {
                if (fullscreen)
                {
                    parent = chromiumWebBrowser.Parent;

                    parent.Controls.Remove(chromiumWebBrowser);

                    fullScreenForm = new Form();
                    fullScreenForm.FormBorderStyle = FormBorderStyle.None;
                    fullScreenForm.WindowState = FormWindowState.Maximized;

                    fullScreenForm.Controls.Add(chromiumWebBrowser);

                    fullScreenForm.ShowDialog(parent.FindForm());
                }
                else
                {
                    fullScreenForm.Controls.Remove(chromiumWebBrowser);

                    parent.Controls.Add(chromiumWebBrowser);

                    fullScreenForm.Close();
                    fullScreenForm.Dispose();
                    fullScreenForm = null;
                }
            });
        }

        bool IDisplayHandler.OnTooltipChanged(IWebBrowser browserControl, ref string text)
        {
            //text = "Sample text";
            return false;
        }

        void IDisplayHandler.OnStatusMessage(IWebBrowser browserControl, StatusMessageEventArgs statusMessageArgs)
        {

        }

        bool IDisplayHandler.OnConsoleMessage(IWebBrowser browserControl, ConsoleMessageEventArgs consoleMessageArgs)
        {
            return false;
        }
    }
}
