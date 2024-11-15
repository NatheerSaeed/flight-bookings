using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class EmailSubscribersItemsServiceBase : IEmailSubscribersItemsService
{
    protected readonly FlightReservationManagementDbContext _context;

    public EmailSubscribersItemsServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one EmailSubscribers
    /// </summary>
    public async Task<EmailSubscribers> CreateEmailSubscribers(
        EmailSubscribersCreateInput createDto
    )
    {
        var emailSubscribers = new EmailSubscribersDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            emailSubscribers.Id = createDto.Id;
        }

        _context.EmailSubscribersItems.Add(emailSubscribers);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<EmailSubscribersDbModel>(emailSubscribers.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one EmailSubscribers
    /// </summary>
    public async Task DeleteEmailSubscribers(EmailSubscribersWhereUniqueInput uniqueId)
    {
        var emailSubscribers = await _context.EmailSubscribersItems.FindAsync(uniqueId.Id);
        if (emailSubscribers == null)
        {
            throw new NotFoundException();
        }

        _context.EmailSubscribersItems.Remove(emailSubscribers);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many EmailSubscribersItems
    /// </summary>
    public async Task<List<EmailSubscribers>> EmailSubscribersItems(
        EmailSubscribersFindManyArgs findManyArgs
    )
    {
        var emailSubscribersItems = await _context
            .EmailSubscribersItems.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return emailSubscribersItems.ConvertAll(emailSubscribers => emailSubscribers.ToDto());
    }

    /// <summary>
    /// Meta data about EmailSubscribers records
    /// </summary>
    public async Task<MetadataDto> EmailSubscribersItemsMeta(
        EmailSubscribersFindManyArgs findManyArgs
    )
    {
        var count = await _context
            .EmailSubscribersItems.ApplyWhere(findManyArgs.Where)
            .CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one EmailSubscribers
    /// </summary>
    public async Task<EmailSubscribers> EmailSubscribers(EmailSubscribersWhereUniqueInput uniqueId)
    {
        var emailSubscribersItems = await this.EmailSubscribersItems(
            new EmailSubscribersFindManyArgs
            {
                Where = new EmailSubscribersWhereInput { Id = uniqueId.Id }
            }
        );
        var emailSubscribers = emailSubscribersItems.FirstOrDefault();
        if (emailSubscribers == null)
        {
            throw new NotFoundException();
        }

        return emailSubscribers;
    }

    /// <summary>
    /// Update one EmailSubscribers
    /// </summary>
    public async Task UpdateEmailSubscribers(
        EmailSubscribersWhereUniqueInput uniqueId,
        EmailSubscribersUpdateInput updateDto
    )
    {
        var emailSubscribers = updateDto.ToModel(uniqueId);

        _context.Entry(emailSubscribers).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.EmailSubscribersItems.Any(e => e.Id == emailSubscribers.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
