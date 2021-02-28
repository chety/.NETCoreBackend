using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult AddProduct(Product product)
        {
            //instead of below line, we use ValidationAspect
            //ValidationTool.Validate(new ProductValidator(), product);

            var checkResult = CheckIfProductCountOfCategoryCorrect(product.CategoryId);
            if (!checkResult.Success)
            {
                return checkResult;
            }
            checkResult = CheckIfProductWithSameNameExists(product.ProductName);
            if (!checkResult.Success)
            {
                return checkResult;
            }

            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll(Expression<Func<Product, bool>> filter)
        {
            //fake business logic
            //if (DateTime.Now.Hour == 9)
            //{
            //    return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            //}
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(filter), Messages.ProductsListed);
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId),
                Messages.ProductListed);
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            //fake business logic
            if (DateTime.Now.Hour == 15)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails(),
                Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetProductsByCategoryId(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == categoryId),
                Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetProductsByMinAndMaxPrice(decimal minPrice, decimal maxPrice)
        {
            return new SuccessDataResult<List<Product>>(
                _productDal.GetAll(p => p.UnitPrice >= minPrice && p.UnitPrice <= maxPrice), Messages.ProductsListed);
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var productsCount = GetProductsByCategoryId(categoryId).Data.Count;
            if (productsCount > 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryExceeded);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductWithSameNameExists(string productName)
        {
            var isProductExist = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (isProductExist)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
