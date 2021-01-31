namespace Receipt
{
    partial class DialogVat
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.btnCash = new DevExpress.XtraEditors.SimpleButton();
            this.btnCard = new DevExpress.XtraEditors.SimpleButton();
            this.btnOther = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtDiscountAmount = new DevExpress.XtraEditors.TextEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDate = new DevExpress.XtraEditors.TextEdit();
            this.txtNozzle = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTotalAmount = new DevExpress.XtraEditors.TextEdit();
            this.txtQuantity = new DevExpress.XtraEditors.TextEdit();
            this.txtUnitPrice = new DevExpress.XtraEditors.TextEdit();
            this.txtItemName = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.txtCustomerName = new DevExpress.XtraEditors.TextEdit();
            this.txtSearchCustomer = new DevExpress.XtraEditors.ButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscountAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNozzle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnitPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchCustomer.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCash
            // 
            this.btnCash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCash.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCash.Location = new System.Drawing.Point(12, 349);
            this.btnCash.Name = "btnCash";
            this.btnCash.Size = new System.Drawing.Size(105, 33);
            this.btnCash.TabIndex = 26;
            this.btnCash.Text = "Бэлэн";
            this.btnCash.Click += new System.EventHandler(this.btnCash_Click);
            // 
            // btnCard
            // 
            this.btnCard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCard.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCard.Location = new System.Drawing.Point(127, 349);
            this.btnCard.Name = "btnCard";
            this.btnCard.Size = new System.Drawing.Size(105, 33);
            this.btnCard.TabIndex = 27;
            this.btnCard.Text = "Карт";
            this.btnCard.Click += new System.EventHandler(this.btnCard_Click);
            // 
            // btnOther
            // 
            this.btnOther.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOther.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnOther.Location = new System.Drawing.Point(242, 349);
            this.btnOther.Name = "btnOther";
            this.btnOther.Size = new System.Drawing.Size(105, 33);
            this.btnOther.TabIndex = 28;
            this.btnOther.Text = "Бусад";
            this.btnOther.Click += new System.EventHandler(this.btnOther_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtDiscountAmount);
            this.groupControl1.Controls.Add(this.label7);
            this.groupControl1.Controls.Add(this.txtDate);
            this.groupControl1.Controls.Add(this.txtNozzle);
            this.groupControl1.Controls.Add(this.label5);
            this.groupControl1.Controls.Add(this.label6);
            this.groupControl1.Controls.Add(this.txtTotalAmount);
            this.groupControl1.Controls.Add(this.txtQuantity);
            this.groupControl1.Controls.Add(this.txtUnitPrice);
            this.groupControl1.Controls.Add(this.txtItemName);
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(335, 224);
            this.groupControl1.TabIndex = 30;
            this.groupControl1.Text = "Борлуулалтын мэдээлэл";
            // 
            // txtDiscountAmount
            // 
            this.txtDiscountAmount.Location = new System.Drawing.Point(14, 186);
            this.txtDiscountAmount.Name = "txtDiscountAmount";
            this.txtDiscountAmount.Properties.AutoHeight = false;
            this.txtDiscountAmount.Properties.DisplayFormat.FormatString = "#,###.00";
            this.txtDiscountAmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtDiscountAmount.Properties.EditFormat.FormatString = "#,###.00";
            this.txtDiscountAmount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtDiscountAmount.Properties.ReadOnly = true;
            this.txtDiscountAmount.Size = new System.Drawing.Size(148, 30);
            this.txtDiscountAmount.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Хөнгөлөгдсөн дүн";
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(176, 40);
            this.txtDate.Name = "txtDate";
            this.txtDate.Properties.AutoHeight = false;
            this.txtDate.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.txtDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.txtDate.Properties.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(148, 30);
            this.txtDate.TabIndex = 10;
            // 
            // txtNozzle
            // 
            this.txtNozzle.Location = new System.Drawing.Point(14, 89);
            this.txtNozzle.Name = "txtNozzle";
            this.txtNozzle.Properties.AutoHeight = false;
            this.txtNozzle.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.txtNozzle.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtNozzle.Properties.ReadOnly = true;
            this.txtNozzle.Size = new System.Drawing.Size(148, 30);
            this.txtNozzle.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(173, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Түгээлтийн огноо";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Хошуу";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Location = new System.Drawing.Point(176, 186);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Properties.AutoHeight = false;
            this.txtTotalAmount.Properties.DisplayFormat.FormatString = "#,###.00";
            this.txtTotalAmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotalAmount.Properties.EditFormat.FormatString = "#,###.00";
            this.txtTotalAmount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotalAmount.Properties.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(148, 30);
            this.txtTotalAmount.TabIndex = 6;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(176, 138);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Properties.AutoHeight = false;
            this.txtQuantity.Properties.DisplayFormat.FormatString = "#,###.00";
            this.txtQuantity.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtQuantity.Properties.EditFormat.FormatString = "#,###.00";
            this.txtQuantity.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtQuantity.Properties.ReadOnly = true;
            this.txtQuantity.Size = new System.Drawing.Size(148, 30);
            this.txtQuantity.TabIndex = 5;
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Location = new System.Drawing.Point(14, 138);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Properties.AutoHeight = false;
            this.txtUnitPrice.Properties.DisplayFormat.FormatString = "#,###.00";
            this.txtUnitPrice.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtUnitPrice.Properties.EditFormat.FormatString = "#,###.00";
            this.txtUnitPrice.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtUnitPrice.Properties.ReadOnly = true;
            this.txtUnitPrice.Size = new System.Drawing.Size(148, 30);
            this.txtUnitPrice.TabIndex = 4;
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(14, 40);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Properties.AutoHeight = false;
            this.txtItemName.Properties.ReadOnly = true;
            this.txtItemName.Size = new System.Drawing.Size(148, 30);
            this.txtItemName.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(173, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Үнийн дүн";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Нэгж үнэ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Литр";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Шатахуун";
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupControl2.Controls.Add(this.txtCustomerName);
            this.groupControl2.Controls.Add(this.txtSearchCustomer);
            this.groupControl2.Location = new System.Drawing.Point(12, 240);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(335, 103);
            this.groupControl2.TabIndex = 31;
            this.groupControl2.Text = "Худалдан авагчийн мэдээлэл";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(11, 62);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Properties.AutoHeight = false;
            this.txtCustomerName.Properties.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(312, 30);
            this.txtCustomerName.TabIndex = 1;
            // 
            // txtSearchCustomer
            // 
            this.txtSearchCustomer.EditValue = "";
            this.txtSearchCustomer.Location = new System.Drawing.Point(11, 26);
            this.txtSearchCustomer.Name = "txtSearchCustomer";
            this.txtSearchCustomer.Properties.AutoHeight = false;
            this.txtSearchCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search, "Хайх", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Хайх", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete, "Цэвэрлэх", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "Цэвэрлэх", null, null, true)});
            this.txtSearchCustomer.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearchCustomer.Properties.MaxLength = 12;
            this.txtSearchCustomer.Properties.NullText = "Регистер оруулна уу";
            this.txtSearchCustomer.Properties.NullValuePrompt = "Регистер оруулна уу";
            this.txtSearchCustomer.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtSearchCustomer.Size = new System.Drawing.Size(312, 30);
            this.txtSearchCustomer.TabIndex = 0;
            this.txtSearchCustomer.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.SearchCustomer_ButtonClick);
            this.txtSearchCustomer.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.SearchCustomer_EditValueChanging);
            // 
            // DialogVat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 394);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.btnOther);
            this.Controls.Add(this.btnCard);
            this.Controls.Add(this.btnCash);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(375, 433);
            this.MinimumSize = new System.Drawing.Size(375, 433);
            this.Name = "DialogVat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Хэвлэх хэсэг";
            this.Load += new System.EventHandler(this.DialogForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DialogForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscountAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNozzle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnitPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchCustomer.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnCash;
        private DevExpress.XtraEditors.SimpleButton btnCard;
        private DevExpress.XtraEditors.SimpleButton btnOther;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.TextEdit txtCustomerName;
        private DevExpress.XtraEditors.ButtonEdit txtSearchCustomer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtTotalAmount;
        private DevExpress.XtraEditors.TextEdit txtUnitPrice;
        private DevExpress.XtraEditors.TextEdit txtQuantity;
        private DevExpress.XtraEditors.TextEdit txtItemName;
        private DevExpress.XtraEditors.TextEdit txtDate;
        private DevExpress.XtraEditors.TextEdit txtNozzle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.TextEdit txtDiscountAmount;
        private System.Windows.Forms.Label label7;
    }
}