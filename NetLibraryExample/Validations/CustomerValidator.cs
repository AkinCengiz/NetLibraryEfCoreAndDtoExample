using FluentValidation;
using NetLibraryExample.Models.ORM;

namespace NetLibraryExample.Validations;

public class CustomerValidator : AbstractValidator<Customer>
{
    public string NotEmptyMessage { get; } = "{PropertyName} alanı boş olamaz...";
    public CustomerValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage(NotEmptyMessage).MinimumLength(3).WithMessage("{PropertyName} en az 3 karakter girilmelidir...");
        RuleFor(x => x.Email).NotEmpty().WithMessage(NotEmptyMessage).EmailAddress()
            .WithMessage("Email formatında değer girmelisiniz...");
    }
}
