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
    public partial class frmCompany : Form
    {
        #region[Variables]
        dbconnection _db;
        #endregion
        #region[Constructor]
        public frmCompany(dbconnection db)
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

            txtCompanyName.Properties.ReadOnly = false;
            txtCompanyRegister.Properties.ReadOnly = false;

            txtCompanyId.EditValue = null;
            txtCompanyName.EditValue = null;
            txtCompanyRegister.EditValue = null;

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
                txtCompanyId.EditValue = dr["CompanyId"];
                txtCompanyName.EditValue = dr["CompanyName"];
                txtCompanyRegister.EditValue = dr["CompanyRegister"];
            }
        }
        void RefreshData()
        {
            using (Result res = _db.GetCompany())
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
            if (btnEdit.Text == "Бүртгэх")
            {
                if (txtCompanyName.EditValue == null)
                {
                    MessageBox.Show("Компаний нэр хоосон байна", "Мэдээлэл", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (Result res = _db.CreateCompany(txtCompanyRegister.Text, txtCompanyName.Text))
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
                if (txtCompanyId.EditValue == null) return;

                using (Result res = _db.UpdateCompany(Convert.ToInt32(txtCompanyId.Text), txtCompanyRegister.Text, txtCompanyName.Text))
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
                    txtCompanyId.EditValue = dr["CompanyId"];
                    txtCompanyName.EditValue = dr["CompanyName"];
                    txtCompanyRegister.EditValue = dr["CompanyRegister"];
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
                    txtCompanyId.EditValue = dr["CompanyId"];
                    txtCompanyName.EditValue = dr["CompanyName"];
                    txtCompanyRegister.EditValue = dr["CompanyRegister"];
                }
            }
        }
        private void frmCompany_Load(object sender, EventArgs e)
        {
            RefreshData();

            if (gridView1.RowCount == 0) NewState();
            else NormalState();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Мэдээллийг устгахдаа итгэлтэй байна уу", "Баталгаажуулалт", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            using (Result res = _db.DeleteCompany(Convert.ToInt32(txtCompanyId.EditValue)))
            {
                if (res.No != 0) { MessageBox.Show(res.Desc); return; }

                RefreshData();
            }
        }
        private void frmCompany_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
        }
        #endregion
    }
}
