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
    public class PersonController : ControllerBase
    {
        readonly IPersonService Service;

        public PersonController(IPersonService service)
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
        public async Task<IActionResult> Post(Person person)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await Service.CreateAsync(person);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Put(Person person)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await Service.UpdateAsync(person);
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
