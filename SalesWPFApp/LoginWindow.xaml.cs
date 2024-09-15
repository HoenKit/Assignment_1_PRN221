using Assignment1_PRN221_Library.IRepository;
using Microsoft.Extensions.Configuration;
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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IConfiguration _configuration;
        private readonly IServiceProvider _serviceProvider;
        private readonly IOrderRepository _orderRepository;
        public LoginWindow(IMemberRepository memberRepository, IConfiguration configuration, IServiceProvider serviceProvider, IOrderRepository orderRepository)
        {
            InitializeComponent();
            _memberRepository = memberRepository;
            _configuration = configuration;
            _serviceProvider = serviceProvider;
            _orderRepository = orderRepository;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;
            var member = _memberRepository.Login(username, password);
            if (username == _configuration["DefaultAccount:Email"] || password == _configuration["DefaultAccount:Password"])
            {
                MessageBox.Show("Admin Login successful!");

                var managementWindow = new ManagementWindow(_serviceProvider, _memberRepository);
                managementWindow.Show();

                this.Close();
            }
            else if ( member!= null)
            {
                MessageBox.Show("Login successful!");
                var profile = new MemberProfile(_memberRepository, member, _orderRepository);
                profile.Show();

                this.Close(); 
            }
            else
            {
                ErrorMessageTextBlock.Text = "Invalid username or password.";
            }
        }
    }
}
