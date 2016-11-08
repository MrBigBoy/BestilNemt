using Controller;
using DataAccessLayer;
using Models;
using System.Collections.Generic;

namespace WcfService
{
    public class BestilNemtService : IBestilNemtService
    {
        public CustomerCtr CustomerCtr { get; set; }
        public WarehouseCtr WarehouseController { get; set; }
        public LoginCtr LoginCtr { get; set; }
        public ShopCtr ShopCtr { get; set; }
        public CompanyCtr CompanyCtr { get; set; }
        public AdminCtr AdminCtr { get; set; }
        public ProductCtr ProductCtr { get; set; }

        /// <summary>
        /// Initialize all Controllers
        /// </summary>
        public BestilNemtService()
        {
            LoginCtr = new LoginCtr(new DbLogin());
            CustomerCtr = new CustomerCtr(new DbCustomer());
            WarehouseController = new WarehouseCtr(new DbWarehouse());
            ShopCtr = new ShopCtr(new DbShop());
            CompanyCtr = new CompanyCtr(new DbCompany());
            AdminCtr = new AdminCtr(new DbAdmin());
            ProductCtr = new ProductCtr(new DbProduct());
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
            return CustomerCtr.AddPerson(customer);
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
            return CompanyCtr.findCompany(id);
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
            return CompanyCtr.updateCompany(company);
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
            return CompanyCtr.removeCompany(id);
        }

        /// <summary>
        /// Add a Warehouse
        /// </summary>
        /// <param name="warehouse"></param>
        /// <returns>
        /// Return 1 if Warehouse was added, else 0
        /// </returns>
        public int AddWarehouse(Warehouse warehouse)
        {
            return WarehouseController.Add(warehouse);
        }

        /// <summary>
        /// Return a Warehouse by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return a Warehouse if found, else null
        /// </returns>
        public Warehouse GetWarehouse(int id)
        {
            return WarehouseController.Get(id);
        }

        /// <summary>
        /// Return a list of all Warehouses
        /// </summary>
        /// <returns>
        /// List of Warehouse
        /// </returns>
        public List<Warehouse> GetAllWarehouses()
        {
            return WarehouseController.GetAll();
        }

        /// <summary>
        /// Update a Warehouse
        /// </summary>
        /// <param name="warehouse"></param>
        /// <returns>
        /// Return 1 if Warehouse was updated, else 0
        /// </returns>
        public int UpdateWarehouse(Warehouse warehouse)
        {
            return WarehouseController.Update(warehouse);
        }

        /// <summary>
        /// Remove a Warehouse
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return 1 if Warehouse was removed, else 0
        /// </returns>
        public int RemoveWarehouse(int id)
        {
            return WarehouseController.Remove(id);
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
            return ShopCtr.AddShop(shop);
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
            return ShopCtr.GetShop(id);
        }

        /// <summary>
        /// Return a list of all Shops
        /// </summary>
        /// <returns>
        /// List of Shop
        /// </returns>
        public List<Shop> GetAllShops()
        {
            return ShopCtr.GetAllShops();
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
            return ShopCtr.UpdateShop(shop);
        }

        /// <summary>
        /// Delete a Shop
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return 1 if Shop was deleted, else 0
        /// </returns>
        public int DeleteShop(int id)
        {
            return ShopCtr.DeleteShop(id);
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
    }
}
