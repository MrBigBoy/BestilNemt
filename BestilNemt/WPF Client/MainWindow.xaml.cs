using System;
using System.Windows;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Controls;
using WPF_Client.BestilNemtWPF;
using System.Collections.Generic;


namespace WPF_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FillDataGridProducts();
            ReadProductWareHouse();
            FillDataGridShop();
            GetChainData();
        }

        private void FillDataGridProducts()
        {

            var CmdString = string.Empty;

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                CmdString = "Select productId, productName, productPrice,(productPrice-productPrice*savingPercent/100) as savingPrice, productDescription, productCategory, productImgPath, productSavingId, savingPercent, CONVERT(date, savingStartDate) as savingStartDate, CONVERT(date, savingEndDate) as savingEndDate from Product, Saving WHERE productSavingId = savingId;SELECT * FROM Saving;";
                SqlCommand cmd = new SqlCommand(CmdString, conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable("Produkter");
                sda.Fill(dt);
                ProductInformation.ItemsSource = dt.DefaultView;
            }
        }

        private void AddSaving_Click(object sender, RoutedEventArgs e)
        {
            createSaving();
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            BestilNemtWPF.BestilNemtServiceClient proxy = new BestilNemtWPF.BestilNemtServiceClient();
            var product = new BestilNemtWPF.Product();
            var saving = new BestilNemtWPF.Saving();
            product.Name = ProductName.Text;
            product.Price = Convert.ToDecimal(ProductPrice.Text);
            product.Category = ProductCategory.Text;
            product.Description = ProductDescription.Text;
            product.ImgPath = ProductImgPath.Text;
            proxy.AddProduct(product);
            FillDataGridProducts();
            MessageBox.Show("hello"); 
        }



        private void LoadDataIntoTextFields_Click(object sender, RoutedEventArgs e)
        {
            DataRowView drv = (DataRowView)ProductInformation.SelectedItem;
            ProductId.Text = (drv["productId"]).ToString();
            ProductName.Text = (drv["productName"]).ToString();
            ProductPrice.Text = (drv["productPrice"]).ToString();
            ProductCategory.Text = (drv["productCategory"]).ToString();
            ProductImgPath.Text = (drv["productImgPath"]).ToString();
            ProductDescription.Text = (drv["productDescription"]).ToString();
            SavingPercent.Text = (drv["savingPercent"]).ToString();
            StartDate.Text = (drv["savingStartDate"]).ToString();
            EndDate.Text = (drv["savingEndDate"]).ToString();
        }

        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            BestilNemtWPF.BestilNemtServiceClient proxy = new BestilNemtWPF.BestilNemtServiceClient();
            var id = Int32.Parse(ProductId.Text);
            proxy.DeleteProduct(id);
            FillDataGridProducts();
        }

        private void UpdateProduct_Click(object sender, RoutedEventArgs e)
        {
            BestilNemtWPF.BestilNemtServiceClient proxy = new BestilNemtWPF.BestilNemtServiceClient();
            var product = new Product();
            product.Id = Int32.Parse(ProductId.Text);
            product.Name = ProductName.Text;
            product.Price = decimal.Parse(ProductPrice.Text);
            product.Category = ProductCategory.Text;
            product.Description = ProductDescription.Text;
            product.ImgPath = ProductImgPath.Text;
            proxy.UpdateProduct(product);
            FillDataGridProducts();
        }
        public void createSaving()
        {
            BestilNemtWPF.BestilNemtServiceClient proxy = new BestilNemtWPF.BestilNemtServiceClient();
            var saving = new BestilNemtWPF.Saving();
            DateTime? startDate = StartDate.SelectedDate;
            DateTime? endDate = EndDate.SelectedDate;
            saving.StartDate = startDate.Value;
            saving.EndDate = endDate.Value;
            saving.SavingPercent = double.Parse(SavingPercent.Text);
            if (ProductId.Text == "")
            {
                MessageBox.Show("Du mangler at indlæse et product");
            }
            else
            {
                Product product = proxy.GetProduct(int.Parse(ProductId.Text));
                proxy.AddSaving(saving, product);
                saving.Id = product.SavingId.Value;
                FillDataGridProducts();
                MessageBox.Show("Du har lavet en rabet på" + product.Name);
            }
        }

        private void CreateRabat_Click(object sender, RoutedEventArgs e)
        {
            createSaving();
        }
        public void clearText()
        {
            ProductId.Text = "";
            ProductName.Text = "";
            ProductPrice.Text = "";
            ProductCategory.Text = "";
            ProductDescription.Text = "";
            ProductImgPath.Text = "";

        }

        private void ClearProductFields_Click(object sender, RoutedEventArgs e)
        {
            clearText();
        }

        private void RemoveSaving_Click(object sender, RoutedEventArgs e)
        {

        }
        public void ReadProductWareHouse()
        {
            var proxy = new BestilNemtServiceClient();

            var login3 = LoginManager.User;


            var shopIdAdmin = 0;
            if (login3 != null)
            {
                var id = login3.PersonId;
                var admin = proxy.GetAdmin(id);
                shopIdAdmin = admin.ShopId;
                var CmdString = string.Empty;
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
                {
                    conn.Open();
                    CmdString = "Select productId, warehouseId, productName, warehouseStock, wareHouseMinStock, administratorShopId  from Product, warehouse, Administrator WHERE warehouseProductId = productId AND warehouseShopId = @administratorShopId  ";
                    // SqlCommand cmd1 = new SqlCommand(CmdString, conn);


                    SqlCommand cmd = new SqlCommand(CmdString, conn);
                    cmd.Parameters.AddWithValue("administratorShopId", shopIdAdmin);


                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable("ProductWareHouse");
                    sda.Fill(dt);

                    ProductWarehouse.ItemsSource = dt.DefaultView;

                }
            }
            else
            {
                MessageBox.Show("n o login");
            }


        }
        public void updateAmount()
        {
            var proxy = new BestilNemtServiceClient();
            var CurrentUser = LoginManager.User;
            var id = CurrentUser.PersonId;
            var admin = proxy.GetAdmin(id);
            var shopIdAdmin = 0;
            //if (admin == null)
            //{
            //    MessageBox.Show("Du er ikke admin for en bestemt shop");
            //}
            if (ProductIdWareHouse.Text.Equals(""))
            {
                MessageBox.Show("Du har glemt at indlæs et produkt");
            }
            if (NewAmount1.Text.Equals(""))
            {
                MessageBox.Show("Du har glemt at tilføje et antal");
            }
            if (Convert.ToInt32(NewAmount1.Text) < Convert.ToInt32(MinAmount.Text))
            {
                MessageBox.Show("Nye Antal kan ikke være mindre min. Antal");
            }
            else
            {

                shopIdAdmin = admin.ShopId;
                Shop getShop = proxy.GetShop(shopIdAdmin);
                Warehouse warehouse = new Warehouse();
                var productID = Int32.Parse(ProductIdWareHouse.Text);

                var warehouses = proxy.GetAllWarehousesByShopId(getShop.Id);
                foreach (var w in warehouses)
                {
                    if (w.Product.Id == productID)
                    {
                        warehouse = w;
                    }
                }
                warehouse.Stock = Int32.Parse(NewAmount1.Text);
                warehouse.MinStock = Int32.Parse(MinAmount.Text);
                warehouse.Shop = getShop;     
                proxy.UpdateWarehouse(warehouse);
                ReadProductWareHouse();
                MessageBox.Show("Dit Antal er nu blevet opdateret");
            }

        }
        public void loadWarehouseProduct()
        {
            DataRowView drv = (DataRowView)ProductWarehouse.SelectedItem;
            ProductIdWareHouse.Text = (drv["productId"]).ToString();
            MinAmount.Text = (drv["wareHouseMinStock"]).ToString();
            NewAmount1.Text = (drv["warehouseStock"]).ToString();
            ProductName1.Text = (drv["productName"]).ToString();
            WareHouseId.Text = (drv["warehouseId"]).ToString();

        }

        private void ReadTable_Click(object sender, RoutedEventArgs e)
        {
            loadWarehouseProduct();
        }

        public void GetChainData()
        {
            var CmdString = string.Empty;

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                CmdString = "Select chainId, chainName From Chain";
                SqlCommand cmd = new SqlCommand(CmdString, conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable("Kæder");
                sda.Fill(dt);
                ChainList.ItemsSource = dt.DefaultView;
            }
        }

        public void FillDataGridShop()
        {
            var CmdString = string.Empty;

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                CmdString = "SELECT shopId, shopName, shopAddress, shopOpeningTime, shopChainId, chainName FROM Shop, Chain WHERE shopChainId = chainId";
                SqlCommand cmd = new SqlCommand(CmdString, conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable("Butikker");
                sda.Fill(dt);
                ShopList.ItemsSource = dt.DefaultView;
            }
        }

        private void AddChain_Click(object sender, RoutedEventArgs e)
        {
            var OpeningTimeRaw = ShopOpeningTimesField.Text;
            var NewOpeningTime = OpeningTimeRaw.Replace("\r\n", ";");
        }

        private void LoadChainIntoTextField_Click(object sender, RoutedEventArgs e)
        {
            DataRowView drv = (DataRowView)ProductWarehouse.SelectedItem;
            ShopIdField.Text = (drv["shopId"]).ToString();
            ShopNameField.Text = (drv["shopName"]).ToString();
            ShopAddressField.Text = (drv["shopAddress"]).ToString();
            ShopOpeningTimesField.Text = (drv["ShopOpeningTime"]).ToString();
            //ChainList.move = (drv["ShopChainId"]).ToString();
        }

        private void DeleteChain_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateChain_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddAmount_Click(object sender, RoutedEventArgs e)
        {
            updateAmount();
        }
        private void ClearWareHouseFields()
        {
            WareHouseId.Text = "";
            ProductIdWareHouse.Text = "";
            NewAmount1.Text = "";
            MinAmount.Text = "";
            ProductName1.Text = "";
        }

        private void ClearFiledsWarehouse_Click(object sender, RoutedEventArgs e)
        {
            ClearWareHouseFields();
        }
    }
}

