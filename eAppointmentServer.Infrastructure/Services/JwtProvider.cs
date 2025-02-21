using eAppointment.Application.Services;
using eAppointment.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;

namespace eAppointmentServer.Infrastructure.Services;

internal sealed class JwtProvider : IJwtProvider
{
    public string CreateToken(AppUser user)
    {
        JwtSecurityToken securityToken = new(
            issuer: "",
            audience: "",
            claims: null,
            notBefore: null,
            expires: null,
            signingCredentials: null);

        JwtSecurityTokenHandler handler = new();

        string token = handler.WriteToken(securityToken);

        return token;
    }
}

