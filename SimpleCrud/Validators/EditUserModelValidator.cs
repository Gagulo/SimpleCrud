using SimpleCrud.Models;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCrud.Validators
{
    public class EditUserModelValidator : IValidator<EditUserModel>
    {
        public IEnumerable<ValidateResult> Validate(EditUserModel model)
        {
            var result = new List<ValidateResult>();
            var firstName = model.FirstName?.Trim();
            var lastName = model.LastName?.Trim();

            if (HasStringContainsDigit(firstName))
            {
                result.Add(new ValidateResult
                {
                    Key = nameof(model.FirstName),
                    Message = "Name contains digits!"
                });
            }

            if (HasStringContainsDigit(lastName))
            {
                result.Add(new ValidateResult
                {
                    Key = nameof(model.LastName),
                    Message = "Last Name contains digits!"
                });
            }
            return result;
        }

        public bool HasStringContainsDigit(string word)
        {
            return word?.Any(char.IsDigit) ?? false;
        }
    }
}