namespace Receipt
{
    partial class DialogForm
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
            this.cboVehicle = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cboCompany = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearchSite = new DevExpress.XtraEditors.TextEdit();
            this.txtDispenser = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtQuantity = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotalizerCount = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.txtItemName = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.lstCustomer = new DevExpress.XtraEditors.ListBoxControl();
            this.popupControlContainer1 = new DevExpress.XtraBars.PopupControlContainer(this.components);
            this.btnClosePopUp = new DevExpress.XtraEditors.SimpleButton();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSiteNumber = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.cboVehicle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchSite.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDispenser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalizerCount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupControlContainer1)).BeginInit();
            this.popupControlContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSiteNumber.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cboVehicle
            // 
            this.cboVehicle.Location = new System.Drawing.Point(10, 332);
            this.cboVehicle.Name = "cboVehicle";
            this.cboVehicle.Properties.AutoHeight = false;
            this.cboVehicle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboVehicle.Properties.NullText = "Машин сонгоно уу";
            this.cboVehicle.Properties.ReadOnly = true;
            this.cboVehicle.Size = new System.Drawing.Size(260, 30);
            this.cboVehicle.TabIndex = 11;
            this.cboVehicle.EditValueChanged += new System.EventHandler(this.cboVehicle_EditValueChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(10, 313);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(39, 13);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "МАШИН";
            // 
            // cboCompany
            // 
            this.cboCompany.Location = new System.Drawing.Point(10, 277);
            this.cboCompany.Name = "cboCompany";
            this.cboCompany.Properties.AutoHeight = false;
            this.cboCompany.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCompany.Properties.NullText = "Компани сонгоно уу";
            this.cboCompany.Properties.ReadOnly = true;
            this.cboCompany.Size = new System.Drawing.Size(260, 30);
            this.cboCompany.TabIndex = 9;
            this.cboCompany.EditValueChanged += new System.EventHandler(this.cboCompany_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(10, 261);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(93, 13);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "ХУДАЛДАН АВАГЧ";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(172, 367);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(98, 33);
            this.btnPrint.TabIndex = 7;
            this.btnPrint.Text = "Баримт хэвлэх";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "ТҮГЭЭГҮҮРИЙН №";
            // 
            // txtSearchSite
            // 
            this.txtSearchSite.Location = new System.Drawing.Point(10, 176);
            this.txtSearchSite.Name = "txtSearchSite";
            this.txtSearchSite.Properties.AutoHeight = false;
            this.txtSearchSite.Size = new System.Drawing.Size(260, 30);
            this.txtSearchSite.TabIndex = 13;
            this.txtSearchSite.EditValueChanged += new System.EventHandler(this.txtSearchSite_EditValueChanged);
            // 
            // txtDispenser
            // 
            this.txtDispenser.Location = new System.Drawing.Point(9, 25);
            this.txtDispenser.Name = "txtDispenser";
            this.txtDispenser.Properties.AutoHeight = false;
            this.txtDispenser.Properties.ReadOnly = true;
            this.txtDispenser.Size = new System.Drawing.Size(128, 30);
            this.txtDispenser.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(7, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "САЙТ ДУГААРААР ХАЙХ";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(9, 127);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Properties.AutoHeight = false;
            this.txtQuantity.Properties.ReadOnly = true;
            this.txtQuantity.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtQuantity.Size = new System.Drawing.Size(128, 30);
            this.txtQuantity.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(7, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "ШАТАХУУНЫ ХЭМЖЭЭ";
            // 
            // txtTotalizerCount
            // 
            this.txtTotalizerCount.Location = new System.Drawing.Point(142, 127);
            this.txtTotalizerCount.Name = "txtTotalizerCount";
            this.txtTotalizerCount.Properties.AutoHeight = false;
            this.txtTotalizerCount.Properties.ReadOnly = true;
            this.txtTotalizerCount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotalizerCount.Size = new System.Drawing.Size(128, 30);
            this.txtTotalizerCount.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(139, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "ЭЦСИЙН МИЛЛЬ";
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(9, 76);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Properties.AutoHeight = false;
            this.txtItemName.Properties.ReadOnly = true;
            this.txtItemName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtItemName.Size = new System.Drawing.Size(261, 30);
            this.txtItemName.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(7, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "ШАТАХУУН";
            // 
            // lstCustomer
            // 
            this.lstCustomer.Dock = System.Windows.Forms.DockStyle.Top;
            this.lstCustomer.ItemAutoHeight = true;
            this.lstCustomer.Location = new System.Drawing.Point(0, 0);
            this.lstCustomer.Name = "lstCustomer";
            this.lstCustomer.Size = new System.Drawing.Size(260, 105);
            this.lstCustomer.TabIndex = 22;
            this.lstCustomer.SelectedValueChanged += new System.EventHandler(this.lstCustomer_SelectedValueChanged);
            this.lstCustomer.MouseLeave += new System.EventHandler(this.lstCustomer_MouseLeave);
            // 
            // popupControlContainer1
            // 
            this.popupControlContainer1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.popupControlContainer1.Controls.Add(this.btnClosePopUp);
            this.popupControlContainer1.Controls.Add(this.lstCustomer);
            this.popupControlContainer1.Location = new System.Drawing.Point(10, 208);
            this.popupControlContainer1.Name = "popupControlContainer1";
            this.popupControlContainer1.Size = new System.Drawing.Size(260, 130);
            this.popupControlContainer1.TabIndex = 23;
            this.popupControlContainer1.Visible = false;
            // 
            // btnClosePopUp
            // 
            this.btnClosePopUp.Location = new System.Drawing.Point(218, 107);
            this.btnClosePopUp.Name = "btnClosePopUp";
            this.btnClosePopUp.Size = new System.Drawing.Size(40, 20);
            this.btnClosePopUp.TabIndex = 23;
            this.btnClosePopUp.Text = "Хаах";
            this.btnClosePopUp.Click += new System.EventHandler(this.btnClosePopUp_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(6, 209);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "САЙТ ДУГААР";
            // 
            // txtSiteNumber
            // 
            this.txtSiteNumber.Location = new System.Drawing.Point(9, 225);
            this.txtSiteNumber.Name = "txtSiteNumber";
            this.txtSiteNumber.Properties.AutoHeight = false;
            this.txtSiteNumber.Properties.ReadOnly = true;
            this.txtSiteNumber.Size = new System.Drawing.Size(260, 30);
            this.txtSiteNumber.TabIndex = 24;
            this.txtSiteNumber.EditValueChanged += new System.EventHandler(this.txtSiteNumber_EditValueChanged);
            // 
            // DialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 412);
            this.Controls.Add(this.popupControlContainer1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSiteNumber);
            this.Controls.Add(this.txtItemName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTotalizerCount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDispenser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSearchSite);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboVehicle);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.cboCompany);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnPrint);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "DialogForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Хэвлэх хэсэг";
            this.Load += new System.EventHandler(this.DialogForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DialogForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.cboVehicle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchSite.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDispenser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalizerCount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupControlContainer1)).EndInit();
            this.popupControlContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSiteNumber.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit cboVehicle;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit cboCompany;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtSearchSite;
        private DevExpress.XtraEditors.TextEdit txtDispenser;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtQuantity;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txtTotalizerCount;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit txtItemName;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.ListBoxControl lstCustomer;
        private DevExpress.XtraBars.PopupControlContainer popupControlContainer1;
        private DevExpress.XtraEditors.SimpleButton btnClosePopUp;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.TextEdit txtSiteNumber;
    }
}