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
    /// Interaction logic for MemberProfile.xaml
    /// </summary>
    public partial class MemberProfile : Window
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IOrderRepository _orderRepository;
        private Member _member;
        public MemberProfile(IMemberRepository memberRepository, Member member, IOrderRepository orderRepository)
        {
            InitializeComponent();
            _memberRepository = memberRepository;
            _member = member;
            _orderRepository = orderRepository;
            LoadMemberProfile();
        }

        private void LoadMemberProfile()
        {
            txtMemberId.Text = _member.MemberId.ToString();
            txtCompanyName.Text = _member.CompanyName;
            txtEmail.Text = _member.Email;
            txtCity.Text = _member.City;
            txtCountry.Text = _member.Country;
            txtPassword.Password = _member.Password;
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Member member = new Member
            {
                MemberId = int.Parse(txtMemberId.Text),
                CompanyName = txtCompanyName.Text,
                Email = txtEmail.Text,
                City = txtCity.Text,
                Country = txtCountry.Text,
                Password = txtPassword.Password,
            };
            _memberRepository.UpdateMember(member);
            MessageBox.Show("Member profile saved successfully!", "Save", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnOrderHistory_Click(object sender, RoutedEventArgs e)
        {
            int memberId = int.Parse(txtMemberId.Text);

            OrderHistoryWindow orderHistoryWindow = new OrderHistoryWindow(memberId, _orderRepository);
            orderHistoryWindow.Show();
        }
    }
}
