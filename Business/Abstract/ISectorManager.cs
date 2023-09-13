using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISectorService
    {
        IDataResult<List<Sector>> GetAll();
        IDataResult<Sector> GetById(int sectorId);
        IResult Add(Sector sector);
        IResult Update(Sector sector);
        IResult Delete(int sectorId);
    }
}
