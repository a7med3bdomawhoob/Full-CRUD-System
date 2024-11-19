using AutoMapper;
using BLL.Interface;
using DAL.Context;
using DAL.Entity;
using DAL.Migrations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NamaaWebSite.Dto;

namespace NamaaWebSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IGenaricRepository<Job> _repo;
        private readonly IGenaricRepository<JobRequirements> _req;
        private readonly IGenaricRepository<JobResponsibilities> _res;

        private readonly IGenaricRepository<Project> _pro;
      
        private readonly IGenaricRepository<Area> _area;

        private readonly ICareerRepository _carr;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment _env;
        private readonly NamaaContext context;
        public JobsController(IMapper mapper, IWebHostEnvironment env, NamaaContext context, IGenaricRepository<Job> repo,ICareerRepository carr,
            IGenaricRepository<JobRequirements> req,

            IGenaricRepository<Project> pro,

 

            IGenaricRepository<JobResponsibilities> res)
        {
            this.mapper = mapper;
            _env = env;
            this.context = context;
            _repo = repo;
            _carr = carr;
            _req = req;
            _res = res;

            _pro = pro;

      
        }



        [HttpGet("GetAllJobs")]
        public async Task<ActionResult<Job>> GetAllJobs()
        {
            var res = await _repo.GetAll();
            return Ok(res);
        }

        [HttpDelete("DeleteById")]
        public async Task<int> DeleteById(int id)
        {
            var x = await _repo.DeleteById(id);
            return x;
        }

        /*        [HttpGet("GetJobByJobId")]
                public async Task<ActionResult<Job>> GetJobByJobId(int JobId)
                {
                    var res = await _carr.GetDetailsByJobId(JobId);
                    return Ok(res);
                }
        */

        //////////////////////////////
        ///
        [HttpGet("GetDetailsByJobId")]
        public async Task<ActionResult<Job>> GetDetailsByJobId(int JobId)
        {
            var res = await _carr.GetDetailsByJobId(JobId);
            return Ok(res);
        }


        ////////////////////////////////////////
        ///
        [HttpGet("SearshByNme")]
        public async Task <ActionResult<IEnumerable<Job> >>  SearchByJobTitle(string name,string Property)
        {
            var res= await _carr.SearshByName(name, Property);
            return Ok(res); 
        }


        [HttpGet("SearchByAll")]
        public async Task<ActionResult<IEnumerable<Job>>> SearchByAll(string JobTitle, string Location,string TimeType)
        {
            var res = await _carr.SearchByAll(JobTitle, Location, TimeType);
            return Ok(res);
        }

        ///////////////////////////////////////////////////////
        ///Form 

        [HttpPost("AddJob")]
        public async Task<IActionResult> AddNews(JobDto job)
        {

            var JopMapped = mapper.Map<Job>(job);
            await _repo.Add(JopMapped);
            return Ok(1); // or any appropriate response
        }



        [HttpPost("AddRequirement")]
        public async Task<IActionResult> AddRequirement(RequirementDto Req)
        {
            var ReqMapped = mapper.Map<JobRequirements>(Req);
            await _req.Add(ReqMapped);
            return Ok(1); // or any appropriate response
        }


        [HttpPost("AddResponsibilities")]
        public async Task<IActionResult> AddResponsibilities(ResponsibilitiesDto Res)
        {
            var ResMapped = mapper.Map<JobResponsibilities>(Res);
            await _res.Add(ResMapped);
            return Ok(1); // or any appropriate response
        }

        [HttpGet("GetMaxJobId")]
        public async Task<ActionResult<int>> GetMaxJobId()
        {
            var res = await _carr.GetMaxJobId();
            return Ok(res);
        }




        [HttpPut("Update")]
        public async Task< IActionResult> Update(JobDto job)
        {
            var Job = mapper.Map<Job>(job);
            try
            {
             _repo.Update(Job);

                return Ok(1);               // Return HTTP 200 (OK) with success code
            }
            catch (Exception ex)
            {
                // Log exception (optional)
                return BadRequest(0);       // Return HTTP 400 (Bad Request) with failure code
            }
        }










    }
}
