namespace Receipt
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.tabControl = new DevExpress.XtraTab.XtraTabControl();
            this.pageTrade = new DevExpress.XtraTab.XtraTabPage();
            this.btnStart = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pageNozzle = new DevExpress.XtraTab.XtraTabPage();
            this.progress = new DevExpress.XtraEditors.ProgressBarControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.menuMain = new DevExpress.XtraBars.BarSubItem();
            this.subVatSales = new DevExpress.XtraBars.BarButtonItem();
            this.subExit = new DevExpress.XtraBars.BarButtonItem();
            this.menuTax = new DevExpress.XtraBars.BarSubItem();
            this.subVatSend = new DevExpress.XtraBars.BarButtonItem();
            this.subVatInfo = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.subLoadConfig = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).BeginInit();
            this.tabControl.SuspendLayout();
            this.pageTrade.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.tabControl);
            this.panelControl1.Controls.Add(this.progress);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 22);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(948, 516);
            this.panelControl1.TabIndex = 2;
            // 
            // tabControl
            // 
            this.tabControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedTabPage = this.pageTrade;
            this.tabControl.Size = new System.Drawing.Size(948, 508);
            this.tabControl.TabIndex = 7;
            this.tabControl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.pageTrade,
            this.pageNozzle});
            // 
            // pageTrade
            // 
            this.pageTrade.Controls.Add(this.btnStart);
            this.pageTrade.Controls.Add(this.gridControl1);
            this.pageTrade.Name = "pageTrade";
            this.pageTrade.Size = new System.Drawing.Size(942, 480);
            this.pageTrade.Text = "Түгээлтийн мэдээлэл";
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnStart.Location = new System.Drawing.Point(908, 23);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(33, 33);
            this.btnStart.TabIndex = 4;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(942, 480);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsView.ShowViewCaption = true;
            this.gridView1.ViewCaption = "Түгээлтийн мэдээлэл";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "№";
            this.gridColumn2.FieldName = "TradeId";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Огноо";
            this.gridColumn1.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn1.FieldName = "TradeDate";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Шатахууны №";
            this.gridColumn3.FieldName = "ItemCode";
            this.gridColumn3.Name = "gridColumn3";
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Шатахуун";
            this.gridColumn4.FieldName = "ItemName";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Түгээгүүр";
            this.gridColumn5.FieldName = "DispenserNo";
            this.gridColumn5.Name = "gridColumn5";
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Хошуу";
            this.gridColumn6.FieldName = "NozzleNo";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 2;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Литр";
            this.gridColumn7.FieldName = "Quantity";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 3;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Нэгж үнэ";
            this.gridColumn8.FieldName = "UnitPrice";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 4;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Нийт дүн";
            this.gridColumn9.FieldName = "TotalAmount";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 5;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Милль заалт";
            this.gridColumn10.FieldName = "TotalizerCount";
            this.gridColumn10.Name = "gridColumn10";
            // 
            // pageNozzle
            // 
            this.pageNozzle.Name = "pageNozzle";
            this.pageNozzle.Size = new System.Drawing.Size(942, 480);
            this.pageNozzle.Text = "Хошууны мэдээлэл";
            // 
            // progress
            // 
            this.progress.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progress.Location = new System.Drawing.Point(0, 508);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(948, 8);
            this.progress.TabIndex = 5;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.menuMain,
            this.subVatSales,
            this.subExit,
            this.barButtonItem3,
            this.menuTax,
            this.subVatSend,
            this.subVatInfo,
            this.barSubItem1,
            this.subLoadConfig});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 14;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.menuMain),
            new DevExpress.XtraBars.LinkPersistInfo(this.menuTax),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem1)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // menuMain
            // 
            this.menuMain.Caption = "Цэс";
            this.menuMain.Id = 4;
            this.menuMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.subVatSales),
            new DevExpress.XtraBars.LinkPersistInfo(this.subExit)});
            this.menuMain.Name = "menuMain";
            // 
            // subVatSales
            // 
            this.subVatSales.Caption = "НӨАТ борлуулалт";
            this.subVatSales.Id = 5;
            this.subVatSales.Name = "subVatSales";
            this.subVatSales.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.subVatSales_ItemClick);
            // 
            // subExit
            // 
            this.subExit.Caption = "Програмыг хаах";
            this.subExit.Id = 6;
            this.subExit.Name = "subExit";
            this.subExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.subExit_ItemClick);
            // 
            // menuTax
            // 
            this.menuTax.Caption = "Татвар";
            this.menuTax.Id = 8;
            this.menuTax.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.subVatSend),
            new DevExpress.XtraBars.LinkPersistInfo(this.subVatInfo)});
            this.menuTax.Name = "menuTax";
            // 
            // subVatSend
            // 
            this.subVatSend.Caption = "Татварт мэдээ илгээх";
            this.subVatSend.Id = 9;
            this.subVatSend.Name = "subVatSend";
            this.subVatSend.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.subVatSend_ItemClick);
            // 
            // subVatInfo
            // 
            this.subVatInfo.Caption = "Мэдээлэл харах";
            this.subVatInfo.Id = 10;
            this.subVatInfo.Name = "subVatInfo";
            this.subVatInfo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.subVatInfo_ItemClick);
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Тохиргоо";
            this.barSubItem1.Id = 12;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.subLoadConfig)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // subLoadConfig
            // 
            this.subLoadConfig.Caption = "Тохиргоо татах";
            this.subLoadConfig.Id = 13;
            this.subLoadConfig.Name = "subLoadConfig";
            this.subLoadConfig.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.subLoadConfig_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(948, 22);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 538);
            this.barDockControlBottom.Size = new System.Drawing.Size(948, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 22);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 516);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(948, 22);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 516);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Татвар";
            this.barButtonItem3.Id = 7;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 561);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Баримт хэвлэгч";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.pageTrade.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnStart;
        private DevExpress.XtraEditors.ProgressBarControl progress;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarSubItem menuMain;
        private DevExpress.XtraBars.BarButtonItem subVatSales;
        private DevExpress.XtraBars.BarButtonItem subExit;
        private DevExpress.XtraBars.BarSubItem menuTax;
        private DevExpress.XtraBars.BarButtonItem subVatSend;
        private DevExpress.XtraBars.BarButtonItem subVatInfo;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem subLoadConfig;
        private DevExpress.XtraTab.XtraTabControl tabControl;
        private DevExpress.XtraTab.XtraTabPage pageTrade;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraTab.XtraTabPage pageNozzle;
    }
}

