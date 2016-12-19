using Controller;
using DataAccessLayer;
using Models;
using System.Collections.Generic;
using System.Data;

namespace WcfService
{
    /// <summary>
    /// The Service class
    /// </summary>
    public class BestilNemtService : IBestilNemtService
    {
        /// <summary>
        /// Global variables of the Constrollers
        /// </summary>
        public LoginCtr LoginCtr { get; set; }
        public CustomerCtr CustomerCtr { get; set; }
        public ShopCtr ShopController { get; set; }
        public ChainCtr ChainCtr { get; set; }
        public AdminCtr AdminCtr { get; set; }
        public ProductCtr ProductCtr { get; set; }
        public PartOrderCtr PartOrderCtr { get; set; }
        public CartCtr CartCtr { get; set; }
        public SavingCtr SavingCtr { get; set; }
        public WarehouseCtr WarehouseCtr { get; set; }

        /// <summary>
        /// Initialize all Controllers
        /// </summary>
        public BestilNemtService()
        {
            LoginCtr = new LoginCtr(new DbLogin());
            CustomerCtr = new CustomerCtr(new DbCustomer());
            ShopController = new ShopCtr(new DbShop());
            ChainCtr = new ChainCtr(new DbChain());
            AdminCtr = new AdminCtr(new DbAdmin());
            ProductCtr = new ProductCtr(new DbProduct());
            CartCtr = new CartCtr(new DbCart());
            PartOrderCtr = new PartOrderCtr(new DbPartOrder());
            SavingCtr = new SavingCtr(new DbSaving());
            WarehouseCtr = new WarehouseCtr(new DbWarehouse());
        }
        ///// <summary>
        ///// Add a Admin
        ///// </summary>
        ///// <param name="admin"></param>
        ///// <returns>
        ///// Id of Admin if added, else 0
        ///// </returns>
        //public int AddAdmin(Admin admin)
        //{
        //    return AdminCtr.AddAdmin(admin);
        //}

        /// <summary>
        /// Get a Admin by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return a Admin if found, else null
        /// </returns>
        public Admin GetAdmin(int id)
        {
            return AdminCtr.GetAdmin(id);
        }

        ///// <summary>
        ///// Update a Admin
        ///// </summary>
        ///// <param name="admin"></param>
        ///// <returns>
        ///// Return 1 if Admin was updated, else 0
        ///// </returns>
        //public int UpdateAdmin(Admin admin)
        //{
        //    return AdminCtr.UpdateAdmin(admin);
        //}

        ///// <summary>
        ///// Delete a Admin
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns>
        ///// Return 1 if Admin was deleted, else 0
        ///// </returns>
        //public int DeleteAdmin(int id)
        //{
        //    return AdminCtr.DeleteAdmin(id);
        //}

        /// <summary>
        /// Add a Shop
        /// </summary>
        /// <param name="shop"></param>
        /// <returns>
        /// Id of Shop if added, else 0
        /// </returns>
        public int AddShop(Shop shop)
        {
            return ShopController.AddShop(shop);
        }

        /// <summary>
        /// Get a Shop
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return a Shop if found, else null
        /// </returns>
        public Shop GetShop(int id)
        {
            return ShopController.GetShop(id);
        }

        /// <summary>
        /// Get all shops a Chain Id
        /// </summary>
        /// <returns>
        /// List of Shop
        /// </returns>
        public List<Shop> GetAllShopsByChainId(int chainId)
        {
            return ShopController.GetAllShopsByChainId(chainId);
        }

        /// <summary>
        /// Update a Shop
        /// </summary>
        /// <param name="shop"></param>
        /// <returns>
        /// Return 1 if Shop was updated, else 0
        /// </returns>
        public int UpdateShop(Shop shop)
        {
            return ShopController.UpdateShop(shop);
        }

        /// <summary>
        /// Delete a Shop
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return 1 if Shop was removed, else 0
        /// </returns>
        public int DeleteShop(int id)
        {
            return ShopController.DeleteShop(id);
        }

