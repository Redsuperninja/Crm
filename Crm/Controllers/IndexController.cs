using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Crm.Controllers
{
    [ApiController]
    [Route("")]
    public class IndexController : ControllerBase
    {
        [HttpGet("")]
        public string Get()
        {
            return "API is running!";
        }
    }
}