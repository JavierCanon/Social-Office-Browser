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
using DevExpress.XtraTab;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraTabbedMdi;
using DevExpress.XtraBars;

namespace SO.Browser.Desktop.Views
{
    /// <summary>
    /// Summary description for FormTabbedMDI.
    /// </summary>
    public partial class FormTabbedMDI : DevExpress.XtraEditors.XtraForm {
        public FormTabbedMDI() {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            InitWindows();
            for(int i = 0; i < 3; i++) AddNewForm();
            InitComboBoxes();
            barCheckItem1.Checked = xtraTabbedMdiManager1.FloatOnDoubleClick == DefaultBoolean.True;
            barCheckItem2.Checked = xtraTabbedMdiManager1.FloatOnDrag == DefaultBoolean.True;
            //Icon = DevExpress.Utils.ResourceImageHelper.CreateIconFromResourcesEx("DevExpress.ApplicationUI.Demos.AppIcon.ico", typeof(frmMain).Assembly);
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        Random rnd = new Random();
        int formCount = 0;

        void InitComboBoxes() {
            repositoryItemImageComboBox1.Items.AddEnum(typeof(TabHeaderLocation));
            repositoryItemImageComboBox2.Items.AddEnum(typeof(TabOrientation));
            repositoryItemImageComboBox3.Items.AddEnum(typeof(TabPageImagePosition));
            repositoryItemImageComboBox4.Items.AddEnum(typeof(DefaultBoolean));
            repositoryItemImageComboBox5.Items.AddEnum(typeof(ClosePageButtonShowMode));
            repositoryItemImageComboBox6.Items.AddEnum(typeof(PinPageButtonShowMode));

            barEditItem1.EditValue = xtraTabbedMdiManager1.HeaderLocation;
            barEditItem2.EditValue = xtraTabbedMdiManager1.HeaderOrientation;
            barEditItem3.EditValue = xtraTabbedMdiManager1.PageImagePosition;
            barEditItem4.EditValue = xtraTabbedMdiManager1.HeaderAutoFill;
            barEditItem5.EditValue = xtraTabbedMdiManager1.ClosePageButtonShowMode;
            barEditItem6.EditValue = xtraTabbedMdiManager1.PinPageButtonShowMode;
        }

        void AddNewForm() {
            XtraForm frm = new XtraForm();
            frm.Text = string.Format("Form {0}", formCount++);
            frm.MdiParent = this;
            frm.Show();
            ColourTab();
        }
        void ColourTab() {
            if(bCheckItem.Checked)
                xtraTabbedMdiManager1.Pages[xtraTabbedMdiManager1.Pages.Count - 1].Appearance.Header.BackColor = TabColor[(formCount - 1) % 6];
        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            AddNewForm();
        }
        void InitWindows() {
            barMdiChildrenListItem1.Enabled = xtraTabbedMdiManager1.Pages.Count > 0;
        }

        private void xtraTabbedMdiManager1_PageAdded(object sender, DevExpress.XtraTabbedMdi.MdiTabPageEventArgs e) {
            InitWindows();
            e.Page.Image = imageList1.Images[rnd.Next(imageList1.Images.Count - 1)];
        }

        private void xtraTabbedMdiManager1_PageRemoved(object sender, DevExpress.XtraTabbedMdi.MdiTabPageEventArgs e) {
            InitWindows();
        }

        private void barEditItem1_EditValueChanged(object sender, System.EventArgs e) {
            xtraTabbedMdiManager1.HeaderLocation = (TabHeaderLocation)barEditItem1.EditValue;
        }

        private void barEditItem2_EditValueChanged(object sender, System.EventArgs e) {
            xtraTabbedMdiManager1.HeaderOrientation = (TabOrientation)barEditItem2.EditValue;
        }

        private void barEditItem3_EditValueChanged(object sender, System.EventArgs e) {
            xtraTabbedMdiManager1.PageImagePosition = (TabPageImagePosition)barEditItem3.EditValue;
        }

        private void barEditItem4_EditValueChanged(object sender, System.EventArgs e) {
            xtraTabbedMdiManager1.HeaderAutoFill = (DefaultBoolean)barEditItem4.EditValue;
        }

        private void barEditItem5_EditValueChanged(object sender, EventArgs e) {
            xtraTabbedMdiManager1.ClosePageButtonShowMode = (ClosePageButtonShowMode)barEditItem5.EditValue;
        }

        private void barEditItem6_EditValueChanged(object sender, EventArgs e) {
            xtraTabbedMdiManager1.PinPageButtonShowMode = (PinPageButtonShowMode)barEditItem6.EditValue;
        }

        private void barCheckItem1_CheckedChanged(object sender, ItemClickEventArgs e) {
            xtraTabbedMdiManager1.FloatOnDoubleClick = barCheckItem1.Checked ? DefaultBoolean.True : DefaultBoolean.False;
        }

        private void barCheckItem2_CheckedChanged(object sender, ItemClickEventArgs e) {
            xtraTabbedMdiManager1.FloatOnDrag = barCheckItem2.Checked ? DefaultBoolean.True : DefaultBoolean.False;
        }

        Color[] TabColor = new Color[]{
            Color.FromArgb(35,83,194),
            Color.FromArgb(64,168,19),
            Color.FromArgb(245,121,10),
            Color.FromArgb(141,62,168),
            Color.FromArgb(70,155,183),
            Color.FromArgb(196,19,19)
        };
        private void bCheckItem_CheckedChanged(object sender, ItemClickEventArgs e) {
            BarCheckItem item = sender as BarCheckItem;
            int j = 0;
            if(item.Checked) {
                foreach(XtraMdiTabPage page in xtraTabbedMdiManager1.Pages) {
                    page.Appearance.Header.BackColor = TabColor[j % 6];
                    j++;
                }
            }
            else {
                foreach(XtraMdiTabPage page in xtraTabbedMdiManager1.Pages) {
                    page.Appearance.Header.BackColor = Color.Empty;
                }
            }
        }

    }
}
