using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_PRN221_Library.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public Category? Category { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string Weight { get; set; }
        public long UnitPrice { get; set; }
        public int UnitInStock { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
