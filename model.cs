using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Receipt
{
    public class TaxPayer : IDisposable
    {
        public string RegisterNo { get; set; }
        public string Name { get; set; }
        public string VatPayerRegisteredDate { get; set; }
        public bool VatPayer { get; set; }
        public bool CityTaxPayer { get; set; }
        public bool Found { get; set; }
        public bool IsTaxFree { get; set; }
        public string UpdatedOn { get; set; }
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
    public class Result : IDisposable
    {
        public int No { get; set; }
        public string Desc { get; set; }
        public int AffectedRows { get; set; }
        public DataTable Data { get; set; }
        public object Json { get; set; }
        public List<Trade> Trade { get; set; }
        public List<VatSales> Vat { get; set; }
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
    public class Config : IDisposable
    {
        public string host { get; set; }
        public string db { get; set; }
        public string userid { get; set; }
        public string password { get; set; }
        public int delay { get; set; }
        public int toprecordcount { get; set; }
        public string stationname { get; set; }
        public string districtcode { get; set; }
        public string companyname { get; set; }
        public List<Nozzle> nozzles { get; set; }
        public List<LoyaltyRule> loyaltyrules { get; set; }
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
    public class Nozzle
    {
        public string nozzleno { get; set; }
        public bool iswhole { get; set; }
    }
    public class LoyaltyRule
    {
        public string nozzleno { get; set; }
        public string itemcode { get; set; }
        public decimal startquantity { get; set; }
        public decimal endquantity { get; set; }
        public decimal discountamount { get; set; }
        public bool iswhole { get; set; }
        public TimeSpan starttime { get; set; }
        public TimeSpan endtime { get; set; }
    }
    public class Trade
    {
        public int TradeId { get; set; }
        public DateTime TradeDate { get; set; }
        public string DispenserNo { get; set; }
        public string NozzleNo { get; set; }
        public bool IsWhole { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public decimal DiscountedAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalizerCount { get; set; }
    }
    public class Sales : IDisposable
    {
        public int SaleNo { get; set; }
        public string BillId { get; set; }
        public string SaleDate { get; set; }
        public string StationNo { get; set; }
        public string StatioName { get; set; }
        public string PosId { get; set; }
        public string CustomerNo { get; set; }
        public string CustomerName { get; set; }
        public bool IsReturned { get; set; }
        public DateTime ReturnedDate { get; set; }
        public decimal NetAmount { get; set; }
        public decimal Vat { get; set; }
        public decimal CityTax { get; set; }
        public decimal OriginalAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal CashAmount { get; set; }
        public decimal CardAmount { get; set; }
        public decimal OtherAmount { get; set; }
        public SalesItemDetail SalesItemDetails { get; set; }
        public SalesPayment SalesPayments { get; set; }
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
    public class SalesItemDetail
    {
        public int SaleNo { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string NozzleNo { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal OriginalAmount { get; set; }
        public decimal Vat { get; set; }
        public decimal CityTax { get; set; }
        public decimal TotalAmount { get; set; }
        public int TradeId { get; set; }
        public DateTime TradeDate { get; set; }
    }
    public class SalesPayment
    {
        public int SaleNo { get; set; }
        public string PaymentType { get; set; }
        public decimal PaymentAmount { get; set; }
    }

    public class VatSales : IDisposable
    {
        public int SaleNo { get; set; }
        public DateTime SaleDate { get; set; }
        public string CustomerNo { get; set; }
        public string CustomerName { get; set; }
        public string NozzleNo { get; set; }
        public string ItemName { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Vat { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal CashAmount { get; set; }
        public decimal CardAmount { get; set; }
        public decimal OtherAmount { get; set; }
        public object ReturnedDate { get; set; }
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
}
