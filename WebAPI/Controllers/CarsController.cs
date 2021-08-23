using Business.Abstract;
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
    public class CarsController : ControllerBase
    {

        ICarService _carService;
        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getbybrandid")]
        public IActionResult GetByBrandId(int id)
        {
            var result = _carService.GetAllByBrandId(id);

            return Ok(result);

        }


        [HttpGet("getcardetail")]
        public IActionResult GetCarDetails()
        {
            var result = _carService.GetCarDetails();
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getcardetailbybrandid")]
        public IActionResult GetCarDetails(int brandId)
        {
            var result = _carService.getCarDetailsByBrandId(brandId);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Uptade(Car car)
        {
            var result = _carService.Uptade(car);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);
            if (result.Succes)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

    }
}

    

