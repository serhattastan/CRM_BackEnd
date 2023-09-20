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
    public class EfCommunicationHistoryDal : EfEntityRepositoryBase<CommunicationHistory, CRMDatabaseContext>, ICommunicationHistoryDal
    {
        public List<CommunicationHistoryDto> GetCommunicationHistoryDetail()
        {
            using (CRMDatabaseContext context = new CRMDatabaseContext())
            {
                var result = from c in context.CommunicationHistories
                             join cus in context.Customers
                             on c.CustomerId equals cus.Id
                             join u in context.Users
                             on c.UserId equals u.Id
                             join ct in context.CommunicationTypes
                             on c.CommunicationTypeId equals ct.Id
                             join r in context.CommunicationResults
                             on c.ResultId equals r.Id
                             join o in context.Offers
                             on c.OfferId equals o.Id
                             select new CommunicationHistoryDto
                             {
                                Id  = c.Id,
                                CustomerName = cus.FirstName + " " + cus.LastName,
                                UserName = u.FirstName + " " + u.LastName,
                                CommunicationTypeName = ct.Name,
                                Notes = c.Notes,
                                Date = c.Date,
                                ResultName = r.ResultName,
                                OfferName = o.Name
                             };
                return result.ToList();
            }
        }
    }
}
