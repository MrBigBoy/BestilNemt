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
using System.ServiceModel.Channels;
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
            var proxy = new BestilNemtServiceClient();
            //Get data table with products info from wcf
            var dt = proxy.GetDataGridProducts();
            //Sets the datatable to correspond to the datatable in the GUI
            ProductInformation.ItemsSource = dt.DefaultView;
        }

        /// <summary>
        /// Used to add a new product to the database when the add button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            //Call the service and create an empty product
            var proxy = new BestilNemtServiceClient();
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
            ClearProductTextField();
        }

        /// <summary>
        /// Used to load the selected item in the product datatable into the textfields
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadDataIntoTextFields_Click(object sender, RoutedEventArgs e)
        {
            //Select the current selected row
            var drv = (DataRowView)ProductInformation.SelectedItem;
            //Take the text in the coloums and puts them into the textfields
            ProductId.Text = (drv["productId"]).ToString();
            ProductName.Text = (drv["productName"]).ToString();
            ProductPrice.Text = (drv["productPrice"]).ToString();
            ProductDescription.Text = (drv["productDescription"]).ToString();
            ProductCategory.Text = (drv["productCategory"]).ToString();
            ProductImgPath.Text = (drv["ProductImgPath"]).ToString();
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
            var proxy = new BestilNemtServiceClient();
            //Parse the textfield from a string to an int
            var id = int.Parse(ProductId.Text);
            //Contact the WCF to delete the ID, that it got from the textfield
            proxy.DeleteProduct(id);
            //Updates the datatable
            FillDataGridProducts();
            ClearProductTextField();
        }

        /// <summary>
        /// Used to update a product
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateProduct_Click(object sender, RoutedEventArgs e)
        {
            var proxy = new BestilNemtServiceClient();
            //Create an empty product
            var product = new Product();
            //Parse the textfield from a string to an int
            product.Id = int.Parse(ProductId.Text);
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
            ClearProductTextField();
        }

        /// <summary>
        /// Button click use to call the createSaving method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddSaving_Click(object sender, RoutedEventArgs e)
        {
            CreateSaving();
            ClearWareHouseFields();
        }

        /// <summary>
        /// Creates a saving for a product in the warehouse
        /// </summary>
        public void CreateSaving()
        {
            var proxy = new BestilNemtServiceClient();
            //gets the current admin 
            var currentUser = LoginManager.User;
            var id = currentUser.PersonId;
            //Get admin 
            var admin = proxy.GetAdmin(id);
            //Finds the login shop
            var shop = proxy.GetShop(admin.ShopId);
            //Create a local saving object
            var saving = new Saving();
            var warehouse = proxy.GetWarehouse(int.Parse(WarehouseIdField.Text));
            //Takes the date selected and makes them a datetime, instead of strings
            DateTime? startDate = StartDate.SelectedDate;
            DateTime? endDate = EndDate.SelectedDate;
            //Sets the datetime to the local saving
            saving.StartDate = startDate.Value;
            saving.EndDate = endDate.Value;
            //Parses the textfield string to a doube to corresponnd to the database
            saving.SavingPercent = double.Parse(SavingPercent.Text);
            //Checks if the user has loaded in a product
            if (WarehouseIdField.Text == "")
            {
                MessageBox.Show("Du mangler at indlæse fra tabellen ");
            }
            else
            {
                saving.Id = warehouse.SavingId.Value;
                //Adding saving with a warehouse
                proxy.AddSaving(saving, warehouse);
                //Setting savingId equals to warehouseId

                //Reloading the tabel agin 
                FillProductWareHouse();
                MessageBox.Show("Du har lavet en rabet på " + ProductName1.Text + " i " + shop.Name);
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
            var proxy = new BestilNemtServiceClient();
            //take the id from the loaded product and saving
            var id = int.Parse(SavingIdField.Text);
            //send the id to the proxy, so the saving can be deleted
            proxy.DeleteSaving(id);
            ClearWareHouseFields();
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
            //If the user is loged in, then it will get all the details of the person
            if (currentUser != null)
            {
                var id = currentUser.PersonId;
                var admin = proxy.GetAdmin(id);
                var shopIdAdmin = admin.ShopId;
                var dt = proxy.GetProductWareHouse(shopIdAdmin);
                //Sets the datatable to correspond to the datatable in the GUI
                ProductWarehouse.ItemsSource = dt.DefaultView;
            }
            else
            {
                MessageBox.Show("Du er ikke logget ind, hvordan åbenede du det her vindue?");
            }
        }

        /// <summary>
        /// Updates the amount on a product in a warehouse
        /// </summary>
        public void UpdateAmount()
        {
            var proxy = new BestilNemtServiceClient();
            //getting the current User 
            var currentUser = LoginManager.User;
            //Finds his PersonID 
            var id = currentUser.PersonId;
            //With id we find the admin, and all admin has shopID
            var admin = proxy.GetAdmin(id);
            //Checks for value input
            if (admin.Id == 0)
            {
                MessageBox.Show("Du er ikke admin for en bestemt shop");
            }
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

                var shopIdAdmin = admin.ShopId;
                //we find the shop for the currentuser/admin
                var getShop = proxy.GetShop(shopIdAdmin);
                //Make a new instance of warehouse 
                var warehouse = new Warehouse();
                //Get the productID 
                var productId = int.Parse(ProductIdWareHouse.Text);
                //GetAllWarehousebyShopid() is a list, so we make a foreach loop, and find the corret warehouse =
                //with right productID
                var warehouses = proxy.GetAllWarehousesByShopId(getShop.Id);
                foreach (var w in warehouses)
                {
                    if (w.Product.Id == productId)
                    {
                        warehouse = w;
                    }
                }
                //sets value for textbox
                warehouse.Stock = int.Parse(NewAmount1.Text);
                warehouse.MinStock = int.Parse(MinAmount.Text);
                warehouse.Shop = getShop;
                //we update warehouse with a new amount
                proxy.UpdateWarehouse(warehouse);
                FillProductWareHouse();
                MessageBox.Show("Dit Antal er nu blevet opdateret");
            }
        }
        //loading tabel into the fields
        public void LoadWarehouseProduct()
        {
            DataRowView drv = (DataRowView)ProductWarehouse.SelectedItem;
            ProductIdWareHouse.Text = (drv["productId"]).ToString();
            MinAmount.Text = (drv["wareHouseMinStock"]).ToString();
            NewAmount1.Text = (drv["warehouseStock"]).ToString();
            ProductName1.Text = (drv["productName"]).ToString();
            WarehouseIdField.Text = (drv["warehouseId"]).ToString();
            SavingPercent.Text = (drv["savingPercent"]).ToString();
            SavingIdField.Text = (drv["warehouseSavingId"]).ToString();
            StartDate.Text = (drv["savingStartDate"]).ToString();
            EndDate.Text = (drv["savingEndDate"]).ToString();
        }

        //Used to update the tabel of the warehouse tab
        private void ReadTable_Click(object sender, RoutedEventArgs e)
        {
            LoadWarehouseProduct();
        }

        /// <summary>
        /// Used to get the desired data of a chain, this is used so you can select it in a datatabel
        /// </summary>
        public void GetChainData()
        {
            var proxy = new BestilNemtServiceClient();
            //Get the list of chains from database via wcf
            var dt = proxy.GetChainData();
            //Sets the datatable to correspond to the datatable in the GUI
            ChainList.ItemsSource = dt.DefaultView;
        }
        /// <summary>
        /// Get the data used to fill the DataGrid in the Butik tab, this is done with a custom SQL qurey that gets all the colums that we need
        /// </summary>
        public void FillDataGridShop()
        {
            var proxy = new BestilNemtServiceClient();
            //Get the list of shops from database via wcf
            var dt = proxy.GetDataGridShop();
            //Sets the datatable to correspond to the datatable in the GUI
            ShopList.ItemsSource = dt.DefaultView;
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
            var openingTimeRaw = ShopOpeningTimesField.Text;
            var newOpeningTime = openingTimeRaw.Replace("\r\n", ";");
            shop.OpeningTime = newOpeningTime;
            shop.Warehouses = new List<Warehouse>().ToArray();
            proxy.AddShop(shop);
            FillDataGridShop();
            ClearAllShopTextFields();
        }

        /// <summary>
        /// Loads the selected item into the textfields
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadShopIntoTextField_Click(object sender, RoutedEventArgs e)
        {
            var drv = (DataRowView)ShopList.SelectedItem;
            ShopIdField.Text = (drv["shopId"]).ToString();
            ShopNameField.Text = (drv["shopName"]).ToString();
            ShopAddressField.Text = (drv["shopAddress"]).ToString();
            ShopCVRField.Text = (drv["shopCVR"]).ToString();
            //Replace the semicolons with new lines because of the database
            var openingTimeRaw = (drv["ShopOpeningTime"]).ToString();
            var newOpeningTime = openingTimeRaw.Replace(";", "\r\n");
            ShopOpeningTimesField.Text = newOpeningTime;
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
            var shopId = ShopIdField.Text;
            proxy.DeleteShop(int.Parse(shopId));
            FillDataGridShop();
            ClearAllShopTextFields();
        }
        /// <summary>
        /// Updates the shop with the data inputed in the textfields
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateShop_Click(object sender, RoutedEventArgs e)
        {
            //Sets the proxy
            var proxy = new BestilNemtServiceClient();
            //Gets the selected item in the datatable
            var drv = (DataRowView)ChainList.SelectedItem;
            //create empty table
            var shop = new Shop();
            //Get id from text field
            shop.Id = int.Parse(ShopIdField.Text);
            //Get chainId from ChainTable
            shop.Chain = proxy.GetChain(int.Parse(drv["chainId"].ToString()));
            //Get name address and CVR from the other text fields
            shop.Name = ShopNameField.Text;
            shop.Address = ShopAddressField.Text;
            shop.Cvr = ShopCVRField.Text;
            //Gets the opening time form the textfield and sets it as a var
            var openingTimeRaw = ShopOpeningTimesField.Text;
            //Replaces the new lines with semicolons because of the databse
            var newOpeningTime = openingTimeRaw.Replace("\r\n", ";");
            //sets the opening time
            shop.OpeningTime = newOpeningTime;
            //Updates empty warehouse for the shop
            shop.Warehouses = new List<Warehouse>().ToArray();
            //Sends the new shop for the update with the shopId
            proxy.UpdateShop(shop);
            //Update the datatabel
            FillDataGridShop();
            ClearAllShopTextFields();
        }

        private void UpdateAmount_Click(object sender, RoutedEventArgs e)
        {
            UpdateAmount();
            ClearWareHouseFields();
            FillProductWareHouse();
        }

        /// <summary>
        /// Clears the textfields in the warehouse tab
        /// </summary>
        private void ClearWareHouseFields()
        {
            WarehouseIdField.Text = "";
            ProductIdWareHouse.Text = "";
            NewAmount1.Text = "";
            MinAmount.Text = "";
            ProductName1.Text = "";
            FillDataGridProducts();
        }

        private void ClearFiledsWarehouse_Click(object sender, RoutedEventArgs e)
        {
            ClearWareHouseFields();
        }
        /// <summary>
        /// Find an product, and then adding a new warehouse
        /// </summary>
        public void AddProductToWarehouse()
        {
            var proxy = new BestilNemtServiceClient();
            //Finds the currentuser, by using our static class
            var currentUser = LoginManager.User;
            var id = currentUser.PersonId;
            //finds the corret admin
            var admin = proxy.GetAdmin(id);
            var shopIdAdmin = 0;
            shopIdAdmin = admin.ShopId;
            //finds the shop through admin
            Shop getShop = proxy.GetShop(shopIdAdmin);
            Warehouse warehouse = new Warehouse();
            var productId = int.Parse(ProductId.Text);
            //Getting all warehouse with a shopID, and loop through it 
            var warehouses = proxy.GetAllWarehousesByShopId(getShop.Id);
            foreach (var w in warehouses)
            {
                if (w.Product.Id == productId)
                {
                    warehouse = w;
                }
            }
            //sets value in the textboxes
            warehouse.MinStock = int.Parse(minStock.Text);
            warehouse.Stock = int.Parse(Stock.Text);
            warehouse.Shop = getShop;
            warehouse.SavingId = null;
            warehouse.Product = proxy.GetProduct(productId);
            var warehouseId = proxy.AddWarehouse(warehouse);
            //If the warehouse couldn't be created, it shows a message telling the user
            //If the warehouse is create, then the user gets a message telling it succeced
            if (warehouseId == 0)
            {
                MessageBox.Show("Varehus findes allerede, opret et ny produkt");
            }
            else
            {
                MessageBox.Show("Produktet er tilføjet til dit varehus");
            }
        }
        /// <summary>
        /// Find the selected chain with a shop.
        /// </summary>

        private void ShopList_SelectionChanged()
        {
            //SelecttedRow in tabel 
            var drvShopView = (DataRowView)ShopList.SelectedItem;
            string chainId = null;
            //Checks for the tabel isnt empty 
            if (drvShopView != null)
                chainId = drvShopView[5].ToString();
            //Runs a for loop for all chains 
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

        private void UpdataTable_Click(object sender, RoutedEventArgs e)
        {
            FillProductWareHouse();
        }

        private void RemoveWarehouseBtn_Click(object sender, RoutedEventArgs e)
        {
            BestilNemtServiceClient proxy = new BestilNemtServiceClient();
            var wId = WarehouseIdField.Text;
            proxy.DeleteWarehouse(int.Parse(wId));
            FillProductWareHouse();
        }

        private void ClearAllShopFields_Click(object sender, RoutedEventArgs e)
        {
            ClearAllShopTextFields();
        }

        private void ClearAllShopTextFields()
        {
            ShopIdField.Text = "";
            ShopAddressField.Text = "";
            ShopCVRField.Text = "";
            ShopNameField.Text = "";
            ShopOpeningTimesField.Text = "";
        }
    }
}