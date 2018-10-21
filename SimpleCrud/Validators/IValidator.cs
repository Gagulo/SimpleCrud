namespace SimpleCrud.Validators
{
    interface IValidator<T>
    {
        ValidateResult Validate(string key, T param);
    }

    public class ValidateResult
    {
        public string Key { get; set; }
        public string Message { get; set; }
    }
}
