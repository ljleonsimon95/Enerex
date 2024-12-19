namespace Application.Helpers;

/// <summary>
/// Represents a paged result of a query.
/// </summary>
/// <typeparam name="T">The type of the items in the result.</typeparam>
public class PagedResult<T>
{
    /// <summary>
    /// The total number of items in the result set.
    /// </summary>
    public int TotalCount { get; set; }

    /// <summary>
    /// The number of the page in the result.
    /// </summary>
    public int PageNumber { get; set; }

    /// <summary>
    /// The number of items per page in the result.
    /// </summary>
    public int PageSize { get; set; }

    /// <summary>
    /// The total number of pages in the result set.
    /// </summary>
    public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);

    /// <summary>
    /// The items in the result.
    /// </summary>
    public IEnumerable<T> Items { get; set; }
}