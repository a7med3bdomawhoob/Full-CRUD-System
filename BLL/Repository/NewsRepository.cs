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
    public class NewsRepository : INewsRepository
    {

        public readonly NamaaContext _context;
        public NewsRepository(NamaaContext context)
        {
            _context = context;

        }

        public async Task<IReadOnlyList<News>> GetAll()
        {
            return await _context.news.OrderBy(n=>n.Image_Name) . ToListAsync();   
        }

        public async Task<int> CheckSimilarityOfImageName(string ImageName)
        {

            var check = await _context.news.AnyAsync(e => e.Image_Name == ImageName);
            return check ? 1 : 0;

        }

    }
}
