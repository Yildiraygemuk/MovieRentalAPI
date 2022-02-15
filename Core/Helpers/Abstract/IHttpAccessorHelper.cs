using Core.Utilities.Security.Jwt;
using Microsoft.AspNetCore.Http;
using System;

namespace Core.Helpers
{
    public interface IHttpAccessorHelper
    {
        Guid GetUserId();

        string GetUserEMail();

        string GetUserName();
        string GetJwtClaim(string claimType);
    }
}