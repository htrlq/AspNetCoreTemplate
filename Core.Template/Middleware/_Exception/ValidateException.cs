using System;

namespace Core.Template.Middleware._Exception
{
    internal class ValidateException:Exception
    {
        public ValidateException(string message): base(message)
        {

        }
    }
}
