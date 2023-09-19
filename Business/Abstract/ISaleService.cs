using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISaleService
    {
        IDataResult<List<Sale>> GetAll();
        IDataResult<Sale> GetById(int saleId);
        IResult Add(Sale sale);
        IResult Update(Sale sale);
        IResult Delete(int saleId);

        //DTOs
        IDataResult<List<SaleDetailDto>> GetSaleDetails();
    }
}
