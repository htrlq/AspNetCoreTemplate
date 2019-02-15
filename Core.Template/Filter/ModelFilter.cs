using Core.Template.Middleware._Exception;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Template.Filter
{
    /// <summary>
    /// Gold Filter Validate Model
    /// </summary>
    public class GoldModelFilter : IActionFilter
    {
        /// <summary>
        /// Action Before
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        /// <summary>
        /// Action After
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
                throw new ValidateException(
                    context.ModelState.Values
                        .FirstOrDefault(item => item.Errors.Count > 0
                        )
                        .Errors.FirstOrDefault().ErrorMessage
                );
        }
    }
}
