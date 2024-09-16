using Assignment1_PRN221_Library.IRepository;
using Assignment1_PRN221_Library.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for ProductManagementWindow.xaml
    /// </summary>
    public partial class ProductManagementWindow : Window
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        public ProductManagementWindow( IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            InitializeComponent();
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            LoadProductList();
        }
        public void LoadProductList()
        {
            try
            {
                lvProduct.ItemsSource = _productRepository.GetAllProducts();
                List<Category> Categories = (List<Category>)_categoryRepository.GetAllCategorys();
                cmbCategory.ItemsSource = Categories;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load product list");
            }
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadProductList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load product list");
            }
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtProductId.Text))
                {
                    if (cmbCategory.SelectedValue == null)
                    {
                        MessageBox.Show("Please select a category.", "Insert product");
                        return;
                    }

                    Product product = new Product
                    {
                        ProductName = txtProductName.Text,
                        CategoryId = Convert.ToInt32(cmbCategory.SelectedValue),
                        Weight = txtWeight.Text,
                        UnitPrice = long.Parse(txtUnitPrice.Text),
                        UnitInStock = int.Parse(txtUnitStock.Text),
                    };

                    _productRepository.AddProduct(product);
                    LoadProductList();
                    MessageBox.Show($"{product.ProductName} inserted successfully", "Insert product");
                }
                else
                {
                    MessageBox.Show("Product Id already existed", "Insert product");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert product");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product product = new Product
                {
                    ProductId = int.Parse(txtProductId.Text),
                    ProductName = txtProductName.Text,
                    CategoryId = Convert.ToInt32(cmbCategory.SelectedValue),
                    Weight = txtWeight.Text,
                    UnitPrice = long.Parse(txtUnitPrice.Text),
                    UnitInStock = int.Parse(txtUnitStock.Text),
                };
                _productRepository.UpdateProduct(product);
                LoadProductList();
                MessageBox.Show($"{product.ProductName} updated successfully", "Update product");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update product");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product product = new Product
                {
                    ProductId = int.Parse(txtProductId.Text),
                    ProductName = txtProductName.Text,
                    Weight = txtWeight.Text,
                    UnitPrice = long.Parse(txtUnitPrice.Text),
                    UnitInStock = int.Parse(txtUnitStock.Text),
                };
                _productRepository.DeleteProduct(product);
                LoadProductList();
                MessageBox.Show($"{product.ProductName} deleted successfully ", "Delete product");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete product");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtProductId.Clear();
            txtProductName.Clear();
            txtUnitPrice.Clear();
            txtUnitStock.Clear();
            txtWeight.Clear();
        }
    }
}
