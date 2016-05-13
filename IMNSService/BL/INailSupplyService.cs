using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using IMNS.ServiceModel.Service.DL;

namespace IMNS.ServiceModel.Service.BL
{
    // Define a service contract.
    [ServiceContract(Namespace = "http://IMNS.ServiceModel.Service.BL")]
    public interface INailSupplyService
    {
        [OperationContract]
        int InsertProductCategory(string name);
        [OperationContract]       
        IList<Category> GetAllProductCategory();
        [OperationContract]
        void UpdateCategoryName(int categoryID, string name);        
        [OperationContract]
        void DeleteCategory(int categoryID);      



        [OperationContract]
        int InsertProvider(string name, string address, string email, string phone, string description);
        [OperationContract]
        void DeleteProvider(int providerId);
        [OperationContract]
        bool UpdateProvider(ref Provider p);
        [OperationContract]
        IList<Provider> GetAllProvider();

        [OperationContract]
        int InsertProduct(int providerId, int categoryId, string name, string barcode, decimal salePrice, decimal importPrice, string barcodeType, string                               descrtiption);
        [OperationContract]
        void DeleteProduct(int productId);
        [OperationContract]
        bool UpdateProduct(ref Product p);
        [OperationContract]
        IList<Product> GetAllProduct();
        [OperationContract]
        int GetNewestProductID();
        [OperationContract]
        Product GetProductByBarcode(string barcode);
        [OperationContract]
        Product GetProductByID(int productID);
        [OperationContract]
        IList<Product> SearchProductByName(string productName);

        [OperationContract]
        int InsertProductImport();
        [OperationContract]
        bool UpdateProductImport(ref ProductImport pImport);
        [OperationContract]
        void DeleteProductImport(int productImportID);
        [OperationContract]
        IList<ProductImport> GetAllProductImport();
        [OperationContract]
        ProductImport GetProductImportByID(int productImportID);

        [OperationContract]
        int InsertProductImportDetail(ProductImportDetail pDetail);
        [OperationContract]
        bool UpdateProductImportDetail(ref ProductImportDetail pImport);
        [OperationContract]
        void DeleteProductImportDetail(int productImportDetailID);
        [OperationContract]
        IList<ProductImportDetail> GetAllProductImportDetail(int productImportID);
        [OperationContract]
        ProductImportDetail GetProductImportDetailByID(int productImportDetailID);
        [OperationContract]
        ProductImportDetail GetProductImportDetailOfProductImportByBarcode(int productImportID, string barcodeValue);

        [OperationContract]
        int InsertInventory(Inventory inventory);
        [OperationContract]
        bool UpdateInventory(ref Inventory inventory);
        [OperationContract]
        void DeleteInventory(int inventoryID);
        [OperationContract]
        IList<Inventory> GetAllInventory();
        [OperationContract]
        Inventory GetInventoryByBarcode(string barcode);
        [OperationContract]
        bool IsAllowDeleteInventory(int inventoryID);
        [OperationContract]
        void UpdateProductQuantityInInventory(int inventoryID, int nQuantity);

        [OperationContract]
        int InsertProductExport(ProductExport export);
        [OperationContract]
        bool UpdateProductExport(ref ProductExport export);
        [OperationContract]
        void DeleteProductExport(int productExportID);
        [OperationContract]
        IList<ProductExport> GetAllProductExport();
        [OperationContract]
        ProductExport GetProductExportByID(int productExportID);
        [OperationContract]
        ProductExport GetProductByBarcodeOrder(string barcodeValue);

        [OperationContract]
        int InsertProductExportDetail(ProductExportDetail exportDetail);
        [OperationContract]
        bool UpdateProductExportDetail(ref ProductExportDetail exportDetail);
        [OperationContract]
        void DeleteProductExportDetail(int productExportDetailID);
        [OperationContract]
        IList<ProductExportDetail> GetAllProductExportDetail(int productExportID);
        [OperationContract]
        ProductExportDetail GetProductExportDetailByID(int productExportDetailID);
        [OperationContract]
        void DecreaseProductInOrderDetail(int productExportID, string barcodeValue, int productReturnDetailID);
        [OperationContract]
        ProductExportDetail GetProductExportDetailByProductBarcode(int productExportID, string barcodeValue);
        [OperationContract]
        int AddProductReturnBackToProductDetail(int productReturnDetailID);

