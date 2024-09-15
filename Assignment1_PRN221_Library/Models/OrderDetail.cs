using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_PRN221_Library.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public Order? Order { get; set; }
        public int OrderId { get; set; }
        public Product? Product { get; set; }
        public int ProductId { get; set; }
        public long UnitPrice { get; set; }
        public int Quantity { get; set; }
        public float Discount { get; set; }
    }
}
