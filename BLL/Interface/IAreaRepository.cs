using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;

namespace BLL.Interface
{
    public interface IAreaRepository
    {
        Task<IEnumerable<Area>> GetAreaByServiceId(int serviceId);
        Task<int> CheckSimilarityOfImageName(string ImageName);
        Task<IEnumerable<Area>> GetAllAreas();
        


    }
}
