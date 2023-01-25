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
    [Route("api/prescriptions")]
    public class PrescriptionController : ControllerBase
    {
        private readonly IPrescriptionDbRepo _repo;

        public PrescriptionController(IPrescriptionDbRepo repo)
        {
            this._repo = repo;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctors(int id)
        {

            return Ok(await _repo.GetPrescription(id));

        }

       


    }
    
}
