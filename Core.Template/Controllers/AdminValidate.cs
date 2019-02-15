using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace Core.Template.Controllers
{
    /// <summary>
    /// Admin Validate
    /// </summary>
    public class AdminValidate
    {
        /// <summary>
        /// Ordinary Validate
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        public static ValidationResult Ordinary(object value, ValidationContext validationContext)
        {
            if (value is AdminRequestModel model)
            {
                if (!model.User.Equals(model.Account))
                {
                    var logger = validationContext.GetService(typeof(ILogger<AdminValidate>)) as ILogger<AdminValidate>;

                    logger.LogError("User not equals Account");

                    return new ValidationResult("User not equals Account");
                }

                return ValidationResult.Success;
            }

            return new ValidationResult("Type Error");
        }
    }
}
