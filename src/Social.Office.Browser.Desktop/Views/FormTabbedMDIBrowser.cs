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
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using DevExpress.XtraTabbedMdi;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SO.Browser.Desktop.Views
{
    /// <summary>
    /// Summary description for FormTabbedMDIBrowser.
    /// </summary>
    public partial class FormTabbedMDIBrowser : DevExpress.XtraEditors.XtraForm
    {
        Random rnd = new Random();
        int formCount = 0;
        bool showColourTabs = true;

        public FormTabbedMDIBrowser()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            InitWindows();
            SetDefaultSettings();

        }

        void SetDefaultSettings() {

            xtraTabbedMdiManager1.FloatOnDoubleClick = DefaultBoolean.True;
            xtraTabbedMdiManager1.FloatOnDrag = DefaultBoolean.True;
            xtraTabbedMdiManager1.PinPageButtonShowMode = PinPageButtonShowMode.InActiveTabPageHeader;
            xtraTabbedMdiManager1.PageImagePosition = TabPageImagePosition.Near;
            xtraTabbedMdiManager1.ClosePageButtonShowMode = ClosePageButtonShowMode.InActiveTabPageAndTabControlHeader;

            //xtraTabbedMdiManager1.HeaderLocation;
            //xtraTabbedMdiManager1.HeaderOrientation;
            //xtraTabbedMdiManager1.HeaderAutoFill;
            //xtraTabbedMdiManager1.PinPageButtonShowMode;

#if DEBUG
            barDebug.Visible = true;
#else
            barDebug.Visible = false;
#endif

        }


        void AddNewForm(string url)
        {

            formCount++;
            XtraForm frm = new FormSOBrowser("cachetab" + formCount.ToString(), url)
            {
                Text = string.Format("Form {0}", formCount),
                MdiParent = this
            };
            frm.Show();
            ColourTab();
        }

        void ColourTab()
        {
            if (showColourTabs)
            {
                xtraTabbedMdiManager1.Pages[xtraTabbedMdiManager1.Pages.Count - 1].Appearance.Header.BackColor = TabColor[(formCount - 1) % 6];
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddNewForm(Properties.User.Default.DefaultBrowserURL);
        }

        void InitWindows()
        {
            barMdiChildrenListItem1.Enabled = xtraTabbedMdiManager1.Pages.Count > 0;
            formCount = xtraTabbedMdiManager1.Pages.Count;
        }

        private void xtraTabbedMdiManager1_PageAdded(object sender, DevExpress.XtraTabbedMdi.MdiTabPageEventArgs e)
        {
            InitWindows();
            e.Page.Image = imageList1.Images[rnd.Next(imageList1.Images.Count - 1)];
        }

        private void xtraTabbedMdiManager1_PageRemoved(object sender, DevExpress.XtraTabbedMdi.MdiTabPageEventArgs e)
        {
            InitWindows();
        }
        
        Color[] TabColor = new Color[]{
            Color.FromArgb(35,83,194),
            Color.FromArgb(64,168,19),
            Color.FromArgb(245,121,10),
            Color.FromArgb(141,62,168),
            Color.FromArgb(70,155,183),
            Color.FromArgb(196,19,19)
        };



        private void FormTabbedMDIBrowser_Load(object sender, EventArgs e)
        {
            //for(int i = 0; i < 3; i++) AddNewForm(); // testing only...
            //AddNewForm();

            RestoreTabsForms();
        }

        void RestoreTabsForms()
        {

            string[] urls = Properties.User.Default.TabsURLs.Split('|');

            foreach (string u in urls)
            {
                // not working for full url with protocol ex. https:, need change to regex 
                //if (string.IsNullOrEmpty(u) && Uri.IsWellFormedUriString(u, UriKind.RelativeOrAbsolute))

                if ( !string.IsNullOrEmpty(u)) AddNewForm(u);
                //}
            }

        }



        private void barButtonShowErrorDialog_ItemClick(object sender, ItemClickEventArgs e)
        {
            throw new System.ArgumentException("Parameter cannot be null", "original");

        }

        private void FormTabbedMDIBrowser_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            //save tabs
            SaveTabsForms();
        }

        void SaveTabsForms()
        {
            string urls = string.Empty;
            foreach (FormSOBrowser child in MdiChildren)
            {
                urls += child.GetLoadedUrlMainFrame() + "|";
            }
            Properties.User.Default.TabsURLs = urls;
            Properties.User.Default.Save();

        }



    }
}
