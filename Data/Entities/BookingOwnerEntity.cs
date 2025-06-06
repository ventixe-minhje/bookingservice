using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class BookingOwnerEntity
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;

    [ForeignKey(nameof(Adress))]
    public string? BookingAdressId { get; set; }
    public BookingAdressEntity? Adress { get; set; } 
}
