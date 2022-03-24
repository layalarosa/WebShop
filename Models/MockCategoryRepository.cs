using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> AllCategories =>
            new List<Category>
            {
                new Category{CategoryId=1, CategoryName="Accion", Description="Lorem"},
                new Category{CategoryId=2, CategoryName="Aventura", Description="Lorem"},
                new Category{CategoryId=3, CategoryName="Terror", Description="Lorem"}

            };
    }
}
