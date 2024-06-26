﻿using Application.Exceptions;
using Application.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Application.Services.Jwt;

public class JwtService : IJwtService
{
	private readonly IHttpContextAccessor _httpContextAccessor;
	private readonly JWTSettings _jwtSettings;

	public JwtService(IHttpContextAccessor httpContextAccessor, IOptions<JWTSettings> jwtSettings)
	{
		_httpContextAccessor = httpContextAccessor;
		_jwtSettings = jwtSettings.Value;
	}

	public string GetSubjectToken()
	{
		string token;
		if (_httpContextAccessor.HttpContext is null)
		{
			throw new ApiException("Ocurrio un problema en los encabezados de esta solicitud.");
		}
		else
		{
			string username = _httpContextAccessor.HttpContext.Request.Headers["Authorization"]!;
			token = username.Split(" ")[1];
		}

		var tokenHandler = new JwtSecurityTokenHandler();
		var key = Encoding.UTF8.GetBytes(_jwtSettings.Key);
		var validationParameters = new TokenValidationParameters();

		validationParameters.ValidateLifetime = true;
		validationParameters.ValidAudience = _jwtSettings.Audience;
		validationParameters.ValidIssuer = _jwtSettings.Issuer;
		validationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));

		tokenHandler.ValidateToken(token, new TokenValidationParameters
		{
			ValidateIssuerSigningKey = true,
			IssuerSigningKey = new SymmetricSecurityKey(key),
			ValidateIssuer = false,
			ValidateAudience = false,
			ClockSkew = TimeSpan.Zero
		}, out SecurityToken validatedToken);

		var jwtToken = (JwtSecurityToken)validatedToken;
		var name = jwtToken.Claims.First(x => x.Type == "sub").Value;

		return name;
	}

	public Guid GetUidToken()
	{
		string token;

		if (_httpContextAccessor.HttpContext == null)
		{
			throw new ApiException("Ocurrio un problema en los encabezados de esta solicitud.");
		}
		else
		{
			string username = _httpContextAccessor.HttpContext.Request.Headers["Authorization"]!;
			token = username.Split(" ")[1];
		}

		var tokenHandler = new JwtSecurityTokenHandler();
		var key = Encoding.UTF8.GetBytes(_jwtSettings.Key);
		var validationParameters = new TokenValidationParameters();

		validationParameters.ValidateLifetime = true;
		validationParameters.ValidAudience = _jwtSettings.Audience;
		validationParameters.ValidIssuer = _jwtSettings.Issuer;
		validationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));

		tokenHandler.ValidateToken(token, new TokenValidationParameters
		{
			ValidateIssuerSigningKey = true,
			IssuerSigningKey = new SymmetricSecurityKey(key),
			ValidateIssuer = false,
			ValidateAudience = false,
			ClockSkew = TimeSpan.Zero
		}, out SecurityToken validatedToken);

		var jwtToken = (JwtSecurityToken)validatedToken;
		var guid = Guid.Parse(jwtToken.Claims.First(x => x.Type == "uid").Value);

		return guid;
	}
}
