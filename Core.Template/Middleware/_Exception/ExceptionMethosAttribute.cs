using System;

namespace Core.Template.Middleware._Exception
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ExceptionMethosAttribute : Attribute
    {
        public Type ExceptionType { get; }

        public ExceptionMethosAttribute(Type type)
        {
            if (!type.IsSubclassOf(typeof(Exception)))
                throw new Exception($"Type Nof Inherit From Exceptoion");

            ExceptionType = type;
        }
    }
}
