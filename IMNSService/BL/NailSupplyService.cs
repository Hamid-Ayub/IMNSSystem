using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using IMNS.ServiceModel.Service.DL;

namespace IMNS.ServiceModel.Service.BL
{
     // Step 1: Create service class that implements the service contract.
    public class NailSupplyService : INailSupplyService
    {
        //Initial: just creating; Ready: finising importing, and ready to export; 
        //Partial: some items have been exported; Done: All items have been exported
        public enum ImportStatus { Initial = 0, Ready_Export, Partial_Export, Done_Export, Product_Return};
        public enum ItemImportStatus { Ready = 0, Partial, Done };
        public enum InventoryProductStatus {Out_Of_Stock = 0, Available = 1};
        public enum ExportStatus {Open = 0, Close = 1};

        #region Category
        public CategoryEntity GetCategory()
        {
            Console.WriteLine("Received GetCategory");
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {

                    var myItem = (from c in db.CategoryEntities
                                  select c);

                    Console.WriteLine("Return Received GetCategory ");
                    return myItem.FirstOrDefault();

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: can not get list of Product category " + ex.Message);
                }
            }           
        }

        private Category TranslateCategoryEntityToCategory(CategoryEntity e)
        {
            Category c = new Category();
            c.CategoryID = e.CategoryID;
            c.Name = e.Name;
           
            return c;
        }

        // Step 2: Implement functionality for the service operations.
        /// <summary>
        /// This function will return a list of Product Category
        /// </summary>
        /// <returns></returns>
        public IList<Category> GetAllProductCategory()
        {
            Console.WriteLine("Received GetAllProductCategory");
            List<Category> lstCategory = new List<Category>();
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {

                    var myItem = (from c in db.CategoryEntities
                                  select c);

                    foreach (CategoryEntity e in myItem)
                    {
                        lstCategory.Add(TranslateCategoryEntityToCategory(e));
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: can not get list of Product category " + ex.Message);
                }
            }

            Console.WriteLine("Return Received GetAllProductCategory ");
            return lstCategory;
        }

        /// <summary>
        /// This function will insert a new product category
        /// </summary>
        /// <param name="name"></param>
        /// <param name="saleTax"></param>
        public int InsertProductCategory(string name)
        {
            Console.WriteLine("Received InsertProductCategory");
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {
                    //check serviceName is existed or not.
                    var myItem = (from c in db.CategoryEntities where c.Name.ToLower() == name.ToLower() select c).FirstOrDefault();
                    if (myItem != null)
                    {
                        //category is already existed.
                        return -2; //category already exsited, do not need to insert
                    }
                    else
                    {
                        //create product category.
                        CategoryEntity e = new CategoryEntity();

                        e.Name = name;
                        db.CategoryEntities.Add(e);
                        db.SaveChanges();
                        return e.CategoryID;
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: Unable to insert a new Product Category" + ex.Message);
                }
            }

        }

