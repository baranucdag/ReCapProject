using Business.Abstract;
using Business.Constans;
using Core.Results.Utilities;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;
        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (!result.Succes)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = ("Image"))] IFormFile file, [FromForm] CarImage images)
        {
            var result = _carImageService.Add(file, images);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
