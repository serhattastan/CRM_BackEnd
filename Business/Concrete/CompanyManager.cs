using Business.Abstract;
using Business.BusinessAspetcs.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
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
    public class CompanyManager : ICompanyService
    {
        ICompanyDal _companyDal;

        public CompanyManager(ICompanyDal companyDal)
        {
            _companyDal = companyDal;
        }

        [SecuredOperation("database_administrator,admin,sale_manager")]
        [ValidationAspect(typeof(CompanyValidator))]
        public IResult Add(Company company)
        {
            IResult result = BusinessRules.Run(
                CheckIfCompanyNameExist(company.Name)
                );
            if (result == null)
            {
                return result;
            }
            _companyDal.Add(company);
            return new SuccessResult(Messages.CompanyAdded);
        }

        [SecuredOperation("database_administrator,admin")]
        public IResult Delete(int companyId)
        {
            var dataDelete = _companyDal.Get(p => p.Id == companyId);

            if (dataDelete != null)
            {
                _companyDal.Delete(dataDelete);
                return new SuccessResult(Messages.CompanyDeleted);
            }

            return new ErrorResult(Messages.CompanyNotFound);
        }

        public IDataResult<List<Company>> GetAll()
        {
            return new SuccessDataResult<List<Company>>(_companyDal.GetAll(), Messages.CompaniesListed);
        }

        public IDataResult<Company> GetById(int companyId)
        {
            return new SuccessDataResult<Company>(_companyDal.Get(p => p.Id == companyId), Messages.SelectedCompany);
        }

        [SecuredOperation("database_administrator,admin,sale_manager")]
        [ValidationAspect(typeof(CompanyValidator))]
        public IResult Update(Company company)
        {
            IResult result = BusinessRules.Run(
                CheckIfCompanyNameExist(company.Name)
                );
            if (result == null)
            {
                return result;
            }
            _companyDal.Add(company);
            return new SuccessResult(Messages.CompanyUpdated);
        }

        private IResult CheckIfCompanyNameExist(string companyName)
        {
            var result = _companyDal.GetAll(p => p.Name == companyName).Any();
            if (result)
            {
                return new ErrorResult(Messages.DataAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
