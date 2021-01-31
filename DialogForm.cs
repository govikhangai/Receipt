using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Receipt
{
    public partial class DialogForm : Form
    {
        #region[Variables]
        private PrintDocument pdoc;
        private int offset;
        private Font font = new Font("Consolas", 8);
        private Font fontbold = new Font("Consolas", 8, FontStyle.Bold);
        private SolidBrush blackbrush = new SolidBrush(Color.Black);
        private StringFormat drawformat = new StringFormat();
        private dbconnection _db;
        private string stationname;
        private string sitenumber;
        #endregion
        #region[Property]
        public Trade Trade { get; set; }

        #endregion
        #region[Constructor]
        public DialogForm(dbconnection db, string StationName)
        {
            InitializeComponent();
            _db = db;
            stationname = StationName;
        }
        #endregion
        #region[Form Events]
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (cboCompany.EditValue == null)
            {
                MessageBox.Show("Компани сонгогдоогүй байна", "Талбарын шалгалт", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (cboVehicle.EditValue == null)
            {
                MessageBox.Show("Машин сонгогдоогүй байна", "Талбарын шалгалт", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Print();
        }
        private void DialogForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
            if (e.KeyCode == Keys.Enter) Print();
        }
        private void DialogForm_Load(object sender, EventArgs e)
        {
            txtDispenser.EditValue = Trade.NozzleNo;
            txtItemName.EditValue = Trade.ItemName;
            txtQuantity.EditValue = Trade.Quantity;
            txtTotalizerCount.EditValue = Trade.TotalizerCount;

            pdoc = new PrintDocument();
            pdoc.PrintPage += Pdoc_PrintPage;

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
        }
        private void Pdoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(string.Format("ШАТАХУУНЫ ЗАРЛАГЫН БАРИМТ №: {0}", Trade.TradeId), fontbold, blackbrush, new Rectangle(40, font.Height, 250, offset), drawformat);
            offset = offset + 36;
            e.Graphics.DrawString(string.Format("{0,-22}{1,-40}", "Станц:", stationname), font, blackbrush, 15, offset);
            offset = offset + 18;
            e.Graphics.DrawString(string.Format("{0,-22}{1,-40}", "Огноо:", Trade.TradeDate.ToString("yyyy-MM-dd HH:mm:ss")), font, blackbrush, 15, offset);
            offset = offset + 18;
            e.Graphics.DrawString(string.Format("{0,-22}{1,-40}", "Түгээгүүрийн №:", txtDispenser.EditValue), font, blackbrush, 15, offset);
            offset = offset + 18;
            e.Graphics.DrawString(string.Format("{0,-22}{1,-40}", "Худалдан авагч:", cboCompany.Properties.GetDisplayText(cboCompany.EditValue)), font, blackbrush, 15, offset);
            offset = offset + 18;
            e.Graphics.DrawString(string.Format("{0,-22}{1,-40}", "Машины дугаар", cboVehicle.Properties.GetDisplayText(cboVehicle.EditValue)), font, blackbrush, 15, offset);
            offset = offset + 18;
            e.Graphics.DrawString(string.Format("{0,-22}{1,-40}", "Сайт №:", sitenumber), font, blackbrush, 15, offset);
            offset = offset + 18;
            e.Graphics.DrawString(string.Format("{0,-22}{1,-40}", "Шатахууны хэмжээ:", Trade.Quantity.ToString("#,###.00")), font, blackbrush, 15, offset);
            offset = offset + 18;
            e.Graphics.DrawString(string.Format("{0,-22}{1,-40}", "Эцсийн милль:", Trade.TotalizerCount.ToString("#,###.00")), font, blackbrush, 15, offset);
            offset = offset + 30;
            e.Graphics.DrawString(string.Format("{0,-22}{1,-40}", "Мото цаг:", "/                 /"), font, blackbrush, 15, offset);
            offset = offset + 45;
            e.Graphics.DrawString(string.Format("{0,-22}{1,-40}", "Операторын гарын үсэг:", "/                 /"), font, blackbrush, 15, offset);
            offset = offset + 45;
            e.Graphics.DrawString(string.Format("{0,-22}{1,-40}", "Түгээгчийн гарын үсэг:", "/                 /"), font, blackbrush, 15, offset);
            offset = offset + 30;
            e.Graphics.DrawString(string.Format("{0,-22}{1,-40}", ".                     ", "                   "), font, blackbrush, 15, offset);
            offset = 0;
        }
        private void cboCompany_EditValueChanged(object sender, EventArgs e)
        {
            if (cboCompany.EditValue == null) return;

            using (Result res = _db.GetVehicle(Convert.ToInt32(cboCompany.EditValue)))
            {
                if (res.No != 0) { MessageBox.Show(res.Desc); return; }

                cboVehicle.Properties.DataSource = res.Data;
                cboVehicle.Properties.ValueMember = "VehicleId";
                cboVehicle.Properties.DisplayMember = "VehicleNumber";

                cboVehicle.Properties.ForceInitialize();
                cboVehicle.Properties.PopulateColumns();
                cboVehicle.Properties.BestFit();

                cboVehicle.Properties.ShowFooter = false;
                cboVehicle.Properties.DropDownRows = 15;

                cboVehicle.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            }
        }
        #endregion
        #region[Functions]
        private void Print()
        {
            try
            {
                if (cboCompany.EditValue == null)
                {
                    MessageBox.Show("Компани сонгоно уу", "Талбарын шалгалт", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                if (cboVehicle.EditValue == null)
                {
                    MessageBox.Show("Машин сонгоно уу", "Талбарын шалгалт", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                pdoc.Print();
                pdoc.Print();

                using (Result res = _db.UpdateTrade(Trade.TradeId))
                {
                    if (res.No != 0) MessageBox.Show(res.Desc);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Баримт хэвлэхэд алдаа гарлаа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        private void cboVehicle_EditValueChanged(object sender, EventArgs e)
        {
            //DevExpress.XtraEditors.LookUpEdit editor = sender as DevExpress.XtraEditors.LookUpEdit;
            //DataRowView row = editor.Properties.GetDataSourceRowByKeyValue(editor.EditValue) as DataRowView;
            //if (row != null) sitenumber = row["SiteNumber"].ToString();
            //else sitenumber = string.Empty;
        }

        private void txtSearchSite_EditValueChanged(object sender, EventArgs e)
        {
            if (txtSearchSite.Text != string.Empty)
            {
                lstCustomer.Items.Clear();
                using (Result res = _db.GetVehicle(txtSearchSite.Text))
                {
                    if (res.No != 0)
                    {
                        MessageBox.Show(string.Format("{0} : {1}", res.No, res.Desc));
                        return;
                    }
                    if (res.AffectedRows == 0)
                    {
                        txtSiteNumber.EditValue = null;
                        cboCompany.EditValue = null;
                        cboVehicle.EditValue = null;
                        popupControlContainer1.Hide();
                        return;
                    }

                    if (res.Data != null)
                    {
                        if (res.Data.Rows.Count > 0)
                        {
                            foreach (DataRow dr in res.Data.Rows)
                            {
                                lstCustomer.Items.Add(string.Format("{0} : {1} : {2}", dr["SiteNumber"], dr["CompanyId"], dr["VehicleId"]));
                            }

                            if (lstCustomer.Items.Count == 1)
                            {
                                txtSiteNumber.EditValue = lstCustomer.SelectedValue.ToString();

                                txtSearchSite.Text = string.Empty;

                                popupControlContainer1.Hide();
                            }
                            else if (lstCustomer.Items.Count > 1)
                            {
                                popupControlContainer1.Show();
                            }
                        }
                    }
                }
            }
            else
            {
                popupControlContainer1.Hide();
            }
        }

        private void lstCustomer_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lstCustomer.SelectedIndex != -1)
            {
                txtSiteNumber.Text = lstCustomer.SelectedValue.ToString();
                popupControlContainer1.Hide();
            }
            else
            {
                txtSiteNumber.EditValue = null;
            }
        }

        private void lstCustomer_MouseLeave(object sender, EventArgs e)
        {
            popupControlContainer1.Hide();
        }

        private void lstCustomer_MouseClick(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("asdf");
        }

        private void btnClosePopUp_Click(object sender, EventArgs e)
        {
            popupControlContainer1.Hide();
        }

        private void txtSiteNumber_EditValueChanged(object sender, EventArgs e)
        {
            if (txtSiteNumber.Text != string.Empty)
            {
                string[] values = lstCustomer.SelectedValue.ToString().Split(':');
                sitenumber = values[0];
                cboCompany.EditValue = Convert.ToInt32(values[1]);
                cboVehicle.EditValue = Convert.ToInt32(values[2]);
            }
        }
    }
}
