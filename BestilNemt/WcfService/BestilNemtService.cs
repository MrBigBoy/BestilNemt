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
        public WarehouseCtr WarehouseController { get; set; }
        public LoginCtr LoginCtr { get; set; }
        public ShopCtr ShopCtr { get; set; }
        public CompanyCtr CompanyCtr { get; set; }
        public AdminCtr AdminCtr { get; set; }
        public BestilNemtService()
        {
            LoginCtr = new LoginCtr(new DbLogin());
            CustomerCtr = new CustomerCtr(new DbCustomer());
            WarehouseController = new WarehouseCtr(new DbWarehouse());
            ShopCtr = new ShopCtr(new DbShop());
            CompanyCtr = new CompanyCtr(new DbCompany1());
            AdminCtr = new AdminCtr(new DbAdmin());
        }

        public Customer FindCustomer(int id)
        {
            return CustomerCtr.FindCustomer(id);
        }

        public int CreateCustomer(Customer customer)
        {
            return CustomerCtr.CreatePerson(customer);
        }

        public List<Customer> GetALlCustomer()
        {
            return CustomerCtr.GetAllCustomer();
        }

        public void CreateAdmin(Admin admin)
        {
            AdminCtr.CreateAdmin(admin);
        }

        public Admin FindAdmin(int id)
        {
            return AdminCtr.FindAdmin(id);
        }

        public List<Admin> GetAllAdmins()
        {
            return AdminCtr.GetAllAdmins();
        }

        public int RemoveAdmin(int id)
        {
            return AdminCtr.RemoveAdmin(id);
        }

        public void UpdateAdmin(Admin admin)
        {
            AdminCtr.UpdateAdmin(admin);
        }

        public Warehouse GetWarehouse(int id)
        {
            return WarehouseController.Get(id);
        }

        public List<Warehouse> GetAllWarehouses()
        {
            return WarehouseController.GetAll();
        }

        public void RemoveWarehouse(int id)
        {
            WarehouseController.Remove(id);
        }

        public void AddWarehouse(Warehouse warehouse)
        {
            WarehouseController.Add(warehouse);
        }

        public void UpdateWarehouse(Warehouse warehouse)
        {
            WarehouseController.Update(warehouse);
        }

        public Login Login(Login login)
        {
            return LoginCtr.Login(login);
        }

        public int AddLogin(Login login)
        {
            return LoginCtr.AddLogin(login);
        }

        public int UpdateLogin(Login login)
        {
            return LoginCtr.UpdateLogin(login);
        }

        public int DelLogin(Login login)
        {
            return LoginCtr.DelLogin(login);
        }

        public Shop GetShop(int id)
        {
            return ShopCtr.GetShop(id);
        }

        public List<Shop> GetAllShops()
        {
            return ShopCtr.GetAllShops();
        }

        public int DeleteShop(int id)
        {
            return ShopCtr.DeleteShop(id);
        }

        public int AddShop(Shop shop)
        {
           return ShopCtr.AddShop(shop);
        }

        public int UpdateShop(Shop shop)
        {
            return ShopCtr.UpdateShop(shop);
        }

        public int RemoveCustomer(int id)
        {
           return CustomerCtr.RemoveCustomer(id);
        }

        public int UpdateCustomer(Customer customer)
        {
           return CustomerCtr.UpdateCustomer(customer); 
        }

        public void CreateCompany(Company company)
        {
            CompanyCtr.CreateCompany(company);
        }

        public List<Company> FindAllCompany()
        {
           return CompanyCtr.GetAllCompany();
        }

        public int RemoveCompany(int id)
        {
           return CompanyCtr.removeCompany(id);
        }

        public void UpdateCompany(Company company)
        {
          CompanyCtr.updateCompany(company);
        }

        public Company FindCompany(int id)
        {
           return CompanyCtr.findCompany(id);
        }
    }
}
