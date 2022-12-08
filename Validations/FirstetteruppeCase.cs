using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Validations
{
    public class FirstetteruppeCase:ValidationAttribute

    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            // este deja pasar el caso de que el ussurio no ponga nada o el elemento sea null
            // ya que no tiene sentido validar en esos casos
            if (value == null ||string.IsNullOrEmpty(value.ToString())) 
            {
                return ValidationResult.Success; 
            }

            var firstLetter = value.ToString()[0].ToString();
            if (firstLetter != firstLetter.ToUpper())
            {
                return new ValidationResult("The first letter must be Upper case");
            }
            return ValidationResult.Success;
        }
    }
}
