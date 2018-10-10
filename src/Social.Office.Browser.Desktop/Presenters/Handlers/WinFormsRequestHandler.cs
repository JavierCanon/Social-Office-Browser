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
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using CefSharp;
using CefSharp.Example.Handlers;
using CefSharp.WinForms.Internals;

namespace SO.Browser.Desktop.Presenters.Handlers
{
    public class WinFormsRequestHandler : RequestHandler
    {
        private Action<string, int?> openNewTab;

        public WinFormsRequestHandler(Action<string, int?> openNewTab)
        {
            this.openNewTab = openNewTab;
        }

        public override bool OnOpenUrlFromTab(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl, WindowOpenDisposition targetDisposition, bool userGesture)
        {
            if (openNewTab == null)
            {
                return false;
            }

            var control = (Control)browserControl;

            control.InvokeOnUiThreadIfRequired(delegate ()
            {
                openNewTab(targetUrl, null);
            });

            return true;
        }

        public override bool OnSelectClientCertificate(IWebBrowser browserControl, IBrowser browser, bool isProxy, string host, int port, X509Certificate2Collection certificates, ISelectClientCertificateCallback callback)
        {
            var control = (Control)browserControl;

            control.InvokeOnUiThreadIfRequired(delegate ()
            {

                var selectedCertificateCollection = X509Certificate2UI.SelectFromCollection(certificates, "Certificates Dialog", "Select Certificate for authentication", X509SelectionFlag.SingleSelection);

                //X509Certificate2UI.SelectFromCollection returns a collection, we've used SingleSelection, so just take the first
                //The underlying CEF implementation only accepts a single certificate
                callback.Select(selectedCertificateCollection[0]);
            });

            return true;
        }
    }
}
