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
using System.Windows.Forms;

namespace CefSharp.WinForms.Example
{
    public partial class InputBox : Form
    {
        public InputBox()
        {
            InitializeComponent();
        }

        public event EventHandler OnEvaluate
        {
            add { _evaluate.Click += value; }
            remove { _evaluate.Click -= value; }
        }

        public string Instructions
        {
            get { return _instructions.Text; }
            set { _instructions.Text = value; }
        }

        public string Result
        {
            get { return _result.Text; }
            set { _result.Text = value; }
        }

        public string Title
        {
            set { Text = "Evaluate script - " + value; }
        }

        public string Value
        {
            get { return _value.Text; }
            set { _value.Text = value; }
        }

        private void _close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
