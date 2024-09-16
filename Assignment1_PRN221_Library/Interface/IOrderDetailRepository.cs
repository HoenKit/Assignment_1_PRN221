using Assignment1_PRN221_Library.Dto;
using Assignment1_PRN221_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_PRN221_Library.IRepository
{
    public interface IOrderDetailRepository
    {
        public void AddOrderDetail(OrderDetail orderDetail);
        public void UpdateOrderDetail(OrderDetail orderDetail);
        public void DeleteOrderDetail(OrderDetail orderDetail);
        public OrderDetail GetOrderDetail(int id);
        public IEnumerable<OrderDetailDto> GetAllOrderDetails();
    }
}
