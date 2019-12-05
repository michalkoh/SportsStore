using System.Collections.Generic;

namespace SportsStore.Models
{
    public interface IProductRepository
    {
        IList<Product> GetProducts();
    }
}