using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MRPSystemBackend.API.LifeAssure
{


    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AssureController : Controller
    {
        IAssureRepository assureRepository;

        public AssureController(IAssureRepository _assureRepository)
        {
            assureRepository = _assureRepository;
        }

        // GET: api/Assure
        [HttpGet]
        [Route("GetAssureList")]
        public IActionResult Get()
        {
            var result = assureRepository.GetAssures();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [HttpPost]
        [Route("AddCustomer")]
        public IActionResult AddCustomer([FromBody] Assure assure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = assureRepository.AddAssure(assure);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok(result);
        }



    }
}
