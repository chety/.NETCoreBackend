using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            using (var context = new NorthwindContext())
            {
                var addedProduct = context.Entry(entity);
                addedProduct.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Product entity)
        {
            using (var context = new NorthwindContext())
            {
                var deletedProduct = context.Entry(entity);
                deletedProduct.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (var context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (var context = new NorthwindContext())
            {
                return filter is null ?
                        context.Set<Product>().ToList()
                        : context.Set<Product>().Where(filter).ToList();

            }
        }

        public void Update(Product entity)
        {
            using (var context = new NorthwindContext())
            {
                var updatedProduct = context.Entry(entity);
                updatedProduct.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
