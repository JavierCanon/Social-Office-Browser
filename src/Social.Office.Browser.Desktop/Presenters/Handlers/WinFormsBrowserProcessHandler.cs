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
using System.Threading.Tasks;
using System.Timers;
using CefSharp;
using CefSharp.Example.Handlers;

namespace SO.Browser.Desktop.Presenters.Handlers
{
    /// <summary>
    /// EXPERIMENTAL - this implementation is very simplistic and not ready for production use
    /// See the following link for the CEF reference implementation.
    /// https://bitbucket.org/chromiumembedded/cef/commits/1ff26aa02a656b3bc9f0712591c92849c5909e04?at=2785
    /// </summary>
    public class WinFormsBrowserProcessHandler : BrowserProcessHandler
    {
        private Timer timer;
        private TaskFactory factory;

        public WinFormsBrowserProcessHandler(TaskScheduler scheduler)
        {
            factory = new TaskFactory(scheduler);
            timer = new Timer { Interval = MaxTimerDelay, AutoReset = true };
            timer.Start();
            timer.Elapsed += TimerTick;
        }

        private void TimerTick(object sender, EventArgs e)
        {
            //Basically execute Cef.DoMessageLoopWork 30 times per second
            //Execute DoMessageLoopWork on UI thread
            factory.StartNew(() => Cef.DoMessageLoopWork());
        }

        protected override void OnScheduleMessagePumpWork(int delay)
        {
            //when delay <= 0 queue the Task up for execution on the UI thread.
            if (delay <= 0)
            {
                //Update the timer to execute almost immediately
                factory.StartNew(() => Cef.DoMessageLoopWork());
            }
        }

        public override void Dispose()
        {
            if (timer != null)
            {
                timer.Stop();
                timer.Dispose();
                timer = null;
            }
        }
    }
}
