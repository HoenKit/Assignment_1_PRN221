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
    /// Interaction logic for MemberManagementWindow.xaml
    /// </summary>
    public partial class MemberManagementWindow : Window
    {
        private readonly IMemberRepository _memberRepository;
        public MemberManagementWindow(IMemberRepository memberRepository)
        {
            InitializeComponent();
            _memberRepository = memberRepository;
            Loaded += OnLoaded;
        }
        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            LoadMemberList(); 
        }
        public void LoadMemberList()
        {
            try
            {
                lvMembers.ItemsSource = _memberRepository.GetAllMembers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load member list");
            }
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadMemberList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load member list");
            }
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMemberId.Text))
                {
                    if (_memberRepository.IsEmailExists(txtEmail.Text))
                    {
                        MessageBox.Show("Email already exists", "Insert member");
                        return;
                    }
                    Member member = new Member
                    {
                        CompanyName = txtCompanyName.Text,
                        Email = txtEmail.Text,
                        City = txtCity.Text,
                        Country = txtCountry.Text,
                        Password = txtPassword.Password,
                    };
                    _memberRepository.AddMember(member);
                    LoadMemberList();
                    MessageBox.Show($"{member.Email} inserted successfully", "Insert member");
                } else
                {
                    MessageBox.Show("Member Id already existed" ,"Insert member");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert member");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
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
                LoadMemberList();
                MessageBox.Show($"{member.Email} updated successfully", "Update member");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update member");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Member member = new Member
                {
                    MemberId = int.Parse(txtMemberId.Text)
                };
                _memberRepository.DeleteMember(member);
                LoadMemberList();
                MessageBox.Show($"{member.Email} deleted successfully ", "Delete member");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete member");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtMemberId.Clear();
            txtCompanyName.Clear();
            txtEmail.Clear();
            txtCity.Clear();
            txtCountry.Clear();
            txtPassword.Clear();

        }

    }
}
