namespace Application.Parameters;

public record PaginatedRequestParameters()
{
	public string? SearchParameter { get; set; }
	public string? SortColumn { get; set; }
	public string? SortOrder { get; set; }
	public bool All { get; set; }
	public int Page { get; set; }
	public int PageSize { get; set; }
}
