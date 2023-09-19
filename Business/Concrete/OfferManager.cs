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
    public class OfferManager : IOfferService
    {
        IOfferDal _offerDal;

        public OfferManager(IOfferDal offerDal)
        {
            _offerDal = offerDal;
        }

        [SecuredOperation("database_administrator,admin,marketing_manager")]
        [ValidationAspect(typeof(OfferValidator))]
        public IResult Add(Offer offer)
        {
            _offerDal.Add(offer);
            return new SuccessResult(Messages.OfferAdded);
        }

        [SecuredOperation("database_administrator,admin")]
        public IResult Delete(int offerId)
        {
            var dataDelete = _offerDal.Get(p => p.Id == offerId);

            if (dataDelete != null)
            {
                _offerDal.Delete(dataDelete);
                return new SuccessResult(Messages.OfferDeleted);
            }

            return new ErrorResult(Messages.OfferNotFound);
        }

        [SecuredOperation("database_administrator,admin,marketing_manager")]
        public IDataResult<List<Offer>> GetAll()
        {
            return new SuccessDataResult<List<Offer>>(_offerDal.GetAll(), Messages.OffersListed);
        }

        [SecuredOperation("database_administrator,admin,marketing_manager")]
        public IDataResult<Offer> GetById(int offerId)
        {
            return new SuccessDataResult<Offer>(_offerDal.Get(p => p.Id == offerId), Messages.SelectedOffer);
        }

        [SecuredOperation("database_administrator,admin,marketing_manager")]
        public IDataResult<List<OfferDetailDto>> GetOfferDetails()
        {
            return new SuccessDataResult<List<OfferDetailDto>>(_offerDal.GetOfferDetail());
        }

        [SecuredOperation("database_administrator,admin,marketing_manager")]
        [ValidationAspect(typeof(OfferValidator))]
        public IResult Update(Offer offer)
        {
            _offerDal.Add(offer);
            return new SuccessResult(Messages.OfferUpdated);
        }
    }
}
