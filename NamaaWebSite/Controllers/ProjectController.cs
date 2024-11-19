using AutoMapper;
using BLL.Interface;
using BLL.Repository;
using DAL.Context;
using DAL.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PL.Dto;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IGenaricRepository<Project> repo;
        private readonly IProjectRepository _projectrepo;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment _env;
        private readonly NamaaContext context;
        public ProjectController(IGenaricRepository<Project> repo, IMapper mapper, IWebHostEnvironment env , NamaaContext context,IProjectRepository projectrepo,
             IWebHostEnvironment hostingEnvironment
            )
        {
            this.repo = repo;
            this.mapper = mapper;
            _env = env;
            this.context = context;
            _projectrepo = projectrepo;
            _hostingEnvironment = hostingEnvironment;
        }

     


        [HttpGet("GetAllProjects")]
        public async Task<IActionResult> GetAllProjects()
        {
            return Ok(await _projectrepo.GetAll());
        }


        [HttpDelete("DeleteById")]
        public async Task<int> DeleteById(int id)
        {
            var x = await repo.DeleteById(id);
            return x;
        }




        [HttpGet("GetProjectByProjectId")]
        public async Task<IActionResult> GetProjectByProjectId(int projectId)
        {
            return Ok(await repo.GetById(projectId));
        }






        [HttpGet("GetImage")]
        public IActionResult GetImages()
        {
            var imagesDirectory = Path.Combine("wwwroot", "Projects");
            var imageFiles = Directory.GetFiles(imagesDirectory);
            var images = new List<string>();

            foreach (var imagePath in imageFiles)
            {
                var x= imagePath.ToString().Split(new[] { "Projects\\" }, StringSplitOptions.None)[1] ;
                var imageBytes = System.IO.File.ReadAllBytes(imagePath);
                var base64String = Convert.ToBase64String(imageBytes);
                images.Add($"data:{x};base64,{base64String}"); // Adjust MIME type as needed
            }

            return Ok(images);
        }





        /// One - Copy.png One - Copy.png
        [HttpGet("GetProjectByImageName")]
        public async Task<Project> GetProjectByImageName(string ImageName)
        {
           return await _projectrepo.GetProjectByImageName(ImageName);
        }



        /// /////////////////////////////////


        [HttpGet("GetProjectByAreaId")]
        public async Task<IEnumerable<Project>> GetProjectByAreaId(int areaId)
        {
            var projects= await _projectrepo.GetProjectsByAreaId(areaId);
            return projects;    
        }


        //GetProjectsImagesByAreaId  project
        [HttpGet("GetProjectsImagesByAreaId")]
        public IActionResult GetProjectsImagesByAreaId([FromQuery] string imageNames)
        {
            if (string.IsNullOrEmpty(imageNames))
            {
                return BadRequest("No image names provided.");
            }

            var imagesDirectory = Path.Combine("wwwroot", "Projects");
            var imageNamesList = imageNames.Split(',');
            var images = new List<string>();

            foreach (var imageName in imageNamesList)
            {
                var imagePath = Path.Combine(imagesDirectory, imageName.Trim());

                if (!System.IO.File.Exists(imagePath))
                {
                    return NotFound($"Image not found: {imageName}");
                }

                var imageBytes = System.IO.File.ReadAllBytes(imagePath);
                var base64String = Convert.ToBase64String(imageBytes);
                var mimeType = GetMimeType(imagePath); // Helper method to get MIME type
                images.Add($"data:{mimeType};base64,{base64String}");
            }

            return Ok(images);
        }

        /// ////////////////////////////////////////////////




        //Get Specific Images 

        [HttpGet("GetImageByImageName")]
        public IActionResult GetImages([FromQuery] string imageNames)
        {
            if (string.IsNullOrEmpty(imageNames))
            {
                return BadRequest("No image names provided.");
            }

            var imagesDirectory = Path.Combine("wwwroot", "Projects");
            var imageNamesList = imageNames.Split(',');
            var images = new List<string>();

            foreach (var imageName in imageNamesList)
            {
                var imagePath = Path.Combine(imagesDirectory, imageName.Trim());

                if (!System.IO.File.Exists(imagePath))
                {
                    return NotFound($"Image not found: {imageName}");
                }

                var imageBytes = System.IO.File.ReadAllBytes(imagePath);
                var base64String = Convert.ToBase64String(imageBytes);
                var mimeType = GetMimeType(imagePath); // Helper method to get MIME type
                images.Add($"data:{mimeType};base64,{base64String}");
            }

            return Ok(images);
        }

        private string GetMimeType(string filePath)
        {
            var extension = Path.GetExtension(filePath).ToLowerInvariant();
            return extension switch
            {
                ".jpg" or ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".gif" => "image/gif",
                ".bmp" => "image/bmp",
                _ => "application/octet-stream"
            };
        }


        ///////////////////////////////////////Forms


        [HttpPost("AddProject")]
        public async Task<ActionResult<int> > AddProject(ProjectDto projectDto)
        {
            var convertToDto = mapper.Map<Project>(projectDto);
           var x= await repo.Add(convertToDto);
            return Ok(x) ;
        }

        [HttpGet("CheckSimilarityOfImageName")]
        public async Task<int> CheckSimilarityOfImageName(string imageName)
        {
            var va = await _projectrepo.CheckSimilarityOfImageName(imageName);
            return va;
        }

        [HttpDelete("DeleteImageFromFolder")]
        public async Task<ActionResult<bool>> DeleteImage(string imageName)
        {
            string uploadsFolderPath = Path.Combine(_hostingEnvironment.WebRootPath, "Projects");

            // Construct the full file path
            string filePath = Path.Combine(uploadsFolderPath, imageName);

            // Check if the file exists in the directory
            if (System.IO.File.Exists(filePath))
            {
                // Delete the file
                System.IO.File.Delete(filePath);
                return Ok(true); // Return success response
            }
            else
            {
                // File not found
                return NotFound("Image not found");
            }
        }






        [HttpPost("Upload")]
        public async Task<ActionResult<string>> Upload([FromForm] IFormFile file)
        {
            string uniqueFileName = null;
            string uploadsFolderPath = Path.Combine(_hostingEnvironment.WebRootPath, "Projects");

            // Ensure the uploads directory exists
            if (!Directory.Exists(uploadsFolderPath))
            {
                Directory.CreateDirectory(uploadsFolderPath);
            }

            if (file != null)
            {
                string originalFileName = Path.GetFileNameWithoutExtension(file.FileName); // Extract file name without extension
                string fileExtension = Path.GetExtension(file.FileName);                   // Extract file extension

                uniqueFileName = file.FileName;
                string filePath = Path.Combine(uploadsFolderPath, uniqueFileName);

                int counter = 1;

                // If the file already exists, append a number to the file name
                while (System.IO.File.Exists(filePath))
                {
                    uniqueFileName = $"{originalFileName}{counter}{fileExtension}"; // Append counter before extension
                    filePath = Path.Combine(uploadsFolderPath, uniqueFileName);
                    counter++;
                }

                // Use a using statement to ensure the stream is disposed of properly
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }

            //return Ok(uniqueFileName); // Return the unique file name as the result
            return Ok(true);
        }


        [HttpPut("Update")]
        public int Update(ProjectDto project)
        {

            var Project = mapper.Map<Project>(project);
            try
            {
                repo.Update(Project);
                return 1;
            }
            catch
            {
                return 0;
            }
        }


    }
}
