using Assignment1_PRN221_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_PRN221_Library.IRepository
{
    public interface ICategoryRepository
    {
        public void AddCategory(Category category);
        public void UpdateCategory(Category category);
        public void DeleteCategory(Category category);
        public Category GetCategory(int id);
        public IEnumerable<Category> GetAllCategorys();
    }
}
