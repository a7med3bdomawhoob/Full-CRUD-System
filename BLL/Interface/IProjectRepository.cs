using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;

namespace BLL.Interface
{
    public interface IProjectRepository
    {
        
       Task<IEnumerable<Project>> GetProjectsByAreaId(int areaId);
        Task<Project> GetProjectByImageName(string imageName);
        Task<IEnumerable<Project>> GetAll();
        Task<int> CheckSimilarityOfImageName(string ImageName);



    }
}
