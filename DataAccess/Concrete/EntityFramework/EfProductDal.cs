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
    public class EfProductDal : EfEntityRepositoryBase<Product, CRMDatabaseContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (CRMDatabaseContext context = new CRMDatabaseContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.Id
                             select new ProductDetailDto
                             {
                                 ProductId = p.Id,
                                 ProductName = p.Name,
                                 CategoryName = c.Name
                             };
                return result.ToList();
            }
        }
    }
}
