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
    public class AreaRepository : IAreaRepository
    {

        public readonly NamaaContext _context;
        public AreaRepository(NamaaContext context)
        {
            _context = context;

        }

        public async Task<IEnumerable<Area>> GetAreaByServiceId(int serviceId)
        {
            return await _context.areas. Where(a => a.ServiceId == serviceId).ToListAsync();
        }


        public async Task<int> CheckSimilarityOfImageName(string ImageName)
        {
          var check=  await _context.areas.AnyAsync(e=>e.Area_Image == ImageName);  
            return check ? 1 : 0;   
        }

        public async Task<IEnumerable<Area>> GetAllAreas()
        {
          return  await _context.areas.Include(a=>a.Service).ToListAsync(); 
        }
    }
}
