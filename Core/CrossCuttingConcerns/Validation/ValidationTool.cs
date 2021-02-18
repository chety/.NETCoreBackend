using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    //Another implementation
    //public class ValidationTool<TEntity, TValidator> where TValidator : AbstractValidator<TEntity>, new()
    //{
    //    public static void Validate(TEntity entity)
    //    {
    //        var context = new ValidationContext<TEntity>(entity);
    //        var validator = new TValidator();
    //        var result = validator.Validate(context);
    //        if (!result.IsValid) throw new ValidationException(result.Errors);
    //    }
    //}

    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid) throw new ValidationException(result.Errors);
        }
    }
}