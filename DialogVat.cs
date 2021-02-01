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
using System.Net;
using Receipt.Properties;
using System.Net.Http;
using System.Web.Script.Serialization;
using vatps;

namespace Receipt
{
    public partial class DialogVat : Form
    {
        #region[Variables]
        private PrintDocument pdoc;
        private int offset;
        private Font font = new Font("Consolas", 8);
        private Font fontbold = new Font("Consolas", 8, FontStyle.Bold);
        private SolidBrush blackbrush = new SolidBrush(Color.Black);
        private StringFormat drawformat = new StringFormat();
        private dbconnection _db;
        private BillData data;
        DateTime now;

        private string ddtd;
        private string lottery;
        private string qrdata;
        private string saledate;
        private string macaddress;
        private string customer;
        private string paymenttype;
        #endregion
        #region[Property]
        public Trade Trade { get; set; }

        #endregion
        #region[Constructor]
        public DialogVat(dbconnection db)
        {
            InitializeComponent();
            _db = db;
            btnCash.Image = Resources.money;
            btnCard.Image = Resources.debit_card;
        }
        #endregion
        #region[Form Events]
        private void DialogForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
            if (e.KeyCode == Keys.Enter) Print("CASH");
        }
        private void DialogForm_Load(object sender, EventArgs e)
        {
            txtItemName.EditValue = Trade.ItemName;
            txtQuantity.EditValue = Trade.Quantity;
            txtUnitPrice.EditValue = Trade.UnitPrice;
            txtDiscountAmount.EditValue = Trade.DiscountedAmount;
            txtTotalAmount.EditValue = Trade.TotalAmount - Trade.DiscountedAmount;
            txtNozzle.EditValue = Trade.NozzleNo;
            txtDate.EditValue = Trade.TradeDate;

            pdoc = new PrintDocument();
            pdoc.PrintPage += Pdoc_PrintPage;

            txtSearchCustomer.Focus();
            txtSearchCustomer.Select();
        }
        private Pen blackpen1 = new Pen(Color.Black, 1);
        private ZXing.IBarcodeWriter writer;
        private void Pdoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                e.Graphics.DrawString("             НӨАТ ТООЦОХ БАРИМТ", fontbold, blackbrush, new Rectangle(0, font.Height, 287, offset), drawformat);
                offset = offset + 32;
                e.Graphics.DrawLine(blackpen1, 0, offset, 287, offset);
                offset += 2;
                e.Graphics.DrawLine(blackpen1, 0, offset, 287, offset);
                offset = offset + 10;
                e.Graphics.DrawString(string.Format("               {0}", Program.companyName), fontbold, blackbrush, 3, offset);
                offset = offset + 18;

                e.Graphics.DrawString(string.Format("{0,-8}{1,-60}", "ДДТД:", ddtd), font, blackbrush, 3, offset);
                offset = offset + 18;
                e.Graphics.DrawString(string.Format("{0,-8}{1,-60}", "ТТД:", Program.registerNo), font, blackbrush, 3, offset);
                offset = offset + 18;
                e.Graphics.DrawString(string.Format("{0,-8}{1,-40}", "Станц:", Program.stationName), font, blackbrush, 3, offset);
                offset = offset + 18;
                e.Graphics.DrawString(string.Format("{0,-8}{1,-40}", "Огноо:", saledate), font, blackbrush, 3, offset);
                offset = offset + 18;
                if (data.billType != "1")
                {
                    e.Graphics.DrawString("Худалдан авагч:", fontbold, blackbrush, 3, offset);
                    offset = offset + 15;
                    e.Graphics.DrawString(string.Format("{0,-8}{1,-60}", "ТТД:", data.customerNo), font, blackbrush, 3, offset);
                    offset = offset + 18;
                    e.Graphics.DrawString(string.Format("{0,-8}{1,-60}", "Нэр:", txtCustomerName.Text.Trim().Length > 35 ? txtCustomerName.Text.Trim().Substring(0, 35) : txtCustomerName.Text.Trim()), font, blackbrush, 3, offset);
                    offset = offset + 18;
                }
                e.Graphics.DrawLine(blackpen1, 0, offset, 287, offset);
                offset += 1;
                e.Graphics.DrawString(String.Format("{0,-10}{1,15}{2,18}\n", "Тоо ширхэг", "Нэгж үнэ", "Нийт"), font, blackbrush, 3, offset);
                offset = offset + 15;
                e.Graphics.DrawLine(blackpen1, 0, offset, 287, offset);
                offset += 2;
                foreach (var item in data.stocks)
                {
                    e.Graphics.DrawString(item.name, font, blackbrush, 3, offset);
                    offset += 15;
                    e.Graphics.DrawString(string.Format("{0,-10}{1,15}{2,18}\n", item.qty, item.unitPrice, item.totalAmount), font, blackbrush, 3, offset);
                    offset += 14;
                }
                e.Graphics.DrawLine(blackpen1, 0, offset, 287, offset);
                offset += 1;

