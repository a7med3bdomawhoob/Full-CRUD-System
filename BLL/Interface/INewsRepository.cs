using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;

namespace BLL.Interface
{
    public interface INewsRepository
    {
        Task<IReadOnlyList<News>> GetAll();
        Task<int> CheckSimilarityOfImageName(string ImageName);
    }
}
