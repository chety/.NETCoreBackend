using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        private readonly List<Product> _products;

        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product
                {
                    ProductId = 1, CategoryId = 1, ProductName = "Bardak", UnitPrice = 15,UnitsInStock = 15
                },
                new Product
                {
                    ProductId = 2, CategoryId = 1, ProductName = "Kamera", UnitPrice = 500,UnitsInStock = 2
                },
                new Product
                {
                    ProductId = 3, CategoryId = 2, ProductName = "Telefon", UnitPrice = 1500,UnitsInStock = 8
                },
                new Product
                {
                    ProductId = 4, CategoryId = 2, ProductName = "Klavye", UnitPrice = 150,UnitsInStock = 65
                },
                new Product
                {
                    ProductId = 5, CategoryId = 2, ProductName = "Fare", UnitPrice = 85,UnitsInStock = 1
                },
            };
        }
        public void Add(Product product)
        {
            if (product is null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            _products.Add(product);
        }

        public void Delete(Product product)
        {
            var productToDelete = _products.Single(p => p.ProductId == product.ProductId);
            if (productToDelete is null)
            {
                throw new ArgumentException("Provided Product is not found", nameof(product));
            }
            _products.Remove(productToDelete);
            Console.WriteLine("Product deleted successfully");
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            return _products.SingleOrDefault(filter.Compile());
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> predicate)
        {
            return predicate is null ? _products : _products.Where(predicate.Compile()).ToList();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            var productToUpdate = _products.Single(p => p.ProductId == product.ProductId);
            if (productToUpdate is null)
            {
                throw new ArgumentException("Provided Product is not found", nameof(product));
            }
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
            Console.WriteLine("Product updated successfully");
        }
    }
}
