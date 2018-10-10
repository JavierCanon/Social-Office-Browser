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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.Browser.Desktop.Presenters.Settings
{
    class SettingsFormPresenter
    {
        //TODO: users settings

        /*
        void InitComboBoxes()
        {
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

        private void barEditItem1_EditValueChanged(object sender, System.EventArgs e)
        {
            xtraTabbedMdiManager1.HeaderLocation = (TabHeaderLocation)barEditItem1.EditValue;
        }

        private void barEditItem2_EditValueChanged(object sender, System.EventArgs e)
        {
            xtraTabbedMdiManager1.HeaderOrientation = (TabOrientation)barEditItem2.EditValue;
        }

        private void barEditItem3_EditValueChanged(object sender, System.EventArgs e)
        {
            xtraTabbedMdiManager1.PageImagePosition = (TabPageImagePosition)barEditItem3.EditValue;
        }

        private void barEditItem4_EditValueChanged(object sender, System.EventArgs e)
        {
            xtraTabbedMdiManager1.HeaderAutoFill = (DefaultBoolean)barEditItem4.EditValue;
        }

        private void barEditItem5_EditValueChanged(object sender, EventArgs e)
        {
            xtraTabbedMdiManager1.ClosePageButtonShowMode = (ClosePageButtonShowMode)barEditItem5.EditValue;
        }

        private void barEditItem6_EditValueChanged(object sender, EventArgs e)
        {
            xtraTabbedMdiManager1.PinPageButtonShowMode = (PinPageButtonShowMode)barEditItem6.EditValue;
        }

        private void barCheckItem1_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            xtraTabbedMdiManager1.FloatOnDoubleClick = barCheckItem1.Checked ? DefaultBoolean.True : DefaultBoolean.False;
        }

        private void barCheckItem2_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            xtraTabbedMdiManager1.FloatOnDrag = barCheckItem2.Checked ? DefaultBoolean.True : DefaultBoolean.False;
        }

        private void bCheckItem_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            BarCheckItem item = sender as BarCheckItem;
            int j = 0;
            if (item.Checked)
            {
                foreach (XtraMdiTabPage page in xtraTabbedMdiManager1.Pages)
                {
                    page.Appearance.Header.BackColor = TabColor[j % 6];
                    j++;
                }
            }
            else
            {
                foreach (XtraMdiTabPage page in xtraTabbedMdiManager1.Pages)
                {
                    page.Appearance.Header.BackColor = Color.Empty;
                }
            }
        }

    */
    }
}
