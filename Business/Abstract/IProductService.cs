using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetProductsByCategoryId(int categoryId);
        List<Product> GetProductsByMinAndMaxPrice(decimal minPrice, decimal maxPrice);
    }
}
