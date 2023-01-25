using cwiczenia_8_s16325.DTO;
using cwiczenia_8_s16325.Repos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cwiczenia_8_s16325.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorDbRepo _repo;

        public DoctorController(IDoctorDbRepo repo)
        {
            this._repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctors()
        {

            return Ok(await _repo.GetDoctors());

        }

        [HttpPost]
        public async Task<IActionResult> AddDoctor([FromBody] DoctorDTO reqBody)
        {
            return Ok(await _repo.AddDoctor(reqBody));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDoctor([FromRoute] int id, [FromBody] DoctorDTO reqBody)
        {
            return Ok(await _repo.UpdateDoctor(id, reqBody));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor([FromRoute] int id)
        {
            return Ok(await _repo.DeleteDoctor(id));
        }


    }
    
}
