using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;

namespace BLL.Interface
{
    public interface IEquipmentsRepository
    {
        Task<IEnumerable<Equipement>> GetAllEquipement();
        Task<IEnumerable<Equipement>> GetEquipementByEquipementId(int equiId);
        Task<int> CheckSimilarityOfImageName(string ImageName);
    }
}
