using System.Collections.Generic;

namespace SportsStore.Models
{
    public class InMemoryProductRepository : IProductRepository
    {
        public IList<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product {Name = "Football", Price = 25},
                new Product {Name = "Surf board", Price = 179},
                new Product {Name = "Running shoes", Price = 95},

            };
        }
    }
}
