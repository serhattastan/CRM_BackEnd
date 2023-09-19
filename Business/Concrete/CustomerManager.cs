using Business.Abstract;
using Business.BusinessAspetcs.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [SecuredOperation("database_administrator,admin,sale_manager,marketing_manager")]
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        [SecuredOperation("database_administrator,admin")]
        public IResult Delete(int customerId)
        {
            var dataDelete = _customerDal.Get(p => p.Id == customerId);

            if (dataDelete != null)
            {
                _customerDal.Delete(dataDelete);
                return new SuccessResult(Messages.CustomerDeleted);
            }

            return new ErrorResult(Messages.CustomerNotFound);
        }

        [SecuredOperation("database_administrator,admin,sale_manager,marketing_manager")]
        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.CustomersListed);
        }

        [SecuredOperation("database_administrator,admin,sale_manager,marketing_manager")]
        public IDataResult<Customer> GetById(int customerId)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(p => p.Id == customerId), Messages.SelectedCustomer);
        }

        [SecuredOperation("database_administrator,admin,sale_manager,marketing_manager")]
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Update(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}
