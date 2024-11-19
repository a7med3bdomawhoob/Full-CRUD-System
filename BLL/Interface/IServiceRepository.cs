using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;

namespace BLL.Interface
{
    public interface IServiceRepository
    {
          Task<IEnumerable<Service>> GetAllServices();
         Task<IEnumerable<Service>> GetServiceByServiceId(int sid);
        Task<int> CheckSimilarityOfImageName(string ImageName);

    }
}