        [OperationContract]
        int InsertCustomer(Customer c);
        [OperationContract]
        bool UpdateCustomer(ref Customer c);
        [OperationContract]
        void DeleteCustomer(int customerID);
        [OperationContract]
        IList<Customer> GetAllCustomer();

        [OperationContract]
        int InsertPayment(Payment p);
        [OperationContract]
        bool UpdatePayment(ref Payment p);
        [OperationContract]
        void DeletePayment(int paymentID);
        [OperationContract]
        IList<Payment> GetAllPayment();

        [OperationContract]
        IList<InventoryReportData> GetAllInventoryReportDataByQuantity(int nQuantity);

        [OperationContract]
        int InsertProductReturn(ProductReturn p);
        [OperationContract]
        bool UpdateProductReturn(ref ProductReturn p);
        [OperationContract]
        void DeleteProductReturn(int productReturnID);
        [OperationContract]
        IList<ProductReturn> GetAllProductReturn(int productExportID);
        [OperationContract]
        ProductReturn GetProductReturnByID(int productReturnID);

        [OperationContract]
        int InsertProductReturnDetail(ProductReturnDetail p);
        [OperationContract]
        bool UpdateProductReturnDetail(ref ProductReturnDetail p);
        [OperationContract]
        void DeleteProductReturnDetail(int productReturnDetailID);
        [OperationContract]
        IList<ProductReturnDetail> GetAllProductReturnDetail(int productReturnID);
        [OperationContract]
        int InsertProductReturnDetailByExportDetail(int productReturnID, ProductExportDetail pExportDetail);
        [OperationContract]
        void ImportProductReturnBackToInventory(int productReturnID);

        [OperationContract]
        IList<SaleReportData> GetSaleReport(DateTime start, DateTime end);

    }

    [DataContract]
    public class Category
    {
        [DataMember]
        public int CategoryID { get; set; }
        [DataMember]
        public string Name { get; set; }       
    }

    [DataContract]
    public class Provider
    {
        [DataMember]
        public int ProviderID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public Byte[] RowVersion { get; set; }
    }

    [DataContract]
    public class Product
    {
        [DataMember]
        public int ProductID { get; set; }
        [DataMember]
        public int ProviderID { get; set; }
        [DataMember]
        public int CategoryID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Barcode { get; set; }
        [DataMember]
        public decimal SalePrice { get; set; }
        [DataMember]
        public decimal ImportPrice { get; set; }
        [DataMember]
        public string BarcodeType { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public Byte[] RowVersion { get; set; }
    }

    [DataContract]
    public class ProductImport
    {
        [DataMember]
        public int ProductImportID {get;set;}
        [DataMember]
        public int TotalInQuantity { get; set; }
        [DataMember]
        public int TotalOutQuantity { get; set; }
        [DataMember]
        public DateTime ImportDate { get; set; }
        [DataMember]
        public decimal SubTotal { get; set; }       
        [DataMember]
        public int ImportStatus { get; set; }
        [DataMember]
        public string ImportBy { get; set; }
        [DataMember]
        public Byte[] RowVersion { get; set; }
    }

    [DataContract]
    public class ProductImportDetail
    {
        [DataMember]
        public int ProductImportDetailID { get; set; }
        [DataMember]
        public int ProductImportID { get; set; }
        [DataMember]
        public int InventoryID { get; set; }
        [DataMember]
        public string Barcode { get; set; }
        [DataMember]
        public int InQuantiry { get; set; }
        [DataMember]
        public int OutQuantity { get; set; }
        [DataMember]
        public DateTime ImportDate { get; set; }
        [DataMember]
        public decimal ItemImportPrice { get; set; }       
        [DataMember]
        public decimal TotalImportPrice { get; set; }
        [DataMember]
        public int ItemImportStatus { get; set; }
        [DataMember]
        public Byte[] RowVersion { get; set; }
    }

    [DataContract]
    public class Inventory
    {
        [DataMember]
        public int InventoryID { get; set; }
        [DataMember]
        public string Barcode { get; set; }
        [DataMember]
        public int TotalQuantity { get; set; }
        [DataMember]
        public int ProductStatus { get; set; }
        [DataMember]
        public DateTime CreateDate { get; set; }
        [DataMember]
        public string Location { get; set; }
        [DataMember]
        public Byte[] RowVersion { get; set; }
    }

