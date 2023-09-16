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
    public class SectorManager : ISectorService
    {
        ISectorDal _sectorDal;

        public SectorManager(ISectorDal sectorDal)
        {
            _sectorDal = sectorDal;
        }

        [SecuredOperation("database_administrator,admin")]
        [ValidationAspect(typeof(SectorValidator))]
        public IResult Add(Sector sector)
        {
            IResult result = BusinessRules.Run(
                CheckIfSectorNameExist(sector.Name)
                );
            if (result == null)
            {
                return result;
            }
            _sectorDal.Add(sector);
            return new SuccessResult(Messages.SectorAdded);
        }

        [SecuredOperation("database_administrator,admin")]
        public IResult Delete(int sectorId)
        {
            var dataDelete = _sectorDal.Get(p => p.Id == sectorId);

            if (dataDelete != null)
            {
                _sectorDal.Delete(dataDelete);
                return new SuccessResult(Messages.SectorDeleted);
            }

            return new ErrorResult(Messages.SectorNotFound);
        }

        [SecuredOperation("database_administrator,admin,sale_manager,marketing_manager")]
        public IDataResult<List<Sector>> GetAll()
        {
            return new SuccessDataResult<List<Sector>>(_sectorDal.GetAll(), Messages.SectorsListed);
        }

        [SecuredOperation("database_administrator,admin,sale_manager,marketing_manager")]
        public IDataResult<Sector> GetById(int sectorId)
        {
            return new SuccessDataResult<Sector>(_sectorDal.Get(p => p.Id == sectorId), Messages.SelectedSector);
        }

        [SecuredOperation("database_administrator,admin")]
        [ValidationAspect(typeof(SectorValidator))]
        public IResult Update(Sector sector)
        {
            IResult result = BusinessRules.Run(
                CheckIfSectorNameExist(sector.Name)
                );
            if (result == null)
            {
                return result;
            }
            _sectorDal.Add(sector);
            return new SuccessResult(Messages.SectorUpdated);
        }
        private IResult CheckIfSectorNameExist(string sectorName)
        {
            var result = _sectorDal.GetAll(p => p.Name == sectorName).Any();
            if (result)
            {
                return new ErrorResult(Messages.DataAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
