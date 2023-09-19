using Business.Abstract;
using Business.BusinessAspetcs.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Castle.Core.Resource;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [SecuredOperation("database_administrator,admin,product_manager")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        [SecuredOperation("database_administrator,admin")]
        public IResult Delete(int productId)
        {
            var dataDelete = _productDal.Get(p => p.Id == productId);

            if (dataDelete != null)
            {
                _productDal.Delete(dataDelete);
                return new SuccessResult(Messages.ProductDeleted);
            }

            return new ErrorResult(Messages.CustomerNotFound);
        }

        [SecuredOperation("database_administrator,admin,product_manager,marketing_manager,sale_manager")]
        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
        }

        [SecuredOperation("database_administrator,admin,product_manager,marketing_manager,sale_manager")]
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.Id == productId), Messages.SelectedProduct);
        }

        [SecuredOperation("database_administrator,admin,product_manager,marketing_manager,sale_manager")]
        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        [SecuredOperation("database_administrator,admin,product_manager")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
