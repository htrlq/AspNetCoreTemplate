using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Core.Template.Middleware._Exception
{
    internal class ExceptionHandler : IExceptionHandler
    {
        private ConcurrentDictionary<Type, MethodInfo> dictionary = new ConcurrentDictionary<Type, MethodInfo>();

        public ExceptionHandler()
        {
            var methods = GetType()
                .GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance | BindingFlags.InvokeMethod)
                .Where(method => !method.Name.Equals("ExecuteAsync") && ValidateMethod(method));

            foreach(var method in methods)
            {
                var exceptionAttribute = method.GetCustomAttribute<ExceptionMethosAttribute>();

                dictionary.TryAdd(exceptionAttribute.ExceptionType, method);
            }
        }

        private bool ValidateMethod(MethodInfo method)
        {
            if (method.GetCustomAttribute(typeof(ExceptionMethosAttribute)) != null)
            {
                var paramInfos = method.GetParameters();

                return paramInfos[0].ParameterType == typeof(HttpContext) &&
                       paramInfos[1].ParameterType == typeof(Exception) &&
                       method.ReturnType == typeof(Task);
            }

            return false;
        }

        public async Task ExecuteAsync(HttpContext context, Exception exception)
        {
            if (dictionary.Keys.Any(item=> item == exception.GetType()))
            {
                var method = dictionary[exception.GetType()];
                method.Invoke(this, new object[] { context, exception });

                await Task.CompletedTask;
            }
            else
                await context.Response.WriteAsync("Exception Hello");
        }

        [ExceptionMethos(typeof(CoreException))]
        public async Task CoreAsync(HttpContext context, Exception exception)
        {
            await context.Response.WriteAsync("Core Exception Hello");
        }
    }

    internal class CoreException : Exception
    {

    }
}
