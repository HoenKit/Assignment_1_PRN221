using Assignment1_PRN221_Library.IRepository;
using Microsoft.Extensions.DependencyInjection;
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
    /// Interaction logic for ManagementWindow.xaml
    /// </summary>
    public partial class ManagementWindow : Window
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IServiceProvider _serviceProvider;
        public ManagementWindow(IServiceProvider serviceProvider, IMemberRepository memberRepository)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _memberRepository = memberRepository;
        }

        private void MemberButton_Click(object sender, RoutedEventArgs e)
        {
            var memberWindow = _serviceProvider.GetService<MemberManagementWindow>();
            memberWindow.Show();
        }
        private void ProductButton_Click(object sender, RoutedEventArgs e)
        {
            var productWindow = _serviceProvider.GetService<ProductManagementWindow>();
            productWindow.Show();
        }
        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            var orderWindow = _serviceProvider.GetService<OrderManagementWindow>();
            orderWindow.Show();
        }

        private void CategoryButton_Click (object sender, RoutedEventArgs e)
        {
            var categoryWindow = _serviceProvider.GetService<CategoryManagementWindow>();
            categoryWindow.Show();
        }
        private void btnClose_Click(object sender, RoutedEventArgs e) => Close();
    }
}
