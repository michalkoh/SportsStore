using System;
using System.Collections.Generic;
using System.Linq;

namespace SportsStore.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly Func<ApplicationDbContext> createContext;

        public ProductRepository(Func<ApplicationDbContext> createContext)
        {
            this.createContext = createContext;
        }

        public IList<Product> GetProducts()
        {
            using (var context = this.createContext())
            {
                var list = context.Products.ToList();
                return list;
            }
        }
    }
}
