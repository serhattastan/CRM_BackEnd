using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOfferDal : EfEntityRepositoryBase<Offer, CRMDatabaseContext>, IOfferDal
    {
        public List<OfferDetailDto> GetOfferDetail()
        {
            using (CRMDatabaseContext context = new CRMDatabaseContext())
            {
                var result = from o in context.Offers
                             join t in context.OfferTypes
                             on o.TypeId equals t.Id
                             select new OfferDetailDto
                             {
                                 Id = o.Id,
                                 Name = o.Name,
                                 TypeName = t.Name,
                                 StartDate = o.StartDate,
                                 EndDate = o.EndDate,
                                 Description = o.Description
                             };
                return result.ToList();
            }
        }
    }
}

