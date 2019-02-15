using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Template.Filter;
using Core.Template.Middleware._Exception;
using Microsoft.AspNetCore.Mvc;

namespace Core.Template.Controllers
{
    /// <summary>
    /// Test Value Controller
    /// </summary>
    [Route("api/[controller]")]
    //[ApiController]
    public class ValuesController : Controller
    {
        /// <summary>
        /// Index
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string Index()
        {
            return "Hello";
        }

        /// <summary>
        /// Test Exception
        /// </summary>
        /// <returns></returns>
        [HttpGet("Exception")]
        public string Exception()
        {
            throw new Exception();
        }

        /// <summary>
        /// Test Core Exceptiopn
        /// </summary>
        /// <returns></returns>
        [HttpGet("CoreException")]
        public string CoreException()
        {
            throw new CoreException();
        }

        /// <summary>
        /// Test Admin
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Admin")]
        public ResponseModel Admin([FromForm] AdminRequestModel model)
        {
            return new AdminResponseModel()
            {
                User = model.User
            };
        }

        /// <summary>
        /// Test Admin
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("AdminFilterAttibute")]
        [ModelFilter]
        public ResponseModel AdminFilterAttibute(AdminRequestModel model)
        {
            return new AdminResponseModel()
            {
                User = model.User
            };
        }

        /// <summary>
        /// Test Admin
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("AdminDIFilterAttibute")]
        [ServiceFilter(typeof(ServiceActionFilterAttribute))]
        public ResponseModel AdminDIFilterAttibute(AdminRequestModel model)
        {
            return new AdminResponseModel()
            {
                User = model.User
            };
        }

        /// <summary>
        /// Test Admin
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("AdminTypeFilterAttibute")]
        [TypeFilter(typeof(ServiceActionFilterAttribute))]
        public ResponseModel AdminTypeFilterAttibute(AdminRequestModel model)
        {
            return new AdminResponseModel()
            {
                User = model.User
            };
        }
    }
}
