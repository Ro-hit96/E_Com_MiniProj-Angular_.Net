using E_ComMIniProj.Model;
using E_ComMIniProj.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace E_ComMIniProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService service;
        public ProductController(IProductService service)// injects an instance of the IProductService into the controller.
                                                         // This allows the controller to interact with the business logic
                                                         // related to products through the service.
        {
                this.service = service;
        }

        [HttpGet]
        [Route("GetProducts")]// GetProducts method from the injected IProductService and returns the result.
        public async Task<IActionResult> Get()
        {
            try
            {
                var list = await service.GetProducts();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetProductById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var model = await service.GetProductById(id);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> Post([FromBody][Bind(include: "P_name,Price,image,Category_id")] Product product)
        {
            try
            {
                var result = await service.AddProduct(product);
                if (result >= 1)
                    return StatusCode(StatusCodes.Status201Created);
                else
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<IActionResult> Put([FromBody] Product product)
        {
            try
            {
                var result = await service.UpdateProduct(product);
                if (result >= 1)
                    return StatusCode(StatusCodes.Status201Created);
                else
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await service.DeleteProduct(id);
                if (result >= 1)
                    return StatusCode(StatusCodes.Status201Created);
                else
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("uploadImage")]
        public IActionResult UploadImage()
        {
            try
            {
                var file = Request.Form.Files[0];
                var fileName=ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                // Adjust the path where you want to save the file
                var filePath = Path.Combine(@"D:\Think Quotient\AngularWokrplace\MiniProj_CRUD\src\assets\Image\", fileName);

                using(var stream=new FileStream(filePath,FileMode.Create))
                {
                    file.CopyTo(stream);
                }   
                string url= @"\assets\Image\" + fileName;
                ImageDTO dto=new ImageDTO();
                dto.Url = url;
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }
        }


    }
}
