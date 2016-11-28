using Controller;
using DataAccessLayer;
using Models;
using System.Collections.Generic;
using System;

namespace WcfService
{
    public class BestilNemtService : IBestilNemtService
    {
        public CustomerCtr CustomerCtr { get; set; }
        public ShopCtr ShopController { get; set; }
        public LoginCtr LoginCtr { get; set; }
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
            WarehouseCtr = new WarehouseCtr(new DbWarehouse());
            SavingCtr = new SavingCtr(new DbSaving());
        }

        /// <summary>
        /// Add a Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>
        /// Return 1 if Customer was added, else 0
        /// </returns>
        public int AddCustomer(Customer customer)
        {
            return CustomerCtr.AddCustomer(customer);
        }

        /// <summary>
        /// Return a Customer by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return a Customer if found, else null
        /// </returns>
        public Customer FindCustomer(int id)
        {
            return CustomerCtr.FindCustomer(id);
        }

        /// <summary>
        /// Return a list of all Customers
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
        /// Return 1 if Admin was added, else 0
        /// </returns>
        public int AddAdmin(Admin admin)
        {
            return AdminCtr.AddAdmin(admin);
        }

        /// <summary>
        /// Find a Admin by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return a Admin if found, else null
        /// </returns>
        public Admin FindAdmin(int id)
        {
            return AdminCtr.FindAdmin(id);
        }

        /// <summary>
        /// Return a list of all Admins
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
        /// Return 1 if Company was added, else 0
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
        public Company FindCompany(int id)
        {
            return CompanyCtr.FindCompany(id);
        }

        /// <summary>
        /// Return a list of all Company
        /// </summary>
        /// <returns>
        /// List of Company
        /// </returns>
        public List<Company> FindAllCompany()
        {
            return CompanyCtr.FindAllCompany();
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
        /// Return 1 if Shop was added, else 0
        /// </returns>
        public int AddShop(Shop shop)
        {
            return ShopController.AddShop(shop);
        }

        /// <summary>
        /// Return a Shop by id
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
        /// Return a list of all Shops
        /// </summary>
        /// <returns>
        /// List of Shop
        /// </returns>
        public List<Shop> GetAllShops()
        {
            return ShopController.FindAllShops();
        }

        /// <summary>
        /// Return a list of all Shops by a chain Id
        /// </summary>
        /// <returns>
        /// List of Shop
        /// </returns>
        public List<Shop> GetAllShopsByChainId(int chainId)
        {
            return ShopController.FindAllShopsByChainId(chainId);
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
        /// Return 1 if Chain was added, else 0
        /// </returns>
        public int AddChain(Chain chain)
        {
            return ChainCtr.AddChain(chain);
        }

        /// <summary>
        /// Return a Chain by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return a Chain if found, else null
        /// </returns>
        public Chain GetChain(int id)
        {
            return ChainCtr.GetChain(id);
        }

        /// <summary>
        /// Return a list of all Chains
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
        /// Return 1 if Product was added, else 0
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
            return ProductCtr.FindProduct(id);
        }

        /// <summary>
        /// Get a list of all Products
        /// </summary>
        /// <returns>
        /// List of Product
        /// </returns>
        public List<Product> GetAllProducts()
        {
            return ProductCtr.FindAllProducts();
        }

        /// <summary>
        /// Get a list of all Sold Products
        /// </summary>
        /// <returns>
        /// List of Product
        /// </returns>
        public List<Product> GetAllSoldProducts()
        {
            return ProductCtr.FindAllSoldProducts();
        }

        /// <summary>
        /// Get a list of all Products with a saving
        /// </summary>
        /// <returns>
        /// List of Product
        /// </returns>
        public List<Product> GetAllProductsWithSavings()
        {
            return ProductCtr.FindAllProductsWithSavings();
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

        public int AddCart(Cart cart)
        {
            return CartCtr.AddCart(cart);
        }

        public Cart FindCart(int id)
        {
            return CartCtr.FindCart(id);
        }
        public Cart FindCartWithPartOrders(int cartId)
        {
            return CartCtr.FindCartWithPartOrders(cartId);
        }

        public List<Cart> GetAllCarts()
        {
            return CartCtr.GetAllCarts();
        }

        public int UpdateCart(Cart cart)
        {
            return CartCtr.UpdateCart(cart);
        }

        public int DeleteCart(int id)
        {
            return CartCtr.DeleteCart(id);
        }

        public int AddPartOrderToCart(Cart cart, PartOrder partOrder)
        {
            return CartCtr.AddPartOrderToCart(cart, partOrder);
        }

        /// <summary>
        /// Add a Login
        /// </summary>
        /// <param name="login"></param>
        /// <returns>
        /// Return 1 if Login was added, else 0
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
        /// Return a Login object if login was correct, else null
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

        public PartOrder FindPartOrder(int id)
        {
            return PartOrderCtr.FindPartOrder(id);
        }

        public int UpdatePartorder(PartOrder partOrder)
        {
            return PartOrderCtr.UpdatePartorder(partOrder);
        }

        public int RemovePartOrder(int id)
        {
            return PartOrderCtr.RemovePartOrder(id);
        }

        public int AddPartOrder(PartOrder partOrder)
        {
            return PartOrderCtr.AddPartOrder(partOrder);
        }

        public List<PartOrder> GetAllPartOrders()
        {
            return PartOrderCtr.GetAllPartOrders();
        }

        public int AddSaving(Saving saving, Product product)
        {
            return SavingCtr.AddSaving(saving, product);
        }

        public Saving FindSaving(int id)
        {
            return SavingCtr.FindSaving(id);
        }

        public List<Saving> FindAllSavings()
        {
            return SavingCtr.FindAllSavings();
        }

        public int UpdateSaving(Saving saving)
        {
            return SavingCtr.UpdateSaving(saving);
        }

        public int DeleteSaving(int id)
        {
            return SavingCtr.DeleteSaving(id);
        }

        public List<Product> FindProductsByName(string input)
        {
            return ProductCtr.FindProductsByName(input);
        }

        //Warehouse

        public int AddWarehouse(Warehouse warehouse)
        {
            return WarehouseCtr.AddWarehouse(warehouse);
        }

        public Warehouse FindWarehouse(int id)
        {
            return WarehouseCtr.FindWarehouse(id);
        }

        public List<Warehouse> FindAllWarehouses()
        {
            return WarehouseCtr.FindAllWarehouses();
        }

        public List<Warehouse> FindAllWarehousesByShopId(int shopId)
        {
            return WarehouseCtr.FindAllWarehousesByShopId(shopId);
        }

        public int UpdateWarehouse(Warehouse warehouse)
        {
            return WarehouseCtr.UpdateWarehouse(warehouse);
        }

        public int DeleteWarehouse(int id)
        {
            return WarehouseCtr.DeleteWarehouse(id);
        }
    }
}
