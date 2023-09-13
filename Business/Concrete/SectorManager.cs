﻿using Business.Abstract;
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
    public class SectorManager : ISectorService
    {
        ISectorDal _sectorDal;

        public SectorManager(ISectorDal sectorDal)
        {
            _sectorDal = sectorDal;
        }

        public IResult Add(Sector sector)
        {
            _sectorDal.Add(sector);
            return new SuccessResult(Messages.SectorAdded);
        }

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

        public IDataResult<List<Sector>> GetAll()
        {
            return new SuccessDataResult<List<Sector>>(_sectorDal.GetAll(), Messages.SectorsListed);
        }

        public IDataResult<Sector> GetById(int sectorId)
        {
            return new SuccessDataResult<Sector>(_sectorDal.Get(p => p.Id == sectorId), Messages.SelectedSector);
        }

        public IResult Update(Sector sector)
        {
            _sectorDal.Add(sector);
            return new SuccessResult(Messages.SectorUpdated);
        }
    }
}
