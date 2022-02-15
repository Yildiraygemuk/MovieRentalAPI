using Core.Utilities.Security.Jwt;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace Core.Helpers
{
    public class HttpAccessorHelper : IHttpAccessorHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpAccessorHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public Guid GetUserId()
        {
            var userId = GetJwtClaim(CustomClaimTypes.UserId);
            return string.IsNullOrEmpty(userId) ? Guid.Empty : Guid.Parse(userId);
        }
        public string GetUserEMail()
        {
            return GetJwtClaim(CustomClaimTypes.UserEmail);
        }
        public string GetUserName()
        {
            return GetJwtClaim(CustomClaimTypes.UserName);
        }
        public string GetJwtClaim(string claimType)
        {
            var claim = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == claimType)?.Value;
            return claim;
        }

    }
}