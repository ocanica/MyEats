using Microsoft.AspNetCore.Http.Features.Authentication;
using MyEats.Business.Models;
using MyEats.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace MyEats.Business.Services.Contracts
{
    public interface IAuthenticationService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
    }
}
