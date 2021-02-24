using MyEats.Business.Models.Authentication;

namespace MyEats.Business.Services
{
    public interface IAuthenticationService
    {
        AuthenticationModel Authenticate(AuthenticateRequest model);
    }
}
