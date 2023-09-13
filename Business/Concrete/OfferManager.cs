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
    public class OfferManager : IOfferService
    {
        IOfferDal _offerDal;

        public OfferManager(IOfferDal offerDal)
        {
            _offerDal = offerDal;
        }

        public IResult Add(Offer offer)
        {
            _offerDal.Add(offer);
            return new SuccessResult(Messages.OfferAdded);
        }

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

        public IDataResult<List<Offer>> GetAll()
        {
            return new SuccessDataResult<List<Offer>>(_offerDal.GetAll(), Messages.OffersListed);
        }

        public IDataResult<Offer> GetById(int offerId)
        {
            return new SuccessDataResult<Offer>(_offerDal.Get(p => p.Id == offerId), Messages.SelectedOffer);
        }

        public IResult Update(Offer offer)
        {
            _offerDal.Add(offer);
            return new SuccessResult(Messages.OfferUpdated);
        }
    }
}
