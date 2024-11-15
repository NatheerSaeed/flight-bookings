using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class AirlinesItemsServiceBase : IAirlinesItemsService
{
    protected readonly FlightReservationManagementDbContext _context;

    public AirlinesItemsServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Airlines
    /// </summary>
    public async Task<Airlines> CreateAirlines(AirlinesCreateInput createDto)
    {
        var airlines = new AirlinesDbModel
        {
            Amount = createDto.Amount,
            CreatedAt = createDto.CreatedAt,
            PaymentStatus = createDto.PaymentStatus,
            Reference = createDto.Reference,
            ResponseCode = createDto.ResponseCode,
            ResponseDescription = createDto.ResponseDescription,
            ResponseFull = createDto.ResponseFull,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            airlines.Id = createDto.Id;
        }
        if (createDto.User != null)
        {
            airlines.User = await _context
                .Users.Where(user => createDto.User.Id == user.Id)
                .FirstOrDefaultAsync();
        }

        _context.AirlinesItems.Add(airlines);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<AirlinesDbModel>(airlines.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Airlines
    /// </summary>
    public async Task DeleteAirlines(AirlinesWhereUniqueInput uniqueId)
    {
        var airlines = await _context.AirlinesItems.FindAsync(uniqueId.Id);
        if (airlines == null)
        {
            throw new NotFoundException();
        }

        _context.AirlinesItems.Remove(airlines);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many AirlinesItems
    /// </summary>
    public async Task<List<Airlines>> AirlinesItems(AirlinesFindManyArgs findManyArgs)
    {
        var airlinesItems = await _context
            .AirlinesItems.Include(x => x.User)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return airlinesItems.ConvertAll(airlines => airlines.ToDto());
    }

    /// <summary>
    /// Meta data about Airlines records
    /// </summary>
    public async Task<MetadataDto> AirlinesItemsMeta(AirlinesFindManyArgs findManyArgs)
    {
        var count = await _context.AirlinesItems.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Airlines
    /// </summary>
    public async Task<Airlines> Airlines(AirlinesWhereUniqueInput uniqueId)
    {
        var airlinesItems = await this.AirlinesItems(
            new AirlinesFindManyArgs { Where = new AirlinesWhereInput { Id = uniqueId.Id } }
        );
        var airlines = airlinesItems.FirstOrDefault();
        if (airlines == null)
        {
            throw new NotFoundException();
        }

        return airlines;
    }

    /// <summary>
    /// Update one Airlines
    /// </summary>
    public async Task UpdateAirlines(
        AirlinesWhereUniqueInput uniqueId,
        AirlinesUpdateInput updateDto
    )
    {
        var airlines = updateDto.ToModel(uniqueId);

        if (updateDto.User != null)
        {
            airlines.User = await _context
                .Users.Where(user => updateDto.User == user.Id)
                .FirstOrDefaultAsync();
        }

        _context.Entry(airlines).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.AirlinesItems.Any(e => e.Id == airlines.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }

    /// <summary>
    /// Get a user_ record for Airlines
    /// </summary>
    public async Task<User> GetUser(AirlinesWhereUniqueInput uniqueId)
    {
        var airlines = await _context
            .AirlinesItems.Where(airlines => airlines.Id == uniqueId.Id)
            .Include(airlines => airlines.User)
            .FirstOrDefaultAsync();
        if (airlines == null)
        {
            throw new NotFoundException();
        }
        return airlines.User.ToDto();
    }
}
