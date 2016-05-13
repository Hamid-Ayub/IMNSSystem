using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMNS.ServiceModel.Service.BL;

namespace IMNSClient.BL
{
    public class NailSupplyManager
    {
        NailSupplyServiceClient _client = null;
        public NailSupplyManager()
        {
            _client = new NailSupplyServiceClient();
        }

        #region Category
        public Category[] GetAllProductCategory()
        {
            return _client != null ? _client.GetAllProductCategory() : null;
        }

        internal int InsertProductCategory(string name)
        {
            if (_client != null)
                return _client.InsertProductCategory(name);

            return -1;
        }

        internal void UpdateCategoryName(int categoryID, string strCategoryName)
        {
            if (_client != null)
                _client.UpdateCategoryName(categoryID, strCategoryName);
        }
       
        internal void DeleteCategory(int categoryID)
        {
            if (_client != null)
                _client.DeleteCategory(categoryID);
        }
        #endregion

        #region

        internal Provider[] GetAllProvider()
        {
            return _client == null ? null : _client.GetAllProvider();
        }

        internal int InsertProvider(string name, string address, string email, string phone, string description)
        {
            if (_client != null)
                return _client.InsertProvider(name, address, email, phone, description);

            return -1;
        }

        internal void DeleteProvider(int providerID)
        {
            if (_client != null)
                _client.DeleteProvider(providerID);
        }

        internal void UpdateProvider(ref Provider p)
        {
            if (_client != null)
                _client.UpdateProvider(ref p);                 
        }

        #endregion       
    
        #region Product
        internal Product[] GetAllProducts()
        {
            if (_client != null)
                return _client.GetAllProduct();

            return null;
        }

        internal Product[] SearchProductByName(string productName)
        {
            if (_client != null)
                return _client.SearchProductByName(productName);

            return null;
        }

        internal int InsertProduct(Product p)
        {
            if (_client != null && p != null)
                return _client.InsertProduct(p.ProviderID, p.CategoryID, p.Name, p.Barcode, p.SalePrice, p.ImportPrice, p.BarcodeType, p.Description);

            return -1;
        }


        internal int GetNewsetProductID()
        {
            if (_client != null)
                return _client.GetNewestProductID();

            return -2;
        }

        internal void DeleteProduct(int productID)
        {
            if (_client != null)
                _client.DeleteProduct(productID);
                 
        }

        internal void UpdateProduct(ref Product p)
        {
            if (_client != null)
                _client.UpdateProduct(ref p);
        }

        internal Product GetProductByBarcode(string barcode)
        {
            if (_client != null)
                return _client.GetProductByBarcode(barcode);

            return null;
        }

        internal bool IsBarCodeExisted(string barcode)
        {
            if (_client != null)
            {
                return _client.GetProductByBarcode(barcode) != null;
            }
            return false;
        }

        internal Product GetProductByID(int productUPK)
        {
            if (_client != null)
                return _client.GetProductByID(productUPK);

            return null;
        }
        
        #endregion     
       
        #region Inventory

        internal Inventory[] GetAllInventory()
        {
            if (_client != null)
            {
                return _client.GetAllInventory();
            }
            return null;
        }

        internal int InsertInventory(Inventory inventory)
        {
            if (_client != null)
            {
                return _client.InsertInventory(inventory);
            }
            return -1;
        }


        internal void DeleteInventory(int inventoryID)
        {
            if (_client != null)
            {
                _client.DeleteInventory(inventoryID);
            }            
        }

        internal void UpdateInventory(ref Inventory inventory)
        {
            if (_client != null)
                _client.UpdateInventory(ref inventory);
                 
        }

        internal Inventory GetInventoryByBarcode(string barcodeValue)
        {
            if (_client != null)
                return _client.GetInventoryByBarcode(barcodeValue);
            return null;
        }

        internal bool IsAllowDeleteInventory(int inventoryID)
        {
            if (_client != null)
                return _client.IsAllowDeleteInventory(inventoryID);
            return false;
        }

        internal void UpdateProductQuantityInInventory(int inventoryID, int nQuantity)
        {
            if (_client != null)
                _client.UpdateProductQuantityInInventory(inventoryID, nQuantity);
        }

        #endregion

        #region Product Import
        internal int InsertProductImport()
        {
            if (_client != null)
                return _client.InsertProductImport();
            return -1;
           
        }

        internal ProductImportDetail[] GetAllProductImportDetail(int productImportID)
        {
            if (_client != null)
                return _client.GetAllProductImportDetail(productImportID);
            return null;
        }

        internal int InsertProductImportDetail(ProductImportDetail pDetail)
        {
            if (_client != null)
                return _client.InsertProductImportDetail(pDetail);

            return -1;
                 
        }

        internal ProductImport[] GetAllProductImport()
        {
            if (_client != null)
                return _client.GetAllProductImport();

            return null;
        }

        internal void UpdateProductImport(ref ProductImport pImport)
        {
            if (_client != null)
                _client.UpdateProductImport(ref pImport);

        }

        internal ProductImport GetProductImportByID(int productImportID)
        {
            if (_client != null)
                return _client.GetProductImportByID(productImportID);
            return null;
        }

        internal void DeleteProductImport(int productImportID)
        {
            if (_client != null)
            {
                _client.DeleteProductImport(productImportID);
            }
        }        

        internal void DeleteProductImportDetail(int productImportDetailID)
        {
            if (_client != null)
                _client.DeleteProductImportDetail(productImportDetailID);
        }