    [DataContract]
    public class ProductExport
    {
        [DataMember]
        public int ProductExportID { get; set; }
        [DataMember]
        public string ExportBarcode { get; set; } //This field uses for look up an product order. It will be printed out on the ticket at the check out.
        [DataMember]
        public int CustomerID { get; set; }
        [DataMember]
        public DateTime ExportDate { get; set; }
        [DataMember]
        public int TotalQuantity { get; set; }
        [DataMember]
        public decimal SubTotal { get; set; }
        [DataMember]
        public decimal SubTax { get; set; }
        [DataMember]
        public decimal SubDiscount { get; set; }
        [DataMember]
        public decimal FinalSalePrice { get; set; }
        [DataMember]
        public decimal TotalImportPrice { get; set; }
        [DataMember]
        public bool Status { get; set; }
        [DataMember]
        public Byte[] RowVersion { get; set; }
    }

    [DataContract]
    public class ProductExportDetail
    {
        [DataMember]
        public int ProductExportDetailID { get; set; }
        [DataMember]
        public int ProductExportID { get; set; }
        [DataMember]
        public int InventoryID { get; set; }
        [DataMember]
        public string Barcode { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public DateTime ExportDate { get; set; }
        [DataMember]
        public decimal ItemPrice { get; set; }
        [DataMember]
        public decimal SubTotal { get; set; }
        [DataMember]
        public Byte[] RowVersion { get; set; }
    }

    [DataContract]
    public class Customer
    {
        [DataMember]
        public int CustomerID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public Byte[] RowVersion { get; set; }
    }

    [DataContract]
    public class Payment
    {
        [DataMember]
        public int PaymentID { get; set;}
        [DataMember]
        public int ProductExportID { get; set;}
        [DataMember]
        public DateTime PaymentDate { get; set; }
        [DataMember]
        public decimal TotalDiscountAmount { get; set; }
        [DataMember]
        public decimal TotalTaxAmount { get; set; }
        [DataMember]
        public decimal TotalItemAmount { get; set; }
        [DataMember]
        public decimal TotalPayment { get; set; }
        [DataMember]
        public string Cashier { get; set; }
        [DataMember]
        public string PaymentType { get; set; }
        [DataMember]
        public Byte[] RowVersion { get; set; }
    }

    [DataContract]
    public class ProductReturn
    {
        [DataMember]
        public int ProductReturnID { get; set; }
        [DataMember]
        public string ProductReturnBarcode { get; set; }
        [DataMember]
        public int ProductExportID { get; set; }
        [DataMember]
        public DateTime ReturnDate { get; set; }
        [DataMember]
        public int TotalItemReturn { get; set; }
        [DataMember]
        public decimal TotalPriceReturn { get; set; }
        [DataMember]
        public decimal TotalTaxReturn { get; set; }
        [DataMember]
        public decimal TotalDiscountReturn { get; set; }
        [DataMember]
        public decimal FinalPriceReturn { get; set; }
        [DataMember]
        public Byte[] RowVersion { get; set; }
    }

    [DataContract]
    public class ProductReturnDetail
    {
        [DataMember]
        public int ProductReturnDetailID { get; set; }
        [DataMember]
        public int ProductReturnID { get; set; }
        [DataMember]
        public string Barcode { get; set; }
        [DataMember]
        public DateTime ReturnDate { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public decimal PriceReturn { get; set; }
        [DataMember]
        public decimal TaxReturn { get; set; }
        [DataMember]
        public decimal DiscountReturn { get; set; }
        [DataMember]
        public decimal FinalPriceReturn { get; set; }
        [DataMember]
        public Byte[] RowVersion { get; set; }
    }

    [DataContract]
    public class InventoryReportData
    {
        [DataMember]
        public int InventoryID
        {
            get;
            set;
        }

        [DataMember]
        public string ProductName
        {
            get;
            set ;
        }

        [DataMember]
        public string Barcode
        {
            get;//is a 00000 string number
            set;
        }

        [DataMember]
        public string ProductUPK
        {
            get;
            set ;
        }

        [DataMember]
        public int TotalQuantity
        {
            get;
            set;
        }
    }

    [DataContract]
    public class SaleReportData
    {
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public decimal TotalSaleAmount { get; set; }
        [DataMember]
        public decimal TotalImportAmount { get; set; }
        [DataMember]
        public decimal IncomeAmount { get; set; }
    }
}
