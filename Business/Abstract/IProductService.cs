using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll(Expression<Func<Product, bool>> filter = null);
        IDataResult<List<Product>> GetProductsByCategoryId(int categoryId);
        IDataResult<List<Product>> GetProductsByMinAndMaxPrice(decimal minPrice, decimal maxPrice);
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IDataResult<Product> GetById(int productId);
        IResult AddProduct(Product product);

    }
}
