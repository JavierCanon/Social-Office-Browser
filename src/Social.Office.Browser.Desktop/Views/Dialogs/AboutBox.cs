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
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace CefSharp.WinForms.Example
{
    partial class AboutBox : Form
    {
        private Assembly ExecutingAssembly { get; set; }

        public string AssemblyTitle
        {
            get
            {
                var attributes = ExecutingAssembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length == 0)
                {
                    return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
                }

                var titleAttribute = (AssemblyTitleAttribute)attributes[0];
                return titleAttribute.Title != "" ? titleAttribute.Title : Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return ExecutingAssembly.GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                var attributes = ExecutingAssembly.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                return attributes.Length == 0 ? "" : ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                var attributes = ExecutingAssembly.GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                return attributes.Length == 0 ? "" : ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                var attributes = ExecutingAssembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                return attributes.Length == 0 ? "" : ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                var attributes = ExecutingAssembly.GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                return attributes.Length == 0 ? "" : ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }

        public AboutBox()
        {
            InitializeComponent();
            ExecutingAssembly = Assembly.GetExecutingAssembly();

            Text = "About CefTest";
            labelProductName.Text = AssemblyProduct;
            labelVersion.Text = String.Format("Version {0} ", Cef.CefSharpVersion);
            labelCopyright.Text = AssemblyCopyright;
            labelCompanyName.Text = AssemblyCompany;
            textBoxDescription.Text = "CefSharp - .Net binding for Chromium\r\n\r\n"
                + "Built on Chromium Embedded Framework\r\n"
                + "   - " + Cef.CefVersion + "\r\n"
                + "Built on Chromium\r\n"
                + "   - " + Cef.ChromiumVersion + "\r\n";
        }
    }
}
