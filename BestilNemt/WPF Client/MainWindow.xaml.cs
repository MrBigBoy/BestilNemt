using System;
using System.Collections;
using System.Windows;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Controls;
using WPF_Client.BestilNemtWPF;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Input;


namespace WPF_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Initilize the main window and fill all the tables
        public MainWindow()
        {
            InitializeComponent();
            FillDataGridProducts();
            FillProductWareHouse();
            FillDataGridShop();
            GetChainData();
        }

        /// <summary>
        /// Fills the main table on the product page, this uses a SQL query to get the desired coloums
        /// </summary>
        private void FillDataGridProducts()
        {
            //Makes a empty string for use with the SQL command
            var CmdString = string.Empty;

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                //Open the connection and send the CmdString
                conn.Open();
                CmdString = "Select productId, productName, productPrice, productDescription, productCategory, productImgPath from Product";
                SqlCommand cmd = new SqlCommand(CmdString, conn);
                //Take the returned SQL and adapt it to a datatable
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Produkter");
                //Fill out the datatable 
                sda.Fill(dt);
                //Sets the datatable to correspond to the datatable in the GUI
                ProductInformation.ItemsSource = dt.DefaultView;
            }
        }

        /// <summary>
        /// Used to add a new product to the database when the add button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            //Call the service and create an empty product
            BestilNemtServiceClient proxy = new BestilNemtServiceClient();
            var product = new Product();
            //Set the textbox text to correspond to the product attributes
            product.Name = ProductName.Text;
            product.Price = Convert.ToDecimal(ProductPrice.Text);
            product.Category = ProductCategory.Text;
            product.Description = ProductDescription.Text;
            product.ImgPath = ProductImgPath.Text;
            //sends the filled attributes to the service and adds a product to the database 
            proxy.AddProduct(product);
            //Updates the product table
            FillDataGridProducts();
        }

        /// <summary>
        /// Used to load the selected item in the product datatable into the textfields
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadDataIntoTextFields_Click(object sender, RoutedEventArgs e)
        {
            //Select the current selected row
            DataRowView drv = (DataRowView)ProductInformation.SelectedItem;
            //Take the text in the coloums and puts them into the textfields
            ProductId.Text = (drv["productId"]).ToString();
            ProductName.Text = (drv["productName"]).ToString();
            ProductPrice.Text = (drv["productPrice"]).ToString();
            ProductCategory.Text = (drv["productCategory"]).ToString();
            //ProductImgPath.Text = (drv["productImgPath"]).ToString();
            //ProductDescription.Text = (drv["productDescription"]).ToString();
            //SavingPercent.Text = (drv["savingPercent"]).ToString();
            //StartDate.Text = (drv["savingStartDate"]).ToString();
            //EndDate.Text = (drv["savingEndDate"]).ToString();
        }

        /// <summary>
        /// Deletes the curret loaded product
        /// This requires you to have used the LoadDataIntoTextFields_Click
        /// to load the id into the field
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            BestilNemtServiceClient proxy = new BestilNemtServiceClient();
            //Parse the textfield from a string to an int
            var id = Int32.Parse(ProductId.Text);
            //Contact the WCF to delete the ID, that it got from the textfield
            proxy.DeleteProduct(id);
            //Updates the datatable
            FillDataGridProducts();
        }

        /// <summary>
        /// Used to update a product
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateProduct_Click(object sender, RoutedEventArgs e)
        {
            BestilNemtServiceClient proxy = new BestilNemtServiceClient();
            //Create an empty product
            var product = new Product();
            //Parse the textfield from a string to an int
            product.Id = Int32.Parse(ProductId.Text);
            //Gets the rest of the textfields and adds them to the local product
            product.Name = ProductName.Text;
            product.Price = decimal.Parse(ProductPrice.Text);
            product.Category = ProductCategory.Text;
            product.Description = ProductDescription.Text;
            product.ImgPath = ProductImgPath.Text;
            //Sends the local product with the ID to update the specific product
            proxy.UpdateProduct(product);
            //Updates the datatable
            FillDataGridProducts();
        }

        /// <summary>
        /// Button click use to call the createSaving method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddSaving_Click(object sender, RoutedEventArgs e)
        {
            createSaving();
        }

        /// <summary>
        /// Creates a saving for a product in the warehouse
        /// </summary>
        public void createSaving()
        {
            BestilNemtServiceClient proxy = new BestilNemtServiceClient();
            //Create a local saving object
            var saving = new Saving();
            //Takes the date selected and makes them a datetime, instead of strings
            DateTime? startDate = StartDate.SelectedDate;
            DateTime? endDate = EndDate.SelectedDate;
            //Sets the datetime to the local saving
            saving.StartDate = startDate.Value;
            saving.EndDate = endDate.Value;
            //Parses the textfield string to a doube to corresponnd to the database
            saving.SavingPercent = double.Parse(SavingPercent.Text);
            //Checks if the user has loaded in a product
            if (ProductId.Text == "")
            {
                MessageBox.Show("Du mangler at indlæse et product");
            }
            else
            {
                //Skriv kommentar når det her er rigtig ;)
                Product product = proxy.GetProduct(int.Parse(ProductId.Text));
                proxy.AddSaving(saving, product);
                //saving.Id = W.SavingId.Value;
                FillDataGridProducts();
                MessageBox.Show("Du har lavet en rabet på" + product.Name);
            }
        }

        /// <summary>
        /// This clears all the fields on the product page
        /// </summary>
        public void ClearProductTextField()
        {
            ProductId.Text = "";
            ProductName.Text = "";
            ProductPrice.Text = "";
            ProductCategory.Text = "";
            ProductDescription.Text = "";
            ProductImgPath.Text = "";

        }

        /// <summary>
        /// Button press action for the ClearProductTextField method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearProductFields_Click(object sender, RoutedEventArgs e)
        {
            ClearProductTextField();
        }

        private void RemoveSaving_Click(object sender, RoutedEventArgs e)
        {
            //?
        }

        /// <summary>
        /// Fills the warehouse datatable with data
        /// </summary>
        public void FillProductWareHouse()
        {
            var proxy = new BestilNemtServiceClient();
            //Creates a empty user, 
            var currentUser = LoginManager.User;
            //Sets the shopId To be 0
            var shopIdAdmin = 0;
            //If the user is loged in, then it will get all the details of the person
            if (currentUser != null)
            {
                var id = currentUser.PersonId;
                var admin = proxy.GetAdmin(id);
                shopIdAdmin = admin.ShopId;
                var CmdString = string.Empty;
                //SQL used to get the warehouses that belong to the shop where the admin is
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
                {
                    //Opens the connection and runs the querey
                    conn.Open();
                    CmdString = "Select productId, warehouseId, productName, productPrice,(productPrice-productPrice*savingPercent/100) as savingPrice, warehouseStock, wareHouseMinStock, administratorShopId, warehouseSavingId, savingPercent  from Product, warehouse, Administrator, saving WHERE warehouseProductId = productId AND warehouseShopId = @administratorShopId AND warehouseSavingId = savingId";
                    //Sends the qurey and adds the missing parameter
                    SqlCommand cmd = new SqlCommand(CmdString, conn);
                    cmd.Parameters.AddWithValue("administratorShopId", shopIdAdmin);
                    //Takes what the SQL return and adapts it so it can be used in a datatabel
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable("ProductWareHouse");
                    //fills the datatabek
                    sda.Fill(dt);
                    ProductWarehouse.ItemsSource = dt.DefaultView;
                }
            }
            else
            {
                MessageBox.Show("Du er ikke logget ind, hvordan åbenede du det her vindue?");
            }
        }
        
        /// <summary>
        /// Updates the amount on a product in a warehouse
        /// </summary>
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
                FillProductWareHouse();
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

        //Used to update the tabel of the warehouse tab
        private void ReadTable_Click(object sender, RoutedEventArgs e)
        {
            loadWarehouseProduct();
        }

        /// <summary>
        /// Used to get the desired data of a chain, this is used so you can select it in a datatabel
        /// </summary>
        public void GetChainData()
        {
            //Sets a empty string used for SQL
            var CmdString = string.Empty;

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                //Opens the connetion and sets the qurey to the cmdstring
                conn.Open();
                CmdString = "Select chainId, chainName From Chain";
                SqlCommand cmd = new SqlCommand(CmdString, conn);
                //Adapts the data that the SQL returnns
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //Makes a new table
                DataTable dt = new DataTable("Kæder");
                //Fills the tabel
                sda.Fill(dt);
                ChainList.ItemsSource = dt.DefaultView;
            }
        }
        /// <summary>
        /// Get the data used to fill the DataGrid in the Butik tab, this is done with a custom SQL qurey that gets all the colums that we need
        /// </summary>
        public void FillDataGridShop()
        {
            //Sets a empty string used for SQL
            var CmdString = string.Empty;

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                //Opens the connetion and sets the qurey to the cmdstring
                conn.Open();
                CmdString = "SELECT shopId, shopName, shopAddress, shopCVR, shopOpeningTime, shopChainId, chainName FROM Shop, Chain WHERE shopChainId = chainId";
                //Adapts the data that the SQL returnns
                SqlCommand cmd = new SqlCommand(CmdString, conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //Makes a new table
                DataTable dt = new DataTable("Butikker");
                //Fills the tabel
                sda.Fill(dt);
                ShopList.ItemsSource = dt.DefaultView;
            }
        }
        /// <summary>
        /// Gets all the text from the textfields and datatable, and sends that to the WCF that creates a new Shop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddShop_Click(object sender, RoutedEventArgs e)
        {
            BestilNemtServiceClient proxy = new BestilNemtServiceClient();
            DataRowView drv = (DataRowView)ChainList.SelectedItem;
            var shop = new Shop();
            //Get the chain id form the ChainDataTable, and get the chain from the prooxy
            shop.Chain = proxy.GetChain(int.Parse(drv["chainId"].ToString()));
            shop.Name = ShopNameField.Text;
            shop.Address = ShopAddressField.Text;
            shop.Cvr = ShopCVRField.Text;
            //Replace the the new lines with semicolons because of the database
            var OpeningTimeRaw = ShopOpeningTimesField.Text;
            var NewOpeningTime = OpeningTimeRaw.Replace("\r\n", ";");
            shop.OpeningTime = NewOpeningTime;
            shop.Warehouses = new List<Warehouse>().ToArray();
            proxy.AddShop(shop);
            FillDataGridShop();
        }

        /// <summary>
        /// Loads the selected item into the textfields
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadShopIntoTextField_Click(object sender, RoutedEventArgs e)
        {
            DataRowView drv = (DataRowView)ShopList.SelectedItem;
            ShopIdField.Text = (drv["shopId"]).ToString();
            ShopNameField.Text = (drv["shopName"]).ToString();
            ShopAddressField.Text = (drv["shopAddress"]).ToString();
            ShopCVRField.Text = (drv["shopCVR"]).ToString();
            //Replace the semicolons with new lines because of the database
            var OpeningTimeRaw = (drv["ShopOpeningTime"]).ToString();
            var NewOpeningTime = OpeningTimeRaw.Replace(";", "\r\n");
            ShopOpeningTimesField.Text = NewOpeningTime;
            var chainId = (drv["ShopChainId"]).ToString();
            ShopList_SelectionChanged();
            ChainList.FindName(chainId);
        }
        /// <summary>
        /// Delete the selected shop in the datatable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteShop_Click(object sender, RoutedEventArgs e)
        {
            BestilNemtServiceClient proxy = new BestilNemtServiceClient();
            var ShopId = ShopIdField.Text;
            proxy.DeleteShop(Int32.Parse(ShopId));
            FillDataGridShop();
        }
        /// <summary>
        /// Updates the shop with the data inputed in the textfields
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateShop_Click(object sender, RoutedEventArgs e)
        {
            //Sets the proxy
            BestilNemtServiceClient proxy = new BestilNemtServiceClient();
            //Gets the selected item in the datatable
            DataRowView drv = (DataRowView)ChainList.SelectedItem;
            //create empty table
            var shop = new Shop();
            //Get id from text field
            shop.Id = Int32.Parse(ShopIdField.Text);
            //Get chainId from ChainTable
            shop.Chain = proxy.GetChain(int.Parse(drv["chainId"].ToString()));
            //Get name address and CVR from the other text fields
            shop.Name = ShopNameField.Text;
            shop.Address = ShopAddressField.Text;
            shop.Cvr = ShopCVRField.Text;
            //Gets the opening time form the textfield and sets it as a var
            var OpeningTimeRaw = ShopOpeningTimesField.Text;
            //Replaces the new lines with semicolons because of the databse
            var NewOpeningTime = OpeningTimeRaw.Replace("\r\n", ";");
            //sets the opening time
            shop.OpeningTime = NewOpeningTime;
            //Updates empty warehouse for the shop
            shop.Warehouses = new List<Warehouse>().ToArray();
            //Sends the new shop for the update with the shopId
            proxy.UpdateShop(shop);
            //Update the datatabel
            FillDataGridShop();
        }

        private void AddAmount_Click(object sender, RoutedEventArgs e)
        {
            updateAmount();
        }

        /// <summary>
        /// Clears the textfields in the warehouse tab
        /// </summary>
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
        public void AddProductToWarehouse()
        {
            var proxy = new BestilNemtServiceClient();
            var CurrentUser = LoginManager.User;
            var id = CurrentUser.PersonId;
            var admin = proxy.GetAdmin(id);
            var shopIdAdmin = 0;

            shopIdAdmin = admin.ShopId;

            shopIdAdmin = admin.ShopId;
            Shop getShop = proxy.GetShop(shopIdAdmin);
            Warehouse warehouse = new Warehouse();
            var productID = Int32.Parse(ProductId.Text);

            var warehouses = proxy.GetAllWarehousesByShopId(getShop.Id);
            foreach (var w in warehouses)
            {
                if (w.Product.Id == productID)
                {
                    warehouse = w;
                }
            }

            // var warehouses = proxy.GetAllWarehousesByShopId(getShop.Id);
            // warehouse.Id =
            warehouse.MinStock = Int32.Parse(minStock.Text);
            warehouse.Stock = Int32.Parse(Stock.Text);
            //    warehouse.Product.Id = Int32.Parse(ProductId.Text);
            warehouse.Shop = getShop;
            warehouse.SavingId = null;

            proxy.AddWarehouse(warehouse);
        }

        private void ShopList_SelectionChanged()
        {
            var drvShopView = (DataRowView)ShopList.SelectedItem;
            string chainId = null;
            if (drvShopView != null)
                chainId = drvShopView[5].ToString();

            for (var i = 0; i < ChainList.Items.Count; i++)
            {
                var row = (DataGridRow)ChainList.ItemContainerGenerator.ContainerFromIndex(i);
                var cellContent = ChainList.Columns[0].GetCellContent(row) as TextBlock;
                if (cellContent != null && cellContent.Text.Equals(chainId))
                {
                    var item = ChainList.Items[i];
                    ChainList.SelectedItem = item;
                    ChainList.ScrollIntoView(item);
                    row.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                    break;
                }
            }
        }

        private void AddToWarehouse_Click(object sender, RoutedEventArgs e)
        {
            AddProductToWarehouse();
            FillProductWareHouse();
        }
    }
}
