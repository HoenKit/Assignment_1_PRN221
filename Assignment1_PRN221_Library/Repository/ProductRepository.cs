using Assignment1_PRN221_Library.IRepository;
using Assignment1_PRN221_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_PRN221_Library.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        public ProductRepository( DataContext context)
        {
            _context = context;
        }
        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            var pr = GetProduct(product.ProductId);
            _context.Remove(pr);
            _context.SaveChanges();
        }

        public IEnumerable<Product> GetAllProducts() => _context.Products.ToList();

        public Product GetProduct(int id) => _context.Products.Where(p => p.ProductId == id).SingleOrDefault();

        public void UpdateProduct(Product product)
        {
            var pr = GetProduct(product.ProductId);
            pr.ProductName = product.ProductName;
            pr.CategoryId = product.CategoryId;
            pr.Weight = product.Weight;
            pr.UnitPrice = product.UnitPrice;
            pr.UnitInStock = product.UnitInStock;
            _context.Update(pr);
            _context.SaveChanges();
        }
    }
}
