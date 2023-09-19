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
    public class EfSaleDal : EfEntityRepositoryBase<Sale, CRMDatabaseContext>, ISaleDal
    {
        public List<SaleDetailDto> GetSaleDetail()
        {
            using (CRMDatabaseContext context = new CRMDatabaseContext())
            {
                var result = from s in context.Sales
                             join c in context.Customers
                             on s.CustomerId equals c.Id
                             join p in context.Products
                             on s.ProductId equals p.Id
                             join st in context.SaleStatus
                             on s.SaleStatusId equals st.Id
                             select new SaleDetailDto
                             {
                                 Id = s.Id,
                                 CustomerName = c.FirstName + " " + c.LastName,
                                 ProductName = p.Name,
                                 InstantPrice = s.InstantPrice,
                                 Date = s.Date,
                                 SaleStatusName = st.StatusName
                             };
                return result.ToList();
            }
        }
    }
}
