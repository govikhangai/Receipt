namespace Receipt
{
    partial class frmVehicle
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtVehicleId = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtVehicleNumber = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDriverName = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.btnNew = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new System.Windows.Forms.Label();
            this.cboCompany = new DevExpress.XtraEditors.LookUpEdit();
            this.txtSiteNumber = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVehicleId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVehicleNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDriverName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSiteNumber.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(555, 491);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn8,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this.gridView1.RowCountChanged += new System.EventHandler(this.gridView1_RowCountChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "№";
            this.gridColumn1.FieldName = "VehicleId";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Компани №";
            this.gridColumn2.FieldName = "CompanyId";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Компани нэр";
            this.gridColumn3.FieldName = "CompanyName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Машины №";
            this.gridColumn4.FieldName = "VehicleNumber";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Жолооч";
            this.gridColumn5.FieldName = "DriverName";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Бүртгэсэн огноо";
            this.gridColumn6.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn6.FieldName = "CreatedDate";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Засварласан огноо";
            this.gridColumn7.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn7.FieldName = "UpdatedDate";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 7;
            // 
            // txtVehicleId
            // 
            this.txtVehicleId.Location = new System.Drawing.Point(564, 26);
            this.txtVehicleId.Name = "txtVehicleId";
            this.txtVehicleId.Properties.AutoHeight = false;
            this.txtVehicleId.Properties.ReadOnly = true;
            this.txtVehicleId.Size = new System.Drawing.Size(161, 30);
            this.txtVehicleId.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(561, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "№";
            // 
            // txtVehicleNumber
            // 
            this.txtVehicleNumber.Location = new System.Drawing.Point(564, 126);
            this.txtVehicleNumber.Name = "txtVehicleNumber";
            this.txtVehicleNumber.Properties.AutoHeight = false;
            this.txtVehicleNumber.Size = new System.Drawing.Size(161, 30);
            this.txtVehicleNumber.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(561, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Машины дугаар";
            // 
            // txtDriverName
            // 
            this.txtDriverName.Location = new System.Drawing.Point(564, 225);
            this.txtDriverName.Name = "txtDriverName";
            this.txtDriverName.Properties.AutoHeight = false;
            this.txtDriverName.Size = new System.Drawing.Size(161, 30);
            this.txtDriverName.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(561, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Жолооч";
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(564, 261);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(96, 26);
            this.btnNew.TabIndex = 22;
            this.btnNew.Text = "Шинээр бүртгэх";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(666, 261);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(59, 26);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "Болих";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(564, 293);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(96, 26);
            this.btnEdit.TabIndex = 24;
            this.btnEdit.Text = "Засварлах";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(666, 293);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(59, 26);
            this.btnDelete.TabIndex = 25;
            this.btnDelete.Text = "Устгах";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(561, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Компани";
            // 
            // cboCompany
            // 
            this.cboCompany.Location = new System.Drawing.Point(564, 76);
            this.cboCompany.Name = "cboCompany";
            this.cboCompany.Properties.AutoHeight = false;
            this.cboCompany.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCompany.Properties.NullText = "Компани сонгоно уу";
            this.cboCompany.Size = new System.Drawing.Size(161, 30);
            this.cboCompany.TabIndex = 27;
            // 
            // txtSiteNumber
            // 
            this.txtSiteNumber.Location = new System.Drawing.Point(564, 175);
            this.txtSiteNumber.Name = "txtSiteNumber";
            this.txtSiteNumber.Properties.AutoHeight = false;
            this.txtSiteNumber.Size = new System.Drawing.Size(161, 30);
            this.txtSiteNumber.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(561, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Сайт дугаар";
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Сайт №";
            this.gridColumn8.FieldName = "SiteNumber";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 4;
            // 
            // frmVehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 491);
            this.Controls.Add(this.txtSiteNumber);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboCompany);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.txtDriverName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtVehicleNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtVehicleId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridControl1);
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(750, 530);
            this.MinimumSize = new System.Drawing.Size(750, 530);
            this.Name = "frmVehicle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Компани бүртгэл, жагсаалт";
            this.Load += new System.EventHandler(this.frmCompany_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmVehicle_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVehicleId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVehicleNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDriverName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSiteNumber.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.TextEdit txtVehicleId;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtVehicleNumber;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtDriverName;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton btnNew;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.LookUpEdit cboCompany;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.TextEdit txtSiteNumber;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
    }
}