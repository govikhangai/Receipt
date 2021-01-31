using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Receipt
{
    public partial class frmVehicle : Form
    {
        #region[Variables]
        dbconnection _db;
        #endregion
        #region[Constructor]
        public frmVehicle(dbconnection db)
        {
            InitializeComponent();
            _db = db;
        }
        #endregion
        #region[Functions]
        void NewState()
        {
            btnNew.Enabled = false;
            btnEdit.Enabled = true;
            btnEdit.Text = "Бүртгэх";
            btnCancel.Visible = true;
            btnDelete.Enabled = false;

            txtVehicleId.EditValue = null;
            txtDriverName.EditValue = null;
            txtVehicleNumber.EditValue = null;
            txtSiteNumber.EditValue = null;
            cboCompany.EditValue = null;
        }
        void NormalState()
        {
            btnEdit.Text = "Засварлах";
            btnNew.Enabled = true;
            btnEdit.Enabled = true;
            btnCancel.Visible = false;
            btnDelete.Enabled = true;

            DataRow dr = gridView1.GetFocusedDataRow();
            if (dr != null)
            {
                cboCompany.EditValue = dr["CompanyId"];
                txtVehicleId.EditValue = dr["VehicleId"];
                txtDriverName.EditValue = dr["DriverName"];
                txtVehicleNumber.EditValue = dr["VehicleNumber"];
                txtSiteNumber.EditValue = dr["SiteNumber"];
            }
        }
        void RefreshData()
        {
            using (Result res = _db.GetVehicle())
            {
                if (res.No != 0) { MessageBox.Show(res.Desc); return; }

                gridControl1.DataSource = res.Data;
                gridView1.BestFitColumns();
            }
        }
        #endregion
        #region[Form Events]
        private void btnNew_Click(object sender, EventArgs e)
        {
            NewState();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboCompany.EditValue) == 0)
            {
                MessageBox.Show("Компани сонгогдоогүй байна", "Мэдээлэл", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtVehicleNumber.EditValue == null)
            {
                MessageBox.Show("Машины дугаар хоосон байна", "Мэдээлэл", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtSiteNumber.EditValue == null)
            {
                MessageBox.Show("Сайт дугаар хоосон байна", "Мэдээлэл", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (btnEdit.Text == "Бүртгэх")
            {
                using (Result res = _db.CreateVehicle(Convert.ToInt32(cboCompany.EditValue), txtVehicleNumber.Text, txtDriverName.Text, txtSiteNumber.Text))
                {
                    if (res.No != 0) { MessageBox.Show(res.Desc); return; }

                    btnEdit.Text = "Засварлах";
                    RefreshData();
                    NormalState();

                    MessageBox.Show("Амжилттай бүртгэгдлээ");
                }
            }
            else if (btnEdit.Text == "Засварлах")
            {
                using (Result res = _db.UpdateVehicle(Convert.ToInt32(txtVehicleId.Text), Convert.ToInt32(cboCompany.EditValue), txtVehicleNumber.Text, txtDriverName.Text, txtSiteNumber.Text))
                {
                    if (res.No != 0) { MessageBox.Show(res.Desc); return; }

                    RefreshData();
                    MessageBox.Show("Амжилттай засварлагдлаа");
                }
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            NormalState();
        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.RowCount == 0) NewState();
            else
            {
                if (btnEdit.Text == "Бүртгэх")
                {
                    MessageBox.Show("Шинээр бүртгэх төлөвтэй байгаа тул та бүртгэлээ хийнэ үү", "Мэдээлэл", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DataRow dr = gridView1.GetDataRow(e.FocusedRowHandle);
                if (dr != null)
                {
                    cboCompany.EditValue = dr["CompanyId"];
                    txtVehicleId.EditValue = dr["VehicleId"];
                    txtDriverName.EditValue = dr["DriverName"];
                    txtVehicleNumber.EditValue = dr["VehicleNumber"];
                    txtSiteNumber.EditValue = dr["SiteNumber"];
                }
            }
        }
        private void gridView1_RowCountChanged(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0) NewState();
            else
            {
                DataRow dr = gridView1.GetFocusedDataRow();
                if (dr != null)
                {
                    cboCompany.EditValue = dr["CompanyId"];
                    txtVehicleId.EditValue = dr["VehicleId"];
                    txtDriverName.EditValue = dr["DriverName"];
                    txtVehicleNumber.EditValue = dr["VehicleNumber"];
                    txtSiteNumber.EditValue = dr["SiteNumber"];
                }
            }
        }
        private void frmCompany_Load(object sender, EventArgs e)
        {
            using (Result res = _db.GetCompany())
            {
                if (res.No != 0) { MessageBox.Show(res.Desc); return; }

                cboCompany.Properties.DataSource = res.Data;
                cboCompany.Properties.ValueMember = "CompanyId";
                cboCompany.Properties.DisplayMember = "CompanyName";

                cboCompany.Properties.ForceInitialize();
                cboCompany.Properties.PopulateColumns();
                cboCompany.Properties.BestFit();

                cboCompany.Properties.ShowFooter = false;
                cboCompany.Properties.DropDownRows = 15;

                cboCompany.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;

                cboCompany.Properties.Columns["CreatedDate"].Visible = false;
                cboCompany.Properties.Columns["UpdatedDate"].Visible = false;
            }

            RefreshData();

            if (gridView1.RowCount == 0) NewState();
            else NormalState();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Мэдээллийг устгахдаа итгэлтэй байна уу", "Баталгаажуулалт", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            using (Result res = _db.DeleteVehicle(Convert.ToInt32(txtVehicleId.EditValue)))
            {
                if (res.No != 0) { MessageBox.Show(res.Desc); return; }

                RefreshData();
            }
        }
        private void frmVehicle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
        }
        #endregion
    }
}
