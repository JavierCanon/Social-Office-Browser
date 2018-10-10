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
namespace CefSharp.Example.RequestEventHandler
{
    public class OnBeforeBrowseEventArgs : BaseRequestEventArgs
    {
        public OnBeforeBrowseEventArgs(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, bool userGesture, bool isRedirect)
            : base(browserControl, browser)
        {
            Frame = frame;
            Request = request;
            IsRedirect = isRedirect;
            UserGesture = userGesture;

            CancelNavigation = false; // default
        }

        public IFrame Frame { get; private set; }
        public IRequest Request { get; private set; }
        public bool IsRedirect { get; private set; }
        public bool UserGesture { get; private set; }

        /// <summary>
        ///     Set to true to cancel the navigation or false to allow the navigation to proceed.
        /// </summary>
        public bool CancelNavigation { get; set; }
    }
}
