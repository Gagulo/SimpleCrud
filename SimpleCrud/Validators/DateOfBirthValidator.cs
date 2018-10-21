using System;

namespace SimpleCrud.Validators
{
    public class DateOfBirthValidator : IValidator<DateTime>
    {
        public ValidateResult Validate(string key, DateTime param)
        {
            var now = DateTime.UtcNow;

            var yearDifference = now.Year - param.Year;

            if(yearDifference <= 10)
            {
                return new ValidateResult
                {
                    Key = key,
                    Message = "U must be older then 10yo."
                };
            }
            return null;
        }
    }
}