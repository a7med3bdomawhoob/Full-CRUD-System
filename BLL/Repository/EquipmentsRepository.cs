using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface;
using DAL.Context;
using DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace BLL.Repository
{
    public class EquipmentsRepository:IEquipmentsRepository
    {
        public readonly NamaaContext _context;
        public EquipmentsRepository(NamaaContext context)
        {
            _context = context;

        }

        public async Task<IEnumerable<Equipement>> GetAllEquipement()
        {
            return await _context.equipments.OrderBy(s => s.Equipement_Name).ToListAsync();
        }




        public async Task<IEnumerable<Equipement>> GetEquipementByEquipementId(int eid)
        {
            return await _context.equipments.Where(item => item.Id == eid).ToListAsync();
        }

        public async Task<int> CheckSimilarityOfImageName(string ImageName)
        {

            var check = await _context.equipments.AnyAsync(e => e.Equipement_Name == ImageName);
            return check ? 1 : 0;

        }



    }
}
