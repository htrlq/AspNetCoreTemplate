using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Core.Template.Filter
{
    /// <summary>
    /// Model Filter Attribute
    /// </summary>
    public class ModelFilterAttribute:ActionFilterAttribute
    {
        /// <summary>
        /// Action Before
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            //leave out
        }

        /// <summary>
        /// Action After
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //leave out
        }
    }

    /// <summary>
    /// Register Service Action Filter
    /// </summary>
    public class ServiceActionFilterAttribute : ActionFilterAttribute
    {
        private ILogger<ServiceActionFilterAttribute> Logger { get; }

        /// <summary>
        /// Generate
        /// </summary>
        /// <param name="logger"></param>
        public ServiceActionFilterAttribute(ILogger<ServiceActionFilterAttribute> logger)
        {
            Logger = logger;
        }

        /// <summary>
        /// Action Before
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            //leave out
        }

        /// <summary>
        /// Action After
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //leave out
        }
    }
}
