using Controller;
using DataAccessLayer;
using Models;
using System.Collections.Generic;
using System;

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
        public CompanyCtr CompanyCtr { get; set; }
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
            CompanyCtr = new CompanyCtr(new DbCompany());
            AdminCtr = new AdminCtr(new DbAdmin());
            ProductCtr = new ProductCtr(new DbProduct());
            CartCtr = new CartCtr(new DbCart());
            PartOrderCtr = new PartOrderCtr(new DbPartOrder());
            SavingCtr = new SavingCtr(new DbSaving());
            WarehouseCtr = new WarehouseCtr(new DbWarehouse());
        }

        /// <summary>
        /// Add a Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>
        /// Id of Customer if added, else 0
        /// </returns>
        public int AddCustomer(Customer customer)
        {
            return CustomerCtr.AddCustomer(customer);
        }

        /// <summary>
        /// Get a Customer by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return a Customer if found, else null
        /// </returns>
        public Customer GetCustomer(int id)
        {
            return CustomerCtr.GetCustomer(id);
        }

        /// <summary>
        /// Get All Customers
        /// </summary>
        /// <returns>
        /// List of Customer
        /// </returns>
        public List<Customer> GetAllCustomer()
        {
            return CustomerCtr.GetAllCustomer();
        }

        /// <summary>
        /// Update a Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>
        /// Return 1 if Customer was updated, else 0
        /// </returns>
        public int UpdateCustomer(Customer customer)
        {
            return CustomerCtr.UpdateCustomer(customer);
        }

        /// <summary>
        /// Delete a Customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return 1 if Customer was deleted, else 0
        /// </returns>
        public int DeleteCustomer(int id)
        {
            return CustomerCtr.DeleteCustomer(id);
        }

        /// <summary>
        /// Add a Admin
        /// </summary>
        /// <param name="admin"></param>
        /// <returns>
        /// Id of Admin if added, else 0
        /// </returns>
        public int AddAdmin(Admin admin)
        {
            return AdminCtr.AddAdmin(admin);
        }

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

        /// <summary>
        /// Get all Admins
        /// </summary>
        /// <returns>
        /// List of Admin
        /// </returns>
        public List<Admin> GetAllAdmins()
        {
            return AdminCtr.GetAllAdmins();
        }

        /// <summary>
        /// Update a Admin
        /// </summary>
        /// <param name="admin"></param>
        /// <returns>
        /// Return 1 if Admin was updated, else 0
        /// </returns>
        public int UpdateAdmin(Admin admin)
        {
            return AdminCtr.UpdateAdmin(admin);
        }

        /// <summary>
        /// Delete a Admin
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return 1 if Admin was deleted, else 0
        /// </returns>
        public int DeleteAdmin(int id)
        {
            return AdminCtr.DeleteAdmin(id);
        }

        /// <summary>
        /// Add a Company
        /// </summary>
        /// <param name="company"></param>
        /// <returns>
        /// Id of Company if added, else 0
        /// </returns>
        public int AddCompany(Company company)
        {
            return CompanyCtr.AddCompany(company);
        }

        /// <summary>
        /// Get a Company by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return Company if found, else null
        /// </returns>
        public Company GetCompany(int id)
        {
            return CompanyCtr.GetCompany(id);
        }

        /// <summary>
        /// Get all Companies
        /// </summary>
        /// <returns>
        /// List of Company
        /// </returns>
        public List<Company> GetAllCompany()
        {
            return CompanyCtr.GetAllCompany();
        }

        /// <summary>
        /// Update a Company
        /// </summary>
        /// <param name="company"></param>
        /// <returns>
        /// Return 1 if Company was updated, else 0
        /// </returns>
        public int UpdateCompany(Company company)
        {
            return CompanyCtr.UpdateCompany(company);
        }

        /// <summary>
        /// Delete a Company
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return 1 if Company was deleted, else 0
        /// </returns>
        public int DeleteCompany(int id)
        {
            return CompanyCtr.RemoveCompany(id);
        }

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
        /// Get all Shops
        /// </summary>
        /// <returns>
        /// List of Shop
        /// </returns>
        public List<Shop> GetAllShops()
        {
            return ShopController.GetAllShops();
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

        /// <summary>
        /// Add a Chain
        /// </summary>
        /// <param name="chain"></param>
        /// <returns>
        /// id of Chain if added, else 0
        /// </returns>
        public int AddChain(Chain chain)
        {
            return ChainCtr.AddChain(chain);
        }

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

        /// <summary>
        /// Update a Chain
        /// </summary>
        /// <param name="chain"></param>
        /// <returns>
        /// Return 1 if Chain was updated, else 0
        /// </returns>
        public int UpdateChain(Chain chain)
        {
            return ChainCtr.UpdateChain(chain);
        }

        /// <summary>
        /// Delete a Chain
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return 1 if Chain was deleted, else 0
        /// </returns>
        public int DeleteChain(int id)
        {
            return ChainCtr.DeleteChain(id);
        }

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
        /// Get all Products
        /// </summary>
        /// <returns>
        /// List of Product
        /// </returns>
        public List<Product> GetAllProducts()
        {
            return ProductCtr.GetAllProducts();
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
        /// Get a Cart
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Cart if found, else null
        /// </returns>
        public Cart GetCart(int id)
        {
            return CartCtr.GetCart(id);
        }

        /// <summary>
        /// Get a Cart with a list of PartOrders
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns>
        /// Cart if found, else null
        /// </returns>
        public Cart GetCartWithPartOrders(int cartId)
        {
            return CartCtr.GetCartWithPartOrders(cartId);
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
        /// Update a Cart
        /// </summary>
        /// <param name="cart"></param>
        /// <returns>
        /// 1 if cart was updated, else 0
        /// </returns>
        public int UpdateCart(Cart cart)
        {
            return CartCtr.UpdateCart(cart);
        }

        /// <summary>
        /// Delete a Cart
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// 1 if Cart was deleted, else 0
        /// </returns>
        public int DeleteCart(int id)
        {
            return CartCtr.DeleteCart(id);
        }

        /// <summary>
        /// Add a PartOrder to a Cart
        /// </summary>
        /// <param name="cart"></param>
        /// <param name="partOrder"></param>
        /// <returns>
        /// 1 if the partOrder was added to the cart
        /// </returns>
        public int AddPartOrderToCart(Cart cart, PartOrder partOrder)
        {
            return CartCtr.AddPartOrderToCart(cart, partOrder);
        }

        /// <summary>
        /// Add a Login
        /// </summary>
        /// <param name="login"></param>
        /// <returns>
        /// if of Login if added, else 0
        /// </returns>
        public int AddLogin(Login login)
        {
            return LoginCtr.AddLogin(login);
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

        /// <summary>
        /// Update a Login
        /// </summary>
        /// <param name="login"></param>
        /// <returns>
        /// Return 1 if Login was updated, else 0
        /// </returns>
        public int UpdateLogin(Login login)
        {
            return LoginCtr.UpdateLogin(login);
        }

        /// <summary>
        /// Delete a Login
        /// </summary>
        /// <param name="login"></param>
        /// <returns>
        /// Return 1 if Login was deleted, else 0
        /// </returns>
        public int DeleteLogin(Login login)
        {
            return LoginCtr.DeleteLogin(login);
        }

        /// <summary>
        /// Get a PartOrder by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// PartOrder if found, else null
        /// </returns>
        public PartOrder GetPartOrder(int id)
        {
            return PartOrderCtr.GetPartOrder(id);
        }

        /// <summary>
        /// Update a PartOrder
        /// </summary>
        /// <param name="partOrder"></param>
        /// <returns>
        /// 1 if PartOrder was updated, else 0
        /// </returns>
        public int UpdatePartOrder(PartOrder partOrder)
        {
            return PartOrderCtr.UpdatePartOrder(partOrder);
        }

        /// <summary>
        /// Delete a PartOrder
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// 1 if PartOrder was deleted, else 0
        /// </returns>
        public int DeletePartOrder(int id)
        {
            return PartOrderCtr.DeletePartOrder(id);
        }

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
        /// Get all PartOrders
        /// </summary>
        /// <returns>
        /// List of PartOrder
        /// </returns>
        public List<PartOrder> GetAllPartOrders()
        {
            return PartOrderCtr.GetAllPartOrders();
        }

        /// <summary>
        /// Add a Saving
        /// </summary>
        /// <param name="saving"></param>
        /// <param name="product"></param>
        /// <returns>
        /// Id of Saving if added, else 0
        /// </returns>
        public int AddSaving(Saving saving, Product product)
        {
            return SavingCtr.AddSaving(saving, product);
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
        /// Get all Savings
        /// </summary>
        /// <returns>
        /// List of Saving
        /// </returns>
        public List<Saving> GetAllSavings()
        {
            return SavingCtr.GetAllSavings();
        }

        /// <summary>
        /// Update a Saving
        /// </summary>
        /// <param name="saving"></param>
        /// <returns>
        /// 1 if Saving is updated, else 0
        /// </returns>
        public int UpdateSaving(Saving saving)
        {
            return SavingCtr.UpdateSaving(saving);
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
        /// Get a product by Name
        /// Used to find all products with a name similar to input
        /// </summary>
        /// <param name="input"></param>
        /// <returns>
        /// List of Product
        /// </returns>
        public List<Product> GetProductsByName(string input)
        {
            return ProductCtr.GetProductsByName(input);
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
        /// Get all Warehouses
        /// </summary>
        /// <returns>
        /// list of Warehouse
        /// </returns>
        public List<Warehouse> GetAllWarehouses()
        {
            return WarehouseCtr.GetAllWarehouses();
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

        public Warehouse GetWarehouseByProductId(int productId, int shopId)
        {
            return ProductCtr.GetWarehouseByProductId(productId, shopId);
        }
    }
}