        ///// <summary>
        ///// Add a Chain
        ///// </summary>
        ///// <param name="chain"></param>
        ///// <returns>
        ///// id of Chain if added, else 0
        ///// </returns>
        //public int AddChain(Chain chain)
        //{
        //    return ChainCtr.AddChain(chain);
        //}

        /// <summary>
        /// Get a Chain by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Chain if found, else null
        /// </returns>
        public Chain GetChain(int id)
        {
            return ChainCtr.GetChain(id);
        }

        /// <summary>
        /// Get all Chains
        /// </summary>
        /// <returns>
        /// List of Chain
        /// </returns>
        public List<Chain> GetAllChains()
        {
            return ChainCtr.GetAllChains();
        }

        ///// <summary>
        ///// Delete a Chain
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns>
        ///// Return 1 if Chain was deleted, else 0
        ///// </returns>
        //public int DeleteChain(int id)
        //{
        //    return ChainCtr.DeleteChain(id);
        //}

        /// <summary>
        /// Add a Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns>
        /// Id of Product if added, else 0
        /// </returns>
        public int AddProduct(Product product)
        {
            return ProductCtr.AddProduct(product);
        }

        /// <summary>
        /// Get a Product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return Product if found, else null
        /// </returns>
        public Product GetProduct(int id)
        {
            return ProductCtr.GetProduct(id);
        }

        /// <summary>
        /// Get all Sold Products
        /// </summary>
        /// <returns>
        /// List of Product
        /// </returns>
        public List<Product> GetAllSoldProducts()
        {
            return ProductCtr.GetAllSoldProducts();
        }

        /// <summary>
        /// Get all Products with a Saving
        /// </summary>
        /// <returns>
        /// List of Product
        /// </returns>
        public List<Product> GetAllProductsWithSavings()
        {
            return ProductCtr.GetAllProductsWithSavings();
        }

        /// <summary>
        /// Update a Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns>
        /// Return 1 if Product was updated, else 0
        /// </returns>
        public int UpdateProduct(Product product)
        {
            return ProductCtr.UpdateProduct(product);
        }

        /// <summary>
        /// Delete a Product
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return 1 if Product was deleted, else 0
        /// </returns>
        public int DeleteProduct(int id)
        {
            return ProductCtr.DeleteProduct(id);
        }

        /// <summary>
        /// Add a Cart
        /// </summary>
        /// <param name="cart"></param>
        /// <returns>
        /// 1 if cart waas added, else 0
        /// </returns>
        public int AddCart(Cart cart)
        {
            return CartCtr.AddCart(cart);
        }

        /// <summary>
        /// Add a Cart with a List of PartOrders
        /// </summary>
        /// <param name="cart"></param>
        /// <returns>
        /// 1 if cart was added, else 0
        /// </returns>
        public int AddCartWithPartOrders(Cart cart)
        {
            return CartCtr.AddCartWithPartOrders(cart);
        }

        /// <summary>
        /// Get all carts
        /// </summary>
        /// <returns>
        /// List of Cart
        /// </returns>
        public List<Cart> GetAllCarts()
        {
            return CartCtr.GetAllCarts();
        }

        /// <summary>
        /// Get all Cart by a person id
        /// </summary>
        /// <param name="personId"></param>
        /// <returns>
        /// list of Cart 
        /// </returns>
        public List<Cart> GetAllCartsByPersonId(int personId)
        {
            return CartCtr.GetAllCartsByPersonId(personId);
        }

        /// <summary>
        /// Login with a login object
        /// </summary>
        /// <param name="login"></param>
        /// <returns>
        /// Login object if login was correct, else null
        /// </returns>
        public Login Login(Login login)
        {
            return LoginCtr.Login(login);
        }

        ///// <summary>
        ///// Update a Login
        ///// </summary>
        ///// <param name="login"></param>
        ///// <returns>
        ///// Return 1 if Login was updated, else 0
        ///// </returns>
        //public int UpdateLogin(Login login)
        //{
        //    return LoginCtr.UpdateLogin(login);
        //}