        internal ProductImportDetail GetProductImportDetailByID(int productImportDetailID)
        {
            if (_client != null)
                return _client.GetProductImportDetailByID(productImportDetailID);

            return null;
        }

        internal bool UpdateProductImportDetail(ref ProductImportDetail productImportDetail)
        {
            if (_client != null)
                return _client.UpdateProductImportDetail(ref productImportDetail);

            return false;
        }

        internal ProductImportDetail GetProductImportDetailOfProductImportByBarcode(int productImportID, string barcodeValue)
        {
            if (_client != null)
                return _client.GetProductImportDetailOfProductImportByBarcode(productImportID, barcodeValue);

            return null;
        }
        
        #endregion     
    
        #region Product Export

        internal int InsertProductExport(ProductExport export)
        {
            if (_client != null)
                return _client.InsertProductExport(export);

            return -1;
        }

        internal int InsertProductExportDetail(ProductExportDetail orderDetail)
        {
            if (_client != null)
                return _client.InsertProductExportDetail(orderDetail);

            return -1;
        }

        internal ProductExportDetail[] GetAllProductExportDetail(int productExportID)
        {
            if (_client != null)
                return _client.GetAllProductExportDetail(productExportID);

            return null;
        }


        internal void DeleteProductExportDetail(int productExportDetailID)
        {
            if (_client != null)
                _client.DeleteProductExportDetail(productExportDetailID);
        }

        internal ProductExport[] GetAllProductExport()
        {
            if (_client != null)
                return _client.GetAllProductExport();
            return null;
        }

        internal void DeleteProductExport(int productExportID)
        {
            if (_client != null)
                _client.DeleteProductExport(productExportID);
        }

        internal ProductExportDetail GetProductExportDetailByID(int productExportDetailID)
        {
            if (_client != null)
                return _client.GetProductExportDetailByID(productExportDetailID);

            return null;                 
        }

        internal void UpdateProductExportDetail(ref ProductExportDetail orderDetail)
        {
            if (_client != null)
                _client.UpdateProductExportDetail(ref orderDetail);
        }


        internal ProductExport GetProductExportByID(int productExportID)
        {
            if (_client != null)
                return _client.GetProductExportByID(productExportID);

            return null;
        }

        internal void UpdateProductExport(ref ProductExport pExport)
        {
            if (_client != null)
                _client.UpdateProductExport(ref pExport);
        }

        internal ProductExport GetProductByBarcodeOrder(string barcodeValue)
        {
            if (_client != null)
                return _client.GetProductByBarcodeOrder(barcodeValue);
            return null;

        }

        internal void DecreaseProductInOrderDetail(int productExportID, string barcodeValue, int productReturnDetailID)
        {
            if (_client != null)
                _client.DecreaseProductInOrderDetail(productExportID, barcodeValue, productReturnDetailID);
        }

        internal ProductExportDetail GetProductExportDetailByProductBarcode(int productExportID, string barcodeValue)
        {
            if (_client != null)
                return _client.GetProductExportDetailByProductBarcode(productExportID, barcodeValue);

            return null;
        }

        internal int AddProductReturnBackToProductDetail(int productReturnDetailID)
        {
            if (_client != null)
                return _client.AddProductReturnBackToProductDetail(productReturnDetailID);
            return -1;

        }
        #endregion

        #region Customer

        internal int InsertCustomer(Customer c)
        {
            if (_client != null)
                return _client.InsertCustomer(c);
            return -1;
        }

        #endregion     
       
    
        #region Payment
        internal int InsertPayment(Payment p)
        {
            if (_client != null)
               return  _client.InsertPayment(p);
            return -1;
        }
        #endregion

        #region Report
        internal InventoryReportData[] GetAllInventoryReportDataByQuantity(int nQuantity)
        {
            if (_client != null)
                return _client.GetAllInventoryReportDataByQuantity(nQuantity);

            return null;
        }

        internal SaleReportData[] GetSaleReport(DateTime startDate, DateTime endDate)
        {
            if (_client != null)
                return _client.GetSaleReport(startDate, endDate);
            return null;
        }
        #endregion


        #region Product Return
        internal ProductReturnDetail[] GetAllProductReturnDetail(int productReturnID)
        {
            if (_client != null)
                return _client.GetAllProductReturnDetail(productReturnID);

            return null;
        }

        internal int InsertProductReturn(ProductReturn pReturn)
        {
            if (_client != null)
                return _client.InsertProductReturn(pReturn);

            return -1;
        }

        #endregion          
        
        #region Product Return Detail


        internal int InsertProductReturnDetailByExportDetail(int productReturnID, ProductExportDetail pExportDetail)
        {
            if (_client != null)
                return _client.InsertProductReturnDetailByExportDetail(productReturnID, pExportDetail);

            return -1;
        }

        internal void DeleteProductReturnDetail(int productReturnDetailID)
        {
            if (_client != null)
                _client.DeleteProductReturnDetail(productReturnDetailID);
        }

        internal void ImportProductReturnBackToInventory(int productReturnID)
        {
            if (_client != null)
                _client.ImportProductReturnBackToInventory(productReturnID);
        }

        internal ProductReturn GetProductReturnByID(int productReturnID)
        {
            if (_client != null)
                return _client.GetProductReturnByID(productReturnID);

            return null;
        }

        internal void UpdateProductReturn(ref ProductReturn pReturn)
        {
            if (_client != null)
                _client.UpdateProductReturn(ref pReturn);
        }
        
        #endregion              
        
    
       
    }
}
