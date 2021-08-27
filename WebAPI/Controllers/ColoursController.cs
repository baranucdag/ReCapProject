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
    public class ColoursController : ControllerBase
    {
        IColourService _colourService;
        public ColoursController(IColourService colourService)
        {
            _colourService = colourService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _colourService.GetAll();
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getbycolourid")]
        public IActionResult GetByColourId(int id)
        {
            var result = _colourService.GetByColourId(id);

            return Ok(result);

        }


        [HttpPost("add")]
        public IActionResult Add(Colour colour)
        {
            var result = _colourService.Add(colour);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Uptade(Colour colour)
        {
            var result = _colourService.Update(colour);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Colour colour)
        {
            var result = _colourService.Delete(colour);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
