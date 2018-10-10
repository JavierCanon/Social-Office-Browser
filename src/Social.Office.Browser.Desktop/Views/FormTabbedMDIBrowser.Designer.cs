namespace SO.Browser.Desktop.Views
{
    partial class FormTabbedMDIBrowser {
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing) {
            if(disposing) {
                if(components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.Animation.PushTransition pushTransition1 = new DevExpress.Utils.Animation.PushTransition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTabbedMDIBrowser));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barMain = new DevExpress.XtraBars.Bar();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barMdiChildrenListItem1 = new DevExpress.XtraBars.BarMdiChildrenListItem();
            this.barWorkspaceMenuItem1 = new DevExpress.XtraBars.BarWorkspaceMenuItem();
            this.workspaceManager1 = new DevExpress.Utils.WorkspaceManager();
            this.barDebug = new DevExpress.XtraBars.Bar();
            this.barButtonShowErrorDialog = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.bCheckItem = new DevExpress.XtraBars.BarCheckItem();
            this.barEditItem2 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemImageComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.barEditItem3 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemImageComboBox3 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.barEditItem4 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemImageComboBox4 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.barEditItem5 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemImageComboBox5 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.barCheckItem1 = new DevExpress.XtraBars.BarCheckItem();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemImageComboBox6 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.barCheckItem2 = new DevExpress.XtraBars.BarCheckItem();
            this.barEditItem6 = new DevExpress.XtraBars.BarEditItem();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barMain,
            this.bar3,
            this.barDebug});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.barMdiChildrenListItem1,
            this.barEditItem1,
            this.bCheckItem,
            this.barEditItem2,
            this.barEditItem3,
            this.barEditItem4,
            this.barEditItem5,
            this.barCheckItem1,
            this.barButtonShowErrorDialog,
            this.barWorkspaceMenuItem1});
            this.barManager1.MaxItemId = 18;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1,
            this.repositoryItemImageComboBox2,
            this.repositoryItemImageComboBox3,
            this.repositoryItemImageComboBox4,
            this.repositoryItemImageComboBox5,
            this.repositoryItemCheckEdit1,
            this.repositoryItemImageComboBox6});
            // 
            // barMain
            // 
            this.barMain.BarName = "barWindows";
            this.barMain.DockCol = 0;
            this.barMain.DockRow = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.FloatLocation = new System.Drawing.Point(42, 179);
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1)});
            this.barMain.Text = "Principal";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Nueva";
            this.barButtonItem1.Hint = "Abre nueva pestaña";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.ImageOptions.ImageUri.Uri = "AddItem;Office2013";
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "ClosePage Buttons";
            this.bar3.DockCol = 1;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barMdiChildrenListItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barWorkspaceMenuItem1)});
            this.bar3.Offset = 181;
            this.bar3.Text = "ClosePage Buttons";
            // 
            // barMdiChildrenListItem1
            // 
            this.barMdiChildrenListItem1.Caption = "Tabs";
            this.barMdiChildrenListItem1.Hint = "Listado tabs abiertos";
            this.barMdiChildrenListItem1.Id = 1;
            this.barMdiChildrenListItem1.Name = "barMdiChildrenListItem1";
            // 
            // barWorkspaceMenuItem1
            // 
            this.barWorkspaceMenuItem1.Caption = "Workspace";
            this.barWorkspaceMenuItem1.Hint = "Entorno de trabajo";
            this.barWorkspaceMenuItem1.Id = 17;
            this.barWorkspaceMenuItem1.Name = "barWorkspaceMenuItem1";
            this.barWorkspaceMenuItem1.WorkspaceManager = this.workspaceManager1;
            // 
            // workspaceManager1
            // 
            this.workspaceManager1.TargetControl = this;
            this.workspaceManager1.TransitionType = pushTransition1;
            // 
            // barDebug
            // 
            this.barDebug.BarName = "Custom 6";
            this.barDebug.DockCol = 0;
            this.barDebug.DockRow = 1;
            this.barDebug.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barDebug.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonShowErrorDialog)});
            this.barDebug.Text = "Custom 6";
            // 
            // barButtonShowErrorDialog
            // 
            this.barButtonShowErrorDialog.Caption = "ShowErrorDialog";
            this.barButtonShowErrorDialog.Id = 16;
            this.barButtonShowErrorDialog.Name = "barButtonShowErrorDialog";
            this.barButtonShowErrorDialog.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonShowErrorDialog_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlTop.Size = new System.Drawing.Size(1122, 65);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 577);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlBottom.Size = new System.Drawing.Size(1122, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 65);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 512);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1122, 65);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 512);
            // 
            // barEditItem1
            // 
            this.barEditItem1.Caption = "Header Location";
            this.barEditItem1.Edit = this.repositoryItemImageComboBox1;
            this.barEditItem1.Id = 5;
            this.barEditItem1.Name = "barEditItem1";
            this.barEditItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.Caption;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            // 
            // bCheckItem
            // 
            this.bCheckItem.BindableChecked = true;
            this.bCheckItem.Caption = "Colored Tabs";
            this.bCheckItem.Checked = true;
            this.bCheckItem.Id = 4;
            this.bCheckItem.Name = "bCheckItem";
            // 
            // barEditItem2
            // 
            this.barEditItem2.Caption = "Header Orientation";
            this.barEditItem2.Edit = this.repositoryItemImageComboBox2;
            this.barEditItem2.Id = 6;
            this.barEditItem2.Name = "barEditItem2";
            this.barEditItem2.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.Caption;
            // 
            // repositoryItemImageComboBox2
            // 
            this.repositoryItemImageComboBox2.AutoHeight = false;
            this.repositoryItemImageComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox2.Name = "repositoryItemImageComboBox2";
            // 
            // barEditItem3
            // 
            this.barEditItem3.Caption = "Page Image Position";
            this.barEditItem3.Edit = this.repositoryItemImageComboBox3;
            this.barEditItem3.Id = 7;
            this.barEditItem3.Name = "barEditItem3";
            this.barEditItem3.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.Caption;
            // 
            // repositoryItemImageComboBox3
            // 
            this.repositoryItemImageComboBox3.AutoHeight = false;
            this.repositoryItemImageComboBox3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox3.Name = "repositoryItemImageComboBox3";
            // 
            // barEditItem4
            // 
            this.barEditItem4.Caption = "Header AutoFill";
            this.barEditItem4.Edit = this.repositoryItemImageComboBox4;
            this.barEditItem4.Id = 8;
            this.barEditItem4.Name = "barEditItem4";
            this.barEditItem4.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.Caption;
            // 
            // repositoryItemImageComboBox4
            // 
            this.repositoryItemImageComboBox4.AutoHeight = false;
            this.repositoryItemImageComboBox4.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox4.Name = "repositoryItemImageComboBox4";
            // 
            // barEditItem5
            // 
            this.barEditItem5.Caption = "Close Page Button";
            this.barEditItem5.Edit = this.repositoryItemImageComboBox5;
            this.barEditItem5.EditWidth = 120;
            this.barEditItem5.Id = 10;
            this.barEditItem5.Name = "barEditItem5";
            this.barEditItem5.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.Caption;
            // 
            // repositoryItemImageComboBox5
            // 
            this.repositoryItemImageComboBox5.AutoHeight = false;
            this.repositoryItemImageComboBox5.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox5.Name = "repositoryItemImageComboBox5";
            // 
            // barCheckItem1
            // 
            this.barCheckItem1.Caption = "FloatOnDoubleClick";
            this.barCheckItem1.Id = 13;
            this.barCheckItem1.Name = "barCheckItem1";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "Check";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // repositoryItemImageComboBox6
            // 
            this.repositoryItemImageComboBox6.AutoHeight = false;
            this.repositoryItemImageComboBox6.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox6.Name = "repositoryItemImageComboBox6";
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageHeader;
            this.xtraTabbedMdiManager1.FloatOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
            this.xtraTabbedMdiManager1.FloatOnDrag = DevExpress.Utils.DefaultBoolean.True;
            this.xtraTabbedMdiManager1.MdiParent = this;
            this.xtraTabbedMdiManager1.PageAdded += new DevExpress.XtraTabbedMdi.MdiTabPageEventHandler(this.xtraTabbedMdiManager1_PageAdded);
            this.xtraTabbedMdiManager1.PageRemoved += new DevExpress.XtraTabbedMdi.MdiTabPageEventHandler(this.xtraTabbedMdiManager1_PageRemoved);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            // 
            // barCheckItem2
            // 
            this.barCheckItem2.Caption = "FloatOnDrag";
            this.barCheckItem2.Id = 14;
            this.barCheckItem2.Name = "barCheckItem2";
            // 
            // barEditItem6
            // 
            this.barEditItem6.Caption = "Show Pin Tab";
            this.barEditItem6.Edit = this.repositoryItemImageComboBox6;
            this.barEditItem6.EditWidth = 85;
            this.barEditItem6.Id = 15;
            this.barEditItem6.Name = "barEditItem6";
            this.barEditItem6.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.Caption;
            // 
            // FormTabbedMDIBrowser
            // 
            this.ActiveGlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 577);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FormTabbedMDIBrowser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Social Browser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTabbedMDIBrowser_FormClosing);
            this.Load += new System.EventHandler(this.FormTabbedMDIBrowser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarCheckItem bCheckItem;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarMdiChildrenListItem barMdiChildrenListItem1;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraBars.BarEditItem barEditItem2;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox2;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraBars.BarEditItem barEditItem3;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox3;
        private DevExpress.XtraBars.BarEditItem barEditItem4;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox4;
        private System.ComponentModel.IContainer components;
        private DevExpress.XtraBars.BarEditItem barEditItem5;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox5;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraBars.BarCheckItem barCheckItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox6;
        private DevExpress.XtraBars.Bar barDebug;
        private DevExpress.XtraBars.BarButtonItem barButtonShowErrorDialog;
        private DevExpress.Utils.WorkspaceManager workspaceManager1;
        private DevExpress.XtraBars.BarWorkspaceMenuItem barWorkspaceMenuItem1;
        private DevExpress.XtraBars.BarCheckItem barCheckItem2;
        private DevExpress.XtraBars.BarEditItem barEditItem6;
    }
}
