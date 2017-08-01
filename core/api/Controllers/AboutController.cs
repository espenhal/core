using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Controllers
{
    //[Route("about")]
    [Route("company/[controller]/[action]")]
    public class AboutController : Controller
    {
        private ILogger _logger;

        public AboutController(ILogger logger)
        {
            _logger = logger;
        }

        //[Route("phone")]
        //[Route("[action]")]
        public IActionResult Phone()
        {
            _logger.Information("Get Phone");

            var dateTime = DateTime.Now.ToString("ss");
            if (dateTime.Contains("1"))
                return BadRequest($"Sekunder {dateTime} inneholder 1...");
            if (dateTime.Contains("2"))
                return StatusCode(500, $"En inni helsikkes STOR feil fra vår side... (Sekunder {dateTime} inneholder 2...)");
            if (dateTime.Contains("3"))
                return StatusCode(500, $"En inni helsikkes STOR feil fra vår side... (Sekunder {dateTime} inneholder 2...)");
            if (dateTime.Contains("4"))
                return StatusCode(500, $"En inni helsikkes STOR feil fra vår side... (Sekunder {dateTime} inneholder 2...)");

            return Ok($"1+555-555-555 ({dateTime})");
        }

        //[Route("address")]
        //[Route("[action]")]
        public string Address()
        {
            _logger.Information("Get Address");



            return "USA";
        }
    }
}
