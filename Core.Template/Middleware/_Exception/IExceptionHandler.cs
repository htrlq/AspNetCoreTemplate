using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Core.Template.Middleware._Exception
{
    public interface IExceptionHandler
    {
        Task ExecuteAsync(HttpContext context,Exception exception);
    }
}