        /// <summary>
        /// Add a PartOrder
        /// </summary>
        /// <param name="partOrder"></param>
        /// <returns>
        /// Id of PartOrder if added, else 0
        /// </returns>
        public int AddPartOrder(PartOrder partOrder)
        {
            return PartOrderCtr.AddPartOrder(partOrder);
        }

        /// <summary>
        /// Add a Saving
        /// </summary>
        /// <param name="saving"></param>
        /// <param name="warehouse"></param>
        /// <returns>
        /// Id of Saving if added, else 0
        /// </returns>
        public int AddSaving(Saving saving, Warehouse warehouse)
        {
            return SavingCtr.AddSaving(saving, warehouse);
        }

        /// <summary>
        /// Get a Saving
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Saving if found, else null
        /// </returns>
        public Saving GetSaving(int id)
        {
            return SavingCtr.GetSaving(id);
        }

        /// <summary>
        /// Delete a Saving
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// 1 if Saving was deleted, else 0
        /// </returns>
        public int DeleteSaving(int id)
        {
            return SavingCtr.DeleteSaving(id);
        }

        /// <summary>
        /// Add a Warehouse
        /// </summary>
        /// <param name="warehouse"></param>
        /// <returns>
        /// Id of Warehouse if added, else 0
        /// </returns>
        public int AddWarehouse(Warehouse warehouse)
        {
            return WarehouseCtr.AddWarehouse(warehouse);
        }

        /// <summary>
        /// Get a Warehouse
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Warehouse if found, else null
        /// </returns>
        public Warehouse GetWarehouse(int id)
        {
            return WarehouseCtr.GetWarehouse(id);
        }

        /// <summary>
        /// Get all Warehouses by a Shop id
        /// </summary>
        /// <param name="shopId"></param>
        /// <returns>
        /// List of Warehouse
        /// </returns>
        public List<Warehouse> GetAllWarehousesByShopId(int shopId)
        {
            return WarehouseCtr.GetAllWarehousesByShopId(shopId);
        }

        /// <summary>
        /// Update a Warehouse
        /// </summary>
        /// <param name="warehouse"></param>
        /// <returns>
        /// 1 if Warehouse was updated, else 0
        /// </returns>
        public int UpdateWarehouse(Warehouse warehouse)
        {
            return WarehouseCtr.UpdateWarehouse(warehouse);
        }

        /// <summary>
        /// Delete a Warehouse
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// 1 if Warehouse was deleted, else 0
        /// </returns>
        public int DeleteWarehouse(int id)
        {
            return WarehouseCtr.DeleteWarehouse(id);
        }

        /// <summary>
        /// Add a Customer with a Login
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="login"></param>
        /// <returns>
        /// Id of Customer if added, else 0
        /// </returns>
        public int AddCustomerWithLogin(Customer customer, Login login)
        {
            return CustomerCtr.AddCustomerWithLogin(customer, login);
        }

        /// <summary>
        /// Get a Warehouse by product id
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="shopId"></param>
        /// <returns>
        /// Warehouse if found, else null
        /// </returns>
        public Warehouse GetWarehouseByProductId(int productId, int shopId)
        {
            return WarehouseCtr.GetWarehouseByProductId(productId, shopId);
        }

        /// <summary>
        /// Get data grid for Product
        /// </summary>
        /// <returns>
        /// DataTable
        /// </returns>
        public DataTable GetDataGridProducts()
        {
            return ProductCtr.GetDataGridProducts();
        }

        /// <summary>
        /// Get a Warehouse with a Product by a adminId
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns>
        /// DataTable
        /// </returns>
        public DataTable GetProductWareHouse(int adminId)
        {
            return ProductCtr.GetProductWareHouse(adminId);
        }

        /// <summary>
        /// Get a Chain DataTable
        /// </summary>
        /// <returns>
        /// DataTable
        /// </returns>
        public DataTable GetChainData()
        {
            return ChainCtr.GetChainData();
        }

        /// <summary>
        /// Get Data Grid for Shop
        /// </summary>
        /// <returns>
        /// DataTable
        /// </returns>
        public DataTable GetDataGridShop()
        {
            return ShopController.GetDataGridShop();
        }
    }
}
