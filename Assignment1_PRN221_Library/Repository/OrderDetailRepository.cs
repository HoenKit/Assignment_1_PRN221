using Assignment1_PRN221_Library.Dto;
using Assignment1_PRN221_Library.IRepository;
using Assignment1_PRN221_Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_PRN221_Library.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly DataContext _context;
        public OrderDetailRepository(DataContext context)
        {
            _context = context;
        }
        public void AddOrderDetail(OrderDetail orderDetail)
        {
            _context.OrderDetails.Add(orderDetail);
            _context.SaveChanges();
        }

        public void DeleteOrderDetail(OrderDetail orderDetail)
        {
            var or = GetOrderDetail(orderDetail.Id);
            _context.OrderDetails.Remove(or);
            _context.SaveChanges();
        }

        public IEnumerable<OrderDetailDto> GetAllOrderDetails()
        {
            return _context.OrderDetails
                .Include(p => p.Product)
                .Include(o => o.Order) 
                .Select(od => new OrderDetailDto
                {
                    OrderDetailId = od.Id,
                    OrderId = od.Order.OrderId,
                    ProductId = od.Product.ProductId,
                    UnitPrice = (long)Math.Round((decimal)od.UnitPrice),
                    Quantity = od.Quantity,
                    Discount = od.Discount,
                    OrderDate = od.Order.OrderDate,
                    RequiredDate = od.Order.RequiredDate,
                    ShippedDate = od.Order.ShippedDate,
                    Freight = od.Order.Freight,
                    MemberId = od.Order.MemberId,
                })
                .ToList();
        }


        public OrderDetail GetOrderDetail(int id) => _context.OrderDetails.Include(o => o.Product).Where(o => o.Id == id).SingleOrDefault();

        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            var or = GetOrderDetail(orderDetail.Id);
            or.OrderId = orderDetail.OrderId;
            or.ProductId = orderDetail.ProductId;
            or.UnitPrice = orderDetail.UnitPrice;
            or.Discount = orderDetail.Discount;
            or.Quantity = orderDetail.Quantity;
            _context.Update(or);
            _context.SaveChanges();
        }
    }
}
