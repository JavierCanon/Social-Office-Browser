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
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace SO.Browser.Desktop.Presenters
{
    /// <summary>
    /// Intercepts Windows messages sent to the ChromiumWebBrowser control's widget sub-window.
    /// 
    /// It is necessary to listen to the widget sub-window because it receives all Windows messages
    /// and forwards them to CEF, rather than the ChromiumWebBrowser.Handle.
    /// 
    /// The supplied Action delegate is fired upon each message.
    /// </summary>
    internal class ChromeWidgetMessageInterceptor : NativeWindow
    {
        private Action<Message> forwardAction;

        internal ChromeWidgetMessageInterceptor(Control browser, IntPtr chromeWidgetHostHandle, Action<Message> forwardAction)
        {
            AssignHandle(chromeWidgetHostHandle);

            browser.HandleDestroyed += BrowserHandleDestroyed;

            this.forwardAction = forwardAction;
        }

        private void BrowserHandleDestroyed(object sender, EventArgs e)
        {
            ReleaseHandle();

            var browser = (Control)sender;

            browser.HandleDestroyed -= BrowserHandleDestroyed;
            forwardAction = null;
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (forwardAction != null)
            {
                forwardAction(m);
            }
        }
    }

    internal static class ChromeWidgetHandleFinder
    {
        private delegate bool EnumWindowProc(IntPtr hwnd, IntPtr lParam);

        [DllImport("user32")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool EnumChildWindows(IntPtr window, EnumWindowProc callback, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        private class ClassDetails
        {
            public IntPtr DescendantFound { get; set; }
        }

        private static bool EnumWindow(IntPtr hWnd, IntPtr lParam)
        {
            const string chromeWidgetHostClassName = "Chrome_RenderWidgetHostHWND";

            var buffer = new StringBuilder(128);
            GetClassName(hWnd, buffer, buffer.Capacity);

            if (buffer.ToString() == chromeWidgetHostClassName)
            {
                var gcHandle = GCHandle.FromIntPtr(lParam);

                var classDetails = (ClassDetails)gcHandle.Target;

                classDetails.DescendantFound = hWnd;
                return false;
            }

            return true;
        }

        /// <summary>
        /// Chrome's message-loop Window isn't created synchronously, so this may not find it.
        /// If so, you need to wait and try again later.
        /// </summary>
        public static bool TryFindHandle(IntPtr browserHandle, out IntPtr chromeWidgetHostHandle)
        {
            var classDetails = new ClassDetails();
            var gcHandle = GCHandle.Alloc(classDetails);

            var childProc = new EnumWindowProc(EnumWindow);
            EnumChildWindows(browserHandle, childProc, GCHandle.ToIntPtr(gcHandle));

            chromeWidgetHostHandle = classDetails.DescendantFound;

            gcHandle.Free();

            return classDetails.DescendantFound != IntPtr.Zero;
        }
    }
}
