﻿using Microsoft.AspNetCore.Http;
using PMCS.BLL.Exceptions;
using PMCS.BLL.Interfaces.Services;
using System.Security.Claims;

namespace PMCS.BLL.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IHttpContextAccessor _context;

        public IdentityService(IHttpContextAccessor context)
        {
            ArgumentNullException.ThrowIfNull(context);

            _context = context;
        }

        public int GetUserId()
        {
            var idFromClaims = _context.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var succeed = Int32.TryParse(idFromClaims, out var id);

            if (!succeed) throw new InvalidNameIdentifierClaimException();

            return id;
        }
    }
}
