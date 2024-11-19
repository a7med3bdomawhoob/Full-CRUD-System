using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface;
using DAL.Context;
using DAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BLL.Repository
{
    public class CareerRepository : ICareerRepository
    {
        public readonly NamaaContext _context;
        public CareerRepository(NamaaContext context)
        {
            _context = context;

        }

        public async Task<Job> GetDetailsByJobId(int jobId)
        {
            return await _context.jobs
                .Include(job => job.JobResponsibilities)    // Include related JobRequirements
                .Include(job => job.JobRequirements) // Include related JobResponsibilities
                .FirstOrDefaultAsync(job => job.Job_Id == jobId); // Filter by jobId
        }

        public async Task<int> GetMaxJobId()
        {
            return await _context.jobs.AnyAsync()
                ? await _context.jobs.MaxAsync(j => j.Job_Id)
                : 0;  // Return 0 if no jobs exist
        }


        public async Task<IEnumerable<Job>> SearchByAll(string JobTitle, string Location, string TimeType)
        {

         if (TimeType == "null" && Location == "null" && JobTitle == "null")
            {
                return await _context.jobs.ToListAsync();
            }

         else if(TimeType != "null" && Location != "null" && JobTitle != "null")
            {
                return await _context.jobs.Where(j => j.Job_Title == JobTitle)
                                        .Where(j => j.Location == Location)
                                        .Where(j => j.Time_Type == TimeType).ToListAsync();
            }


         else   if (JobTitle == "null" && Location == "null" && TimeType!="null")
            {
                return await _context.jobs
                                         .Where(j => j.Time_Type == TimeType).ToListAsync();
            }

            else if (JobTitle == "null" && Location != "null" && TimeType == "null")
            {
                return await _context.jobs
                                         .Where(j => j.Location == Location).ToListAsync();
            }


            else if (JobTitle != "null" && Location == "null" && TimeType == "null")
            {
                return await _context.jobs
                                         .Where(j => j.Job_Title == JobTitle).ToListAsync();
            }














            else if (JobTitle=="null"  )
            {
                return await _context.jobs
                                         .Where(j => j.Location == Location)
                                         .Where(j => j.Time_Type == TimeType).ToListAsync();
            }
            else if(Location=="null")
            {
                return await _context.jobs.Where(j => j.Job_Title == JobTitle)
                                         .Where(j => j.Time_Type == TimeType).ToListAsync();
            }
            else if(TimeType=="null")
            {
                return await _context.jobs.Where(j => j.Job_Title == JobTitle)
                          .Where(j => j.Location == Location).ToListAsync();
            }



            else
            {
                return await _context.jobs.Where(j => j.Job_Title == JobTitle)
                                          .Where(j => j.Location == Location)
                                          .Where(j => j.Time_Type == TimeType).ToListAsync();
            }

        }

        public async Task<IEnumerable<Job>> SearshByName(string name, string Property)
        {
            return await _context.jobs.Where(j => EF.Property<string>(j, Property) == name).ToListAsync();
        }

        public async Task UpdateJob(Job job)
        {
           _context.jobs.Update(job);  
            await _context.SaveChangesAsync();  
        }
    }
}
