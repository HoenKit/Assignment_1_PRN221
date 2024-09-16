using Assignment1_PRN221_Library.IRepository;
using Assignment1_PRN221_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_PRN221_Library.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;
        public CategoryRepository(DataContext context)
        {
            _context = context;
        }
        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void DeleteCategory(Category category)
        {
            var category1 = GetCategory(category.CategoryId);
            _context.Remove(category1);
            _context.SaveChanges();
        }

        public IEnumerable<Category> GetAllCategorys() => _context.Categories.ToList();

        public Category GetCategory(int id) => _context.Categories.Where(c => c.CategoryId == id).SingleOrDefault();

        public void UpdateCategory(Category category)
        {
            var category1 = GetCategory(category.CategoryId);
            category1.Name = category.Name;
            _context.Update(category1);
            _context.SaveChanges();
        }
    }
}
