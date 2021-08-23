using FluentValidation;

namespace WebApi.BookOperations.GetBooks
{
    public class GetByIdBookQueryValidator : AbstractValidator<GetByIdBookQuery>
    {
        public GetByIdBookQueryValidator()
        {
            RuleFor(validator=>validator.Id).GreaterThan(0);
        }
    }
}