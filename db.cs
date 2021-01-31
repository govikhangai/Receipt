using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using System.Linq;
using System.Text;

namespace Receipt
{
    public class dbconnection
    {
        #region[Variables]
        private string connectionString;
        private List<Trade> tradeList;
        private List<VatSales> vatList;
        #endregion

        #region[Constructor]
        public dbconnection(string connectionstring)
        {
            connectionString = connectionstring;
        }
        public dbconnection(string host, string user, string pass, string db)
        {
            SqlConnectionStringBuilder conbuilder = new SqlConnectionStringBuilder();
            conbuilder.UserID = user;
            conbuilder.Password = pass;
            conbuilder.InitialCatalog = db;
            conbuilder.DataSource = host;
            connectionString = conbuilder.ConnectionString;
        }
        #endregion
        public Result GetStation()
        {
            using (Result res = new Result())
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionString))
                {
                    try
                    {
                        if (sqlcon.State == ConnectionState.Closed) sqlcon.Open();
                    }
                    catch (Exception ex)
                    {
                        res.No = 1001;
                        res.Desc = string.Format("Өгөгдлийн баазтай холбогдоход алдаа гарлаа. Та сүлжээ болон холболтын тохиргоогоо шалгана уу\r\n\r\n{0}", ex.Message);
                        return res;
                    }
                    using (SqlCommand command = sqlcon.CreateCommand())
                    {
                        command.CommandText = string.Format("SELECT TOP 1 * FROM [dbo].[BasSiteSet]");
                        try
                        {
                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                res.Data = new DataTable();
                                res.AffectedRows = adapter.Fill(res.Data);
                                return res;
                            }
                        }
                        catch (Exception ex)
                        {
                            res.No = 1002;
                            res.Desc = string.Format("Өгөгдлийн баазтай харьцахад алдаа гарлаа. \r\n{0}", ex.Message);
                        }
                    }
                }
                return res;
            }
        }
        public Result initialDb()
        {
            using (Result res = new Result())
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionString))
                {
                    try
                    {
                        if (sqlcon.State == ConnectionState.Closed) sqlcon.Open();
                    }
                    catch (Exception ex)
                    {
                        res.No = 1001;
                        res.Desc = string.Format("Өгөгдлийн баазтай холбогдоход алдаа гарлаа. Та сүлжээ болон холболтын тохиргоог шалгана уу\r\n{0}", ex.Message);
                        return res;
                    }
                    using (SqlCommand command = sqlcon.CreateCommand())
                    {
                        command.CommandText = string.Format(@"
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='Vehicle')
CREATE TABLE [dbo].[Vehicle](
	[VehicleId] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[VehicleNumber] [nvarchar](15) NOT NULL,
	[DriverName] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Vehicle] PRIMARY KEY CLUSTERED 
(
	[VehicleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_Vehicle] UNIQUE NONCLUSTERED 
(
	[VehicleNumber] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='Company')
CREATE TABLE [dbo].[Company](
	[CompanyId] [int] IDENTITY(1,1) NOT NULL,
	[CompanyRegister] [nvarchar](15) NULL,
	[CompanyName] [nvarchar](100) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[CompanyId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

IF NOT EXISTS(SELECT *
          FROM   INFORMATION_SCHEMA.COLUMNS
          WHERE  TABLE_NAME = 'Vehicle'
                 AND COLUMN_NAME = 'SiteNumber')
BEGIN
    ALTER TABLE [dbo].Vehicle
    ADD SiteNumber nvarchar(25)
END

IF NOT EXISTS(SELECT *
          FROM   INFORMATION_SCHEMA.COLUMNS
          WHERE  TABLE_NAME = 'TrdTrade'
                 AND COLUMN_NAME = 'IsPrinted')
BEGIN
    ALTER TABLE [dbo].TrdTrade
    ADD IsPrinted bit
END



IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='Sales')
CREATE TABLE [dbo].[Sales](
	[SaleNo] [int] IDENTITY(1,1) NOT NULL,
	[BillId] [varchar](40) NOT NULL,
	[SaleDate] [datetime] NOT NULL,
	[StationNo] [nvarchar](3) NULL,
	[StationName] [nvarchar](50) NULL,
	[PosId] [varchar](10) NULL,
	[CustomerNo] [nvarchar](12) NULL,
	[CustomerName] [nvarchar](100) NULL,
	[IsReturned] [bit] NULL,
	[ReturnedDate] [datetime] NULL,
	[Vat] [decimal](18, 2) NULL,
	[CityTax] [decimal](18, 2) NULL,
	[TotalAmount] [decimal](18, 2) NULL,
    [OriginalAmount] [decimal](18, 2) NOT NULL,
	[CashAmount] [decimal](18, 2) NULL,
	[CardAmount] [decimal](18, 2) NULL,
	[OtherAmount] [decimal](18, 2) NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_Sales1] PRIMARY KEY CLUSTERED 
(
	[SaleNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='SalesItemDetail')
CREATE TABLE [dbo].[SalesItemDetail](
	[SaleNo] [int] NOT NULL,
	[ItemCode] [nvarchar](15) NOT NULL,
	[ItemName] [nvarchar](50) NOT NULL,
	[Quantity] [decimal](18, 2) NOT NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL,
	[Vat] [decimal](18, 2) NOT NULL,
	[CityTax] [decimal](18, 2) NOT NULL,
	[TotalAmount] [decimal](18, 2) NOT NULL,
    [OriginalAmount] [decimal](18, 2) NOT NULL,
	[NozzleNo] [varchar](2) NULL,
	[TradeId] [int] NULL,
	[TradeDate] [datetime] NULL,
 CONSTRAINT [PKEY_ItemDetail] PRIMARY KEY CLUSTERED 
(
	[SaleNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='SalesPayment')
CREATE TABLE [dbo].[SalesPayment](
	[SaleNo] [int] NOT NULL,
	[PaymentType] [nvarchar](10) NOT NULL,
	[PaymentAmount] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PKEY_Payment] PRIMARY KEY CLUSTERED 
(
	[SaleNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]"
);

//                        IF NOT EXISTS(SELECT *
//          FROM   INFORMATION_SCHEMA.COLUMNS
//          WHERE  TABLE_NAME = 'Sales'
//                 AND COLUMN_NAME = 'OriginalAmount')
//BEGIN
//    ALTER TABLE[dbo].Sales
//    ADD OriginalAmount decimal(18, 2)
//END

//IF NOT EXISTS(SELECT *
//          FROM   INFORMATION_SCHEMA.COLUMNS
//          WHERE  TABLE_NAME = 'SalesItemDetail'
//                 AND COLUMN_NAME = 'OriginalAmount')
//BEGIN
//    ALTER TABLE[dbo].SalesItemDetail
//    ADD OriginalAmount decimal(18, 2)
//END"
                        try
                        {
                            res.AffectedRows = command.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            res.No = 1002;
                            res.Desc = string.Format("Өгөгдлийн баазтай харьцахад алдаа гарлаа. \r\n{0}", ex.Message);
                        }
                    }
                }
                return res;
            }
        }

        #region[Trade]
        public Result GetTrade(int toprecord)
        {
            using (Result res = new Result())
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionString))
                {
                    try
                    {
                        if (sqlcon.State == ConnectionState.Closed) sqlcon.Open();
                    }
                    catch (Exception ex)
                    {
                        res.No = 1001;
                        res.Desc = string.Format("Өгөгдлийн баазтай холбогдоход алдаа гарлаа. Та сүлжээ болон холболтын тохиргоог шалгана уу\r\n{0}", ex.Message);
                        return res;
                    }
                    using (SqlCommand command = sqlcon.CreateCommand())
                    {
                        command.CommandText = string.Format(@"
                        SELECT TOP {0} [TrdId] AS TradeId
                        , [PcRcvTime] AS TradeDate
                        , [OilNo] AS ItemCode
                        , [OilName] as ItemName
                        , 0 AS DispenserNo
                        , [GunNo] AS NozzleNo
                        , [Qty] AS Quantity
                        , [Price] AS UnitPrice
                        , [Money] AS TotalAmount
                        , [PumpQty] AS TotalizerCount 
                        FROM [dbo].[TrdTrade]
                        WHERE [IsPrinted] = 0 OR [IsPrinted] IS NULL
                        ORDER BY [TrdId] DESC", toprecord);

                        //command.CommandText = string.Format(@"
                        //SELECT * 
                        //FROM [dbo].[Trade]
                        //ORDER BY [TradeId] DESC", toprecord);
                        try
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                tradeList = new List<Trade>();
                                while (reader.Read())
                                {
                                    tradeList.Add(new Trade()
                                    {
                                        TradeId = Convert.ToInt32(reader["TradeId"]),
                                        TradeDate = Convert.ToDateTime(reader["TradeDate"]),
                                        DispenserNo = reader["DispenserNo"] != DBNull.Value ? Convert.ToString(reader["DispenserNo"]) : string.Empty,
                                        NozzleNo = reader["NozzleNo"] != DBNull.Value ? Convert.ToString(reader["NozzleNo"]) : string.Empty,
                                        ItemCode = reader["ItemCode"] != DBNull.Value ? Convert.ToString(reader["ItemCode"]) : string.Empty,
                                        ItemName = reader["ItemName"] != DBNull.Value ? Convert.ToString(reader["ItemName"]) : string.Empty,
                                        Quantity = Convert.ToDecimal(reader["Quantity"]),
                                        UnitPrice = Convert.ToDecimal(reader["UnitPrice"]),
                                        TotalAmount = Convert.ToDecimal(reader["TotalAmount"]),
                                        TotalizerCount = Convert.ToDecimal(reader["TotalizerCount"]),
                                    });
                                }
                                res.Trade = tradeList;
                                res.AffectedRows = tradeList.Count;
                            }
                        }
                        catch (Exception ex)
                        {
                            res.No = 1002;
                            res.Desc = string.Format("Өгөгдлийн баазтай харьцахад алдаа гарлаа. \r\n{0}", ex.Message);
                        }
                    }
                }
                return res;
            }
        }
        public Result UpdateTrade(int TradeId)
        {
            using (Result res = new Result())
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionString))
                {
                    try
                    {
                        if (sqlcon.State == ConnectionState.Closed) sqlcon.Open();
                    }
                    catch (Exception ex)
                    {
                        res.No = 1001;
                        res.Desc = string.Format("Өгөгдлийн баазтай холбогдоход алдаа гарлаа. Та сүлжээ болон холболтын тохиргоог шалгана уу\r\n{0}", ex.Message);
                        return res;
                    }
                    using (SqlCommand command = sqlcon.CreateCommand())
                    {
                        command.CommandText = string.Format(@"UPDATE [dbo].[TrdTrade] SET [IsPrinted]=1 WHERE [TrdId]=@1");

                        try
                        {
                            command.Parameters.AddWithValue("@1", TradeId);

                            res.AffectedRows = command.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            res.No = 1002;
                            res.Desc = string.Format("Өгөгдлийн баазтай харьцахад алдаа гарлаа. \r\n{0}", ex.Message);
                        }
                    }
                }
                return res;
            }
        }
        public Result InsertVatSales(Sales sales)
        {
            int saleno = 0;
            using (Result res = new Result())
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionString))
                {
                    try
                    {
                        if (sqlcon.State == ConnectionState.Closed) sqlcon.Open();
                    }
                    catch (Exception ex)
                    {
                        res.No = 1001;
                        res.Desc = string.Format("Өгөгдлийн баазтай холбогдоход алдаа гарлаа. Та сүлжээ болон холболтын тохиргоог шалгана уу\r\n{0}", ex.Message);
                        return res;
                    }
                    using (SqlTransaction tran = sqlcon.BeginTransaction())
                    {
                        #region[Sales]
                        using (SqlCommand command = sqlcon.CreateCommand())
                        {
                            command.Transaction = tran;
                            command.CommandText = string.Format(@"INSERT INTO [dbo].[Sales]
           (
            [BillId]
           ,[SaleDate]
           ,[StationNo]
           ,[StationName]
           ,[PosId]
           ,[CustomerNo]
           ,[CustomerName]
           ,[IsReturned]
           ,[Vat]
           ,[CityTax]
           ,[TotalAmount]
           ,[OriginalAmount]
           ,[CashAmount]
           ,[CardAmount]
           ,[OtherAmount]
           ,[CreatedDate])
OUTPUT inserted.SaleNo
VALUES(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15,GETDATE());");

                            try
                            {
                                command.Parameters.AddWithValue("@1", sales.BillId);
                                command.Parameters.AddWithValue("@2", sales.SaleDate);
                                command.Parameters.AddWithValue("@3", sales.StationNo);
                                command.Parameters.AddWithValue("@4", sales.StatioName);
                                command.Parameters.AddWithValue("@5", sales.PosId);
                                command.Parameters.AddWithValue("@6", sales.CustomerNo);
                                command.Parameters.AddWithValue("@7", sales.CustomerName);
                                command.Parameters.AddWithValue("@8", 0);
                                command.Parameters.AddWithValue("@9", sales.Vat);
                                command.Parameters.AddWithValue("@10", sales.CityTax);
                                command.Parameters.AddWithValue("@11", sales.TotalAmount);
                                command.Parameters.AddWithValue("@12", sales.OriginalAmount);
                                command.Parameters.AddWithValue("@13", sales.CashAmount);
                                command.Parameters.AddWithValue("@14", sales.CardAmount);
                                command.Parameters.AddWithValue("@15", sales.OtherAmount);
                                saleno = Convert.ToInt32(command.ExecuteScalar());
                            }
                            catch (Exception ex)
                            {
                                res.No = 1002;
                                res.Desc = string.Format("Үндсэн мэдээлэл хадгалахад алдаа гарлаа. \r\n{0}", ex.Message);
                                tran.Rollback();
                                return res;
                            }
                        }
                        #endregion
                        #region[SalesItem]
                        using (SqlCommand command = sqlcon.CreateCommand())
                        {
                            command.Transaction = tran;
                            command.CommandText = string.Format(@"INSERT INTO [dbo].[SalesItemDetail]
               ([SaleNo]
               ,[ItemCode]
               ,[ItemName]
               ,[Quantity]
               ,[UnitPrice]
               ,[Vat]
               ,[CityTax]
               ,[TotalAmount]
               ,[OriginalAmount]
               ,[NozzleNo]
               ,[TradeId]
               ,[TradeDate]) VALUES(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12);");

                            try
                            {
                                command.Parameters.AddWithValue("@1", saleno);
                                command.Parameters.AddWithValue("@2", sales.SalesItemDetails.ItemCode);
                                command.Parameters.AddWithValue("@3", sales.SalesItemDetails.ItemName);
                                command.Parameters.AddWithValue("@4", sales.SalesItemDetails.Quantity);
                                command.Parameters.AddWithValue("@5", sales.SalesItemDetails.UnitPrice);
                                command.Parameters.AddWithValue("@6", sales.SalesItemDetails.Vat);
                                command.Parameters.AddWithValue("@7", sales.SalesItemDetails.CityTax);
                                command.Parameters.AddWithValue("@8", sales.SalesItemDetails.TotalAmount);
                                command.Parameters.AddWithValue("@9", sales.SalesItemDetails.OriginalAmount);
                                command.Parameters.AddWithValue("@10", sales.SalesItemDetails.NozzleNo);
                                command.Parameters.AddWithValue("@11", sales.SalesItemDetails.TradeId);
                                command.Parameters.AddWithValue("@12", sales.SalesItemDetails.TradeDate);
                                res.AffectedRows = command.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                res.No = 1002;
                                res.Desc = string.Format("Барааны мэдээлэл хадгалахад алдаа гарлаа. \r\n{0}", ex.Message);
                                tran.Rollback();
                                return res;
                            }
                        }
                        #endregion
                        #region[SalesPayment]
                        using (SqlCommand command = sqlcon.CreateCommand())
                        {
                            command.Transaction = tran;
                            command.CommandText = string.Format(@"INSERT INTO [dbo].[SalesPayment]([SaleNo],[PaymentType],[PaymentAmount]) VALUES(@1,@2,@3);");
                            try
                            {
                                command.Parameters.AddWithValue("@1", saleno);
                                command.Parameters.AddWithValue("@2", sales.SalesPayments.PaymentType);
                                command.Parameters.AddWithValue("@3", sales.SalesPayments.PaymentAmount);
                                res.AffectedRows = command.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                res.No = 1002;
                                res.Desc = string.Format("Төлбөрийн мэдээлэл хадгалахад алдаа гарлаа. \r\n{0}", ex.Message);
                                tran.Rollback();
                                return res;
                            }
                        }
                        #endregion
                        #region[UpdateTrade]
                        using (SqlCommand command = sqlcon.CreateCommand())
                        {
                            command.Transaction = tran;
                            command.CommandText = string.Format(@"UPDATE [dbo].[TrdTrade] SET [IsPrinted]=1 WHERE [TrdId]=@1");

                            try
                            {
                                command.Parameters.AddWithValue("@1", sales.SalesItemDetails.TradeId);
                                res.AffectedRows = command.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                res.No = 1002;
                                res.Desc = string.Format("Түгээлтийн төлөв өөрчлөөд алдаа гарлаа. \r\n{0}", ex.Message);
                                tran.Rollback();
                                return res;
                            }
                        }
                        #endregion

                        tran.Commit();
                    }
                }
                return res;
            }
        }
        public Result GetVatSales(DateTime date)
        {
            using (Result res = new Result())
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionString))
                {
                    try
                    {
                        if (sqlcon.State == ConnectionState.Closed) sqlcon.Open();
                    }
                    catch (Exception ex)
                    {
                        res.No = 1001;
                        res.Desc = string.Format("Өгөгдлийн баазтай холбогдоход алдаа гарлаа. Та сүлжээ болон холболтын тохиргоог шалгана уу\r\n{0}", ex.Message);
                        return res;
                    }
                    using (SqlCommand command = sqlcon.CreateCommand())
                    {
                        command.CommandText = @"
SELECT s.SaleNo, SaleDate, CustomerNo, CustomerName,ReturnedDate,i.ItemName,i.Quantity,i.UnitPrice,i.Vat,i.TotalAmount,NozzleNo,CashAmount,CardAmount,OtherAmount
FROM [dbo].[Sales] as s
LEFT JOIN dbo.SalesItemDetail as i on s.saleno=i.saleno
WHERE CONVERT(varchar(8), saledate, 112) = CONVERT(varchar(8), @1, 112)
ORDER BY s.SaleNo DESC";
                        try
                        {
                            command.Parameters.AddWithValue("@1", date);

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                vatList = new List<VatSales>();
                                while (reader.Read())
                                {
                                    vatList.Add(new VatSales()
                                    {
                                        SaleNo = Static.ToInt(reader["SaleNo"]),
                                        SaleDate = Static.ToDateTime(reader["SaleDate"]),
                                        CustomerNo = Static.ToStr(reader["CustomerNo"]),
                                        CustomerName = Static.ToStr(reader["CustomerName"]),
                                        NozzleNo = Static.ToStr(reader["NozzleNo"]),
                                        ItemName = Static.ToStr(reader["ItemName"]),
                                        Quantity = Static.ToDecimal(reader["Quantity"]),
                                        UnitPrice = Static.ToDecimal(reader["UnitPrice"]),
                                        Vat = Static.ToDecimal(reader["Vat"]),
                                        TotalAmount = Static.ToDecimal(reader["TotalAmount"]),
                                        CashAmount = Static.ToDecimal(reader["CashAmount"]),
                                        CardAmount = Static.ToDecimal(reader["CardAmount"]),
                                        OtherAmount = Static.ToDecimal(reader["OtherAmount"]),
                                        ReturnedDate = reader["ReturnedDate"]
                                    });
                                }
                                res.Vat = vatList;
                                res.AffectedRows = vatList.Count;
                            }
                        }
                        catch (Exception ex)
                        {
                            res.No = 1002;
                            res.Desc = string.Format("Өгөгдлийн баазтай харьцахад алдаа гарлаа. \r\n{0}", ex.Message);
                        }
                    }
                }
                return res;
            }
        }
        #endregion

        #region[Company]
        public Result GetCompany()
        {
            using (Result res = new Result())
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionString))
                {
                    try
                    {
                        if (sqlcon.State == ConnectionState.Closed) sqlcon.Open();
                    }
                    catch (Exception ex)
                    {
                        res.No = 1001;
                        res.Desc = string.Format("Өгөгдлийн баазтай холбогдоход алдаа гарлаа. Та сүлжээ болон холболтын тохиргоог шалгана уу\r\n{0}", ex.Message);
                        return res;
                    }
                    using (SqlCommand command = sqlcon.CreateCommand())
                    {
                        command.CommandText = string.Format("SELECT * FROM [dbo].[Company] ORDER BY CompanyId DESC");
                        try
                        {
                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                res.Data = new DataTable();
                                res.AffectedRows = adapter.Fill(res.Data);
                                return res;
                            }
                        }
                        catch (Exception ex)
                        {
                            res.No = 1002;
                            res.Desc = string.Format("Өгөгдлийн баазтай харьцахад алдаа гарлаа. \r\n{0}", ex.Message);
                        }
                    }
                }
                return res;
            }
        }
        public Result CreateCompany(string CompanyRegister, string CompanyName)
        {
            using (Result res = new Result())
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionString))
                {
                    try
                    {
                        if (sqlcon.State == ConnectionState.Closed) sqlcon.Open();
                    }
                    catch (Exception ex)
                    {
                        res.No = 1001;
                        res.Desc = string.Format("Өгөгдлийн баазтай холбогдоход алдаа гарлаа. Та сүлжээ болон холболтын тохиргоог шалгана уу\r\n{0}", ex.Message);
                        return res;
                    }
                    using (SqlCommand command = sqlcon.CreateCommand())
                    {
                        command.CommandText = string.Format(@"INSERT INTO [dbo].[Company]([CompanyRegister],[CompanyName],[CreatedDate]) VALUES(@1,@2,GETDATE());");
                        try
                        {
                            command.Parameters.AddWithValue("@1", CompanyRegister);
                            command.Parameters.AddWithValue("@2", CompanyName);

                            res.AffectedRows = command.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            res.No = 1002;
                            res.Desc = string.Format("Өгөгдлийн баазтай харьцахад алдаа гарлаа. \r\n{0}", ex.Message);
                        }
                    }
                }
                return res;
            }
        }
        public Result UpdateCompany(int CompanyId, string CompanyRegister, string CompanyName)
        {
            using (Result res = new Result())
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionString))
                {
                    try
                    {
                        if (sqlcon.State == ConnectionState.Closed) sqlcon.Open();
                    }
                    catch (Exception ex)
                    {
                        res.No = 1001;
                        res.Desc = string.Format("Өгөгдлийн баазтай холбогдоход алдаа гарлаа. Та сүлжээ болон холболтын тохиргоог шалгана уу\r\n{0}", ex.Message);
                        return res;
                    }
                    using (SqlCommand command = sqlcon.CreateCommand())
                    {
                        command.CommandText = string.Format(@"UPDATE [dbo].[Company] SET [CompanyRegister] = @2, [CompanyName] = @3, [UpdatedDate] = GETDATE() WHERE [CompanyId]=@1");

                        try
                        {
                            command.Parameters.AddWithValue("@1", CompanyId);
                            command.Parameters.AddWithValue("@2", CompanyRegister);
                            command.Parameters.AddWithValue("@3", CompanyName);

                            res.AffectedRows = command.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            res.No = 1002;
                            res.Desc = string.Format("Өгөгдлийн баазтай харьцахад алдаа гарлаа. \r\n{0}", ex.Message);
                        }
                    }
                }
                return res;
            }
        }
        public Result DeleteCompany(int CompanyId)
        {
            using (Result res = new Result())
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionString))
                {
                    try
                    {
                        if (sqlcon.State == ConnectionState.Closed) sqlcon.Open();
                    }
                    catch (Exception ex)
                    {
                        res.No = 1001;
                        res.Desc = string.Format("Өгөгдлийн баазтай холбогдоход алдаа гарлаа. Та сүлжээ болон холболтын тохиргоог шалгана уу\r\n{0}", ex.Message);
                        return res;
                    }
                    using (SqlCommand command = sqlcon.CreateCommand())
                    {
                        command.CommandText = string.Format(@"DELETE [dbo].[Company] WHERE [CompanyId]=@1");

                        try
                        {
                            command.Parameters.AddWithValue("@1", CompanyId);

                            res.AffectedRows = command.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            res.No = 1002;
                            res.Desc = string.Format("Өгөгдлийн баазтай харьцахад алдаа гарлаа. \r\n{0}", ex.Message);
                        }
                    }
                }
                return res;
            }
        }
        #endregion

        #region[Vehicle]
        public Result GetVehicle()
        {
            using (Result res = new Result())
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionString))
                {
                    try
                    {
                        if (sqlcon.State == ConnectionState.Closed) sqlcon.Open();
                    }
                    catch (Exception ex)
                    {
                        res.No = 1001;
                        res.Desc = string.Format("Өгөгдлийн баазтай холбогдоход алдаа гарлаа. Та сүлжээ болон холболтын тохиргоог шалгана уу\r\n{0}", ex.Message);
                        return res;
                    }
                    using (SqlCommand command = sqlcon.CreateCommand())
                    {
                        command.CommandText = string.Format(@"
SELECT v.*,c.CompanyName FROM [dbo].[Vehicle] as v
LEFT JOIN [dbo].[Company] as c on c.CompanyId=v.CompanyId
ORDER BY VehicleId DESC");
                        try
                        {
                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                res.Data = new DataTable();
                                res.AffectedRows = adapter.Fill(res.Data);
                                return res;
                            }
                        }
                        catch (Exception ex)
                        {
                            res.No = 1002;
                            res.Desc = string.Format("Өгөгдлийн баазтай харьцахад алдаа гарлаа. \r\n{0}", ex.Message);
                        }
                    }
                }
                return res;
            }
        }
        public Result GetVehicle(int CompanyId)
        {
            using (Result res = new Result())
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionString))
                {
                    try
                    {
                        if (sqlcon.State == ConnectionState.Closed) sqlcon.Open();
                    }
                    catch (Exception ex)
                    {
                        res.No = 1001;
                        res.Desc = string.Format("Өгөгдлийн баазтай холбогдоход алдаа гарлаа. Та сүлжээ болон холболтын тохиргоог шалгана уу\r\n{0}", ex.Message);
                        return res;
                    }
                    using (SqlCommand command = sqlcon.CreateCommand())
                    {
                        command.CommandText = string.Format(@"
SELECT v.VehicleId,v.VehicleNumber,v.DriverName,v.SiteNumber
FROM [dbo].[Vehicle] as v
LEFT JOIN [dbo].[Company] as c on c.CompanyId=v.CompanyId
WHERE v.CompanyId=@1
ORDER BY VehicleId DESC");
                        command.Parameters.AddWithValue("@1", CompanyId);
                        try
                        {
                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                res.Data = new DataTable();
                                res.AffectedRows = adapter.Fill(res.Data);
                                return res;
                            }
                        }
                        catch (Exception ex)
                        {
                            res.No = 1002;
                            res.Desc = string.Format("Өгөгдлийн баазтай харьцахад алдаа гарлаа. \r\n{0}", ex.Message);
                        }
                    }
                }
                return res;
            }
        }
        public Result GetVehicle(string SiteNumber)
        {
            using (Result res = new Result())
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionString))
                {
                    try
                    {
                        if (sqlcon.State == ConnectionState.Closed) sqlcon.Open();
                    }
                    catch (Exception ex)
                    {
                        res.No = 1001;
                        res.Desc = string.Format("Өгөгдлийн баазтай холбогдоход алдаа гарлаа. Та сүлжээ болон холболтын тохиргоог шалгана уу\r\n{0}", ex.Message);
                        return res;
                    }
                    using (SqlCommand command = sqlcon.CreateCommand())
                    {
                        command.CommandText = string.Format(@"
SELECT c.CompanyId,v.VehicleId,v.VehicleNumber,v.DriverName,v.SiteNumber
FROM [dbo].[Vehicle] as v
LEFT JOIN [dbo].[Company] as c on c.CompanyId=v.CompanyId
WHERE v.SiteNumber like N'{0}%'
ORDER BY VehicleId DESC", SiteNumber);
                        try
                        {
                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                res.Data = new DataTable();
                                res.AffectedRows = adapter.Fill(res.Data);
                                return res;
                            }
                        }
                        catch (Exception ex)
                        {
                            res.No = 1002;
                            res.Desc = string.Format("Өгөгдлийн баазтай харьцахад алдаа гарлаа. \r\n{0}", ex.Message);
                        }
                    }
                }
                return res;
            }
        }
        public Result CreateVehicle(int CompanyId, string VehicleNumber, string DriverName, string SiteNumber)
        {
            using (Result res = new Result())
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionString))
                {
                    try
                    {
                        if (sqlcon.State == ConnectionState.Closed) sqlcon.Open();
                    }
                    catch (Exception ex)
                    {
                        res.No = 1001;
                        res.Desc = string.Format("Өгөгдлийн баазтай холбогдоход алдаа гарлаа. Та сүлжээ болон холболтын тохиргоог шалгана уу\r\n{0}", ex.Message);
                        return res;
                    }
                    using (SqlCommand command = sqlcon.CreateCommand())
                    {
                        command.CommandText = string.Format(@"INSERT INTO [dbo].[Vehicle]([CompanyId],[VehicleNumber],[DriverName],[SiteNumber],[CreatedDate]) VALUES(@1,@2,@3,@4,GETDATE());");
                        try
                        {
                            command.Parameters.AddWithValue("@1", CompanyId);
                            command.Parameters.AddWithValue("@2", VehicleNumber);
                            command.Parameters.AddWithValue("@3", DriverName);
                            command.Parameters.AddWithValue("@4", SiteNumber);

                            res.AffectedRows = command.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            res.No = 1002;
                            res.Desc = string.Format("Өгөгдлийн баазтай харьцахад алдаа гарлаа. \r\n{0}", ex.Message);
                        }
                    }
                }
                return res;
            }
        }
        public Result UpdateVehicle(int VehicleId, int CompanyId, string VehicleNumber, string DriverName, string SiteNumber)
        {
            using (Result res = new Result())
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionString))
                {
                    try
                    {
                        if (sqlcon.State == ConnectionState.Closed) sqlcon.Open();
                    }
                    catch (Exception ex)
                    {
                        res.No = 1001;
                        res.Desc = string.Format("Өгөгдлийн баазтай холбогдоход алдаа гарлаа. Та сүлжээ болон холболтын тохиргоог шалгана уу\r\n{0}", ex.Message);
                        return res;
                    }
                    using (SqlCommand command = sqlcon.CreateCommand())
                    {
                        command.CommandText = string.Format(@"UPDATE [dbo].[Vehicle] SET [CompanyId] = @2, [VehicleNumber] = @3, [DriverName] = @4, [SiteNumber] = @5, [UpdatedDate] = GETDATE() WHERE [VehicleId]=@1");

                        try
                        {
                            command.Parameters.AddWithValue("@1", VehicleId);
                            command.Parameters.AddWithValue("@2", CompanyId);
                            command.Parameters.AddWithValue("@3", VehicleNumber);
                            command.Parameters.AddWithValue("@4", DriverName);
                            command.Parameters.AddWithValue("@5", SiteNumber);

                            res.AffectedRows = command.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            res.No = 1002;
                            res.Desc = string.Format("Өгөгдлийн баазтай харьцахад алдаа гарлаа. \r\n{0}", ex.Message);
                        }
                    }
                }
                return res;
            }
        }
        public Result DeleteVehicle(int VehicleId)
        {
            using (Result res = new Result())
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionString))
                {
                    try
                    {
                        if (sqlcon.State == ConnectionState.Closed) sqlcon.Open();
                    }
                    catch (Exception ex)
                    {
                        res.No = 1001;
                        res.Desc = string.Format("Өгөгдлийн баазтай холбогдоход алдаа гарлаа. Та сүлжээ болон холболтын тохиргоог шалгана уу\r\n{0}", ex.Message);
                        return res;
                    }
                    using (SqlCommand command = sqlcon.CreateCommand())
                    {
                        command.CommandText = string.Format(@"DELETE [dbo].[Vehicle] WHERE [VehicleId]=@1");

                        try
                        {
                            command.Parameters.AddWithValue("@1", VehicleId);

                            res.AffectedRows = command.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            res.No = 1002;
                            res.Desc = string.Format("Өгөгдлийн баазтай харьцахад алдаа гарлаа. \r\n{0}", ex.Message);
                        }
                    }
                }
                return res;
            }
        }
        #endregion
    }
}
