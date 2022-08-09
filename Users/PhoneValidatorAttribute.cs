
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace GradeTaskApp.Users
{
	public class PhoneValidatorAttribute : ValidationAttribute
	{
        private readonly static Regex phoneRegex = new(@"\+7\([\d]{3}\)\s[\d]{3}-[\d]{2}-[\d]{2}");
        public override bool IsValid(object? value)
        {
            if (value is string phone)
            {
                if (phoneRegex.IsMatch(phone))
                    return true;
                else
                    ErrorMessage = "Телефон должен иметь формат +7(999) 999-99-99";
            }
            return false;
        }


    }
}