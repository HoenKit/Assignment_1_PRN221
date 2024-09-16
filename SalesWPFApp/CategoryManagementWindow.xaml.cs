using Assignment1_PRN221_Library.IRepository;
using Assignment1_PRN221_Library.Models;
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

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for CategoryManagementWindow.xaml
    /// </summary>
    public partial class CategoryManagementWindow : Window
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryManagementWindow( ICategoryRepository categoryRepository)
        {
            InitializeComponent();
            _categoryRepository = categoryRepository;
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            LoadCategoryList();
        }
        public void LoadCategoryList()
        {
            try
            {
                lvCategory.ItemsSource = _categoryRepository.GetAllCategorys();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load category list");
            }
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadCategoryList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load category list");
            }
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCategoryId.Text))
                {
                    Category category = new Category
                    {
                        Name = txtName.Text,
                    };
                    _categoryRepository.AddCategory(category);
                    LoadCategoryList();
                    MessageBox.Show($"{category.Name} inserted successfully", "Insert category");
                }
                else
                {
                    MessageBox.Show("Category Id already existed", "Insert category");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert category");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Category category = new Category
                {
                    CategoryId = int.Parse(txtCategoryId.Text),
                    Name = txtName.Text,
                };
                _categoryRepository.UpdateCategory(category);
                LoadCategoryList();
                MessageBox.Show($"{category.Name} updated successfully", "Update category");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update category");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Category category = new Category
                {
                    CategoryId = int.Parse(txtCategoryId.Text),
                    Name = txtName.Text,
                };
                _categoryRepository.DeleteCategory(category);
                LoadCategoryList();
                MessageBox.Show($"{category.Name} deleted successfully ", "Delete category");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete category");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtCategoryId.Clear();
            txtName.Clear();
        }
    }
}