        public void UpdateCategoryName(int categoryID, string name)
        {
            Console.WriteLine("Received UpdateCategoryName");
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {
                    var myItem = (from c in db.CategoryEntities
                                  where c.CategoryID == categoryID
                                  select c).FirstOrDefault();

                    if (myItem != null)
                    {
                        myItem.Name = name;
                        db.SaveChanges();
                    }

                    Console.WriteLine("Return Received UpdateCategoryName ");

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: There is an error while UpdateCategoryName " + ex.Message);
                }
            }           
        }

       

        public void DeleteCategory(int categoryID)
        {
            Console.WriteLine("Received DeleteCategory");
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {
                    var myItem = (from c in db.CategoryEntities
                                  where c.CategoryID == categoryID
                                  select c).FirstOrDefault();

                    if (myItem != null)
                    {
                        db.CategoryEntities.Remove(myItem);
                        db.SaveChanges();
                    }

                    Console.WriteLine("Return Received DeleteCategory ");

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: There is an error while DeleteCategory " + ex.Message);
                }
            }           
        }

        #endregion

        #region Provider

        public int InsertProvider(string name, string address, string email, string phone, string description)
        {
            Console.WriteLine("Received InsertProvider");
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {
                    //check serviceName is existed or not.
                    var myItem = (from c in db.ProviderEntities where c.Name.ToLower() == name.ToLower() select c).FirstOrDefault();
                    if (myItem != null)
                    {
                        //category is already existed.
                        return -2; //provider already exsited, do not need to insert
                    }
                    else
                    {
                        //create product category.
                        ProviderEntity p = new ProviderEntity();

                        p.Name = name;
                        p.Address = address;
                        p.Email = email;
                        p.Phone = phone;
                        p.Description = description;

                        db.ProviderEntities.Add(p);
                        db.SaveChanges();
                        return p.ProviderID;
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: Unable to insert a new InsertProvider" + ex.Message);
                }
            }
        }

        public void DeleteProvider(int providerId)
        {
            Console.WriteLine("Received DeleteProvider");
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {
                    var myItem = (from c in db.ProviderEntities
                                  where c.ProviderID == providerId
                                  select c).FirstOrDefault();

                    if (myItem != null)
                    {
                        db.ProviderEntities.Remove(myItem);
                        db.SaveChanges();
                    }

                    Console.WriteLine("Return Received DeleteProvider ");

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: There is an error while DeleteProvider " + ex.Message);
                }
            }           
        }

        public bool UpdateProvider(ref Provider p)
        {
            Console.WriteLine("Received UpdateProvider");
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {
                    int providerID = p.ProviderID;
                    var providerEntity = (from c in db.ProviderEntities
                                                   where c.ProviderID == providerID
                                                   select c).FirstOrDefault();
                    if (providerEntity == null)
                    {
                        throw new Exception("No product with ID " + p.ProviderID);
                    }

                    //detach it first.
                    ((IObjectContextAdapter)db).ObjectContext.Detach(providerEntity);
                    //update the product
                    providerEntity.Address = p.Address;
                    providerEntity.Name = p.Name;
                    providerEntity.Description = p.Description;
                    providerEntity.Email = p.Email;
                    providerEntity.Phone = p.Phone;
                    providerEntity.RowVersion = p.RowVersion;
                    //attach it.
                    //((IObjectContextAdapter)db).ObjectContext.Attach((IEntityWithKey)providerEntity);
                    ((IObjectContextAdapter)db).ObjectContext.AttachTo("ProviderEntities", providerEntity);
                    // change object state
                    ((IObjectContextAdapter)db).ObjectContext.ObjectStateManager.ChangeObjectState(providerEntity, System.Data.EntityState.Modified);

                    db.SaveChanges();
                    p.RowVersion = providerEntity.RowVersion;
                    db.Dispose();
                    Console.WriteLine("Return Received UpdateProvider ");
                    return true;              
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: There is an error while UpdateProvider " + ex.Message);
                }
            }           
        }

        public IList<Provider> GetAllProvider()
        {
            Console.WriteLine("Received GetAllProvider");
            List<Provider> lstProvider = new List<Provider>();
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {

                    var myItem = (from c in db.ProviderEntities
                                  select c);

                    foreach (ProviderEntity p in myItem)
                    {
                        lstProvider.Add(TranslateProviderEntityToProvider(p));
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: can not get list of GetAllProvider category " + ex.Message);
                }
            }

            Console.WriteLine("Return Received GetAllProvider ");
            return lstProvider;
        }

        private Provider TranslateProviderEntityToProvider(ProviderEntity entity)
        {
            Provider p = new Provider();
            p.ProviderID = entity.ProviderID;
            p.Name = entity.Name;
            p.Phone = entity.Phone;
            p.Address = entity.Address;
            p.Email = entity.Email;
            p.Description = entity.Description;
            p.RowVersion = entity.RowVersion;
            return p;
        }

        #endregion

        #region Product
        public int InsertProduct(int providerId, int categoryId, string name, string barcode, decimal salePrice, decimal importPrice, string barcodeType, string descrtiption)
        {
            Console.WriteLine("Received InsertProduct");
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {
                    //check serviceName is existed or not.
                    var myItem = (from c in db.ProductEntities
                                  where c.UPCBarCode.ToLower() == barcode.ToLower() 
                                        select c)
                                  .FirstOrDefault();
                    if (myItem != null)
                    {
                        //product already existed
                        return -2; //provider already exsited, do not need to insert
                    }
                    else
                    {
                        //create product category.
                        ProductEntity p = new ProductEntity();
                        p.ProviderID = providerId;
                        p.CategoryID = categoryId;
                        p.UPCBarCode = barcode;
                        p.Name = name;
                        p.SalePrice = salePrice;
                        p.ImportPrice = importPrice;
                        p.UPCType = barcodeType;
                        p.Description = descrtiption;

                        db.ProductEntities.Add(p);
                        db.SaveChanges();
                        Console.WriteLine("Return InsertProduct");
                        return p.ProviderID;
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: Unable to insert a new InsertProduct" + ex.Message);
                }
            }
        }

        public void DeleteProduct(int productId)
        {
            Console.WriteLine("Received DeleteProduct");
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {
                    var myItem = (from c in db.ProductEntities
                                  where c.ProductID == productId
                                  select c).FirstOrDefault();

                    if (myItem != null)
                    {
                        db.ProductEntities.Remove(myItem);
                        db.SaveChanges();
                    }

                    Console.WriteLine("Return Received DeleteProduct ");

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: There is an error while DeleteProduct " + ex.Message);
                }
            }           
        }
        
        public bool UpdateProduct(ref Product p)
        {
            Console.WriteLine("Received UpdateProduct");
                        
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {
                    int productID = p.ProductID;
                    ProductEntity productEntity = (from c in db.ProductEntities
                                         where c.ProductID == productID
                                            select c).FirstOrDefault();
                    if (productEntity == null)
                    {
                        throw new Exception("No product with ID " + p.ProductID);
                    }

                    //detach it first.
                    ((IObjectContextAdapter)db).ObjectContext.Detach(productEntity);
                    //update the product
                    productEntity.CategoryID = p.CategoryID;
                    productEntity.ProviderID = p.ProviderID;
                    productEntity.UPCBarCode = p.Barcode;
                    productEntity.UPCType = p.BarcodeType;
                    productEntity.SalePrice = p.SalePrice;
                    productEntity.ImportPrice = p.ImportPrice;
                    productEntity.Name = p.Name;
                    productEntity.Description = p.Description;
                    productEntity.RowVersion = p.RowVersion;
                    //attach it.
                    //((IObjectContextAdapter)db).ObjectContext.Attach((IEntityWithKey)productEntity);
                    ((IObjectContextAdapter)db).ObjectContext.AttachTo("ProductEntities", productEntity);
                    // change object state
                    ((IObjectContextAdapter)db).ObjectContext.ObjectStateManager.ChangeObjectState(productEntity, System.Data.EntityState.Modified);
                    db.SaveChanges();
                    p.RowVersion = productEntity.RowVersion;
                    db.Dispose();
                    Console.WriteLine("Return Received UpdateProduct ");
                    return true;               
                  
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: There is an error while UpdateProduct " + ex.Message);
                }
            }           
        }

        public IList<Product> GetAllProduct()
        {
            Console.WriteLine("Received GetAllProduct");
            List<Product> lstProduct = new List<Product>();
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {

                    var myItem = (from c in db.ProductEntities
                                  select c);

                    foreach (ProductEntity p in myItem)
                    {
                        lstProduct.Add(TranslateProductEntityToProduct(p));
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: can not get list of GetAllProduct  " + ex.Message);
                }
            }

            Console.WriteLine("Return Received GetAllProduct ");
            lstProduct = lstProduct.OrderBy(p => p.Name).ToList(); //sort by ASC

            return lstProduct;
        }

        //this function will return all products that match the product name
        public IList<Product> SearchProductByName(string productName)
        {
            Console.WriteLine("Received SearchProductByName");
            List<Product> lstProduct = new List<Product>();
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {
                    var myItem = (from c in db.ProductEntities
                                  select c);

                    foreach (ProductEntity p in myItem)
                    {
                        string name = p.Name;

                        if (name.ToLower().CompareTo(productName.ToLower()) == 0)
                        {
                            //match, return do not need to find any.
                            lstProduct.Add(TranslateProductEntityToProduct(p));
                            break;
                        }                    
                        
                    }

                    if (lstProduct.Count > 0)
                        return lstProduct;

                    if (lstProduct.Count == 0)
                    {
                        foreach (ProductEntity p in myItem)
                        {
                            string name = p.Name;
                            //find contain product
                            if (name.ToLower().Contains(productName.ToLower()))
                            {
                                lstProduct.Add(TranslateProductEntityToProduct(p));                                
                            }
                        }
                    }

                    if (lstProduct.Count > 0)
                        return lstProduct;

                    if (lstProduct.Count == 0) //seach start with
                    {
                        foreach (ProductEntity p in myItem)
                        {
                            string name = p.Name;
                            //find start with
                            string first5Char = productName.Substring(0, 5);
                            if (!string.IsNullOrEmpty(first5Char)
                                && name.ToLower().StartsWith(first5Char.ToLower()))
                                lstProduct.Add(TranslateProductEntityToProduct(p));
                            else
                            {
                                string first3Char = productName.Substring(0, 3);
                                if (!string.IsNullOrEmpty(first3Char)
                                && name.ToLower().StartsWith(first3Char.ToLower()))
                                    lstProduct.Add(TranslateProductEntityToProduct(p));
                            }

                        }
                    }
                   
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: can not get list of Product by SearchProductByName  " + ex.Message);
                }
            }

            Console.WriteLine("Return Received SearchProductByName ");

            return lstProduct;
        }


        public int GetNewestProductID()
        {
            Console.WriteLine("Received GetNewestProductID");
            
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {

                    var myItem = (from c in db.ProductEntities
                                  select c);

                    Console.WriteLine("Return Received GetNewestProductID ");
                    if (myItem == null)
                        return -1;

                    List<ProductEntity> lstProducts = new List<ProductEntity>(myItem);
                    int count = lstProducts.Count;
                    if (count == 0)
                        return -1;

                    return lstProducts[count - 1].ProductID;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: can not get latest GetNewestProductID " + ex.Message);
                }
            }
        }

        public Product GetProductByBarcode(string barcode)
        {
            Console.WriteLine("Received GetProductByBarcode");           
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {

                    var myItem = (from c in db.ProductEntities
                                  where c.UPCBarCode == barcode
                                  select c).FirstOrDefault();

                    if (myItem != null)
                    {
                        Console.WriteLine("Return Received GetProductByBarcode ");
                        Product p = TranslateProductEntityToProduct(myItem);
                        return p;
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: can not get GetProductByBarcode  " + ex.Message);
                }
            }

            Console.WriteLine("Return Received GetProductByBarcode ");
            return null;
        }

        public Product GetProductByID(int productID)
        {
            Console.WriteLine("Received GetProductByID");
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {

                    var myItem = (from c in db.ProductEntities
                                  where c.ProductID == productID
                                  select c).FirstOrDefault();

                    if (myItem != null)
                    {
                        Console.WriteLine("Return Received GetProductByID ");
                        Product p = TranslateProductEntityToProduct(myItem);
                        return p;
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: can not get GetProductByID  " + ex.Message);
                }
            }

            Console.WriteLine("Return Received GetProductByID ");
            return null;
        }
        
        private Product TranslateProductEntityToProduct(ProductEntity entity)
        {
            Product p = new Product();
            p.ProductID = entity.ProductID;
            p.ProviderID = entity.ProviderID;
            p.CategoryID = entity.CategoryID;
            p.Name = entity.Name;
            p.Barcode = entity.UPCBarCode;
            p.BarcodeType = entity.UPCType;
            p.SalePrice = entity.SalePrice.HasValue ? entity.SalePrice.Value : 0;
            p.ImportPrice = entity.ImportPrice.HasValue ? entity.ImportPrice.Value : 0;
            p.Description = entity.Description;
            p.RowVersion = entity.RowVersion;
            return p;
        }
        #endregion

        #region Product Import

        public int InsertProductImport()
        {
            Console.WriteLine("Received InsertProductImport");
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {
                    //create product category.
                    ProductImportEntity p = new ProductImportEntity();
                    p.ImportDate = DateTime.Now;
                    p.ImportStatus = (int)ImportStatus.Initial; // just creating.                    

                    db.ProductImportEntities.Add(p);
                    db.SaveChanges();
                    Console.WriteLine("Return InsertProductImport");
                    return p.ProductImportID;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: Unable to insert a new InsertProductImport" + ex.Message);
                }
            }
        }

        public bool UpdateProductImport(ref ProductImport pImport)
        {
            Console.WriteLine("Received UpdateProductImport");

            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {
                    int productImportID = pImport.ProductImportID;
                    ProductImportEntity pImportEntity = (from c in db.ProductImportEntities
                                                         where c.ProductImportID == productImportID
                                                        select c).FirstOrDefault();
                    if (pImportEntity == null)
                    {
                        throw new Exception("No product with ID " + pImport.ProductImportID);
                    }

                    //detach it first.
                    ((IObjectContextAdapter)db).ObjectContext.Detach(pImportEntity);
                    //update the product import entity                    
                    pImportEntity.ImportStatus = pImport.ImportStatus;
                    pImportEntity.RowVersion = pImport.RowVersion;                    
                    pImportEntity.SubTotal = pImport.SubTotal;
                    pImportEntity.TotalInQuantity = pImport.TotalInQuantity;
                    pImportEntity.TotalOutQuantity = pImport.TotalOutQuantity;
                    pImportEntity.ImportBy = pImport.ImportBy;
                    //attach it.
                    //((IObjectContextAdapter)db).ObjectContext.Attach((IEntityWithKey)productEntity);
                    ((IObjectContextAdapter)db).ObjectContext.AttachTo("ProductImportEntities", pImportEntity);
                    // change object state
                    ((IObjectContextAdapter)db).ObjectContext.ObjectStateManager.ChangeObjectState(pImportEntity, System.Data.EntityState.Modified);
                    db.SaveChanges();
                    pImport.RowVersion = pImportEntity.RowVersion;
                    db.Dispose();
                    Console.WriteLine("Return Received UpdateProductImport ");
                    return true;

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: There is an error while UpdateProductImport " + ex.Message);
                }
            }           
        }

        public void DeleteProductImport(int productImportID)
        {
            Console.WriteLine("Received DeleteProductImport");

            DeleteAllProductImportDetails(productImportID);

            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {
                    var myItem = (from c in db.ProductImportEntities
                                  where c.ProductImportID == productImportID
                                  select c).FirstOrDefault();

                    if (myItem != null)
                    {
                        db.ProductImportEntities.Remove(myItem);
                        db.SaveChanges();
                    }

                    Console.WriteLine("Return Received DeleteProductImport ");

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: There is an error while DeleteProductImport " + ex.Message);
                }
            }           
        }

        private void DeleteAllProductImportDetails(int productImportID)
        {
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {
                    var myItem = (from c in db.ProductImportDetailEntities
                                  where c.ProductImportID == productImportID
                                  select c);

                    foreach (ProductImportDetailEntity d in myItem)
                    {
                        DeleteProductImportDetail(d.ProductImportDetailID);
                    }

                    db.SaveChanges();                   

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: There is an error while DeleteProductImport " + ex.Message);
                }
            }           
        }

        public ProductImport GetProductImportByID(int productImportID)
        {
            Console.WriteLine("Received GetProductImportByID");
            ProductImport pImport = null;
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {

                    var myItem = (from c in db.ProductImportEntities
                                  where c.ProductImportID == productImportID
                                  select c).FirstOrDefault();

                    if (myItem != null)
                    {
                        pImport = TranslateProductImportEntityToProductImport(myItem);

                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: can not get list of GetProductImportByID  " + ex.Message);
                }
            }

            Console.WriteLine("Return Received GetProductImportByID ");
            return pImport;
        }

        public IList<ProductImport> GetAllProductImport()
        {
            Console.WriteLine("Received GetAllProductImport");
            List<ProductImport> lstProductImport = new List<ProductImport>();
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {

                    var myItem = (from c in db.ProductImportEntities
                                  //where c.ImportStatus != (int)ImportStatus.Initial
                                  orderby c.ProductImportID descending
                                  select c);

                    foreach (ProductImportEntity p in myItem)
                    {
                        lstProductImport.Add(TranslateProductImportEntityToProductImport(p));
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: can not get list of GetAllProductImport  " + ex.Message);
                }
            }

            Console.WriteLine("Return Received GetAllProductImport ");
            return lstProductImport;
        }

        private ProductImport TranslateProductImportEntityToProductImport(ProductImportEntity entity)
        {
            ProductImport p = new ProductImport();
            p.ImportDate  = entity.ImportDate.HasValue ? entity.ImportDate.Value : DateTime.MinValue;
            p.ImportStatus = entity.ImportStatus.HasValue ? entity.ImportStatus.Value : -1;
            p.ProductImportID = entity.ProductImportID;
            p.RowVersion = entity.RowVersion;            
            p.SubTotal = entity.SubTotal.HasValue ? entity.SubTotal.Value : 0;
            p.TotalInQuantity = entity.TotalInQuantity.HasValue ? entity.TotalInQuantity.Value : 0;
            p.TotalOutQuantity = entity.TotalOutQuantity.HasValue ? entity.TotalOutQuantity.Value : 0;
            p.ImportBy = entity.ImportBy;
            
            return p;
        }

        #endregion

        #region Product Import Detail
        public int InsertProductImportDetail(ProductImportDetail pDetail)
        {
            Console.WriteLine("Received InsertProductImportDetail");
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {
                    //create product category.
                    ProductImportDetailEntity pEntity = new ProductImportDetailEntity();
                    
                    pEntity.ImportDate = DateTime.Now;
                    pEntity.InQuantity = pDetail.InQuantiry;
                    pEntity.InventoryID = pDetail.InventoryID;
                    pEntity.ItemImportPrice = pDetail.ItemImportPrice;
                    pEntity.ItemImportStatus = (int)ItemImportStatus.Ready; //for the very first time to import
                    pEntity.OutQuantity = 0; //first time, not have any out quantity
                    pEntity.ProductImportID = pDetail.ProductImportID;
                    pEntity.TotalImportPrice = pDetail.TotalImportPrice;
                    pEntity.UPCBarCode = pDetail.Barcode;

                    db.ProductImportDetailEntities.Add(pEntity);
                    db.SaveChanges();

                    //update quantity and product status of this product in the Inventory.
                    UpdateInventoryAfterChangeImportProductDetail(pEntity, true); //insert, so adding product quantity into the inventory

                    Console.WriteLine("Return InsertProductImportDetail");
                    return pEntity.ProductImportDetailID;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: Unable to insert a new InsertProductImportDetail" + ex.Message);
                }
            }
        }       

        private void UpdateInventoryAfterChangeImportProductDetail(ProductImportDetailEntity pEntity, bool bIsAdded)
        {
            if (pEntity == null)
                return;

            int inventoryID = pEntity.InventoryID;
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {
                    InventoryEntity inventoryEntity = (from c in db.InventoryEntities
                                                                     where c.InventoryID == inventoryID
                                                                     select c).FirstOrDefault();

                    if (inventoryEntity != null)
                    {
                        if (bIsAdded)
                        {
                            inventoryEntity.TotalQuantity += pEntity.InQuantity;
                            if (inventoryEntity.TotalQuantity > 0)
                                inventoryEntity.ProductStatus = (int)InventoryProductStatus.Available;
                        }
                        else //substract
                        {
                            inventoryEntity.TotalQuantity -= pEntity.InQuantity;
                            if (inventoryEntity.TotalQuantity <= 0)
                            {
                                inventoryEntity.TotalQuantity = 0;
                                inventoryEntity.ProductStatus = (int)InventoryProductStatus.Out_Of_Stock;
                            }
                        }

                        Inventory inventory = TranslateInventoryEntityToInventory(inventoryEntity);
                        UpdateInventory(ref inventory); //update here to make sure other client has to refresh.
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: Unable to insert a new InsertInventory" + ex.Message);
                }
            }
        }

        public bool UpdateProductImportDetail(ref ProductImportDetail pImport)
        {
            Console.WriteLine("Received UpdateProductImport");

            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {
                    int productImportDetailID = pImport.ProductImportDetailID;
                    ProductImportDetailEntity pImportDetailEntity = (from c in db.ProductImportDetailEntities
                                                                     where c.ProductImportDetailID == productImportDetailID
                                                         select c).FirstOrDefault();
                    if (pImportDetailEntity == null)
                    {
                        throw new Exception("No product import detail with ID " + pImport.ProductImportDetailID);
                    }

                    //detach it first.
                    ((IObjectContextAdapter)db).ObjectContext.Detach(pImportDetailEntity);
                    //update the product import entity                   
                    pImportDetailEntity.InQuantity = pImport.InQuantiry;
                    pImportDetailEntity.RowVersion = pImport.RowVersion;
                    pImportDetailEntity.InventoryID = pImport.InventoryID;
                    pImportDetailEntity.ItemImportPrice = pImport.ItemImportPrice;
                    pImportDetailEntity.ItemImportStatus = pImport.ItemImportStatus;
                    pImportDetailEntity.OutQuantity = pImport.OutQuantity;
                    pImportDetailEntity.ProductImportID = pImport.ProductImportID;
                    pImportDetailEntity.TotalImportPrice = pImport.TotalImportPrice;
                    pImportDetailEntity.UPCBarCode = pImport.Barcode;

                    //attach it.
                    //((IObjectContextAdapter)db).ObjectContext.Attach((IEntityWithKey)productEntity);
                    ((IObjectContextAdapter)db).ObjectContext.AttachTo("ProductImportDetailEntities", pImportDetailEntity);
                    // change object state
                    ((IObjectContextAdapter)db).ObjectContext.ObjectStateManager.ChangeObjectState(pImportDetailEntity, System.Data.EntityState.Modified);
                    db.SaveChanges();
                    pImport.RowVersion = pImportDetailEntity.RowVersion;
                    db.Dispose();
                    Console.WriteLine("Return Received UpdateProductImport ");
                    return true;

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: There is an error while UpdateProductImport " + ex.Message);
                }
            }           
        }

        /// <summary>
        /// //after updating product quantity in the inventory, we should update the product out quantity in the 
        //appropriate product import detail, product import also
        //then we have to change the status of that product import to import status.
        //the way to update product out quantity from product import detail following by queue, first in, first out
        //1/ update out quantity in product import detail, then product import
        //total inventory quantity of an product in a product import detail will be updated to total out quantity 
        //total out quantity will alway be less than or equal total import quantity of an product import detail, if the quantity export of an 
        //product in the inventory bigger than the total product import, we will observe another product import detail to update product out quantity
        /// </summary>
        /// <param name="inventoryID"></param>
        /// <param name="nQuantity"></param>
        private void UpdateOutQuantityForProductImport(int inventoryID, int nQuantity)
        {
            //Console.WriteLine("Received UpdateOutQuantityForProductImport");
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {
                    var myItem = (from c in db.ProductImportDetailEntities
                                  where (c.InventoryID == inventoryID && 
                                        c.ItemImportStatus != (int)ItemImportStatus.Done)
                                  orderby c.ImportDate ascending
                                  select c);

                    foreach (ProductImportDetailEntity d in myItem)
                    {
                        if (d.OutQuantity + nQuantity > 0
                            && d.OutQuantity + nQuantity <= d.InQuantity)
                        {
                            ExcuteUpdateProductImportOutQuantity(nQuantity, d);
                            //finish, break the loop
                            break;
                        }
                        else if (d.OutQuantity + nQuantity > 0
                            && d.OutQuantity + nQuantity > d.InQuantity) //just have a few left
                        {
                            int realQuantityLeft = d.InQuantity.Value - d.OutQuantity.Value;
                            ExcuteUpdateProductImportOutQuantity(realQuantityLeft, d); 
                            //still have some quantity left needed to update.
                            int remainedQuantity = nQuantity - realQuantityLeft;
                            nQuantity = remainedQuantity;//update out quantity for order import detail. It means that we take item from other product import
                        }
                    }

                    //Console.WriteLine("Return Received UpdateOutQuantityForProductImport ");

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: There is an error while UpdateOutQuantityForProductImport " + ex.Message);
                }
            }       
        }

        private void ExcuteUpdateProductImportOutQuantity(int nQuantity, ProductImportDetailEntity d)
        {
            d.OutQuantity += nQuantity;
            if (d.OutQuantity == d.InQuantity) //update status to done
                d.ItemImportStatus = (int)ItemImportStatus.Done;

            ProductImportDetail detail = TranslateProductImportDetailEntityToProductImportDetail(d);
            UpdateProductImportDetail(ref detail);

            //update out quantity of product import
            int productImportID = d.ProductImportID;
            ProductImport pImport = GetProductImportByID(productImportID);
            if (pImport != null)
            {
                if (pImport.TotalOutQuantity + nQuantity > 0
                    && pImport.TotalOutQuantity + nQuantity <= pImport.TotalInQuantity)
                {
                    pImport.TotalOutQuantity += nQuantity;
                    if (pImport.TotalInQuantity == pImport.TotalOutQuantity)
                        pImport.ImportStatus = (int)ImportStatus.Done_Export;

                    //update product import.
                    UpdateProductImport(ref pImport);
                }
            }
        }

        public void DeleteProductImportDetail(int productImportDetailID)
        {
            Console.WriteLine("Received DeleteProductImportDetail");
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {
                    var myItem = (from c in db.ProductImportDetailEntities
                                  where c.ProductImportDetailID == productImportDetailID
                                  select c).FirstOrDefault();

                    if (myItem != null)
                    {
                        if (myItem.ItemImportStatus.Value != (int)ItemImportStatus.Done) //not already finishing export, need to update inventory   
                        {
                            //before deleting product import detail, we should update inventory quantity and status for the product quantity.
                            UpdateInventoryAfterChangeImportProductDetail(myItem, false); //substract product quantity in the inventory
                        }

                        db.ProductImportDetailEntities.Remove(myItem);
                        db.SaveChanges();
                    }

                    Console.WriteLine("Return Received DeleteProductImportDetail ");

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: There is an error while DeleteProductImportDetail " + ex.Message);
                }
            }           
        }
       
        public IList<ProductImportDetail> GetAllProductImportDetail(int productImportID)
        {
            Console.WriteLine("Received GetAllProductImport");
            List<ProductImportDetail> lstProductImportDetail = new List<ProductImportDetail>();
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {

                    var myItem = (from c in db.ProductImportDetailEntities
                                  where c.ProductImportID == productImportID
                                  select c);

                    foreach (ProductImportDetailEntity p in myItem)
                    {
                        lstProductImportDetail.Add(TranslateProductImportDetailEntityToProductImportDetail(p));
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: can not get list of GetAllProductImport  " + ex.Message);
                }
            }

            Console.WriteLine("Return Received GetAllProductImport ");
            return lstProductImportDetail;
        }

        public ProductImportDetail GetProductImportDetailByID(int productImportDetailID)
        {
            Console.WriteLine("Received GetProductImportDetailByID");
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {

                    var myItem = (from c in db.ProductImportDetailEntities
                                  where c.ProductImportDetailID == productImportDetailID
                                  select c).FirstOrDefault();

                    if (myItem != null)
                    {
                        Console.WriteLine("Return Received GetProductImportDetailByID ");
                        return TranslateProductImportDetailEntityToProductImportDetail(myItem);
                    }

                    return null;

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: can not get GetProductImportDetailByID " + ex.Message);
                }
            }         
            
        }

        public ProductImportDetail GetProductImportDetailOfProductImportByBarcode(int productImportID, string barcode)
        {
            Console.WriteLine("Received GetProductImportDetailOfProductImportByBarcode");
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {

                    var myItem = (from c in db.ProductImportDetailEntities
                                  where (c.ProductImportID == productImportID 
                                        && c.UPCBarCode == barcode)
                                  select c).FirstOrDefault();

                    if (myItem != null)
                    {
                        Console.WriteLine("Return Received GetProductImportDetailOfProductImportByBarcode ");
                        return TranslateProductImportDetailEntityToProductImportDetail(myItem);
                    }

                    return null;

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: can not get GetProductImportDetailOfProductImportByBarcode " + ex.Message);
                }
            }         
        }

        private ProductImportDetail TranslateProductImportDetailEntityToProductImportDetail(ProductImportDetailEntity entity)
        {
            ProductImportDetail p = new ProductImportDetail();

            p.Barcode = entity.UPCBarCode;            
            p.ImportDate = entity.ImportDate.HasValue ? entity.ImportDate.Value : DateTime.MinValue;
            p.InQuantiry = entity.InQuantity.HasValue ? entity.InQuantity.Value : 0;
            p.RowVersion = entity.RowVersion;
            p.InventoryID = entity.InventoryID;
            p.ItemImportPrice = entity.ItemImportPrice.HasValue ? entity.ItemImportPrice.Value : 0;
            p.ItemImportStatus = entity.ItemImportStatus.HasValue ? entity.ItemImportStatus.Value : 0;
            p.OutQuantity = entity.OutQuantity.HasValue ? entity.OutQuantity.Value : 0;
            p.ProductImportDetailID = entity.ProductImportDetailID;
            p.ProductImportID = entity.ProductImportID;
            p.TotalImportPrice = entity.TotalImportPrice.HasValue ? entity.TotalImportPrice.Value : 0;

            return p;
        }
        #endregion

        #region Inventory
        public int InsertInventory(Inventory inventory)
        {
            Console.WriteLine("Received InsertInventory");
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {
                    //create product category.
                    InventoryEntity pEntity = new InventoryEntity();

                    pEntity.CreatedDate = DateTime.Now;
                    pEntity.Location = inventory.Location;
                    pEntity.TotalQuantity = inventory.TotalQuantity;
                    pEntity.ProductStatus = pEntity.TotalQuantity > 0 ? (int)InventoryProductStatus.Available :                                                                             (int)InventoryProductStatus.Out_Of_Stock;
                    pEntity.UPCBarCode = inventory.Barcode;                        

                    db.InventoryEntities.Add(pEntity);
                    db.SaveChanges();
                    Console.WriteLine("Return InsertInventory");
                    return pEntity.InventoryID;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: Unable to insert a new InsertInventory" + ex.Message);
                }
            }
        }

        public bool UpdateInventory(ref Inventory inventory)
        {
            Console.WriteLine("Received UpdateInventory");

            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {
                    int inventoryID = inventory.InventoryID;
                    InventoryEntity pInventoryEntity = (from c in db.InventoryEntities
                                                                     where c.InventoryID == inventoryID
                                                         select c).FirstOrDefault();
                    if (pInventoryEntity == null)
                    {
                        throw new Exception("No Inventory with ID " + inventoryID);
                    }

                    //detach it first.
                    ((IObjectContextAdapter)db).ObjectContext.Detach(pInventoryEntity);
                    //update the inventory entity
                    pInventoryEntity.Location = inventory.Location;
                    pInventoryEntity.RowVersion = inventory.RowVersion;
                    pInventoryEntity.ProductStatus = inventory.ProductStatus;
                    pInventoryEntity.TotalQuantity =  inventory.TotalQuantity;
                    pInventoryEntity.UPCBarCode = inventory.Barcode;

                    //attach it.
                    //((IObjectContextAdapter)db).ObjectContext.Attach((IEntityWithKey)productEntity);
                    ((IObjectContextAdapter)db).ObjectContext.AttachTo("InventoryEntities", pInventoryEntity);
                    // change object state
                    ((IObjectContextAdapter)db).ObjectContext.ObjectStateManager.ChangeObjectState(pInventoryEntity, System.Data.EntityState.Modified);
                    db.SaveChanges();
                    inventory.RowVersion = pInventoryEntity.RowVersion;
                    db.Dispose();
                    Console.WriteLine("Return Received UpdateInventory ");
                    return true;

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: There is an error while UpdateInventory " + ex.Message);
                }
            }          
        }

        /// <summary>
        /// When deleting an inventory, we should delete all product import details, then update quantity in the product import of that 
        /// product import detail.
        /// then, delete all product export details, product export which associated with that inventory also.
        /// this bussiness logic is quiet complicate, so we go with a simpler business logic is that we will check the inventory has product import detail 
        /// or not, if yes, we can not delete it. Thus, if there is a product export detail, if yes, we can not delete the inventory also.
        /// 
        /// </summary>
        /// <param name="inventoryID"></param>
        public void DeleteInventory(int inventoryID)
        {
            Console.WriteLine("Received DeleteInventory");
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {
                    var myItem = (from c in db.InventoryEntities
                                  where c.InventoryID == inventoryID
                                  select c).FirstOrDefault();

                    if (myItem != null)
                    {
                        db.InventoryEntities.Remove(myItem);
                        db.SaveChanges();
                    }

                    Console.WriteLine("Return Received DeleteInventory ");

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: There is an error while DeleteInventory " + ex.Message);
                }
            }       
        }

        public IList<Inventory> GetAllInventory()
        {
            Console.WriteLine("Received GetAllInventory");
            List<Inventory> lstInventory = new List<Inventory>();
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {

                    var myItem = (from c in db.InventoryEntities
                                 select c);

                    foreach (InventoryEntity p in myItem)
                    {
                        lstInventory.Add(TranslateInventoryEntityToInventory(p));
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: can not get list of GetAllInventory  " + ex.Message);
                }
            }

            Console.WriteLine("Return Received GetAllInventory ");
            return lstInventory;
        }

        public Inventory GetInventoryByBarcode(string barcode)
        {
            Console.WriteLine("Received GetInventoryByBarcode");
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {

                    var myItem = (from c in db.InventoryEntities
                                  where c.UPCBarCode.ToLower() == barcode.ToLower()
                                  select c).FirstOrDefault();

                    if (myItem != null)
                        return TranslateInventoryEntityToInventory(myItem);

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: can not get list of GetInventoryByBarcode  " + ex.Message);
                }
            }

            Console.WriteLine("Return Received GetInventoryByBarcode ");
            return null;
        }

        /// <summary>
        /// check to whether or not be able to delete an inventory.
        /// </summary>
        /// <param name="inventoryID"></param>
        /// <returns></returns>
        public bool IsAllowDeleteInventory(int inventoryID)
        {
            Console.WriteLine("Received IsAllowDeleteInventory");            
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {
                    //check product import details
                    var myItem = (from c in db.ProductImportDetailEntities
                                  where c.InventoryID == inventoryID
                                  select c).FirstOrDefault();

                    if (myItem != null)
                    {
                        Console.WriteLine("Return Received IsAllowDeleteInventory ");
                        return false;
                    }

                    //check product export details.
                    var exportItem = (from c in db.ProductExportDetailEntities
                                      where c.InventoryID == inventoryID
                                      select c).FirstOrDefault();

                    if (exportItem != null)
                    {
                        Console.WriteLine("Return Received IsAllowDeleteInventory ");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: IN IsAllowDeleteInventory  " + ex.Message);
                }
            }

            Console.WriteLine("Return Received IsAllowDeleteInventory ");
            return true;
        }

       
        public void UpdateProductQuantityInInventory(int inventoryID, int nQuantity)
        {
            Console.WriteLine("Received UpdateProductQuantityInInventory");
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {
                    InventoryEntity inventoryEntity = (from c in db.InventoryEntities
                                                       where c.InventoryID == inventoryID
                                                       select c).FirstOrDefault();

                    if (inventoryEntity != null)
                    {
                        inventoryEntity.TotalQuantity += nQuantity;
                        if (inventoryEntity.TotalQuantity > 0)
                            inventoryEntity.ProductStatus = (int)InventoryProductStatus.Available;
                        else
                            inventoryEntity.ProductStatus = (int)InventoryProductStatus.Out_Of_Stock;

                        Inventory inventory = TranslateInventoryEntityToInventory(inventoryEntity);
                        UpdateInventory(ref inventory); //update here to make sure other client has to refresh.
                        Console.WriteLine("Done Received UpdateProductQuantityInInventory");                        
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: Unable to use UpdateProductQuantityInInventory" + ex.Message);
                }
            }
        }       
           

        private Inventory TranslateInventoryEntityToInventory(InventoryEntity entity)
        {
            Inventory p = new Inventory();

            p.Barcode = entity.UPCBarCode;
            p.CreateDate = entity.CreatedDate.HasValue ? entity.CreatedDate.Value : DateTime.MinValue;
            p.InventoryID = entity.InventoryID;
            p.Location = entity.Location;
            p.RowVersion = entity.RowVersion;
            p.ProductStatus = entity.ProductStatus.HasValue ? entity.ProductStatus.Value : 0;
            p.TotalQuantity = entity.TotalQuantity.HasValue ? entity.TotalQuantity.Value : 0;
            return p;
        }
        #endregion

        #region Product Export
        public int InsertProductExport(ProductExport export)
        {
            Console.WriteLine("Received InsertProductExport");
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {
                    //create product category.
                    ProductExportEntity pEntity = new ProductExportEntity();

                    pEntity.CustomerID = export.CustomerID;
                    pEntity.ExportBarcode = export.ExportBarcode;
                    pEntity.ExportDate = DateTime.Now;
                    pEntity.FinalSalePrice = export.FinalSalePrice;
                    pEntity.SubDiscount = export.SubDiscount;
                    pEntity.SubTax = export.SubTax;
                    pEntity.SubTotal = export.SubTotal;
                    pEntity.TotalImportPrice = export.TotalImportPrice;
                    pEntity.TotalQuantity = export.TotalQuantity;
                    pEntity.Status = false; //default is in completed.

                    db.ProductExportEntities.Add(pEntity);
                    db.SaveChanges();
                    Console.WriteLine("Return InsertProductExport");
                    return pEntity.ProductExportID;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: Unable to insert a new InsertProductExport" + ex.Message);
                }
            }
        }

        public bool UpdateProductExport(ref ProductExport export)
        {
            Console.WriteLine("Received UpdateProductExport");

            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {
                    int productExportID = export.ProductExportID;
                    ProductExportEntity pExportEntity = (from c in db.ProductExportEntities
                                                         where c.ProductExportID == productExportID
                                                         select c).FirstOrDefault();
                    if (pExportEntity == null)
                    {
                        throw new Exception("No product export with ID " + export.ProductExportID);
                    }

                    //detach it first.
                    ((IObjectContextAdapter)db).ObjectContext.Detach(pExportEntity);
                    //update the product export entity                    
                    pExportEntity.ProductExportID = export.ProductExportID;
                    pExportEntity.CustomerID = export.CustomerID;
                    pExportEntity.ExportBarcode = export.ExportBarcode;
                    pExportEntity.FinalSalePrice = export.FinalSalePrice;
                    pExportEntity.RowVersion = export.RowVersion;
                    pExportEntity.SubDiscount = export.SubDiscount;
                    pExportEntity.SubTax = export.SubTax;
                    pExportEntity.SubTotal = export.SubTotal;
                    pExportEntity.TotalImportPrice = export.TotalImportPrice;
                    pExportEntity.TotalQuantity = export.TotalQuantity;
                    pExportEntity.Status = export.Status;
                    //attach it.
                    //((IObjectContextAdapter)db).ObjectContext.Attach((IEntityWithKey)productEntity);
                    ((IObjectContextAdapter)db).ObjectContext.AttachTo("ProductExportEntities", pExportEntity);
                    // change object state
                    ((IObjectContextAdapter)db).ObjectContext.ObjectStateManager.ChangeObjectState(pExportEntity, System.Data.EntityState.Modified);
                    db.SaveChanges();
                    export.RowVersion = pExportEntity.RowVersion;
                    db.Dispose();
                    Console.WriteLine("Return Received UpdateProductExport ");
                    return true;

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: There is an error while UpdateProductImport " + ex.Message);
                }
            }           
        }

        public void DeleteProductExport(int productExportID)
        {
            Console.WriteLine("Received DeleteProductExport");

            DeleteAllProductExportDetails(productExportID); //will consider it later

            DeleteAllPayment(productExportID);

            DeleteAllProductReturn(productExportID); //need to implement this func soon

            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {
                    var myItem = (from c in db.ProductExportEntities
                                  where c.ProductExportID == productExportID
                                  select c).FirstOrDefault();

                    if (myItem != null)
                    {
                        db.ProductExportEntities.Remove(myItem);
                        db.SaveChanges();
                    }

                    Console.WriteLine("Return Received DeleteProductExport ");

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: There is an error while DeleteProductExport " + ex.Message);
                }
            }        
        }


        private void DeleteAllProductExportDetails(int productExportID)
        {
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {
                    var myItem = (from c in db.ProductExportDetailEntities
                                  where c.ProductExportID == productExportID
                                  select c);

                    foreach (ProductExportDetailEntity d in myItem)
                    {
                        DeleteProductExportDetail(d.ProductExportDetailID);
                    }

                    db.SaveChanges();

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: There is an error while DeleteProductImport " + ex.Message);
                }
            }           
        }

        public IList<ProductExport> GetAllProductExport()
        {
            Console.WriteLine("Received GetAllProductExport");
            List<ProductExport> lstProductExport = new List<ProductExport>();
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {

                    var myItem = (from c in db.ProductExportEntities
                                  //where c.ImportStatus != (int)ImportStatus.Initial
                                  orderby c.ProductExportID descending
                                  select c);

                    foreach (ProductExportEntity p in myItem)
                    {
                        lstProductExport.Add(TranslateProductExportEntityToProductExport(p));
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: can not get list of GetAllProductExport  " + ex.Message);
                }
            }

            Console.WriteLine("Return Received GetAllProductExport ");
            return lstProductExport;
        }

        public ProductExport GetProductExportByID(int productExportID)
        {
            Console.WriteLine("Received GetProductExportByID");
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {

                    ProductExportEntity myItem = (from c in db.ProductExportEntities
                                                  where c.ProductExportID == productExportID
                                                  select c).FirstOrDefault();

                    if (myItem != null)
                    {
                        Console.WriteLine("Done Received GetProductExportByID");
                        return TranslateProductExportEntityToProductExport(myItem);
                    }

                    Console.WriteLine("Done Received GetProductExportByID");
                    return null;

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: can not get GetProductExportByID  " + ex.Message);
                }
            }          
        }

        public ProductExport GetProductByBarcodeOrder(string barcodeValue)
        {
            Console.WriteLine("Received GetProductByBarcodeOrder");
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {

                    ProductExportEntity myItem = (from c in db.ProductExportEntities
                                                  where c.ExportBarcode == barcodeValue
                                                  select c).FirstOrDefault();

                    if (myItem != null)
                    {
                        Console.WriteLine("Done Received GetProductExportByID");
                        return TranslateProductExportEntityToProductExport(myItem);
                    }

                    Console.WriteLine("Done Received GetProductByBarcodeOrder");
                    return null;

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: can not get GetProductByBarcodeOrder  " + ex.Message);
                }
            }          
        }

        private ProductExport TranslateProductExportEntityToProductExport(ProductExportEntity entity)
        {
            ProductExport p = new ProductExport();

            p.ExportBarcode = entity.ExportBarcode;
            p.ExportDate = entity.ExportDate.HasValue ? entity.ExportDate.Value : DateTime.MinValue;
            p.CustomerID = entity.CustomerID.HasValue ? entity.CustomerID.Value : 0;
            p.FinalSalePrice = entity.FinalSalePrice.HasValue ? entity.FinalSalePrice.Value : 0;
            p.ProductExportID = entity.ProductExportID;
            p.RowVersion = entity.RowVersion;
            p.SubDiscount = entity.SubDiscount.HasValue ? entity.SubDiscount.Value : 0;
            p.SubTax = entity.SubTax.HasValue ? entity.SubTax.Value : 0;
            p.SubTotal = entity.SubTotal.HasValue ? entity.SubTotal.Value : 0;
            p.TotalImportPrice = entity.TotalImportPrice.HasValue ? entity.TotalImportPrice.Value : 0;
            p.TotalQuantity = entity.TotalQuantity.HasValue ? entity.TotalQuantity.Value : 0;
            p.Status = entity.Status.HasValue ? entity.Status.Value : false;

            return p;
        }
        #endregion

        public int InsertProductExportDetail(ProductExportDetail exportDetail)
        {
            Console.WriteLine("Received InsertProductImportDetail");
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {
                    //create product category.
                    ProductExportDetailEntity pEntity = new ProductExportDetailEntity();

                    pEntity.ExportDate = DateTime.Now;
                    pEntity.InventoryID = exportDetail.InventoryID;
                    pEntity.ItemPrice = exportDetail.ItemPrice;
                    pEntity.ProductExportID = exportDetail.ProductExportID;
                    pEntity.Quantity = exportDetail.Quantity;
                    pEntity.SubTotal = exportDetail.SubTotal;
                    pEntity.UPCBarCode = exportDetail.Barcode;

                    db.ProductExportDetailEntities.Add(pEntity);
                    db.SaveChanges();

                    //update inventory, since we have just exported an product, so the quantity of this product has been decreased in the Inventory.
                    int decreaseQuantity = 0 - exportDetail.Quantity;
                    UpdateProductQuantityInInventory(exportDetail.InventoryID, decreaseQuantity);

                    //after updating product quantity in the inventory, we should update the product out quantity in the 
                    //appropriate product import detail, product import also
                    //then we have to change the status of that product import to import status.
                    //the way to update product out quantity from product import detail following by queue, first in, first out
                    //1/ update out quantity in product import detail, then product import
                    UpdateOutQuantityForProductImport(exportDetail.InventoryID, exportDetail.Quantity);

                    Console.WriteLine("Return InsertProductImportDetail");
                    return pEntity.ProductExportDetailID;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: Unable to insert a new InsertProductImportDetail" + ex.Message);
                }
            }
        }

        public bool UpdateProductExportDetail(ref ProductExportDetail exportDetail)
        {
            Console.WriteLine("Received UpdateProductExportDetail");
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {
                    int productExportDetailID = exportDetail.ProductExportDetailID;

                    ProductExportDetailEntity pExportDetailEntity = (from c in db.ProductExportDetailEntities
                                                                     where c.ProductExportDetailID == productExportDetailID
                                                                     select c).FirstOrDefault();
                    if (pExportDetailEntity == null)
                    {
                        throw new Exception("No product export detail with ID " + exportDetail.ProductExportDetailID);
                    }

                    //detach it first.
                    ((IObjectContextAdapter)db).ObjectContext.Detach(pExportDetailEntity);
                    //update the product import entity                   
                    pExportDetailEntity.InventoryID = exportDetail.InventoryID;
                    pExportDetailEntity.RowVersion = exportDetail.RowVersion;
                    pExportDetailEntity.ItemPrice = exportDetail.ItemPrice;
                    pExportDetailEntity.ProductExportDetailID = exportDetail.ProductExportDetailID;
                    pExportDetailEntity.ProductExportID = exportDetail.ProductExportID;
                    pExportDetailEntity.Quantity = exportDetail.Quantity;
                    pExportDetailEntity.SubTotal = exportDetail.SubTotal;
                    pExportDetailEntity.UPCBarCode = exportDetail.Barcode;                    

                    //attach it.
                    //((IObjectContextAdapter)db).ObjectContext.Attach((IEntityWithKey)productEntity);
                    ((IObjectContextAdapter)db).ObjectContext.AttachTo("ProductExportDetailEntities", pExportDetailEntity);
                    // change object state
                    ((IObjectContextAdapter)db).ObjectContext.ObjectStateManager.ChangeObjectState(pExportDetailEntity, System.Data.EntityState.Modified);
                    db.SaveChanges();
                    exportDetail.RowVersion = pExportDetailEntity.RowVersion;
                    db.Dispose();
                    Console.WriteLine("Return Received UpdateProductExportDetail ");
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: Unable to update a new UpdateProductExportDetail" + ex.Message);
                }
            }
        }

        public void DeleteProductExportDetail(int productExportDetailID)
        {
            Console.WriteLine("Received DeleteProductExportDetail");
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {
                    var myItem = (from c in db.ProductExportDetailEntities
                                  where c.ProductExportDetailID == productExportDetailID
                                  select c).FirstOrDefault();

                    if (myItem != null)
                    {
                        //when delete an productexportdetail, there are two scenarios we need to concern.
                        //1 - if the status of the product export is closed - it means that the order has been already paid, so delete export do not need
                        //to update the inventory.
                        //2 - if the status of the product export is opened - it means that the order has not been paid, so delete export detail needs to 
                        //update the inventory.

                        int productExportID = myItem.ProductExportID;
                        ProductExportEntity export = (from c in db.ProductExportEntities
                                                      where c.ProductExportID == productExportID
                                                      select c).FirstOrDefault();

                        if (export != null)
                        {
                            if (!export.Status.HasValue || 
                                export.Status.Value == Convert.ToBoolean((int)ExportStatus.Open)) //need to add back to inventory
                            {
                                UpdateProductQuantityInInventory(myItem.InventoryID, myItem.Quantity.Value);

                                //after updating product quantity in the inventory, we should update the product out quantity in the 
                                //appropriate product import detail, product import also
                                //then we have to change the status of that product import to import status.
                                //the way to update product out quantity from product import detail following by queue, first in, first out
                                //1/ update out quantity in product import detail, then product import
                                UpdateOutQuantityForProductImport(myItem.InventoryID, -myItem.Quantity.Value);
                            }
                        }     
                        

                        db.ProductExportDetailEntities.Remove(myItem);
                        db.SaveChanges();
                    }

                    Console.WriteLine("Return Received DeleteProductExportDetail ");

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: There is an error while DeleteProductExportDetail " + ex.Message);
                }
            }           
        }

        public IList<ProductExportDetail> GetAllProductExportDetail(int productExportID)
        {
            Console.WriteLine("Received GetAllProductExportDetail");
            List<ProductExportDetail> lstProductExportDetail = new List<ProductExportDetail>();
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {

                    var myItem = (from c in db.ProductExportDetailEntities
                                  where c.ProductExportID == productExportID
                                  select c);

                    foreach (ProductExportDetailEntity p in myItem)
                    {
                        lstProductExportDetail.Add(TranslateProductExportDetailEntityToProductExportDetail(p));
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: can not get list of GetAllProductExportDetail  " + ex.Message);
                }
            }

            Console.WriteLine("Return Received GetAllProductExportDetail ");
            return lstProductExportDetail;
        }

        public ProductExportDetail GetProductExportDetailByID(int productExportDetailID)
        {
            Console.WriteLine("Received GetProductExportDetailByID ");
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {

                    var myItem = (from c in db.ProductExportDetailEntities
                                  where c.ProductExportDetailID == productExportDetailID
                                  select c).FirstOrDefault();

                    if (myItem != null)
                    {
                        Console.WriteLine("Return Received GetProductExportDetailByID ");
                        return TranslateProductExportDetailEntityToProductExportDetail(myItem);
                    }

                    Console.WriteLine("Return Received GetProductExportDetailByID ");
                    return null;

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: can not get list of GetProductExportDetailByID  " + ex.Message);
                }
            }      
           
        }

        public ProductExportDetail GetProductExportDetailByProductBarcode(int productExportID, string barcodeValue)
        {
            Console.WriteLine("Received GetProductExportDetailByProductBarcode");
           
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {
                    var myItem = (from c in db.ProductExportDetailEntities
                                  where (c.ProductExportID == productExportID
                                        && c.UPCBarCode == barcodeValue)
                                  select c).FirstOrDefault();

                    ProductExportDetail p = TranslateProductExportDetailEntityToProductExportDetail(myItem);
                    Console.WriteLine("Return Received GetProductExportDetailByProductBarcode ");
                    return p;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: can not get list of GetProductExportDetailByProductBarcode  " + ex.Message);
                }
            }          
            
        }

        /// <summary>
        /// This function uses for decrease a product detail in an order while returning that product.
        /// after decrease an order detail, we need to update its tax, and discount in that order also.
        /// </summary>
        /// <param name="productExportID"></param>
        /// <param name="barcodeValue"></param>
        public void DecreaseProductInOrderDetail(int productExportID, string barcodeValue, int productReturnDetailID)
        {
            Console.WriteLine("Received DecreaseProductInOrderDetail");            
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {

                    var myItem = (from c in db.ProductExportDetailEntities
                                  where (c.ProductExportID == productExportID 
                                        && c.UPCBarCode == barcodeValue)                                  
                                  select c).FirstOrDefault();

                    if (myItem != null)
                    {
                        //check its quantity to decide decrease or delete
                        if (myItem.Quantity == 1) //delete it
                            DeleteProductExportDetail(myItem.ProductExportDetailID);
                        else //decrease its quantity by 1, then update it
                        {
                            myItem.Quantity -= 1;
                            //update subtotal,
                            myItem.SubTotal = myItem.ItemPrice * myItem.Quantity;

                            ProductExportDetail p = TranslateProductExportDetailEntityToProductExportDetail(myItem);
                            UpdateProductExportDetail(ref p);
                        }

                        //update discount and tax in the product export since the product export detail has been removed
                        ProductReturnDetailEntity pReturnDetailEntity = (from c in db.ProductReturnDetailEntities
                                                             where c.ProductReturnDetailEntityID == productReturnDetailID
                                                             select c).FirstOrDefault();

                        if (pReturnDetailEntity != null) //update discount and its tax, and sub total also.
                        {
                            ProductReturnDetail pReturnDetail = TranslateProductReturnDetailEntityToProductReturnDetail(pReturnDetailEntity);
                            decimal taxReturn = pReturnDetail.TaxReturn;
                            decimal disReturn = pReturnDetail.DiscountReturn;

                            ProductExport pExport = GetProductExportByID(productExportID);
                            if (pExport != null)
                            {
                                pExport.SubTax = pExport.SubTax - taxReturn;
                                pExport.SubDiscount = pExport.SubDiscount - disReturn;
                                pExport.SubTotal = pExport.SubTotal - pReturnDetail.PriceReturn;
                                pExport.TotalQuantity -= 1;
                                Product product = GetProductByBarcode(pReturnDetail.Barcode);
                                if (product != null)
                                {
                                    pExport.TotalImportPrice -= product.ImportPrice;
                                }
                                pExport.FinalSalePrice = pExport.SubTotal - pExport.SubDiscount + pExport.SubTax;

                                //update order 
                                UpdateProductExport(ref pExport);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: can not get list of DecreaseProductInOrderDetail  " + ex.Message);
                }
            }

            Console.WriteLine("Return Received DecreaseProductInOrderDetail ");
            
        }

        public int AddProductReturnBackToProductDetail(int productReturnDetailID)
        {
            Console.WriteLine("Received AddProductReturnBackToProductDetail");

            //get product return detail from its id first.
            ProductReturnDetail pReturnDetail = GetProdutReturnDetailByID(productReturnDetailID);

            if (pReturnDetail == null)
                return -1;

            //get product return from product return detail
            ProductReturn pReturn = GetProductReturnById(pReturnDetail.ProductReturnID);
            if (pReturn == null)
                return -1;

            //get inventory of this product
            Inventory inventory = GetInventoryByBarcode(pReturnDetail.Barcode);
            if (inventory == null)
                return -1;

            //create product export detail from product return detail
            ProductExportDetail pExportDetail = new ProductExportDetail();
            pExportDetail.Barcode = pReturnDetail.Barcode;
            pExportDetail.InventoryID = inventory.InventoryID;
            pExportDetail.ItemPrice = pReturnDetail.PriceReturn;
            pExportDetail.ProductExportID = pReturn.ProductExportID;
            pExportDetail.Quantity = 1; //one by one item at time.
            pExportDetail.SubTotal = pExportDetail.ItemPrice;

            return InsertProductExportDetail(pExportDetail);
            
        }       

        private ProductExportDetail TranslateProductExportDetailEntityToProductExportDetail(ProductExportDetailEntity entity)
        {
            ProductExportDetail p = new ProductExportDetail();

            p.Barcode = entity.UPCBarCode;
            p.ExportDate = entity.ExportDate.HasValue ? entity.ExportDate.Value : DateTime.MinValue;
            p.InventoryID = entity.InventoryID;
            p.ItemPrice = entity.ItemPrice.HasValue ? entity.ItemPrice.Value : 0;
            p.ProductExportDetailID = entity.ProductExportDetailID;
            p.ProductExportID = entity.ProductExportID;
            p.Quantity = entity.Quantity.HasValue ? entity.Quantity.Value : 0;
            p.RowVersion = entity.RowVersion;
            p.SubTotal = entity.SubTotal.HasValue ? entity.SubTotal.Value : 0;

            return p;
        }

        #region Product Return

        public int InsertProductReturn(ProductReturn p)
        {
            Console.WriteLine("Received InsertProductReturn");
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {
                    //create product category.
                    ProductReturnEntity pEntity = new ProductReturnEntity();

                    pEntity.FinalPriceReturn = p.FinalPriceReturn;
                    pEntity.ProductReturnBarcode = p.ProductReturnBarcode;
                    pEntity.ReturnDate = DateTime.Now;
                    pEntity.ProductExportID = p.ProductExportID;
                    pEntity.TotalDiscountReturn = p.TotalDiscountReturn;
                    pEntity.TotalItemReturn = p.TotalItemReturn;
                    pEntity.TotalPriceReturn = p.TotalPriceReturn;
                    pEntity.TotalTaxReturn = p.TotalTaxReturn;
                   
                    db.ProductReturnEntities.Add(pEntity);
                    db.SaveChanges();
                    Console.WriteLine("Return InsertProductReturn");
                    return pEntity.ProductReturnID;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: Unable to insert a new InsertProductReturn" + ex.Message);
                }
            }
        }

        public ProductReturn GetProductReturnByID(int productReturnID)
        {
            Console.WriteLine("Received GetProductReturnByID");

            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {
                    ProductReturnEntity pReturnEntity = (from c in db.ProductReturnEntities
                                                         where c.ProductReturnID == productReturnID
                                                         select c).FirstOrDefault();
                    if (pReturnEntity == null)
                    {
                        throw new Exception("No product return with ID " + productReturnID);
                    }
                    Console.WriteLine("Done GetProductReturnByID");
                    return TranslateProductReturnEntityToProductReturn(pReturnEntity);

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: There is an error while GetProductReturnByID " + ex.Message);
                }
            }           
        }

        public bool UpdateProductReturn(ref ProductReturn p)
        {
            Console.WriteLine("Received UpdateProductReturn");

            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {
                    int productReturnID = p.ProductReturnID;
                    ProductReturnEntity pReturnEntity = (from c in db.ProductReturnEntities
                                                         where c.ProductReturnID == productReturnID
                                                         select c).FirstOrDefault();
                    if (pReturnEntity == null)
                    {
                        throw new Exception("No product return with ID " + p.ProductReturnID);
                    }

                    //detach it first.
                    ((IObjectContextAdapter)db).ObjectContext.Detach(pReturnEntity);
                    //update the product export entity                    
                    pReturnEntity.FinalPriceReturn = p.FinalPriceReturn;
                    pReturnEntity.ProductExportID = p.ProductExportID;
                    pReturnEntity.ProductReturnBarcode = p.ProductReturnBarcode;
                    pReturnEntity.ReturnDate = p.ReturnDate;
                    pReturnEntity.RowVersion = p.RowVersion;
                    pReturnEntity.TotalDiscountReturn = p.TotalDiscountReturn;
                    pReturnEntity.TotalItemReturn = p.TotalItemReturn;
                    pReturnEntity.TotalPriceReturn = p.TotalPriceReturn;
                    pReturnEntity.TotalTaxReturn = p.TotalTaxReturn;                    
                    //attach it.
                    //((IObjectContextAdapter)db).ObjectContext.Attach((IEntityWithKey)productEntity);
                    ((IObjectContextAdapter)db).ObjectContext.AttachTo("ProductReturnEntities", pReturnEntity);
                    // change object state
                    ((IObjectContextAdapter)db).ObjectContext.ObjectStateManager.ChangeObjectState(pReturnEntity, System.Data.EntityState.Modified);
                    db.SaveChanges();
                    p.RowVersion = pReturnEntity.RowVersion;
                    db.Dispose();
                    Console.WriteLine("Return Received UpdateProductReturn ");
                    return true;

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: There is an error while UpdateProductReturn " + ex.Message);
                }
            }           
        }

        public void DeleteAllProductReturn(int productExportID)
        {
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {
                    var myItem = (from c in db.ProductReturnEntities
                                  where c.ProductExportID == productExportID
                                  select c);

                    foreach (ProductReturnEntity p in myItem)
                    {
                        DeleteProductReturn(p.ProductReturnID);
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: There is an error while DeleteProductReturn " + ex.Message);
                }
            }
        }
       
        public void DeleteProductReturn(int productReturnID)
        {
            Console.WriteLine("Received DeleteProductReturn");

            DeleteAllProductReturnDetails(productReturnID); //will consider it later

            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {
                    var myItem = (from c in db.ProductReturnEntities
                                  where c.ProductReturnID == productReturnID
                                  select c).FirstOrDefault();

                    if (myItem != null)
                    {
                        db.ProductReturnEntities.Remove(myItem);
                        db.SaveChanges();
                    }

                    Console.WriteLine("Return Received DeleteProductReturn ");

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: There is an error while DeleteProductReturn " + ex.Message);
                }
            }        
        }

        public IList<ProductReturn> GetAllProductReturn(int productExportID)
        {
            Console.WriteLine("Received GetAllProductReturn");
            List<ProductReturn> lstProductReturn = new List<ProductReturn>();
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {

                    var myItem = (from c in db.ProductReturnEntities
                                  where c.ProductExportID == productExportID
                                  select c);

                    foreach (ProductReturnEntity p in myItem)
                    {
                        lstProductReturn.Add(TranslateProductReturnEntityToProductReturn(p));
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: can not get list of GetAllProductReturn category " + ex.Message);
                }
            }

            Console.WriteLine("Return Received GetAllProductReturn ");
            return lstProductReturn;
        }

        private ProductReturn GetProductReturnById(int productReturnID)
        {
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {

                    var myItem = (from c in db.ProductReturnEntities
                                  where c.ProductReturnID == productReturnID
                                  select c).FirstOrDefault();

                    if (myItem != null)
                        return TranslateProductReturnEntityToProductReturn(myItem);

                    return null;

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: can not get list of GetAllProductReturn category " + ex.Message);
                }
            }
        }       


        private ProductReturn TranslateProductReturnEntityToProductReturn(ProductReturnEntity entity)
        {
            ProductReturn p = new ProductReturn();

            p.FinalPriceReturn = entity.FinalPriceReturn.HasValue ? entity.FinalPriceReturn.Value : 0;
            p.ProductExportID = entity.ProductExportID;
            p.ProductReturnBarcode = entity.ProductReturnBarcode;
            p.ProductReturnID = entity.ProductReturnID;
            p.ReturnDate = entity.ReturnDate.HasValue ? entity.ReturnDate.Value : DateTime.MinValue;
            p.RowVersion = entity.RowVersion;
            p.TotalDiscountReturn = entity.TotalDiscountReturn.HasValue ? entity.TotalDiscountReturn.Value : 0;
            p.TotalItemReturn = entity.TotalItemReturn.HasValue ? entity.TotalItemReturn.Value : 0;
            p.TotalPriceReturn = entity.TotalPriceReturn.HasValue ? entity.TotalPriceReturn.Value : 0;
            p.TotalTaxReturn = entity.TotalTaxReturn.HasValue ? entity.TotalTaxReturn.Value : 0;
           

            return p;
        }

        #endregion

        #region Product Return Detail

        public int InsertProductReturnDetail(ProductReturnDetail p)
        {
            Console.WriteLine("Received InsertProductReturnDetail");
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {
                    //create product category.
                    ProductReturnDetailEntity pEntity = new ProductReturnDetailEntity();

                    pEntity.FinalPriceReturn = p.FinalPriceReturn;
                    pEntity.DiscountReturn = p.DiscountReturn;
                    pEntity.ReturnDate = DateTime.Now;
                    pEntity.PriceReturn = p.PriceReturn;
                    pEntity.ProductReturnID = p.ProductReturnID;
                    pEntity.Quantity = p.Quantity;
                    pEntity.TaxReturn = p.TaxReturn;
                    pEntity.UPCBarCode = p.Barcode;

                    db.ProductReturnDetailEntities.Add(pEntity);
                    db.SaveChanges();
                    Console.WriteLine("Return InsertProductReturnDetail");
                    return pEntity.ProductReturnID;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: Unable to insert a new InsertProductReturnDetail" + ex.Message);
                }
            }
        }

        public bool UpdateProductReturnDetail(ref ProductReturnDetail p)
        {
            Console.WriteLine("Received UpdateProductReturnDetail");

            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {
                    int productReturnDetailID = p.ProductReturnDetailID;

                    ProductReturnDetailEntity pReturnEntity = (from c in db.ProductReturnDetailEntities
                                                               where c.ProductReturnDetailEntityID == productReturnDetailID
                                                         select c).FirstOrDefault();
                    if (pReturnEntity == null)
                    {
                        throw new Exception("No product return detail with ID " + p.ProductReturnDetailID);
                    }

                    //detach it first.
                    ((IObjectContextAdapter)db).ObjectContext.Detach(pReturnEntity);
                    //update the product export entity                    
                    pReturnEntity.DiscountReturn = p.DiscountReturn;
                    pReturnEntity.FinalPriceReturn = p.FinalPriceReturn;
                    pReturnEntity.PriceReturn = p.PriceReturn;
                    pReturnEntity.ProductReturnDetailEntityID = p.ProductReturnDetailID;
                    pReturnEntity.RowVersion = p.RowVersion;
                    pReturnEntity.ProductReturnID = p.ProductReturnID;
                    pReturnEntity.Quantity = p.Quantity;
                    pReturnEntity.ReturnDate = p.ReturnDate;
                    pReturnEntity.TaxReturn = p.TaxReturn;
                    pReturnEntity.UPCBarCode = p.Barcode;
                    //attach it.
                    //((IObjectContextAdapter)db).ObjectContext.Attach((IEntityWithKey)productEntity);
                    ((IObjectContextAdapter)db).ObjectContext.AttachTo("ProductReturnDetailEntities", pReturnEntity);
                    // change object state
                    ((IObjectContextAdapter)db).ObjectContext.ObjectStateManager.ChangeObjectState(pReturnEntity, System.Data.EntityState.Modified);
                    db.SaveChanges();
                    p.RowVersion = pReturnEntity.RowVersion;
                    db.Dispose();
                    Console.WriteLine("Return Received UpdateProductReturnDetail ");
                    return true;

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: There is an error while UpdateProductReturnDetail " + ex.Message);
                }
            }           
        }

        public void DeleteProductReturnDetail(int productReturnDetailID)
        {
            Console.WriteLine("Received DeleteProductReturnDetail");

            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {
                    var myItem = (from c in db.ProductReturnDetailEntities
                                  where c.ProductReturnDetailEntityID == productReturnDetailID
                                  select c).FirstOrDefault();

                    if (myItem != null)
                    {
                        db.ProductReturnDetailEntities.Remove(myItem);
                        db.SaveChanges();
                    }

                    Console.WriteLine("Return Received DeleteProductReturnDetail ");

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: There is an error while DeleteProductReturnDetail " + ex.Message);
                }
            }        
        }

        public void DeleteAllProductReturnDetails(int productReturnID)
        {
              using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {
                    var myItem = (from c in db.ProductReturnDetailEntities
                                  where c.ProductReturnID == productReturnID
                                  select c);

                    foreach (ProductReturnDetailEntity p in myItem)
                    {
                        DeleteProductReturnDetail(p.ProductReturnDetailEntityID);
                    }

                    Console.WriteLine("Return Received DeleteProductReturnDetail ");

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: There is an error while DeleteProductReturnDetail " + ex.Message);
                }
            }        

        }

        public IList<ProductReturnDetail> GetAllProductReturnDetail(int productReturnID)
        {
            Console.WriteLine("Received GetAllProductReturnDetail");
            List<ProductReturnDetail> lstProductReturnDetail = new List<ProductReturnDetail>();
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {

                    var myItem = (from c in db.ProductReturnDetailEntities
                                  where c.ProductReturnID == productReturnID
                                  select c);

                    foreach (ProductReturnDetailEntity p in myItem)
                    {
                        lstProductReturnDetail.Add(TranslateProductReturnDetailEntityToProductReturnDetail(p));
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: can not get list of GetAllProductReturnDetail category " + ex.Message);
                }
            }

            Console.WriteLine("Return Received GetAllProductReturnDetail ");
            return lstProductReturnDetail;
        }

        public int InsertProductReturnDetailByExportDetail(int productReturnID, ProductExportDetail pExportDetail)
        {
            Console.WriteLine("Received InsertProductReturnDetailByExportDetail");

            ProductExport pExport = GetProductExportByID(pExportDetail.ProductExportID);
            if (pExport == null)
                return -1;

            //calcualte tax return and discount return amount if any.
            decimal totalItemPrice = pExport.SubTotal;
            decimal itemPrice = pExportDetail.ItemPrice;

            decimal taxTotal = pExport.SubTax;
            decimal taxPercent = taxTotal / totalItemPrice;
            decimal taxReturn = itemPrice * taxPercent;

            decimal discountTotal = pExport.SubDiscount;            
            decimal discountPercent = discountTotal / totalItemPrice;
            decimal discountReturn = itemPrice * discountPercent;

            decimal finalReturn = itemPrice + taxReturn - discountReturn;
            

            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {
                    //create product category.
                    ProductReturnDetailEntity pEntity = new ProductReturnDetailEntity();

                    pEntity.FinalPriceReturn = finalReturn;
                    pEntity.DiscountReturn = discountReturn;
                    pEntity.ReturnDate = DateTime.Now;
                    pEntity.PriceReturn = itemPrice;
                    pEntity.ProductReturnID = productReturnID;
                    pEntity.Quantity = 1; //return only one item each time.
                    pEntity.TaxReturn = taxReturn;
                    pEntity.UPCBarCode = pExportDetail.Barcode;

                    db.ProductReturnDetailEntities.Add(pEntity);
                    db.SaveChanges();
                    Console.WriteLine("Return InsertProductReturnDetailByExportDetail");
                    return pEntity.ProductReturnDetailEntityID;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: Unable to insert a new InsertProductReturnDetailByExportDetail" + ex.Message);
                }
            }
        }

        private ProductReturnDetail GetProdutReturnDetailByID(int productReturnDetailID)
        {
            Console.WriteLine("Received GetProdutReturnDetailByID");
           
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {

                    var myItem = (from c in db.ProductReturnDetailEntities
                                  where c.ProductReturnDetailEntityID == productReturnDetailID
                                  select c).FirstOrDefault();

                    if (myItem != null)
                    {
                        Console.WriteLine("Return Received GetProdutReturnDetailByID ");
                        return TranslateProductReturnDetailEntityToProductReturnDetail(myItem);
                    }

                    Console.WriteLine("Return Received GetProdutReturnDetailByID ");
                    return null;

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: can not excute GetProdutReturnDetailByID " + ex.Message);
                }
            }            
        }

        /// <summary>
        /// This function will import the return product back to the inventory by finding the oldest import product that still opens to put in
        /// </summary>
        /// <param name="productReturnID"></param>
        public void ImportProductReturnBackToInventory(int productReturnID)
        {
            Console.WriteLine("Received ImportProductReturnBackToInventory");

            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {

                    ProductReturn pReturn = GetProductReturnById(productReturnID);

                    if (pReturn != null)
                    {
                        //import all product return detail to product import
                        //then, update product import price, total here.
                        int nInQuantity = 0;
                        decimal subTotal = 0;
                        List<ProductReturnDetail> lstProductReturnDetail = (List<ProductReturnDetail>)GetAllProductReturnDetail(productReturnID);
                        if (lstProductReturnDetail != null
                            && lstProductReturnDetail.Count > 0)
                        {
                            //Insert an product import
                            int productImportID = InsertProductImport();
                            foreach (ProductReturnDetail pReturnDetail in lstProductReturnDetail)
                            {
                                Inventory inventory = GetInventoryByBarcode(pReturnDetail.Barcode);
                                Product p = GetProductByBarcode(pReturnDetail.Barcode);
                                if (inventory != null
                                    && p != null)
                                {
                                    ProductImportDetail pImportDetail = new ProductImportDetail();
                                    pImportDetail.Barcode = pReturnDetail.Barcode;
                                    pImportDetail.InQuantiry = 1;
                                    pImportDetail.InventoryID = inventory.InventoryID;
                                    pImportDetail.ItemImportPrice = p.ImportPrice;
                                    pImportDetail.ProductImportID = productImportID;
                                    pImportDetail.TotalImportPrice = p.ImportPrice; //since the quantity is one
                                    InsertProductImportDetail(pImportDetail);

                                    nInQuantity += pImportDetail.InQuantiry;
                                    subTotal += pImportDetail.TotalImportPrice;
                                }
                            }

                            ProductImport pImport = GetProductImportByID(productImportID);
                            if (pImport != null)
                            {

                                pImport.TotalInQuantity = nInQuantity;
                                pImport.SubTotal = subTotal;

                                pImport.ImportStatus = (int)ImportStatus.Product_Return;
                                UpdateProductImport(ref pImport);
                            }
                        }
                    }
                    

                    Console.WriteLine("Return Received ImportProductReturnBackToInventory ");
                    

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: can not excute ImportProductReturnBackToInventory " + ex.Message);
                }
            }            
        }

        private ProductReturnDetail TranslateProductReturnDetailEntityToProductReturnDetail(ProductReturnDetailEntity entity)
        {
            ProductReturnDetail p = new ProductReturnDetail();

            p.DiscountReturn = entity.DiscountReturn.HasValue ? entity.DiscountReturn.Value : 0;
            p.FinalPriceReturn = entity.FinalPriceReturn.HasValue ? entity.FinalPriceReturn.Value : 0;
            p.PriceReturn = entity.PriceReturn.HasValue ? entity.PriceReturn.Value : 0;
            p.ProductReturnDetailID = entity.ProductReturnDetailEntityID;
            p.ProductReturnID = entity.ProductReturnID;

            p.ReturnDate = entity.ReturnDate.HasValue ? entity.ReturnDate.Value : DateTime.MinValue;
            p.RowVersion = entity.RowVersion;
            p.Quantity = entity.Quantity.HasValue ? entity.Quantity.Value : 0;
            p.TaxReturn = entity.TaxReturn.HasValue ? entity.TaxReturn.Value : 0;
            p.Barcode = entity.UPCBarCode;


            return p;
        }


        #endregion

        #region Customer

        public int InsertCustomer(Customer c)
        {
            Console.WriteLine("Received InsertCustomer");
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {
                    //create product category.
                    CustomerEntity pEntity = new CustomerEntity();

                    pEntity.Address = c.Address;
                    pEntity.Description = c.Description;
                    pEntity.Email = c.Email;
                    pEntity.Name = c.Name;
                    pEntity.Phone = c.Phone;
                    
                    db.CustomerEntities.Add(pEntity);
                    db.SaveChanges();

                    Console.WriteLine("Return InsertCustomer");
                    return pEntity.CustomerID;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: Unable to insert a new InsertCustomer" + ex.Message);
                }
            }
        }

        public bool UpdateCustomer(ref Customer c)
        {
            Console.WriteLine("Received UpdateCustomer");
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {
                    int customerID = c.CustomerID;
                    var customerEntity = (from cu in db.CustomerEntities
                                                   where cu.CustomerID == customerID
                                                   select cu).FirstOrDefault();
                    if (customerEntity == null)
                    {
                        throw new Exception("No customer with ID " + customerID);
                    }

                    //detach it first.
                    ((IObjectContextAdapter)db).ObjectContext.Detach(customerEntity);
                    //update the product
                    customerEntity.Address = c.Address;
                    customerEntity.Name = c.Name;
                    customerEntity.Description = c.Description;
                    customerEntity.Email = c.Email;
                    customerEntity.Phone = c.Phone;
                    customerEntity.RowVersion = c.RowVersion;
                    //attach it.
                    //((IObjectContextAdapter)db).ObjectContext.Attach((IEntityWithKey)providerEntity);
                    ((IObjectContextAdapter)db).ObjectContext.AttachTo("CustomerEntities", customerEntity);
                    // change object state
                    ((IObjectContextAdapter)db).ObjectContext.ObjectStateManager.ChangeObjectState(customerEntity, System.Data.EntityState.Modified);

                    db.SaveChanges();
                    c.RowVersion = customerEntity.RowVersion;
                    db.Dispose();
                    Console.WriteLine("Return Received UpdateCustomer ");
                    return true;              
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: There is an error while UpdateCustomer " + ex.Message);
                }
            }           
        }


        public void DeleteCustomer(int customerID)
        {
            Console.WriteLine("Received DeleteCustomer");
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {
                    var myItem = (from c in db.CustomerEntities
                                  where c.CustomerID == customerID
                                  select c).FirstOrDefault();

                    if (myItem != null)
                    {
                        db.CustomerEntities.Remove(myItem);
                        db.SaveChanges();
                    }

                    Console.WriteLine("Return Received DeleteCustomer ");

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: There is an error while DeleteCustomer " + ex.Message);
                }
            }      
        }

        public IList<Customer> GetAllCustomer()
        {
            Console.WriteLine("Received GetAllCustomer");
            List<Customer> lstCustomer = new List<Customer>();
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {

                    var myItem = (from c in db.CustomerEntities
                                  select c);

                    foreach (CustomerEntity p in myItem)
                    {
                        lstCustomer.Add(TranslateCustomerEntityToCustomer(p));
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: can not get list of GetAllCustomer category " + ex.Message);
                }
            }

            Console.WriteLine("Return Received GetAllCustomer ");
            return lstCustomer;
        }

        private Customer TranslateCustomerEntityToCustomer(CustomerEntity entity)
        {
            Customer c = new Customer();
            c.CustomerID = entity.CustomerID;
            c.Name = entity.Name;
            c.Phone = entity.Phone;
            c.Address = entity.Address;
            c.Email = entity.Email;
            c.Description = entity.Description;
            c.RowVersion = entity.RowVersion;
            return c;
        }

        #endregion

        #region Payment
        public int InsertPayment(Payment p)
        {
            Console.WriteLine("Received InsertPayment");
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {
                    //create product category.
                    PaymentEntity pEntity = new PaymentEntity();

                    pEntity.Cashier = p.Cashier;
                    pEntity.PaymentDate = DateTime.Now;
                    pEntity.PaymentType = p.PaymentType;
                    pEntity.ProductExportID = p.ProductExportID;
                    pEntity.TotalDiscountAmount = p.TotalDiscountAmount;
                    pEntity.TotalItemAmount = p.TotalItemAmount;
                    p.TotalPayment = p.TotalPayment;
                    p.TotalTaxAmount = p.TotalTaxAmount;

                    db.PaymentEntities.Add(pEntity);
                    db.SaveChanges();

                    Console.WriteLine("Return InsertPayment");
                    return pEntity.PaymentID;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: Unable to insert a new InsertPayment" + ex.Message);
                }
            }
        }

        public bool UpdatePayment(ref Payment p)
        {
            Console.WriteLine("Received UpdatePayment");
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {
                    int paymentID = p.PaymentID;
                    var paymentEntity = (from pay in db.PaymentEntities
                                         where pay.PaymentID == paymentID
                                         select pay).FirstOrDefault();
                    if (paymentEntity == null)
                    {
                        throw new Exception("No payment with ID " + paymentID);
                    }

                    //detach it first.
                    ((IObjectContextAdapter)db).ObjectContext.Detach(paymentEntity);
                    //update the product
                    paymentEntity.Cashier = p.Cashier;
                    paymentEntity.PaymentDate = p.PaymentDate;
                    paymentEntity.PaymentType = p.PaymentType;
                    paymentEntity.ProductExportID = p.ProductExportID;
                    paymentEntity.TotalDiscountAmount = p.TotalDiscountAmount;
                    paymentEntity.TotalItemAmount = p.TotalItemAmount;
                    paymentEntity.TotalPayment = p.TotalPayment;
                    paymentEntity.TotalTaxAmount = p.TotalTaxAmount;
                    //attach it.
                    //((IObjectContextAdapter)db).ObjectContext.Attach((IEntityWithKey)providerEntity);
                    ((IObjectContextAdapter)db).ObjectContext.AttachTo("PaymentEntities", paymentEntity);
                    // change object state
                    ((IObjectContextAdapter)db).ObjectContext.ObjectStateManager.ChangeObjectState(paymentEntity, System.Data.EntityState.Modified);

                    db.SaveChanges();
                    p.RowVersion = paymentEntity.RowVersion;
                    db.Dispose();
                    Console.WriteLine("Return Received UpdatePayment ");
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: There is an error while UpdatePayment " + ex.Message);
                }
            }           
        }


        private void DeleteAllPayment(int productExportID)
        {
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {
                    var myItem = (from c in db.PaymentEntities
                                  where c.ProductExportID == productExportID                                  
                                  select c);

                    foreach (PaymentEntity p in myItem)
                    {
                        DeletePayment(p.PaymentID);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: There is an error while DeleteAllPayment " + ex.Message);
                }
            }      
        }

        public void DeletePayment(int paymentID)
        {
            Console.WriteLine("Received DeletePayment");
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {
                    var myItem = (from c in db.PaymentEntities
                                  where c.PaymentID == paymentID
                                  select c).FirstOrDefault();

                    if (myItem != null)
                    {
                        db.PaymentEntities.Remove(myItem);
                        db.SaveChanges();
                    }

                    Console.WriteLine("Return Received DeletePayment ");

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: There is an error while DeletePayment " + ex.Message);
                }
            }      
        }

        public IList<Payment> GetAllPayment()
        {
            Console.WriteLine("Received GetAllPayment");
            List<Payment> lstPayment = new List<Payment>();
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {

                    var myItem = (from c in db.PaymentEntities
                                  select c);

                    foreach (PaymentEntity p in myItem)
                    {
                        lstPayment.Add(TranslatePaymentEntityToPayment(p));
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: can not get list of GetAllPayment " + ex.Message);
                }
            }

            Console.WriteLine("Return Received GetAllPayment ");
            return lstPayment;
        }

        private Payment TranslatePaymentEntityToPayment(PaymentEntity entity)
        {
            Payment p = new Payment();
            p.Cashier = entity.Cashier;
            p.PaymentDate = entity.PaymentDate.HasValue ? entity.PaymentDate.Value : DateTime.MinValue;
            p.PaymentID = entity.PaymentID;
            p.PaymentType = entity.PaymentType;
            p.ProductExportID = entity.ProductExportID;
            p.RowVersion = entity.RowVersion;
            p.TotalDiscountAmount = entity.TotalDiscountAmount.HasValue ? entity.TotalDiscountAmount.Value : 0;
            p.TotalItemAmount = entity.TotalItemAmount.HasValue ? entity.TotalItemAmount.Value : 0;
            p.TotalPayment = entity.TotalPayment.HasValue ? entity.TotalPayment.Value : 0;
            p.TotalTaxAmount = entity.TotalTaxAmount.HasValue ? entity.TotalTaxAmount.Value : 0;
            return p;
        }

        #endregion

        #region Report
        public IList<InventoryReportData> GetAllInventoryReportDataByQuantity(int nQuantity)
        {
            Console.WriteLine("Received GetAllInventoryReportDataByQuantity");
            List<InventoryReportData> lstInventoryReportData = new List<InventoryReportData>();
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {

                    var myItem = (from c in db.InventoryEntities
                                  where c.TotalQuantity <= nQuantity
                                  select c);

                    foreach (InventoryEntity inventory in myItem)
                    {
                        Product p = GetProductByBarcode(inventory.UPCBarCode);
                        if (p != null)
                        {
                            InventoryReportData d = new InventoryReportData();
                            d.Barcode = inventory.UPCBarCode;
                            d.InventoryID = inventory.InventoryID;
                            d.ProductName = p.Name;
                            d.ProductUPK = p.ProductID.ToString("00000");
                            d.TotalQuantity = inventory.TotalQuantity.HasValue ? inventory.TotalQuantity.Value : 0;

                            lstInventoryReportData.Add(d);
                        }
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("Error: can not get list of GetAllInventoryReportDataByQuantity" + ex.Message);
                }
            }

            Console.WriteLine("Return Received GetAllInventoryReportDataByQuantity ");
            lstInventoryReportData = lstInventoryReportData.OrderBy(q => q.ProductName).ToList(); //sort by ASC 
            return lstInventoryReportData;
        }

        /// <summary>
        /// end date should be add by 1 to ensure that the daily report will run correctly
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public IList<SaleReportData> GetSaleReport(DateTime start, DateTime end)
        {
            Console.WriteLine("Received GetSaleReport");
            List<SaleReportData> lstSaleReportData = new List<SaleReportData>();
            using (dbnailsupplyEntities db = new dbnailsupplyEntities())
            {
                try
                {
                    DateTime shortStartDate = Convert.ToDateTime(start.ToShortDateString());
                    DateTime shortEndDate = Convert.ToDateTime(end.ToShortDateString());

                    var productExports = (from c in db.ProductExportEntities
                                  where ((c.ExportDate >= shortStartDate)
                                        && (c.ExportDate <= shortEndDate))                                  
                                  select c);

                    //translate datetime to shortdate time
                    List<ProductExport> lstProductExport = new List<ProductExport>();
                    foreach (ProductExportEntity entity in productExports)
                    {
                        ProductExport export = TranslateProductExportEntityToProductExport(entity);
                        export.ExportDate = Convert.ToDateTime(export.ExportDate.ToShortDateString());
                        lstProductExport.Add(export);
                    }

                    var myItem = (from c in lstProductExport
                                  group c by c.ExportDate into grouping
                                  select new
                                  {
                                      Date = grouping.Key,
                                      TotalSaleAmount = grouping.Sum(p => p.FinalSalePrice),
                                      TotalImportAmount = grouping.Sum(p => p.TotalImportPrice),                                    
                                  });

                    foreach (var p in myItem)
                    {
                        SaleReportData d = new SaleReportData();
                        d.Date = p.Date;
                        d.TotalSaleAmount = p.TotalSaleAmount;
                        d.TotalImportAmount = p.TotalImportAmount;
                        d.IncomeAmount = d.TotalSaleAmount - d.TotalImportAmount;
                        lstSaleReportData.Add(d);
                    }

                    Console.WriteLine("Return Received GetSaleReport ");
                    //lstInventoryReportData = lstInventoryReportData.OrderBy(q => q.ProductName).ToList(); //sort by ASC 
                    return lstSaleReportData;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: can not get list of GetSaleReport" + ex.Message);
                }
            }

            
        }
        #endregion
    }    
}
