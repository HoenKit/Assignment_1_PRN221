using Assignment1_PRN221_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_PRN221_Library.IRepository
{
    public interface IOrderRepository
    {
        public IEnumerable<Order> GetOrdersByMemberId(int memberId);
    }
}
