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
using System.Threading;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.IO;
using Receipt.Properties;

namespace Receipt
{
    public partial class frmMain : Form
    {
        #region[Variables]
        private Thread thread = null;
        private bool running = false;
        private dbconnection db;
        private Trade currentTrade;
        private int vatcounter = 0;

        public int toprecordcount { get; set; }
        public int delay { get; set; }
        private int index = 0;

        private Config config;

        #endregion
        #region[Constructor]
        public frmMain()
        {
            InitializeComponent();
        }
        #endregion
        #region[Functions]
        private void InvokeUI(Action action)
        {
            Invoke(action);
        }
        private void Fillings()
        {
            while (running)
            {
                if (vatcounter == 900)
                {
                    try
                    {
                        vatps.vatps.SendData();
                    }
                    catch (Exception ex)
                    {

                    }
                    vatcounter = 0;
                }

                if (index % delay == 0)
                {
                    index = 0;
                    try
                    {
                        using (Result res = db.GetTrade(toprecordcount))
                        {
                            if (res.No != 0) { MessageBox.Show(string.Format("{0} : {1}", res.No, res.Desc)); index++; continue; }
                            if (res.AffectedRows == 0) { index++; return; }

                            InvokeUI(() => gridControl1.DataSource = res.Trade);
                            InvokeUI(() => gridView1.BestFitColumns());
                            InvokeUI(() => gridView1.ExpandAllGroups());
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                InvokeUI(() => progress.EditValue = index);
                index++;
                vatcounter++;
                Thread.Sleep(1000);
            }
        }
        private void LoadConfig()
        {
            try
            {
                string text = File.ReadAllText("config.ini");

                config = new JavaScriptSerializer().Deserialize<Config>(text);

                if (config.host == string.Empty || config.host == null)
                {
                    MessageBox.Show("Host empty");
                    this.Close();
                }
                if (config.db == string.Empty || config.db == null)
                {
                    MessageBox.Show("Db empty");
                    this.Close();
                }
                if (config.userid == string.Empty || config.userid == null)
                {
                    MessageBox.Show("UserId empty");
                    this.Close();
                }
                if (config.password == string.Empty || config.password == null)
                {
                    MessageBox.Show("Password empty");
                    this.Close();
                }

                if (config.stationname == string.Empty || config.stationname == null)
                {
                    MessageBox.Show("StationName empty");
                    this.Close();
                }
                if (config.districtcode == string.Empty || config.districtcode == null)
                {
                    MessageBox.Show("District empty");
                    this.Close();
                }
                if (config.companyname == string.Empty || config.companyname == null)
                {
                    MessageBox.Show("CompanyName empty");
                    this.Close();
                }

                Program.districtCode = config.districtcode;
                Program.stationName = config.stationname;
                Program.companyName = config.companyname;

                if (config.delay < 5) delay = 5;
                else delay = config.delay;

                progress.Properties.Maximum = delay;

                if (config.toprecordcount == 0) toprecordcount = 50;
                else toprecordcount = config.toprecordcount;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Тохиргооны мэдээлэл татахад алдаа гарлаа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion
        #region[Form Events]
        private void frmMain_Load(object sender, EventArgs e)
        {
            btnStart.Image = Resources.play_button;
            //Crypt.Encrypt(config.password, "Simple")
            //Crypt.Decrypt(config.password, "Simple");

            LoadConfig();

            db = new dbconnection(config.host, config.userid, config.password, config.db);
            using (Result res = db.initialDb())
            {
                if (res.No != 0) MessageBox.Show(res.Desc, "Баазын өөрчлөлт хийхэд алдаа гарлаа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //using (Result res = db.GetStation())
            //{
            //    if (res.No != 0) MessageBox.Show(res.Desc, "Станцын мэдээлэл авахад алдаа гарлаа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    else if (res.AffectedRows == 0)
            //    {
            //        StationName = res.Data.Rows[0]["StationName"].ToString();
            //        this.Text = this.Text + " : " + StationName;
            //    }
            //}


            gridControl1.DataSource = new List<Trade>();
            gridView1.BestFitColumns();

            running = true;
            thread = new Thread(Fillings);
            thread.IsBackground = true;
            //thread.Start();
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Програмыг хаахдаа итгэлтэй байна уу ?", "Баталгаажуулалт", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                e.Cancel = true;
            }

            running = false;
        }
        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            currentTrade = (Trade)gridView1.GetFocusedRow();
            if (currentTrade != null)
            {
                if (config.loyaltyrules != null)
                {
                    if (config.loyaltyrules.Count() > 0)
                    {
                        foreach (LoyaltyRule rule in config.loyaltyrules)
                        {
                            //Хурдны мөн эсэхийг шалгаж байна
                            if (rule.iswhole)
                            {
                                if (config.nozzles == null) continue;       //Хошууны бүртгэл байгаа эсэхийг шалгаж байна
                                if (config.nozzles.Count() == 0) continue;  //Хошууны бүртгэл хоосон байгаа эсэхийг шалгаж байна

                                Nozzle nozzle = config.nozzles.Where(x => x.nozzleno == currentTrade.NozzleNo).FirstOrDefault();
                                if (nozzle == null) continue;               //Тухайн хошуу бүртгэлтэй байгаа эсэхийг шалгаж байна
                                if (!nozzle.iswhole) continue;              //Тухайн хошууны бөөн эсэхийг шалгаж байна
                            }

                            //Хошуугаар тохируулсан хөнгөлөлт мөн эсэхийг галгаж байна
                            if (rule.nozzleno != string.Empty)
                                if (rule.nozzleno != currentTrade.NozzleNo) continue;

                            //Шатахуунаар тохируулсан хөнгөлөлт мөн эсэхийг галгаж байна
                            if (rule.itemcode != string.Empty)
                                if (rule.itemcode != currentTrade.ItemCode) continue;

                            //Худалдан авалтын литр хөнгөлөгдөх нөхцөлийг хангаж байгаа эсэхийг шалгаж байна
                            if (rule.endquantity < rule.startquantity)
                            {
                                //Тухайн худалдан авалтын хэмжээ хөнгөлөгдөх нөхцөлийг хангаж байгаа эсэхийг шалгаж байна
                                if (currentTrade.Quantity >= rule.startquantity)
                                {
                                    if (rule.discountamount < currentTrade.UnitPrice)
                                        currentTrade.DiscountedPrice = currentTrade.UnitPrice - rule.discountamount;
                                }
                            }
                            else
                            {
                                if (currentTrade.Quantity >= rule.startquantity && currentTrade.Quantity < rule.endquantity)
                                {
                                    if (rule.discountamount < currentTrade.UnitPrice)
                                        currentTrade.DiscountedPrice = currentTrade.UnitPrice - rule.discountamount;
                                }
                            }

                            if (currentTrade.DiscountedPrice != 0)
                                currentTrade.DiscountedAmount =
                                    (currentTrade.UnitPrice - currentTrade.DiscountedPrice)
                                    * Static.ToInt(currentTrade.Quantity); //Бүхэл литр тутамд хөнгөлөлт тооцож байна
                        }
                    }
                }

                DialogVat d = new DialogVat(db);
                d.Trade = currentTrade;
                d.ShowDialog();
            }
            else
            {
                MessageBox.Show(this, "Түгээлтийн мэдээлэл хоосон байна", "Мэдээлэл", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void subExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private void subLoadConfig_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadConfig();
        }

        #region[Buttons]
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!running)
            {
                running = true;

                thread = new Thread(Fillings);
                thread.IsBackground = true;
                thread.Start();

                btnStart.Image = Resources.play_button;
            }
            else
            {
                running = false;
                btnStart.Image = Resources.money;
            }
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            
        }
        private void btnCompany_Click(object sender, EventArgs e)
        {
            frmCompany frm = new frmCompany(db);
            frm.ShowDialog();
        }
        private void btnVehicle_Click(object sender, EventArgs e)
        {
            frmVehicle frm = new frmVehicle(db);
            frm.ShowDialog();
        }
        #endregion

        #endregion
        #region[Menu]
        private void subVatInfo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Result res = vatps.vatps.GetInformationString();
            if (res.No != 0)
            {
                MessageBox.Show(this, string.Format("{0} : {1}", res.No, res.Desc), "Татварын мэдээлэл авахалд алдаа гарлаа", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                MessageBox.Show(this, res.Desc, "Мэдээлэл", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        } 
        private void subVatSend_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (var wait = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(frmWaitIndicator), true, true, false))
            {
                wait.ShowWaitForm();
                wait.SetWaitFormCaption("Татварт мэдээ илгээж байна.");
                wait.SetWaitFormDescription("Та түр хүлээнэ үү");

                Result res = vatps.vatps.SendData();
                if (res.No != 0)
                {
                    MessageBox.Show(this, string.Format("{0} : {1}", res.No, res.Desc), "Татварт мэдээ илгээхэд алдаа гарлаа", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    MessageBox.Show(this, "Амжилттай илгээгдлээ", "Мэдээлэл", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void subVatSales_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmVatList frm = new frmVatList(db);
            frm.ShowDialog();
        }
        #endregion
    }
}
