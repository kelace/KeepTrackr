﻿namespace Authorization.Api.Services.Authentication
{
    public class SignInUser
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
