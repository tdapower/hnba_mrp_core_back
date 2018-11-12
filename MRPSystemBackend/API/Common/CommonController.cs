using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MRPSystemBackend.API.Common
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CommonController : Controller
    {

        ICommonRepository commonRepository;
        public CommonController(ICommonRepository _commonRepository)
        {
            commonRepository = _commonRepository;
        }

        [HttpGet]
        [Route("GetNationalityList")]
        public IActionResult GetNationalityList()
        {
            var result = commonRepository.GetAllNationalities();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


    }
}