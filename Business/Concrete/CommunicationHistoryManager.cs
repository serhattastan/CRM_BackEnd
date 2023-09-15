using Business.Abstract;
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

namespace Business.Concrete
{
    public class CommunicationHistoryManager : ICommunicationHistoryService
    {
        ICommunicationHistoryDal _communicationHistoryDal;

        public CommunicationHistoryManager(ICommunicationHistoryDal communicationHistoryDal)
        {
            _communicationHistoryDal = communicationHistoryDal;
        }

        [ValidationAspect(typeof(CommunicationHistoryValidator))]
        public IResult Add(CommunicationHistory communicationHistory)
        {
            _communicationHistoryDal.Add(communicationHistory);
            return new SuccessResult(Messages.CommunicationHistoryAdded);
        }

        public IResult Delete(int communicationHistoryId)
        {
            var dataDelete = _communicationHistoryDal.Get(p => p.Id == communicationHistoryId);

            if (dataDelete != null)
            {
                _communicationHistoryDal.Delete(dataDelete);
                return new SuccessResult(Messages.CommunicationHistoryDeleted);
            }

            return new ErrorResult(Messages.CommunicationHistoryNotFound);
        }

        public IDataResult<List<CommunicationHistory>> GetAll()
        {
            return new SuccessDataResult<List<CommunicationHistory>>(_communicationHistoryDal.GetAll(), Messages.CommunicationHistoryListed);
        }

        public IDataResult<CommunicationHistory> GetById(int communicationHistoryId)
        {
            return new SuccessDataResult<CommunicationHistory>(_communicationHistoryDal.Get(p => p.Id == communicationHistoryId), Messages.SelectedCommunicationHistory);
        }

        [ValidationAspect(typeof(CommunicationHistoryValidator))]
        public IResult Update(CommunicationHistory communicationHistory)
        {
            _communicationHistoryDal.Add(communicationHistory);
            return new SuccessResult(Messages.CommunicationHistoryUpdated);
        }
    }
}
