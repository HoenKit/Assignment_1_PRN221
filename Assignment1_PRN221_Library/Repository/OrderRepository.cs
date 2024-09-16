using Assignment1_PRN221_Library.IRepository;
using Assignment1_PRN221_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_PRN221_Library.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;
        public OrderRepository(DataContext context)
        {
            _context = context;
        }

        public void AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void DeleteOrder(Order order)
        {
            var or = GetOrder(order.OrderId);
            _context.Remove(or);
            _context.SaveChanges();
        }

        public IEnumerable<Order> GetAllOrders() => _context.Orders.ToList();

        public Order GetOrder(int id) => _context.Orders.Where(o => o.OrderId == id).SingleOrDefault();

        public IEnumerable<Order> GetOrdersByMemberId(int memberId) => _context.Orders.Where(o => o.MemberId == memberId).ToList();

        public void UpdateOrder(Order order)
        {
            var or = GetOrder(order.OrderId);
            or.MemberId = order.MemberId;
            or.OrderDate = order.OrderDate;
            or.RequiredDate = order.RequiredDate;
            or.ShippedDate = order.ShippedDate;
            or.Freight = order.Freight;
            _context.Update(or);
            _context.SaveChanges();
        }
    }
}
