
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace GradeTaskApp.Users
{
	public class EmailValidatorAttribute : ValidationAttribute
	{
        private readonly static Regex emailRegex = new(@"[\w\d.-_]{3,}@[\w-]{2,}.[\w]{2,}");
        public override bool IsValid(object? value)
        {
            if (value is string email)
            {
                if (emailRegex.IsMatch(email))
                    return true;
                else
                    ErrorMessage = "email должен иметь формат xxx@xxx.xx и не может содержать спецсимволы";
            }
            return false;
        }
    }
}