using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;

namespace BLL.Interface
{
    public interface ICareerRepository
    {
        Task<Job> GetDetailsByJobId(int jobId);

        Task<IEnumerable<Job>> SearshByName(string name, string Property);


        Task<IEnumerable<Job>> SearchByAll(string JobTitle,string Location,string TimeType );

        Task <int>  GetMaxJobId();

        Task UpdateJob(Job job);




    }
}
