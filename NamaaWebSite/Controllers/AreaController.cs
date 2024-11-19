using AutoMapper;
using BLL.Interface;
using DAL.Context;
using DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PL.Dto;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly IAreaRepository _arearepo;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment _env;
        private readonly NamaaContext context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        private readonly IGenaricRepository<Area> _area;

        public AreaController( IMapper mapper, IWebHostEnvironment env, NamaaContext context, IAreaRepository arearepo, IWebHostEnvironment hostingEnvironment,
                       IGenaricRepository<Area> area
                     
                       )
        {
            this.mapper = mapper;
            _env = env;
            this.context = context;
            _arearepo = arearepo;
            _area = area;
            _hostingEnvironment = hostingEnvironment;
        }



        




        [HttpGet("GetAreaInfoByServiceId")]
        public async Task<IEnumerable<Area>> GetAreaInfoByServiceId(int serviceId) {

           
            var Data = await _arearepo.GetAreaByServiceId(serviceId);
            if (Data == null)
            {
                return Enumerable.Empty<Area>();
            }

            // Assuming _mapper is an instance of IMapper
            var result = mapper.Map<IEnumerable<Area>>(Data);
            return result;

        }


        //GetImagesAreaByServiceId area
        [HttpGet("GetImagesForAreaByImagesString")]   //All Area Images 
        public IActionResult GetImagesAreaByServiceId([FromQuery] string imageNames)
        {
            if (string.IsNullOrEmpty(imageNames))
            {
                return BadRequest("No image names provided.");
            }

            var imagesDirectory = Path.Combine("wwwroot", "Areas");
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



        [HttpDelete("DeleteImageFromFolder")]
        public async Task<ActionResult<bool>> DeleteImage(string imageName)
        {
            string uploadsFolderPath = Path.Combine(_hostingEnvironment.WebRootPath, "Areas");

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
                return NotFound(false);
            }
        }






        [HttpPost("Upload")]
        public async Task<ActionResult<string>> Upload([FromForm] IFormFile file)
        {
            string uniqueFileName = null;
            string uploadsFolderPath = Path.Combine(_hostingEnvironment.WebRootPath, "Areas");

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

        [HttpGet("CheckSimilarityOfImageName")]
      public async Task<int>  CheckSimilarityOfImageName(string imageName)
        {
          var va=await _arearepo.CheckSimilarityOfImageName(imageName);
            return va;
        }


        [HttpPost("AddArea")]
        public async Task<IActionResult> AddArea(AreaDto areaa)
        {
            var AreaMapped = mapper.Map<Area>(areaa);
            await _area.Add(AreaMapped);
            return Ok(1); // or any appropriate response
        }
        /*
                [HttpGet("GetAllAreas")]
                public async Task<ActionResult<IEnumerable<AreaDto>>> GetAllAreas()
                {
                    var res = await _area.GetAll();
                    return Ok(res);
                }*/


        [HttpGet("GetAllAreas")]
        public async Task<ActionResult<IEnumerable<AreaDto>>> GetAllAreas()
       {
            var areas = await _arearepo.GetAllAreas();
            var areaDtos = mapper.Map<IEnumerable<AreaDto>>(areas);  // Using AutoMapper to map entities to DTOs
            return Ok(areaDtos);
            // return Ok( await _arearepo.GetAllAreas());
        }

        [HttpGet("GetAreaByAreaId")]
        public async Task<Area> GetAreaByAreaId(int areaId)
        {
            return (await _area.GetById(areaId));

        }


        [HttpDelete("DeleteAreaByAreaId")]
        public async Task<int> DeleteAreaByAreaId(int areaId)
        {
          var x= await _area.DeleteById(areaId);
            return x;
        }

        [HttpPut("Update")]
        public int Update(AreaDto area)
        {

            var Area = mapper.Map<Area>(area);
            try
            {
                _area.Update(Area);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

    }
}