                writer = new ZXing.BarcodeWriter
                {
                    Format = ZXing.BarcodeFormat.QR_CODE
                };
                using (var dataQr = writer.Write(qrdata))
                {
                    using (var barcodeBitmap = new Bitmap(dataQr))
                    {
                        e.Graphics.DrawImage(barcodeBitmap, 4, offset, 150, 150);
                    }
                }
                offset += 40;
                if (lottery != string.Empty)
                {
                    e.Graphics.DrawString(string.Format("{0,-12} {1}", "Сугалааны №:\r\n", lottery), fontbold, blackbrush, 160, offset);
                }
                offset += 50;
                e.Graphics.DrawString(string.Format("{0,-12} {1}", "Баримтын дүн:\r\n", data.amount), fontbold, blackbrush, 160, offset);
                offset += 56;
                e.Graphics.DrawLine(blackpen1, 0, offset, 287, offset);
                offset += 2;
                e.Graphics.DrawString(string.Format("{0,-7}{1,12}   {2,-8}{3,13}", "Нийт:", data.amount, "Бэлэн:", paymenttype == "CASH" ? data.amount : "0.00"), font, blackbrush, 3, offset);
                offset += 15;
                e.Graphics.DrawString(string.Format("{0,-7}{1,12}   {2,-8}{3,13}", "НӨАТ:", data.vat, "Карт:", paymenttype == "CARD" ? data.amount : "0.00"), font, blackbrush, 3, offset);
                offset += 15;
                e.Graphics.DrawString(string.Format("{0,-7}{1,12}   {2,-8}{3,13}", "НХАТ:", data.cityTax, "Бусад:", paymenttype == "OTHER" ? data.amount : "0.00"), font, blackbrush, 3, offset);
                offset += 15;
                e.Graphics.DrawLine(blackpen1, 0, offset, 287, offset);
                offset += 3;
                e.Graphics.DrawString("     Манайхаар үйлчлүүлсэнд баярлалаа", font, blackbrush, 5, offset);

                offset = 0;
                data = null;
                lottery = string.Empty;
                qrdata = string.Empty;
                saledate = string.Empty;
                ddtd = string.Empty;
                customer = string.Empty;
                paymenttype = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private async void SearchCustomer_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            txtCustomerName.EditValue = null;

