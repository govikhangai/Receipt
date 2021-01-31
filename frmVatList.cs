using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Receipt
{
    public partial class frmVatList : DevExpress.XtraEditors.XtraForm
    {
        private dbconnection _db;
        public frmVatList(dbconnection db)
        {
            InitializeComponent();
            _db = db;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Result res = _db.GetVatSales(txtDate.DateTime);
            if (res.No != 0)
            {
                MessageBox.Show(string.Format("{0} : {1}", res.No, res.Desc), "Алдаа гарлаа", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            grdVat.DataSource = res.Vat;

            gvwVat.Columns["SaleDate"].SummaryItem.DisplayFormat = "Борлуулалтын тоо:{0:N2}";
            gvwVat.Columns["SaleDate"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;

            gvwVat.Columns["TotalAmount"].SummaryItem.DisplayFormat = "Нийт: {0:n2}";
            gvwVat.Columns["TotalAmount"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;

            gvwVat.Columns["CashAmount"].SummaryItem.DisplayFormat = "Бэлэн: {0:n2}";
            gvwVat.Columns["CashAmount"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;

            gvwVat.Columns["CardAmount"].SummaryItem.DisplayFormat = "Карт: {0:n2}";
            gvwVat.Columns["CardAmount"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;

            gvwVat.Columns["OtherAmount"].SummaryItem.DisplayFormat = "Бусад: {0:n2}";
            gvwVat.Columns["OtherAmount"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gvwVat.BestFitColumns();
        }
    }
}