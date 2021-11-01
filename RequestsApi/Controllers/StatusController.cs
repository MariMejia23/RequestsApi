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
    public class StatusController : ControllerBase
    {
        readonly IStatusService Service;

        public StatusController(IStatusService service)
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
        public async Task<IActionResult> Post(Status status)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await Service.CreateAsync(status);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Put(Status status)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await Service.UpdateAsync(status);
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
