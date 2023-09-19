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
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, CRMDatabaseContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetail()
        {
            using (CRMDatabaseContext context = new CRMDatabaseContext())
            {
                var result = from c in context.Customers
                             join co in context.Companies
                             on c.CompanyId equals co.Id
                             select new CustomerDetailDto
                             {
                                 Id = c.Id,
                                 FirstName = c.FirstName,
                                 LastName = c.LastName,
                                 Email = c.Email,
                                 PhoneNumber = c.PhoneNumber,
                                 Address = c.Address,
                                 CompanyName = co.Name
                                 
                             };
                return result.ToList();
            }
        }
    }
}