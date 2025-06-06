namespace Data.Models;

public class BookingResult
{
    public bool Success { get; set; }
    public string? Error { get; set; }
    public int? StatusCode { get; set; }
}

public class BookingResult<T> : BookingResult
{
    public T? Result { get; set; }
}
