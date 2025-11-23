using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Prova.Api.Utils
{
    public class PasswordValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$");

            if (regex.IsMatch(value.ToString()))
            {
                return true;
            }

            return false;
        }
    }
}

