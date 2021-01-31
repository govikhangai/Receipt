using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Web.Script.Serialization;
using Receipt;

namespace vatps
{
    public static class vatps
    {
        #region [Vat Functions]
        [DllImport("PosAPI.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.BStr)]
        public static extern string put(String message);

        [DllImport("PosAPI.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.BStr)]
        private static extern string returnBill(String message);

        [DllImport("PosAPI.dll")]
        [return: MarshalAs(UnmanagedType.BStr)]
        private static extern string sendData();

        [DllImport("PosAPI.dll")]
        [return: MarshalAs(UnmanagedType.BStr)]
        private static extern string checkAPI();

        [DllImport("PosAPI.dll")]
        [return: MarshalAs(UnmanagedType.BStr)]
        private static extern string getInformation();

        [DllImport("PosAPI.dll")]
        [return: MarshalAs(UnmanagedType.BStr)]
        private static extern string callFunctions(String functioname, String parameter);
        #endregion
        #region[Function]

        public static Result SendData()
        {
            using (Result res = new Result())
            {
                try
                {
                    res.Json = new JavaScriptSerializer().Deserialize<vatResponse>(sendData());
                }
                catch (Exception ex)
                {
                    res.No = 1001;
                    res.Desc = ex.Message;
                }
                return res;
            }
        }
        public static Result GetInformation()
        {
            using (Result res = new Result())
            {
                try
                {
                    res.Json = new JavaScriptSerializer().Deserialize<posInfo>(getInformation());
                }
                catch (Exception ex)
                {
                    res.No = 1001;
                    res.Desc = ex.Message;
                }
                return res;
            }
        }

        public static Result GetInformationString()
        {
            using (Result res = new Result())
            {
                try
                {
                    res.Desc = getInformation();
                }
                catch (Exception ex)
                {
                    res.No = 1001;
                    res.Desc = ex.Message;
                }
                return res;
            }
        }
        public static Result CheckApi()
        {
            using (Result res = new Result())
            {
                try
                {
                    res.Json = new JavaScriptSerializer().Deserialize<Result>(checkAPI());
                }
                catch (Exception ex)
                {
                    res.No = 1001;
                    res.Desc = ex.Message;
                }
                return res;
            }
        }
        public static Result ReturnBill(string BillId, DateTime SaleDate)
        {
            using (Result res = new Result())
            {

                try
                {
                    var returnBillData = new returnBill()
                    {
                        returnBillId = BillId,
                        date = SaleDate.ToString("yyyy-MM-dd HH:mm:ss")
                    };
                    res.Json = new JavaScriptSerializer().Deserialize<vatResponse>(returnBill(new JavaScriptSerializer().Serialize(returnBillData)));
                }
                catch (Exception ex)
                {
                    res.No = 1001;
                    res.Desc = ex.Message;
                }
                return res;
            }
        }

        #endregion
    }
    public class vatResponse : IDisposable
    {
        public string success;
        public string registerNo;
        public string billId;
        public string date;
        public string macAddress;
        public string internalCode;
        public string billType;
        public string qrData;
        public string lottery;
        public string lotterywarningMsg;
        public string errorCode;
        public string message;
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }
                disposedValue = true;
            }
        }
        void IDisposable.Dispose()
        {
            Dispose(true);
            //GC.SuppressFinalize(this);
        }
        #endregion
    }
    public class posInfo : IDisposable
    {
        public string registerNo;
        public string branchNo;
        public string posId;
        public string dbDirPath;
        public extraInfo extraInfo;
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }
                disposedValue = true;
            }
        }
        void IDisposable.Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
    public class returnBill
    {
        public string returnBillId;
        public string date;
    }
    public class extraInfo
    {
        public string countBill;
        public string countLottery;
        public string lastSentDate;
    }
    public class BillData : IDisposable
    {
        public string amount;
        public string vat;
        public string cityTax;
        public string cashAmount;
        public string nonCashAmount;
        public string billIdSuffix;
        public string districtCode;
        public string posNo;
        public string customerNo;
        public string billType;
        public string reportMonth;
        public List<BillDetail> stocks;
        public BindingList<BillBankTransaction> bankTransactions;
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }
                disposedValue = true;
            }
        }
        void IDisposable.Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
    public class BillDetail : IDisposable
    {
        public string code;
        public string name;
        public string measureUnit;
        public string qty;
        public string unitPrice;
        public string totalAmount;
        public string vat;
        public string barCode;
        public string cityTax;
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }
                disposedValue = true;
            }
        }
        void IDisposable.Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
    public class BillBankTransaction : IDisposable
    {
        public string rrn;
        public string bankId;
        public string acquiringBankId;
        public string bankName;
        public string terminalId;
        public string approvalCode;
        public string amount;
        public string cardnumber;
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }
                disposedValue = true;
            }
        }
        void IDisposable.Dispose()
        {
            Dispose(true);
            //GC.SuppressFinalize(this);
        }
        #endregion
    }
}
