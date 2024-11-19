using System.Runtime.ConstrainedExecution;
using AutoMapper;
using BLL.Interface;
using DAL.Context;
using DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PL.Dto;
using Zaabee.Extensions;

namespace PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SrviceController : ControllerBase
    {
        private readonly IGenaricRepository<Project> repo;
        private readonly IGenaricRepository<Service> _ser;
        private readonly IServiceRepository servicerepo;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment _env;
        private readonly NamaaContext context;
        private readonly IWebHostEnvironment _hostingEnvironment;

      
        public SrviceController(IGenaricRepository<Project> repo, IMapper mapper, IWebHostEnvironment env, NamaaContext context, IServiceRepository _servicerepo,
                  IGenaricRepository<Service> ser, IWebHostEnvironment hostingEnvironment
            )
        {
            this.repo = repo;
            this.mapper = mapper;
            _env = env;
            this.context = context;
            servicerepo = _servicerepo;
            _ser = ser;
            _hostingEnvironment = hostingEnvironment;
        }




        [HttpGet("GetImages")]
        public async Task<IActionResult> GetImages()
        {
            var imagesDirectory = Path.Combine("wwwroot", "Services");
            var imageFiles = Directory.GetFiles(imagesDirectory);
            var images = new List<string>();

            foreach (var imagePath in imageFiles)
            {
                var x = imagePath.ToString().Split(new[] { "Services\\" }, StringSplitOptions.None)[1];
                var imageBytes = await System.IO.File.ReadAllBytesAsync(imagePath); // Read bytes asynchronously
                var base64String = Convert.ToBase64String(imageBytes);
                images.Add($"data:{x};base64,{base64String}"); // Adjust MIME type as needed
            }

            return Ok(images);
        }

        [HttpGet("GetServiceByServiceId")]
      public async Task<ActionResult<Service>>  GetServiceByServiceId(int sid)
        {
          return Ok(  await   servicerepo.GetServiceByServiceId(sid));
        }



        //return specific Image
        [HttpGet("GetImageOfServiceByImageName")]   //Header Image Return One Image 
        public IActionResult GetImageOfServiceByImageName(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return BadRequest("No image names provided.");
            }

            var imagesDirectory = Path.Combine("wwwroot", "Services");
            var imageNamesList = fileName.Split(',');
            var images = new List<string>();

            foreach (var imageName in imageNamesList)
            {
                var imagePath = Path.Combine(imagesDirectory, fileName.Trim());

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




        /////////////////////////////////Forms
      

        [HttpPost("AddService")]
        public async Task<IActionResult> AddService(ServiceDto serr)
        {
            var SerMapped = mapper.Map<Service>(serr);
            var x=await _ser.Add(SerMapped);    //Genaric
            return Ok(x); // or any appropriate response
        }

        [HttpGet("CheckSimilarityOfImageName")]
        public async Task<int> CheckSimilarityOfImageName(string imageName)
        {
            var va = await servicerepo.CheckSimilarityOfImageName(imageName);
            return va;
        }



        [HttpDelete("DeleteImageFromFolder")]
        public async Task<ActionResult<bool>> DeleteImage(string imageName)
        {
            string uploadsFolderPath = Path.Combine(_hostingEnvironment.WebRootPath, "Services");

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
            string uploadsFolderPath = Path.Combine(_hostingEnvironment.WebRootPath, "Services");

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



        [HttpGet("GetAllServices")]
        public async Task<IEnumerable<Service>> GetAllServices()
        {
            return await servicerepo.GetAllServices();
        }



        [HttpDelete("DeleteById")]
        public async Task<int> DeleteById(int Id)
        {
            var x = await _ser.DeleteById(Id);
            return x;
        }


        [HttpPut("Update")]
        public int Update(ServiceDto service)
        {

          var  Service= mapper.Map<Service>(service);
            try
            {
                _ser.Update(Service);
                return 1;
            }
            catch 
            {
                return 0;
            }
        }




    }
}
