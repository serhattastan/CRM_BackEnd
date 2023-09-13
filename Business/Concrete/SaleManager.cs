using Business.Abstract;
using Business.Constants;
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
    public class SaleManager : ISaleService
    {
        ISaleDal _saleDal;

        public SaleManager(ISaleDal saleDal)
        {
            _saleDal = saleDal;
        }

        public IResult Add(Sale sale)
        {
            _saleDal.Add(sale);
            return new SuccessResult(Messages.SaleAdded);
        }

        public IResult Delete(int saleId)
        {
            var dataDelete = _saleDal.Get(p => p.Id == saleId);

            if (dataDelete != null)
            {
                _saleDal.Delete(dataDelete);
                return new SuccessResult(Messages.SaleDeleted);
            }

            return new ErrorResult(Messages.SaleNotFound);
        }

        public IDataResult<List<Sale>> GetAll()
        {
            return new SuccessDataResult<List<Sale>>(_saleDal.GetAll(), Messages.SalesListed);
        }

        public IDataResult<Sale> GetById(int saleId)
        {
            return new SuccessDataResult<Sale>(_saleDal.Get(p => p.Id == saleId), Messages.SelectedSale);
        }

        public IResult Update(Sale sale)
        {
            _saleDal.Add(sale);
            return new SuccessResult(Messages.SaleUpdated);
        }
    }
}
