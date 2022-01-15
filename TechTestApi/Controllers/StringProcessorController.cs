using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TechTest;

namespace TechTestApi.Controllers
{
  
    [ApiController]
    [Route("[controller]")]
    public class StringProcessorController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetStringStats(string subject)
        {
            try
            {
                if(subject == null)
                {
                    return BadRequest(); 
                }
                StringStatsProcessor processor = new StringStatsProcessor();

                var result = processor.Run(subject);

                return new JsonResult(result);

            }catch(Exception e)
            {
                return StatusCode(500);
            }

        }
    }
}
