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
                new Category{CategoryId=1, CategoryName="Accion", Description="Lorem Ipsum"},
                new Category{CategoryId=2, CategoryName="Action-Aventura", Description="Lorem Ipsum"},
                new Category{CategoryId=3, CategoryName="Action-Terror", Description="Lorem Ipsum"}

            };
    }
}
