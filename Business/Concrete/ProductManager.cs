using Business.Abstract;
using Business.Constants;
using Castle.Core.Resource;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
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

        public IResult Add(Product product)
        {
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

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

        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.Id == productId), Messages.SelectedProduct);
        }

        public IResult Update(Product product)
        {
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
