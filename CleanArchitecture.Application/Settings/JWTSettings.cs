﻿namespace Application.Settings;

public class JWTSettings
{
	public string Key { get; set; } = null!;
	public string Issuer { get; set; } = null!;
	public string Audience { get; set; } = null!;
	public string DurationInMinutes { get; set; } = null!;
}
