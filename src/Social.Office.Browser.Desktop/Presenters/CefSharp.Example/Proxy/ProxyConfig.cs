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
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace CefSharp.Example.Proxy
{
    public class ProxyConfig
    {
        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool InternetQueryOption(IntPtr hInternet, uint dwOption, IntPtr lpBuffer, ref int lpdwBufferLength);

        private const uint InternetOptionProxy = 38;

        public static InternetProxyInfo GetProxyInformation()
        {
            var bufferLength = 0;
            InternetQueryOption(IntPtr.Zero, InternetOptionProxy, IntPtr.Zero, ref bufferLength);
            var buffer = IntPtr.Zero;

            try
            {
                buffer = Marshal.AllocHGlobal(bufferLength);

                if (InternetQueryOption(IntPtr.Zero, InternetOptionProxy, buffer, ref bufferLength))
                {
                    var ipi = (InternetProxyInfo)Marshal.PtrToStructure(buffer, typeof(InternetProxyInfo));
                    return ipi;
                }
                {
                    throw new Win32Exception();
                }
            }
            finally
            {
                if (buffer != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(buffer);
                }
            }
        }
    }
}