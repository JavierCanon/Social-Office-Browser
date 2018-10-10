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
using CefSharp.WinForms.Internals;
using SO.Browser.Desktop.Presenters.Handlers;
using System;
using System.IO;
using System.Windows.Forms;

namespace SO.Browser.Desktop.Views
{
    public partial class FormSOBrowser : DevExpress.XtraEditors.XtraForm
    {
        ChromiumWebBrowser browser;
        RequestContextSettings requestContextSettings;
        RequestContext requestContext;

        string _cacheDirName, _url;

        public FormSOBrowser(string cacheDirName, string url)
        {
            _cacheDirName = cacheDirName;
            _url = url;

            InitializeComponent();
            Load += OnLoad;

            //Only perform layout when control has completly finished resizing
            ResizeBegin += (s, e) => SuspendLayout();
            ResizeEnd += (s, e) => ResumeLayout(true);

#if DEBUG
            outputLabel.Visible = true;
#else
            outputLabel.Visible = false;
#endif


            // cache path
            //To get the location the assembly normally resides on disk or the install directory
            string path = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            string directory = Path.GetDirectoryName(path);
            string localpath = new Uri(directory).LocalPath;
            if (!Directory.Exists(localpath))
            {
                Directory.CreateDirectory(localpath);
            }

            localpath += "\\" + cacheDirName;
            if (!Directory.Exists(localpath))
            {
                Directory.CreateDirectory(localpath);
            }


            requestContextSettings = new RequestContextSettings
            {
                CachePath = localpath,
                PersistSessionCookies = true,
                PersistUserPreferences = true,
                IgnoreCertificateErrors = true,
                AcceptLanguageList = "es-419, es;q=0.8"
            };

            requestContext = new RequestContext(requestContextSettings);


        }

        public string GetLoadedUrlMainFrame()
        {

            return browser.GetMainFrame().Url;
        }


        private void OnLoad(object sender, EventArgs e)
        {
            CreateBrowser(_url);
        }

        private void CreateBrowser(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                url = "about:blank";
            }

            // get cache folder
            browser = new ChromiumWebBrowser(url, requestContext)
            {
                Dock = DockStyle.Fill,

                BrowserSettings =    {
                    ApplicationCache = CefState.Enabled,
                    // if not load images Google Analytics dont track visit
                    ImageLoading = CefState.Enabled,
                    //                ImageShrinkStandaloneToFit = CefState.Disabled,
                    //                RemoteFonts = CefState.Disabled,
                    WebSecurity = CefState.Disabled,
                    //                WindowlessFrameRate = 1,
                    FileAccessFromFileUrls = CefState.Enabled,
                    Javascript = CefState.Enabled,
                    JavascriptAccessClipboard = CefState.Enabled,
                    JavascriptCloseWindows = CefState.Enabled,
                    JavascriptDomPaste = CefState.Enabled,
                    AcceptLanguageList = "es-419, es;q=0.8"
                }

            };

            browser.DownloadHandler = new DownloadHandler();
            browser.LoadingStateChanged += OnBrowserLoadingStateChanged;
            browser.ConsoleMessage += OnBrowserConsoleMessage;
            browser.StatusMessage += OnBrowserStatusMessage;
            browser.TitleChanged += OnBrowserTitleChanged;
            browser.AddressChanged += OnBrowserAddressChanged;
            //browser.JavascriptObjectRepository.Register("bound", new BoundObject());

            toolStripContainer.ContentPanel.Controls.Add(browser);
        }

        private void OnBrowserConsoleMessage(object sender, ConsoleMessageEventArgs args)
        {

            string txt = string.Format("Line: {0}, Source: {1}, Message: {2}", args.Line, args.Source, args.Message);
            DisplayOutput(txt);
            Program.LogDebug(txt);
        }

        private void OnBrowserStatusMessage(object sender, StatusMessageEventArgs args)
        {
            this.InvokeOnUiThreadIfRequired(() => statusLabel.Text = args.Value);
            Program.LogInfo(_cacheDirName + " " + args.Value);
        }

        private void OnBrowserLoadingStateChanged(object sender, LoadingStateChangedEventArgs args)
        {
            SetCanGoBack(args.CanGoBack);
            SetCanGoForward(args.CanGoForward);

            this.InvokeOnUiThreadIfRequired(() => SetIsLoading(!args.CanReload));
        }

        // string _pageTitle;
        private void OnBrowserTitleChanged(object sender, TitleChangedEventArgs args)
        {
            /* acehart: generating mscordlib errors from index .length of string:
            _pageTitle = args.Title;

            if (!string.IsNullOrEmpty(_pageTitle)) {
                if (_pageTitle.Contains("about:blank"))
                    _pageTitle = "";
                else
                    _pageTitle.Substring(0, 20);

            this.InvokeOnUiThreadIfRequired(() => Text = _pageTitle);
            }*/

            this.InvokeOnUiThreadIfRequired(() => Text = args.Title);
        }

        private void OnBrowserAddressChanged(object sender, AddressChangedEventArgs args)
        {
            this.InvokeOnUiThreadIfRequired(() => urlTextBox.Text = args.Address);
        }

        private void SetCanGoBack(bool canGoBack)
        {
            this.InvokeOnUiThreadIfRequired(() => backButton.Enabled = canGoBack);
        }

        private void SetCanGoForward(bool canGoForward)
        {
            this.InvokeOnUiThreadIfRequired(() => forwardButton.Enabled = canGoForward);
        }

        private void SetIsLoading(bool isLoading)
        {
            goButton.Text = isLoading ?
                "Stop" :
                "Go";
            goButton.Image = isLoading ?
                SO.Browser.Desktop.Properties.Resources.nav_plain_red :
                SO.Browser.Desktop.Properties.Resources.nav_plain_green;

            HandleToolStripLayout();
        }

        public void DisplayOutput(string output)
        {
            this.InvokeOnUiThreadIfRequired(() => outputLabel.Text = output);
        }

        private void HandleToolStripLayout(object sender, LayoutEventArgs e)
        {
            HandleToolStripLayout();
        }

        private void HandleToolStripLayout()
        {
            int width = toolStrip1.Width;
            foreach (ToolStripItem item in toolStrip1.Items)
            {
                if (item != urlTextBox)
                {
                    width -= item.Width - item.Margin.Horizontal;
                }
            }
            urlTextBox.Width = Math.Max(0, width - urlTextBox.Margin.Horizontal - 18);
        }

        private void ExitMenuItemClick(object sender, EventArgs e)
        {
            browser.Dispose();
            //Cef.Shutdown();
            Close();
        }

        private void GoButtonClick(object sender, EventArgs e)
        {
            LoadUrl(urlTextBox.Text);
        }

        private void BackButtonClick(object sender, EventArgs e)
        {
            browser.Back();
        }

        private void ForwardButtonClick(object sender, EventArgs e)
        {
            browser.Forward();
        }

        private void UrlTextBoxKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            LoadUrl(urlTextBox.Text);
        }

        private void LoadUrl(string url)
        {
            if (!string.IsNullOrEmpty(url) && Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
            {
                browser.Load(url);

            }

        }

    }
}
