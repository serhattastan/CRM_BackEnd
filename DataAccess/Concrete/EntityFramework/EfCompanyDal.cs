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
    public class EfCompanyDal : EfEntityRepositoryBase<Company, CRMDatabaseContext>, ICompanyDal
    {
        public List<CompanyDetailDto> GetCompanyDetails()
        {
            using (CRMDatabaseContext context = new CRMDatabaseContext())
            {
                var result = from c in context.Companies
                             join s in context.Sectors
                             on c.SectorId equals s.Id
                             select new CompanyDetailDto
                             {
                                 Id = c.Id,
                                 Name = c.Name,
                                 SectorName = s.Name
                             };
                return result.ToList();
            }
        }
    }
}
