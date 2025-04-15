using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Task7.Model;

namespace Task7
{
    public partial class MainWindow : Window
    {
        ProductDbContext context;
        Product NewProduct = new Product();
        Product selectedProduct = new Product();
        public MainWindow()
        {
            InitializeComponent();
        }
        public MainWindow(ProductDbContext context)
        {
            InitializeComponent();
            this.context = context;
            InitializeComponent();
            GetProducts();
            NewProductGrid.DataContext = NewProduct;
        }

        private void GetProducts()
        {
            ProductDG.ItemsSource = context.Products.ToList();
        }
        

        private void BtnSelectProductToEdit_Click(object sender, RoutedEventArgs e)
        {
            selectedProduct = (sender as FrameworkElement).DataContext as Product;
            UpdateProductGrid.DataContext = selectedProduct;
        }

        private void BtnEditItem_Click(object sender, RoutedEventArgs e)
        {
            context.Update(selectedProduct);
            context.SaveChanges();
            GetProducts();
        }

        private void BtnDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            var productToDelete = (sender as FrameworkElement).DataContext as Product;
            context.Products.Remove(productToDelete);
            context.SaveChanges();
            GetProducts();
        }

        private void BtnAddItem_Click(object sender, RoutedEventArgs e)
        {
            context.Products.Add(NewProduct);
            context.SaveChanges();
            GetProducts();
            NewProduct = new Product();
            NewProductGrid.DataContext = NewProduct;
        }
    }
}