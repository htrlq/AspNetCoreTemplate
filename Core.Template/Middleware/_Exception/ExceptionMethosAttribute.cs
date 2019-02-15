using System;

namespace Core.Template.Middleware._Exception
{
    /// <summary>
    /// Exception Methos
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class ExceptionMethodAttribute : Attribute
    {
        /// <summary>
        /// Exception Type
        /// </summary>
        public Type ExceptionType { get; }

        /// <summary>
        /// Generate
        /// </summary>
        /// <param name="type"></param>
        public ExceptionMethodAttribute(Type type)
        {
            if (!type.IsSubclassOf(typeof(Exception)))
                throw new Exception($"Type Nof Inherit From Exceptoion");

            ExceptionType = type;
        }
    }
}
