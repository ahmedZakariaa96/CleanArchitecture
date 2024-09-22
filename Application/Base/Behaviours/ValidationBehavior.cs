namespace Application.Base.Behaviours
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            // Check if there are any validators
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                // Run all validators asynchronously
                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                // If there are validation errors, return a failure result
                if (failures.Count != 0)
                {
                    // Concatenate error messages into a single formatted string
                    var errorMessage = string.Join(", ", failures.Select(f => $"{f.ErrorCode} , {f.PropertyName}: {f.ErrorMessage}"));

                    // Assuming TResponse is of type Result<string>, you need to cast appropriately
                    if (typeof(TResponse) == typeof(Result<string>))
                    {
                        // Return a validation failure result
                        return (TResponse)(object)Result<string>.Falid(null, errorMessage);
                    }

                    // You can customize handling for different types of TResponse if needed
                }
            }

            // Continue with the next behavior in the pipeline
            return await next();
        }
    }
}
