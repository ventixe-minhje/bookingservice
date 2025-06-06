using Data.Contexts;
using Data.Entities;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories;

public class BookingRepository(DataContext context) : BaseRepository<BookingEntity>(context), IBookingRepository
{
    public override async Task<RepositoryResult<IEnumerable<BookingEntity>>> GetAllAsync()
    {
        try
        {
            var entities = await _table.Include(x => x.BookingOwner).ThenInclude(x => x!.Adress).ToListAsync();
            return new RepositoryResult<IEnumerable<BookingEntity>> { Success = true, Result = entities };
        }

        catch (Exception ex)
        {
            return new RepositoryResult<IEnumerable<BookingEntity>> { Success = false, StatusCode = 400, Error = ex.Message };
        }
    }

    public override async Task<RepositoryResult> GetAsync(Expression<Func<BookingEntity, bool>> expression)
    {
        try
        {
            var entity = await _table.Include(x => x.BookingOwner).ThenInclude(x => x!.Adress).FirstOrDefaultAsync(expression) ?? throw new Exception("Not found.");
            return new RepositoryResult<BookingEntity?> { Success = true, Result = entity };
        }

        catch (Exception ex)
        {
            return new RepositoryResult<BookingEntity?> { Success = false, StatusCode = 400, Error = ex.Message };
        }
    }
}