            if (txtSearchCustomer.Text != string.Empty)
            {
                if (IsNumeric(txtSearchCustomer.Text))
                {
                    if (txtSearchCustomer.Text.Length == 7) await GetTaxPayer(txtSearchCustomer.Text);
                    else if (txtSearchCustomer.Text.Length > 7)
                    {
                        txtCustomerName.EditValue = null;
                    }
                }
                else
                {
                    if (txtSearchCustomer.Text.Length == 10) await GetTaxPayer(txtSearchCustomer.Text);
                    else if (txtSearchCustomer.Text.Length > 10)
                    {
                        txtCustomerName.EditValue = null;
                    }
                }
            }
        }
        private async void SearchCustomer_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Caption == "Хайх") await GetTaxPayer(txtSearchCustomer.Text);
            else
            {
                txtSearchCustomer.EditValue = null;
                txtCustomerName.EditValue = null;
            }
        }
        #endregion
        #region[Functions]
        public void Search()
        {

        }
        public bool Validation()
        {
            if (Static.ToStr(txtSearchCustomer.EditValue) != string.Empty)
                if (Static.ToStr(txtCustomerName.EditValue) == string.Empty)
                {
                    MessageBox.Show(this, "Байгуулагын регистер буруу байна !!!", "Талбарын шалгалт", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return false;
                }

            return true;
        }
        private void Print(string PaymentType)
        {
            try
            {
                paymenttype = PaymentType;

                if (!Validation()) return;

                now = new DateTime();
                data = new BillData();
                {
                    data.districtCode = Program.districtCode;
                    data.customerNo = txtSearchCustomer.Text;
                    data.amount = Static.ToDecimal(txtTotalAmount.EditValue).ToString("0.00");
                    data.cashAmount = data.amount;
                    data.nonCashAmount = "0.00";
                    data.vat = (Static.ToDecimal(data.amount) / 11).ToString("0.00");
                    data.cityTax = "0.00";
                    data.billType = txtSearchCustomer.Text == string.Empty ? "1" : "3";
                    //data.billIdSuffix = string.Format("{0}{1}{2}", now.ToString("HH"), now.ToString("mm"), now.ToString("ss"));

                    data.stocks = new List<BillDetail>();
                    data.stocks.Add(new BillDetail()
                    {
                        code = Trade.ItemCode,
                        name = Trade.ItemName,
                        measureUnit = "Литр",
                        qty = Trade.Quantity.ToString("0.00"),
                        unitPrice = Trade.DiscountedPrice != 0 ? Trade.DiscountedPrice.ToString("0.00") : Trade.UnitPrice.ToString("0.00"),
                        totalAmount = Static.ToDecimal(txtTotalAmount.EditValue).ToString("0.00"),
                        vat = data.vat,
                        cityTax = data.cityTax
                    });

                    vatResponse resp = new JavaScriptSerializer().Deserialize<vatResponse>(
                        vatps.vatps.put(new JavaScriptSerializer().Serialize(data)));
                    if (resp.success == "False")
                    {
                        MessageBox.Show(this, string.Format("{0} : {1}", resp.errorCode, resp.message), "Татварын мэдээлэл үүсгэхэд алдаа гарлаа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    using (Sales sales = new Sales())
                    {
                        sales.BillId = resp.billId;
                        sales.SaleDate = resp.date;
                        sales.TotalAmount = Convert.ToDecimal(data.amount);
                        sales.OriginalAmount = Static.ToDecimal(txtTotalAmount.EditValue) + Static.ToDecimal(txtDiscountAmount.EditValue);
                        sales.StationNo = Program.stationNo;
                        sales.StatioName = Program.stationName;
                        sales.PosId = Program.posId;
                        sales.CustomerNo = data.customerNo;
                        sales.CustomerName = txtCustomerName.Text;
                        sales.Vat = Convert.ToDecimal(data.vat);
                        sales.CityTax = Convert.ToDecimal(data.cityTax);
                        sales.CashAmount = PaymentType == "CASH" ? Convert.ToDecimal(data.amount) : 0;
                        sales.CardAmount = PaymentType == "CARD" ? Convert.ToDecimal(data.amount) : 0;
                        sales.OtherAmount = PaymentType == "OTHER" ? Convert.ToDecimal(data.amount) : 0;

                        sales.SalesItemDetails = new SalesItemDetail()
                        {
                            ItemCode = Trade.ItemCode,
                            ItemName = Trade.ItemName,
                            NozzleNo = Trade.NozzleNo,
                            Quantity = Trade.Quantity,
                            UnitPrice = Trade.UnitPrice,
                            Vat = sales.Vat,
                            CityTax = sales.CityTax,
                            TotalAmount = sales.TotalAmount,
                            OriginalAmount = Static.ToDecimal(txtTotalAmount.EditValue) + Static.ToDecimal(txtDiscountAmount.EditValue),
                            TradeId = Trade.TradeId,
                            TradeDate = Trade.TradeDate
                        };

                        sales.SalesPayments = new SalesPayment()
                        {
                            PaymentType = PaymentType,
                            PaymentAmount = sales.TotalAmount
                        };

                        using (Result res = _db.InsertVatSales(sales))
                        {
                            if (res.No != 0)
                            {
                                //WriteLog
                                MessageBox.Show(string.Format("Баримтын мэдээлэл өгөгдлийн баазад хадгалахад алдаа гарлаа. {0}", res.Desc), "Алдаа гарлаа", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }
                        }

                        ddtd = resp.billId;
                        lottery = resp.lottery;
                        saledate = resp.date;
                        macaddress = resp.macAddress;
                        qrdata = resp.qrData;

                        pdoc.Print();
                    }
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Баримт хэвлэхэд алдаа гарлаа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public bool IsNumeric(string s)
        {
            foreach (char c in s)
            {
                if (!char.IsDigit(c) && c != '.')
                {
                    return false;
                }
            }
            return true;
        }
        public async Task<Result> GetTaxPayer(string RegisterNo)
        {
            using (Result res = new Result())
            {
                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        using (var vatres = await client.GetAsync(new Uri(string.Format("http://info.ebarimt.mn/rest/merchant/info?regno={0}", RegisterNo))))
                        {
                            if (vatres.IsSuccessStatusCode)
                            {
                                using (TaxPayer taxpayer = new JavaScriptSerializer().Deserialize<TaxPayer>(await vatres.Content.ReadAsStringAsync()))
                                {
                                    if (taxpayer.Name != string.Empty)
                                    {
                                        txtCustomerName.EditValue = taxpayer.Name;
                                        return res;
                                    }
                                    else txtSearchCustomer.Text = string.Empty;
                                }
                            }
                            else
                            {
                                MessageBox.Show(vatres.ReasonPhrase);
                                //res.No = Static.ToInt(vatres.StatusCode);
                                //res.Desc = vatres.ReasonPhrase;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    res.No = 1;
                    res.Desc = string.Format("Систем админд хандана уу.\r\n{0}", ex.Message);
                }
                return res;
            }
        }
        #endregion
        #region[Buttons]
        private void btnCash_Click(object sender, EventArgs e)
        {
            Print("CASH");
        }
        private void btnCard_Click(object sender, EventArgs e)
        {
            Print("CARD");
        }
        private void btnOther_Click(object sender, EventArgs e)
        {
            Print("OTHER");
        }
        #endregion
    }
}
