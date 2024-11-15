using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class PayLatersItemsServiceBase : IPayLatersItemsService
{
    protected readonly FlightReservationManagementDbContext _context;

    public PayLatersItemsServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one PayLaters
    /// </summary>
    public async Task<PayLaters> CreatePayLaters(PayLatersCreateInput createDto)
    {
        var payLaters = new PayLatersDbModel
        {
            Amount = createDto.Amount,
            BankDetailId = createDto.BankDetailId,
            BookingReference = createDto.BookingReference,
            CreatedAt = createDto.CreatedAt,
            Reference = createDto.Reference,
            SlipPhoto = createDto.SlipPhoto,
            Status = createDto.Status,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            payLaters.Id = createDto.Id;
        }
        if (createDto.User != null)
        {
            payLaters.User = await _context
                .Users.Where(user => createDto.User.Id == user.Id)
                .FirstOrDefaultAsync();
        }

        _context.PayLatersItems.Add(payLaters);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<PayLatersDbModel>(payLaters.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one PayLaters
    /// </summary>
    public async Task DeletePayLaters(PayLatersWhereUniqueInput uniqueId)
    {
        var payLaters = await _context.PayLatersItems.FindAsync(uniqueId.Id);
        if (payLaters == null)
        {
            throw new NotFoundException();
        }

        _context.PayLatersItems.Remove(payLaters);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many PayLatersItems
    /// </summary>
    public async Task<List<PayLaters>> PayLatersItems(PayLatersFindManyArgs findManyArgs)
    {
        var payLatersItems = await _context
            .PayLatersItems.Include(x => x.User)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return payLatersItems.ConvertAll(payLaters => payLaters.ToDto());
    }

    /// <summary>
    /// Meta data about PayLaters records
    /// </summary>
    public async Task<MetadataDto> PayLatersItemsMeta(PayLatersFindManyArgs findManyArgs)
    {
        var count = await _context.PayLatersItems.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one PayLaters
    /// </summary>
    public async Task<PayLaters> PayLaters(PayLatersWhereUniqueInput uniqueId)
    {
        var payLatersItems = await this.PayLatersItems(
            new PayLatersFindManyArgs { Where = new PayLatersWhereInput { Id = uniqueId.Id } }
        );
        var payLaters = payLatersItems.FirstOrDefault();
        if (payLaters == null)
        {
            throw new NotFoundException();
        }

        return payLaters;
    }

    /// <summary>
    /// Update one PayLaters
    /// </summary>
    public async Task UpdatePayLaters(
        PayLatersWhereUniqueInput uniqueId,
        PayLatersUpdateInput updateDto
    )
    {
        var payLaters = updateDto.ToModel(uniqueId);

        if (updateDto.User != null)
        {
            payLaters.User = await _context
                .Users.Where(user => updateDto.User == user.Id)
                .FirstOrDefaultAsync();
        }

        _context.Entry(payLaters).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.PayLatersItems.Any(e => e.Id == payLaters.Id))
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
    /// Get a user_ record for PayLaters
    /// </summary>
    public async Task<User> GetUser(PayLatersWhereUniqueInput uniqueId)
    {
        var payLaters = await _context
            .PayLatersItems.Where(payLaters => payLaters.Id == uniqueId.Id)
            .Include(payLaters => payLaters.User)
            .FirstOrDefaultAsync();
        if (payLaters == null)
        {
            throw new NotFoundException();
        }
        return payLaters.User.ToDto();
    }
}
