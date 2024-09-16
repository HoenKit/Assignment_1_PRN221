using Assignment1_PRN221_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_PRN221_Library.IRepository
{
    public interface IProductRepository
    {
        public void AddProduct(Product product);
        public void UpdateProduct(Product product);
        public void DeleteProduct(Product product);
        public Product GetProduct(int id);
        public IEnumerable<Product> GetAllProducts();
    }
}
