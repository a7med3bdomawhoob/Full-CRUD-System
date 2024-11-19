using AutoMapper;
using BLL.Interface;
using BLL.Repository;
using DAL.Context;
using DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NamaaWebSite.Dto;

namespace NamaaWebSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly IAreaRepository _arearepo;
        private readonly IGenaricRepository<News> repo;
        private readonly INewsRepository _newsRepo;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment _env;
        private readonly NamaaContext context;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public NewsController(IMapper mapper, IWebHostEnvironment env, NamaaContext context, IAreaRepository arearepo,IGenaricRepository<News> repo,INewsRepository newsRepo, IWebHostEnvironment hostingEnvironment)
        {
            this.mapper = mapper;
            _env = env;
            this.context = context;
            _arearepo = arearepo;
            this.repo = repo;
            _hostingEnvironment = hostingEnvironment;
            _newsRepo = newsRepo;
        }


        [HttpGet("GetImageByImageName")]
        public IActionResult GetImages([FromQuery] string imageNames)
        {
            if (string.IsNullOrEmpty(imageNames))
            {
                return BadRequest("No image names provided.");
            }

            var imagesDirectory = Path.Combine("wwwroot", "News");
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



        /// ////////////////////////////////




        [HttpGet("GetAllNewsImages")]
        public async Task<IActionResult> GetImages()
        {
            var imagesDirectory = Path.Combine("wwwroot", "News");
            var imageFiles = Directory.GetFiles(imagesDirectory);
            var images = new List<string>();

            foreach (var imagePath in imageFiles)
            {
                var x = imagePath.ToString().Split(new[] { "News\\" }, StringSplitOptions.None)[1];
                var imageBytes = await System.IO.File.ReadAllBytesAsync(imagePath); // Read bytes asynchronously
                var base64String = Convert.ToBase64String(imageBytes);
                images.Add($"data:{x};base64,{base64String}"); // Adjust MIME type as needed
            }

            return Ok(images);
        }


        [HttpGet("GetAllNewsInfo")]
      public async Task<ActionResult<IEnumerable<News>>> GetAllNewsInfo()
        {
            var res = await _newsRepo.GetAll();
            return Ok(res);
        }


        [HttpDelete("DeleteById")]
        public async Task<int> DeleteById(int id)
        {
            var x = await repo.DeleteById(id);
            return x;
        }


        [HttpGet("GetNewsByNewsId")]
        public async Task<ActionResult<IEnumerable<News>>> GetNewsByNewsId(int NewsId)
        {
            var res = await repo.GetById(NewsId);
            return Ok(res);
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





        ///////////////////////////////////////////
        ///Form
        ///



        [HttpPost("AddNews")]
        public async Task<IActionResult> AddNews(NewsDto news)
        {

            var NewsMaped=mapper.Map<News>(news);   
           var x= await repo.Add(NewsMaped);
            return Ok(x); // or any appropriate response
        }

        [HttpGet("CheckSimilarityOfImageName")]
        public async Task<int> CheckSimilarityOfImageName(string imageName)
        {
            var va = await _newsRepo.CheckSimilarityOfImageName(imageName);
            return va;
        }

        [HttpDelete("DeleteImageFromFolder")]
        public async Task<ActionResult<bool>> DeleteImage(string imageName)
        {
            string uploadsFolderPath = Path.Combine(_hostingEnvironment.WebRootPath, "News");

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
            string uploadsFolderPath = Path.Combine(_hostingEnvironment.WebRootPath, "News");

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
        public int Update(NewsDto news)
        {

            var News = mapper.Map<News>(news);
            try
            {
                repo.Update(News);
                return 1;
            }
            catch
            {
                return 0;
            }
        }


    }
}
