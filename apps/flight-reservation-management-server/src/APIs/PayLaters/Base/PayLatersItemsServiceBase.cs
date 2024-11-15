using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class PayLatersServiceBase : IPayLatersService
{
    protected readonly FlightReservationManagementDbContext _context;

    public PayLatersServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one PayLaters
    /// </summary>
    public async Task<PayLaters> CreatePayLater(PayLaterCreateInput inputDto)
    {
        var payLaters = new PayLater
        {
            Amount = inputDto.Amount,
            BankDetailId = inputDto.BankDetailId,
            BookingReference = inputDto.BookingReference,
            CreatedAt = inputDto.CreatedAt,
            Reference = inputDto.Reference,
            SlipPhoto = inputDto.SlipPhoto,
            Status = inputDto.Status,
            UpdatedAt = inputDto.UpdatedAt
        };

        if (inputDto.Id != null)
        {
            payLaters.Id = inputDto.Id;
        }
        if (inputDto.User != null)
        {
            payLaters.User = await _context
                .Users.Where(user => inputDto.User.Id == user.Id)
                .FirstOrDefaultAsync();
        }

        _context.PayLatersItems.Add(payLaters);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<PayLater>(payLaters.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one PayLaters
    /// </summary>
    public async Task DeletePayLater(PayLatersWhereUniqueInput uniqueId)
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
    public async Task<List<PayLaters>> PayLatersSearchAsync(PayLaterFindManyArgs findManyArgs)
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
    public async Task<MetadataDto> PayLatersItemsMeta(PayLaterFindManyArgs findManyArgs)
    {
        var count = await _context.PayLatersItems.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one PayLaters
    /// </summary>
    public async Task<PayLaters> PayLaters(PayLatersWhereUniqueInput uniqueId)
    {
        var payLatersItems = await this.PayLatersSearchAsync(
            new PayLaterFindManyArgs { Where = new PayLaterWhereInput { Id = uniqueId.Id } }
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
    public async Task UpdatePayLater(
        PayLatersWhereUniqueInput uniqueId,
        PayLaterUpdateInput updateDto
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
