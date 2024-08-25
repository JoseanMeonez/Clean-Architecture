using Application.Exceptions;
using Application.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Application.Services.Jwt;

public class JwtService(IHttpContextAccessor httpContextAccessor, IOptions<JWTSettings> jwtSettings) : IJwtService
{
	public string GetSubjectToken()
	{
		string token;

		if (httpContextAccessor.HttpContext is null)
		{
			throw new ApiException("Ocurrio un problema en los encabezados de esta solicitud.");
		}
		else
		{
			string username = httpContextAccessor.HttpContext.Request.Headers.Authorization!;
			token = username.Split(" ")[1];
		}

		JwtSecurityTokenHandler tokenHandler = new();
		byte[] key = Encoding.UTF8.GetBytes(jwtSettings.Value.Key);

		TokenValidationParameters validationParameters = new()
		{
			ValidateLifetime = true,
			ValidAudience = jwtSettings.Value.Audience,
			ValidIssuer = jwtSettings.Value.Issuer,
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Value.Key))
		};

		tokenHandler.ValidateToken(token, new TokenValidationParameters
		{
			ValidateIssuerSigningKey = true,
			IssuerSigningKey = new SymmetricSecurityKey(key),
			ValidateIssuer = false,
			ValidateAudience = false,
			ClockSkew = TimeSpan.Zero
		}, out SecurityToken validatedToken);

		JwtSecurityToken jwtToken = (JwtSecurityToken)validatedToken;
		string name = jwtToken.Claims.First(x => x.Type == "sub").Value;

		return name;
	}

	public Guid GetUidToken()
	{
		string token;

		if (httpContextAccessor.HttpContext == null)
		{
			throw new ApiException("Ocurrio un problema en los encabezados de esta solicitud.");
		}
		else
		{
			string username = httpContextAccessor.HttpContext.Request.Headers.Authorization!;
			token = username.Split(" ")[1];
		}

		JwtSecurityTokenHandler tokenHandler = new();
		byte[] key = Encoding.UTF8.GetBytes(jwtSettings.Value.Key);

		TokenValidationParameters validationParameters = new()
		{
			ValidateLifetime = true,
			ValidAudience = jwtSettings.Value.Audience,
			ValidIssuer = jwtSettings.Value.Issuer,
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Value.Key))
		};

		tokenHandler.ValidateToken(token, new TokenValidationParameters
		{
			ValidateIssuerSigningKey = true,
			IssuerSigningKey = new SymmetricSecurityKey(key),
			ValidateIssuer = false,
			ValidateAudience = false,
			ClockSkew = TimeSpan.Zero
		}, out SecurityToken validatedToken);

		JwtSecurityToken jwtToken = (JwtSecurityToken)validatedToken;
		Guid guid = Guid.Parse(jwtToken.Claims.First(x => x.Type == "uid").Value);

		return guid;
	}
}
