using Assignment1_PRN221_Library.IRepository;
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
    /// Interaction logic for OrderHistoryWindow.xaml
    /// </summary>
    public partial class OrderHistoryWindow : Window
    {
        private int _memberId;
        private readonly IOrderRepository _orderRepository;
        public OrderHistoryWindow(int memberId, IOrderRepository orderRepository)
        {
            InitializeComponent();
            _memberId = memberId;
            _orderRepository = orderRepository;
            LoadOrderHistory();
        }

        private void LoadOrderHistory()
        {
            var orders = _orderRepository.GetOrdersByMemberId(_memberId);

            if (orders == null || !orders.Any())
            {
                MessageBox.Show("No orders found for this member.", "Order History");
                return;
            }

            lvOrderHistory.ItemsSource = orders;
        }
    }
}
