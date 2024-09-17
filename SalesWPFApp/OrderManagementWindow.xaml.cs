using Assignment1_PRN221_Library.Dto;
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
    /// Interaction logic for OrderManagementWindow.xaml
    /// </summary>
    public partial class OrderManagementWindow : Window
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IProductRepository _productRepository;
        public OrderManagementWindow(IMemberRepository memberRepository, IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository, IProductRepository productRepository)
        {
            InitializeComponent();
            _memberRepository = memberRepository;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _productRepository = productRepository;
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            LoadOrderList();
        }
        public void LoadOrderList()
        {
            try
            {
                var orderDetails = _orderDetailRepository.GetAllOrderDetails();
                lvOrderDetails.ItemsSource = orderDetails;
                List<Product> products =  (List<Product>)_productRepository.GetAllProducts();
                cmbProduct.ItemsSource = products;
                List<Member> Categories = (List<Member>)_memberRepository.GetAllMembers();
                cmbMember.ItemsSource = Categories;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load order list");
            }
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadOrderList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load order list");
            }
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtOrderId.Text))
                {
                    if (cmbMember.SelectedValue == null)
                    {
                        MessageBox.Show("Please select a member.", "Insert order");
                        return;
                    }

                    Order order = new Order
                    {
                        MemberId = Convert.ToInt32(cmbMember.SelectedValue),
                        OrderDate = dpOrderDate.SelectedDate.HasValue ? dpOrderDate.SelectedDate.Value : DateTime.Now,
                        RequiredDate = dpRequiredDate.SelectedDate.HasValue ? dpRequiredDate.SelectedDate.Value : DateTime.Now,
                        ShippedDate = dpShippedDate.SelectedDate.HasValue ? dpShippedDate.SelectedDate.Value : DateTime.Now,
                        Freight = long.Parse(txtFreight.Text),

                    };

                    _orderRepository.AddOrder(order);

                    int generatedOrderId = order.OrderId;
                    OrderDetail orderDetail = new OrderDetail
                    {
                        OrderId = generatedOrderId,
                        ProductId = Convert.ToInt32(cmbProduct.SelectedValue),
                        UnitPrice = long.Parse(txtUnitPrice.Text),
                        Quantity = int.Parse(txtQuantity.Text),
                        Discount = float.Parse(txtDiscount.Text),
                    };
                    _orderDetailRepository.AddOrderDetail(orderDetail);
                    LoadOrderList();
                    MessageBox.Show($"Inserted successfully", "Insert order");
                }
                else
                {
                    MessageBox.Show("Order Id already existed", "Insert order");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert order");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Order order = new Order
                {
                    OrderId = int.Parse(txtOrderId.Text),
                    MemberId = Convert.ToInt32(cmbMember.SelectedValue),
                    OrderDate = dpOrderDate.SelectedDate.HasValue ? dpOrderDate.SelectedDate.Value : DateTime.Now,
                    RequiredDate = dpRequiredDate.SelectedDate.HasValue ? dpRequiredDate.SelectedDate.Value : DateTime.Now,
                    ShippedDate = dpShippedDate.SelectedDate.HasValue ? dpShippedDate.SelectedDate.Value : DateTime.Now,
                    Freight = long.Parse(txtFreight.Text),
                };
                _orderRepository.UpdateOrder(order);
                OrderDetail orderDetail = new OrderDetail
                {
                    Id = int.Parse(txtOrderDetailId.Text),
                    OrderId = int.Parse(txtOrderId.Text),
                    ProductId = Convert.ToInt32(cmbProduct.SelectedValue),
                    UnitPrice = long.Parse(txtUnitPrice.Text),
                    Quantity = int.Parse(txtQuantity.Text),
                    Discount = float.Parse(txtDiscount.Text),
                };
                _orderDetailRepository.UpdateOrderDetail(orderDetail);
                LoadOrderList();
                MessageBox.Show($"Updated successfully", "Update order");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update order");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Order order = new Order
                {
                    OrderId = int.Parse(txtOrderId.Text),
                    MemberId = Convert.ToInt32(cmbMember.SelectedValue),
                    OrderDate = dpOrderDate.SelectedDate.HasValue ? dpOrderDate.SelectedDate.Value : DateTime.Now,
                    RequiredDate = dpRequiredDate.SelectedDate.HasValue ? dpRequiredDate.SelectedDate.Value : DateTime.Now,
                    ShippedDate = dpShippedDate.SelectedDate.HasValue ? dpShippedDate.SelectedDate.Value : DateTime.Now,
                    Freight = long.Parse(txtFreight.Text),
                };
                OrderDetail orderDetail = new OrderDetail
                {
                    Id = int.Parse(txtOrderDetailId.Text)
                };
 
                _orderDetailRepository.DeleteOrderDetail(orderDetail);
                _orderRepository.DeleteOrder(order);
                LoadOrderList();
                MessageBox.Show($"Deleted successfully", "Delete order");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete order");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtOrderId.Clear();
            dpOrderDate.SelectedDate = null;   
            dpRequiredDate.SelectedDate = null; 
            dpShippedDate.SelectedDate = null; 
            txtFreight.Clear();
            txtDiscount.Clear();
            txtOrderDetailId.Clear();
            txtQuantity.Clear();
            txtUnitPrice.Clear();
        }
    }
}
