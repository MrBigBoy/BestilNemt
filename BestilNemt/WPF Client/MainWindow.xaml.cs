using System;
using System.Windows;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WPF_Client.BestilNemtWPF;

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
        }

        private void FillDataGridProducts()
        {

            var CmdString = string.Empty;
            Product product = null;
            Saving saving = null;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ConnectionString))
            {
                conn.Open();
                CmdString = "Select productId, productName, productPrice, productDescription, productCategory, productImgPath, productSavingId, savingPercent, savingStartDate, savingEndDate from Product, Saving WHERE productSavingId = savingId";
                SqlCommand cmd = new SqlCommand(CmdString, conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Produkter");
                //product.Price = Convert.ToDouble(product.Price) * saving.SavingPercent;
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
    }
}

