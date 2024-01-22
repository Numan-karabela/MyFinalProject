using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concreet;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreet
{ 
    public class ProductManager : IProductService
    { 
            IProductDal _productDal;
            ICategoryService    _categoryService;

        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult add(Product product)
        {
           IResult result= BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryId),
                CheckIfProductExists(product.ProductName),CheckIfCategoryLimitExceded());

            if (result !=null)
            {
                return result;

            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded); 
        }

        public IDataResult<List<Product>>GetAll()
         {
            if (DateTime.Now.Hour == 20)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductsListed);
        }

        public IDataResult<List<Product>>GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.CategoryId == id));
        }

        public IDataResult<Product>GetById(int productid)
        {
           return new SuccessDataResult<Product>(_productDal.Get(p=>p.ProductId==productid));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.UnitPrice<=min&&p.UnitPrice>=max));
        }

        public IDataResult<List<ProductDetailDTo>>GetProductsDetails()
        {
            return new SuccessDataResult<List<ProductDetailDTo>>(_productDal.GetProductDetails()); 
        }
        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {

            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 15)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);

            }
            return new SuccessResult();
        }
        private IResult CheckIfProductExists(string ProductName)
        {

            var result = _productDal.GetAll(p => p.ProductName == ProductName).Any();
            if (result )
            { 
                return new ErrorResult(Messages.ProductNameAlreadyExists); 
            }
            return new SuccessResult();
        }
        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count>15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);

            }
            return new SuccessResult(); 
        }

    }
    }