using AutoMapper;
using BLL.Interface;
using DAL.Context;
using DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PL.Dto;


namespace PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipementsController : ControllerBase
    {
        private readonly IEquipmentsRepository _equip;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly NamaaContext context;
        private readonly IGenaricRepository<Equipement> _repo;

        public EquipementsController(IMapper mapper,  NamaaContext context, IEquipmentsRepository equi,
            IGenaricRepository<Equipement> repo,  IWebHostEnvironment hostingEnvironment)
        {
            this.mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
            this.context = context;
            _equip = equi;
            _repo = repo;
        }



        [HttpGet("GetAllEquipment")]
        public async Task<IEnumerable<Equipement>> GetAllEquipments()
        {
            return await _equip.GetAllEquipement();
        }

        [HttpDelete("DeleteById")]
        public async Task<int> DeleteAreaByAreaId(int id)
        {
            var x = await _repo.DeleteById(id);
            return x;
        }



        [HttpGet("GetImages")]
        public async Task<IActionResult> GetImages()
        {
            var imagesDirectory = Path.Combine("wwwroot", "Equipements");
            var imageFiles = Directory.GetFiles(imagesDirectory);
            var images = new List<string>();

            foreach (var imagePath in imageFiles)
            {
                var x = imagePath.ToString().Split(new[] { "Equipements\\" }, StringSplitOptions.None)[1];
                var imageBytes = await System.IO.File.ReadAllBytesAsync(imagePath); // Read bytes asynchronously
                var base64String = Convert.ToBase64String(imageBytes);
                images.Add($"data:{x};base64,{base64String}"); // Adjust MIME type as needed
            }

            return Ok(images);
        }

        [HttpGet("GetEquipementByEquipementId")]
        public async Task<ActionResult<Equipement>> GetEquipementByEquipementId(int eid)
        {
            return Ok(await _equip.GetEquipementByEquipementId(eid));
        }



        //return specific Image
        [HttpGet("GetImageOfEquipementByImageName")]   //Header Image Return One Image 
        public IActionResult GetImageOfEquipementByImageName(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return BadRequest("No image names provided.");
            }

            var imagesDirectory = Path.Combine("wwwroot", "Equipements");
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

        /// <summary>
        /// //////////////////////////////////////////Form
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>

        [HttpPost("AddEquipement")]
        public async Task<IActionResult> AddNews(EquipementDto equipment)
        {

            var EquipementMaped = mapper.Map<Equipement>(equipment);
            var x=  await _repo.Add(EquipementMaped);
            return Ok(x); // or any appropriate response 0 or 1
        }


        [HttpGet("CheckSimilarityOfImageName")]
        public async Task<int> CheckSimilarityOfImageName(string imageName)
        {
            var va = await _equip.CheckSimilarityOfImageName(imageName);
            return va;
        }


        [HttpDelete("DeleteImageFromFolder")]
        public async Task<ActionResult<bool>> DeleteImage(string imageName)
        {
            string uploadsFolderPath = Path.Combine(_hostingEnvironment.WebRootPath, "Equipements");

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
            string uploadsFolderPath = Path.Combine(_hostingEnvironment.WebRootPath, "Equipements");

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
        public int Update(EquipementDto equipement)
        {

            var Equipment = mapper.Map<Equipement>(equipement);
            try
            {
                _repo.Update(Equipment);
                return 1;
            }
            catch
            {
                return 0;
            }
        }


    }
}
