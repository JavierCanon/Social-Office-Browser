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

namespace CefSharp.Example
{
    public class RenderProcessMessageHandler : IRenderProcessMessageHandler
    {
        void IRenderProcessMessageHandler.OnFocusedNodeChanged(IWebBrowser browserControl, IBrowser browser, IFrame frame, IDomNode node)
        {
            var message = node == null ? "lost focus" : node.ToString();

            Console.WriteLine("OnFocusedNodeChanged() - " + message);
        }

        void IRenderProcessMessageHandler.OnContextCreated(IWebBrowser browserControl, IBrowser browser, IFrame frame)
        {
            const string script = "document.addEventListener('DOMContentLoaded', function(){ alert('DomLoaded'); });";

            //frame.ExecuteJavaScriptAsync(script);
        }

        void IRenderProcessMessageHandler.OnContextReleased(IWebBrowser browserControl, IBrowser browser, IFrame frame)
        {
            //The V8Context is about to be released, use this notification to cancel any long running tasks your might have
        }

        void IRenderProcessMessageHandler.OnUncaughtException(IWebBrowser browserControl, IBrowser browser, IFrame frame, JavascriptException exception)
        {
            Console.WriteLine("OnUncaughtException() - " + exception.Message);
        }
    }
}
