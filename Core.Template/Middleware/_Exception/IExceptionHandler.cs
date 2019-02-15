using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Core.Template.Middleware._Exception
{
    /// <summary>
    /// Exception Handler Interface
    /// </summary>
    public interface IExceptionHandler
    {
        /// <summary>
        /// Execute Async Method
        /// </summary>
        /// <param name="context"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        Task ExecuteAsync(HttpContext context,Exception exception);
    }
}
