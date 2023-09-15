using Business.Abstract;
using Business.Constants;
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
