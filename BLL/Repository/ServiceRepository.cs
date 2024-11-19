using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface;
using DAL.Context;
using DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace BLL.Repository
{
    public  class ServiceRepository:IServiceRepository
    {

        public readonly NamaaContext _context;
        public readonly IGenaricRepository<Service> _genaricrepo;
        public ServiceRepository(NamaaContext context,IGenaricRepository<Service> genaricrepo)
        {
            _context = context;
            _genaricrepo = genaricrepo;
        }
        
        public async Task<IEnumerable<Service>>GetAllServices()
        {
            //  return await _genaricrepo.GetAll();
            return await _context.services.OrderBy(s => s.Name).ToListAsync();
            //return await _context.services.OrderBy(s => s.ServiceId).ToListAsync();
        }



        public async Task<IEnumerable<Service>> GetServiceByServiceId(int sid)
        {
            return await _context.services.Where(item => item.ServiceId == sid).ToListAsync();
        }

        public async Task<int> CheckSimilarityOfImageName(string ImageName)
        {

            var check = await _context.services.AnyAsync(e => e.Service_Image == ImageName);
            return check ? 1 : 0;

        }






    }
}
