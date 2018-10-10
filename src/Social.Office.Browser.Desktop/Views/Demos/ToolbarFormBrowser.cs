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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using CefSharp.WinForms;

namespace SO.Browser.Desktop.Views
{
    public partial class ToolbarFormBrowser : DevExpress.XtraBars.TabForm
    {
        
        private static string defaultUrl = "https://www.google.com";


        public ToolbarFormBrowser()
        {
            InitializeComponent();
            this.Text = "Social Office Browser";

            // SetFirstPage();
            CreateNewTabBrowser(new Uri(defaultUrl));
            // chromiumWebBrowser = new ChromiumWebBrowser("https://www.google.com") { Dock = DockStyle.Fill };
            // tabFormControl1.Pages[0].ContentContainer.Controls.Add(chromiumWebBrowser);

        }


        void CreateBrowser(TabFormPage page, string url) {
            
            if (!string.IsNullOrEmpty(url))
            {
                // System.Windows.Forms.Control.ControlCollection controls

                var chromWebBrowser = new ChromiumWebBrowser(url.ToString()) { Dock = DockStyle.Fill };
                page.ContentContainer.Controls.Add(chromWebBrowser);

            }
            
        }

        void CreateNewTabBrowser(Uri url)
        {

            if (!string.IsNullOrEmpty(url.ToString())
                && Uri.IsWellFormedUriString(url.ToString(), UriKind.RelativeOrAbsolute))
            {
                var tab = new TabFormPage();
                tabFormControl1.Pages.Add(tab);
                
            }

        }


        private void tabFormControl1_PageCreated(object sender, PageCreatedEventArgs e)
        {
            //OpenNewTabBrowser(e.Page.ContentContainer.Controls, new Uri(defaultUrl));
            //e.Page.ContentContainer.Controls.Add(chromWebBrowser);

            CreateNewTabBrowser(new Uri(defaultUrl));
        }
    }
}