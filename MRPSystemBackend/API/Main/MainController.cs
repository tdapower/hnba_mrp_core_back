using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MRPSystemBackend.API.LifeAssure;
using Newtonsoft.Json.Linq;

namespace MRPSystemBackend.API.Main
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class MainController : Controller
    {
        IMainRepository mainRepository;
        public MainController(IMainRepository _mainRepository)
        {
            mainRepository = _mainRepository;
        }


        [Route("AddMainDetails")]
        public IActionResult AddEmployee([FromBody]Main main)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = mainRepository.AddMainRecord(main);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GenerateProposalNo")]
        public IActionResult GenerateProposalNo(string bankCode)
        {

            if (bankCode == null || bankCode == "")
            {
                return BadRequest("Bank code is mandatory");
            }
            
            var result = mainRepository.GenerateProposalNo(bankCode);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [Route("SaveMainDetails")]
        public IActionResult SaveMainDetails([FromBody] JObject  data)
        {
            Main main = data["proposalData"].ToObject<Main>();
            Assure assure1 = data["assure1Data"].ToObject<Assure>();
            Assure assure2 = data["assure2Data"].ToObject<Assure>();

            if (data == null )
            {
                return BadRequest();
            }
            var result = mainRepository.SaveMain(main, assure1, assure2);
            if (result.SeqId == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }



    }
}