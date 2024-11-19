using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface;
using DAL.Context;
using DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace BLL.Repository
{
    public class GenaricRepository<T> : IGenaricRepository<T> where T : class 
    {
        private readonly NamaaContext context;

        public GenaricRepository(NamaaContext context)
        {
            this.context = context;
        }
        public async Task<int> Add(T entity)
        {
            try
            {
                await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();
                return 1;
            }
             catch (Exception ex)
            {
                // Log or handle the exception
                Console.WriteLine(ex.Message);
                return 0;  
            }
        }


        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
             context.SaveChangesAsync();
        }


        public async Task<T> GetById(int? id)
        {
            return await context.Set<T>().FindAsync(id);
        }




        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }
 


        public void Update(T entity)
        {
            context.Set<T>().Update(entity);//update values that it is  value changed
            context.SaveChanges();
            // context.Entry(entity).State = EntityState.Modified; //update all values
        }

        public async Task<IReadOnlyList<T>> getall()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<Project>> GetProjectsByAreaId(int? areaId)
        {
            return await context.projects
                       .Where(p => p.AreaId == areaId)
                       .ToListAsync();
        }



        public async Task<int> DeleteById(int id)
        {
            var TableInfoObject = await context.Set<T>().FindAsync(id);
            if (TableInfoObject != null)
            {
                context.Set<T>().Remove(TableInfoObject);
                return await context.SaveChangesAsync();
            }
            return 0;
        }


    }

}
