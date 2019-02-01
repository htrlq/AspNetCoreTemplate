using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Template.Middleware._Exception;
using Microsoft.AspNetCore.Mvc;

namespace Core.Template.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public string Index()
        {
            return "Hello";
        }

        [HttpGet("Exception")]
        public string Exception()
        {
            throw new Exception();
        }

        [HttpGet("CoreException")]
        public string CoreException()
        {
            throw new CoreException();
        }
    }
}
