﻿namespace Application.Settings;

public sealed class JWTSettings
{
	public required string Key { get; set; }
	public required string Issuer { get; set; }
	public required string Audience { get; set; }
	public required string DurationInMinutes { get; set; }
}
