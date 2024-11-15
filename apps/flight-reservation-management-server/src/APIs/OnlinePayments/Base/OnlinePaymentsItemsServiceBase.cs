using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class OnlinePaymentsItemsServiceBase : IOnlinePaymentsItemsService
{
    protected readonly FlightReservationManagementDbContext _context;

    public OnlinePaymentsItemsServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one OnlinePayments
    /// </summary>
    public async Task<OnlinePayments> CreateOnlinePayments(OnlinePaymentsCreateInput createDto)
    {
        var onlinePayments = new OnlinePaymentsDbModel
        {
            Amount = createDto.Amount,
            BookingReference = createDto.BookingReference,
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
            onlinePayments.Id = createDto.Id;
        }
        if (createDto.User != null)
        {
            onlinePayments.User = await _context
                .Users.Where(user => createDto.User.Id == user.Id)
                .FirstOrDefaultAsync();
        }

        _context.OnlinePaymentsItems.Add(onlinePayments);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<OnlinePaymentsDbModel>(onlinePayments.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one OnlinePayments
    /// </summary>
    public async Task DeleteOnlinePayments(OnlinePaymentsWhereUniqueInput uniqueId)
    {
        var onlinePayments = await _context.OnlinePaymentsItems.FindAsync(uniqueId.Id);
        if (onlinePayments == null)
        {
            throw new NotFoundException();
        }

        _context.OnlinePaymentsItems.Remove(onlinePayments);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many OnlinePaymentsItems
    /// </summary>
    public async Task<List<OnlinePayments>> OnlinePaymentsItems(
        OnlinePaymentsFindManyArgs findManyArgs
    )
    {
        var onlinePaymentsItems = await _context
            .OnlinePaymentsItems.Include(x => x.User)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return onlinePaymentsItems.ConvertAll(onlinePayments => onlinePayments.ToDto());
    }

    /// <summary>
    /// Meta data about OnlinePayments records
    /// </summary>
    public async Task<MetadataDto> OnlinePaymentsItemsMeta(OnlinePaymentsFindManyArgs findManyArgs)
    {
        var count = await _context.OnlinePaymentsItems.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one OnlinePayments
    /// </summary>
    public async Task<OnlinePayments> OnlinePayments(OnlinePaymentsWhereUniqueInput uniqueId)
    {
        var onlinePaymentsItems = await this.OnlinePaymentsItems(
            new OnlinePaymentsFindManyArgs
            {
                Where = new OnlinePaymentsWhereInput { Id = uniqueId.Id }
            }
        );
        var onlinePayments = onlinePaymentsItems.FirstOrDefault();
        if (onlinePayments == null)
        {
            throw new NotFoundException();
        }

        return onlinePayments;
    }

    /// <summary>
    /// Update one OnlinePayments
    /// </summary>
    public async Task UpdateOnlinePayments(
        OnlinePaymentsWhereUniqueInput uniqueId,
        OnlinePaymentsUpdateInput updateDto
    )
    {
        var onlinePayments = updateDto.ToModel(uniqueId);

        if (updateDto.User != null)
        {
            onlinePayments.User = await _context
                .Users.Where(user => updateDto.User == user.Id)
                .FirstOrDefaultAsync();
        }

        _context.Entry(onlinePayments).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.OnlinePaymentsItems.Any(e => e.Id == onlinePayments.Id))
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
    /// Get a user_ record for OnlinePayments
    /// </summary>
    public async Task<User> GetUser(OnlinePaymentsWhereUniqueInput uniqueId)
    {
        var onlinePayments = await _context
            .OnlinePaymentsItems.Where(onlinePayments => onlinePayments.Id == uniqueId.Id)
            .Include(onlinePayments => onlinePayments.User)
            .FirstOrDefaultAsync();
        if (onlinePayments == null)
        {
            throw new NotFoundException();
        }
        return onlinePayments.User.ToDto();
    }
}
