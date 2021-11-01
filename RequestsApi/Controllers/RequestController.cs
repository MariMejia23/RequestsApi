using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestsApi.Interfaces;
using RequestsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        readonly IRequestService Service;

        public RequestController(IRequestService service)
        {
            Service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = Service.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Request request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await Service.CreateAsync(request);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Put(Request request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await Service.UpdateAsync(request);
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

           await Service.DeleteAsync(id);
            return NoContent();
        }
    }
}
