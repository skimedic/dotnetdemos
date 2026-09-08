// Copyright Information
// ==================================
// AutoLot-WebApps - AutoLot.Services - MustBeGreaterThanZeroAttribute.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/07
// ==================================

namespace AutoLot.Services.Validation;

public class MustBeGreaterThanZeroAttribute(
    string errorMessage) : ValidationAttribute(errorMessage),
    IClientModelValidator
{
    public MustBeGreaterThanZeroAttribute() : this("{0} must be greater than 0")
    {
    }

    public override string FormatErrorMessage(
        string name) =>
        string.Format(
            ErrorMessageString,
            name);

    protected override ValidationResult IsValid(
        object value,
        ValidationContext validationContext)
    {
        if (value is not int intValue)
        {
            return new ValidationResult(
                FormatErrorMessage(validationContext.DisplayName),
                [
                    validationContext.MemberName
                ]);
        }

        return intValue <= 0
            ? new ValidationResult(
                FormatErrorMessage(validationContext.DisplayName),
                [
                    validationContext.MemberName
                ])
            : ValidationResult.Success;
    }

    public void AddValidation(
        ClientModelValidationContext context)
    {
        string propertyDisplayName = context.ModelMetadata.DisplayName ?? context.ModelMetadata.PropertyName;
        string errorMessage = FormatErrorMessage(propertyDisplayName);
        context.Attributes.Add(
            "data-val-greaterthanzero",
            errorMessage);
        context.Attributes.Add(
            "data-val-greaterthanzero-reevaluate",
            "true");
    }
}