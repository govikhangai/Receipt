using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using System.Threading;
using System.Globalization;

using DevExpress.Skins;
using DevExpress.UserSkins;
using DevExpress.LookAndFeel;

namespace Receipt
{
    static class Program
    {
        public static string districtCode { get; set; }
        public static string stationNo { get; set; }
        public static string stationName { get; set; }
        public static string registerNo { get; set; }
        public static string companyName { get; set; }
        public static string posId { get; set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Result res = vatps.vatps.GetInformation();
            if (res.No != 0)
            {
                MessageBox.Show(string.Format("{0} : {1}", res.No, res.Desc), "Татварын POSAPI-г ачааллахад алдаа гарлаа", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else
            {
                var apires = (vatps.posInfo)res.Json;
                registerNo = apires.registerNo;
                stationNo = apires.branchNo;
                posId = apires.posId;
            }
            CultureInfo ci = new CultureInfo("en-US")
            {
                DateTimeFormat = new DateTimeFormatInfo()
                {
                    LongDatePattern = "yyyy-MM-dd HH:mm:ss.fff",
                    ShortDatePattern = "yyyy-MM-dd",
                    ShortTimePattern = "HH:mm:ss",
                    FullDateTimePattern = "yyyy-MM-dd HH:mm:ss.fff",
                },
                NumberFormat = new NumberFormatInfo()
                {
                    CurrencyDecimalSeparator = ".",
                    CurrencyGroupSeparator = ",",
                    NumberDecimalSeparator = ".",
                    NumberGroupSeparator = ","
                }
            };

            Thread.CurrentThread.CurrentCulture = ci;
            //Static.ci = ci;
            
            BonusSkins.Register();
            SkinManager.EnableFormSkins();

            UserLookAndFeel.Default.SetSkinStyle("Darkroom");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
