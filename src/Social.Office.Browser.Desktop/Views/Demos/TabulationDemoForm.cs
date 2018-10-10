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
using System.Drawing;
using System.Windows.Forms;

namespace CefSharp.WinForms.Example.Minimal
{
    public partial class TabulationDemoForm : Form
    {
        private readonly ChromiumWebBrowser chromiumWebBrowser;
        private readonly Color focusColor = Color.Yellow;
        private readonly Color nonFocusColor = Color.White;

        public TabulationDemoForm()
        {
            InitializeComponent();
            chromiumWebBrowser = new ChromiumWebBrowser(txtURL.Text) { Dock = DockStyle.Fill };
            var userControl = new UserControl { Dock = DockStyle.Fill };
            userControl.Enter += UserControlEnter;
            userControl.Leave += UserControlLeave;
            userControl.Controls.Add(chromiumWebBrowser);
            txtURL.GotFocus += TxtUrlGotFocus;
            txtURL.LostFocus += TxtUrlLostFocus;
            grpBrowser.Controls.Add(userControl);
        }

        private void TxtUrlLostFocus(object sender, EventArgs e)
        {
            // Uncomment this if you want the address bar to go white
            // during deactivation:
            //UpdateUrlColor(nonFocusColor);
        }

        private void TxtUrlGotFocus(object sender, EventArgs e)
        {
            // Ensure the control turns yellow on form
            // activation (since Enter events don't fire then)
            UpdateUrlColor(focusColor);
        }

        private void UpdateUrlColor(Color color)
        {
            if (txtURL.BackColor != color)
            {
                txtURL.BackColor = color;
            }
        }

        private void UserControlLeave(object sender, EventArgs e)
        {
            txtDummy.Text = "UserControl OnLeave";
        }

        private void UserControlEnter(object sender, EventArgs e)
        {
            txtDummy.Text = "UserControl OnEnter";
        }

        private void BtnGoClick(object sender, EventArgs e)
        {
            chromiumWebBrowser.Load(txtURL.Text);
        }

        private void TxtUrlLeave(object sender, EventArgs e)
        {
            UpdateUrlColor(nonFocusColor);
        }

        private void TxtUrlEnter(object sender, EventArgs e)
        {
            UpdateUrlColor(focusColor);
        }
    }
}
