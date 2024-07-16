namespace Authorization.Api.Services.Authentication.Request
{
    public class SignUpEmployee
    {
        public Guid EmployeeId { get; set; }
        public string Token { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
