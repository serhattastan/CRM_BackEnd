using Business.Abstract;
using Business.BusinessAspetcs.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
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
    public class SaleManager : ISaleService
    {
        ISaleDal _saleDal;

        public SaleManager(ISaleDal saleDal)
        {
            _saleDal = saleDal;
        }

        [SecuredOperation("database_administrator,admin,sale_manager")]
        [ValidationAspect(typeof(SaleValidator))]
        public IResult Add(Sale sale)
        {
            _saleDal.Add(sale);
            return new SuccessResult(Messages.SaleAdded);
        }

        [SecuredOperation("database_administrator,admin")]
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

        [SecuredOperation("database_administrator,admin,sale_manager")]
        public IDataResult<List<Sale>> GetAll()
        {
            return new SuccessDataResult<List<Sale>>(_saleDal.GetAll(), Messages.SalesListed);
        }

        [SecuredOperation("database_administrator,admin,sale_manager")]
        public IDataResult<Sale> GetById(int saleId)
        {
            return new SuccessDataResult<Sale>(_saleDal.Get(p => p.Id == saleId), Messages.SelectedSale);
        }

        [SecuredOperation("database_administrator,admin,sale_manager")]
        public IDataResult<List<SaleDetailDto>> GetSaleDetails()
        {
            return new SuccessDataResult<List<SaleDetailDto>>(_saleDal.GetSaleDetail());
        }

        [SecuredOperation("database_administrator,admin")]
        [ValidationAspect(typeof(SaleValidator))]
        public IResult Update(Sale sale)
        {
            _saleDal.Add(sale);
            return new SuccessResult(Messages.SectorUpdated);
        }
    }
}
