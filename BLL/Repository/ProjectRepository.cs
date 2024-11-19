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
    public class ProjectRepository : IProjectRepository
    {
        public readonly NamaaContext _context;
       public ProjectRepository(NamaaContext context)
        {
            _context = context;

        }

        public async Task< IEnumerable< Project>> GetAll()
        {
            return await _context.projects.AsNoTracking().OrderBy(p=>p.Project_Name).ToListAsync();
        }

        public async Task<Project> GetProjectByImageName(string imageName)
       {
            var x= await _context.projects.FirstOrDefaultAsync(p => p.Project_Name == imageName);
            return x;
       }


        public async Task<IEnumerable<Project>> GetProjectsByAreaId(int areaId)
        {
            return await _context.projects
                                 .Where(p => p.AreaId == areaId)
                                 .ToListAsync();
        }
        public async Task<int> CheckSimilarityOfImageName(string ImageName)
        {

            var check = await _context.projects.AnyAsync(e => e.Image_Name == ImageName);
            return check ? 1 : 0;

        }







    }
}
