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
namespace CefSharp.Example
{
    public class JsDialogHandler : IJsDialogHandler
    {
        bool IJsDialogHandler.OnJSDialog(IWebBrowser browserControl, IBrowser browser, string originUrl, CefJsDialogType dialogType, string messageText, string defaultPromptText, IJsDialogCallback callback, ref bool suppressMessage)
        {
            return false;
        }

        /*
        bool IJsDialogHandler.OnBeforeUnloadDialog(IWebBrowser browserControl, IBrowser browser, string message, bool isReload, IJsDialogCallback callback)
        {
            //Custom implementation would look something like
            // - Create/Show dialog on UI Thread
            // - execute callback once user has responded
            // - callback.Continue(true);
            // - return true

            //NOTE: Returning false will trigger the default behaviour, no need to execute the callback if you return false.
            return false;
        }
        */

        void IJsDialogHandler.OnResetDialogState(IWebBrowser browserControl, IBrowser browser)
        {

        }

        void IJsDialogHandler.OnDialogClosed(IWebBrowser browserControl, IBrowser browser)
        {

        }

        public bool OnJSBeforeUnload(IWebBrowser chromiumWebBrowser, IBrowser browser, string message, bool isReload, IJsDialogCallback callback)
        {
            throw new System.NotImplementedException();
        }
    }
}
