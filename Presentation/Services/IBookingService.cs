using Data.Models;

namespace Presentation.Services
{
    public interface IBookingService
    {
        Task<BookingResult> CreateBookingAsync(CreateBookingRequest request);
    }
}