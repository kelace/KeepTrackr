namespace Authorization.Api.Models.Requests
{
    public class InviteSignUpRequest
    {
        public Guid UserId { get; set; }
        public string Token { get; set; }
    }
}
