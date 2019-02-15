using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Template.Controllers
{
    /// <summary>
    /// Admin Request Model
    /// </summary>
    [AdminCheck]
    [CustomValidation(typeof(AdminValidate), "Ordinary")]
    public class AdminRequestModel
    {
        /// <summary>
        /// User
        /// </summary>
        [Required]
        public string User { get; set; }

        /// <summary>
        /// Account
        /// </summary>
        [Required]
        public string Account { get; set; }
    }

    /// <summary>
    /// Admin Check
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class AdminCheckAttribute: ValidationAttribute
    {
        ///// <summary>
        ///// Format Error Message
        ///// </summary>
        ///// <param name="name"></param>
        ///// <returns></returns>
        //public override string FormatErrorMessage(string name)
        //{
        //    return $"User not equals Account, {name} Error";
        //}

        ///// <summary>
        ///// Is Valid
        ///// </summary>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public override bool IsValid(object value)
        //{
        //    if (value is AdminRequestModel model)
        //    {
        //        return model.User.Equals(model.Account);
        //    }

        //    return false;
        //}

        /// <summary>
        ///  Is Valid
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
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
