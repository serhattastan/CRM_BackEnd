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
    public interface ICommunicationHistoryService
    {
        IDataResult<List<CommunicationHistory>> GetAll();
        IDataResult<CommunicationHistory> GetById(int communicationHistoryId);
        IResult Add(CommunicationHistory communicationHistory);
        IResult Update(CommunicationHistory communicationHistory);
        IResult Delete(int communicationHistoryId);

        //DTOs
        IDataResult<List<CommunicationHistoryDto>> GetCommunicationHistoryDetail();
    }
}
