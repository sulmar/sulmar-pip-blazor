using System.ComponentModel.DataAnnotations;

namespace BlazorServerApp.Validations;

public class DateGreaterThanAttribute : ValidationAttribute
{
    private readonly string _otherPropertyName;
    public DateGreaterThanAttribute(string otherPropertyName)
    {
        _otherPropertyName = otherPropertyName;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var otherPropertyInfo = validationContext.ObjectType.GetProperty(_otherPropertyName);

        if (otherPropertyInfo == null)
        {
            return new ValidationResult($"Unkown property: {_otherPropertyName}");
        }
        
        var otherPropertyValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance);

        if (value is DateTime dateValue && otherPropertyValue is DateTime otherDateValue)
        {
            if (dateValue <= otherDateValue)
            {
                return new ValidationResult($"Data {validationContext.DisplayName} musi być większa od {otherPropertyInfo.Name}.");
            }
        }

        return ValidationResult.Success;

    }
}
