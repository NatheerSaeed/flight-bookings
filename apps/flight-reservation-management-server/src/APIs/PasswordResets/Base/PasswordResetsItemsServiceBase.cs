using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class PasswordResetsItemsServiceBase : IPasswordResetsItemsService
{
    protected readonly FlightReservationManagementDbContext _context;

    public PasswordResetsItemsServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one PasswordResets
    /// </summary>
    public async Task<PasswordResets> CreatePasswordResets(PasswordResetsCreateInput createDto)
    {
        var passwordResets = new PasswordResetsDbModel
        {
            CreatedAt = createDto.CreatedAt,
            Email = createDto.Email,
            Token = createDto.Token,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            passwordResets.Id = createDto.Id;
        }

        _context.PasswordResetsItems.Add(passwordResets);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<PasswordResetsDbModel>(passwordResets.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one PasswordResets
    /// </summary>
    public async Task DeletePasswordResets(PasswordResetsWhereUniqueInput uniqueId)
    {
        var passwordResets = await _context.PasswordResetsItems.FindAsync(uniqueId.Id);
        if (passwordResets == null)
        {
            throw new NotFoundException();
        }

        _context.PasswordResetsItems.Remove(passwordResets);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many PasswordResetsItems
    /// </summary>
    public async Task<List<PasswordResets>> PasswordResetsItems(
        PasswordResetsFindManyArgs findManyArgs
    )
    {
        var passwordResetsItems = await _context
            .PasswordResetsItems.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return passwordResetsItems.ConvertAll(passwordResets => passwordResets.ToDto());
    }

    /// <summary>
    /// Meta data about PasswordResets records
    /// </summary>
    public async Task<MetadataDto> PasswordResetsItemsMeta(PasswordResetsFindManyArgs findManyArgs)
    {
        var count = await _context.PasswordResetsItems.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one PasswordResets
    /// </summary>
    public async Task<PasswordResets> PasswordResets(PasswordResetsWhereUniqueInput uniqueId)
    {
        var passwordResetsItems = await this.PasswordResetsItems(
            new PasswordResetsFindManyArgs
            {
                Where = new PasswordResetsWhereInput { Id = uniqueId.Id }
            }
        );
        var passwordResets = passwordResetsItems.FirstOrDefault();
        if (passwordResets == null)
        {
            throw new NotFoundException();
        }

        return passwordResets;
    }

    /// <summary>
    /// Update one PasswordResets
    /// </summary>
    public async Task UpdatePasswordResets(
        PasswordResetsWhereUniqueInput uniqueId,
        PasswordResetsUpdateInput updateDto
    )
    {
        var passwordResets = updateDto.ToModel(uniqueId);

        _context.Entry(passwordResets).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.PasswordResetsItems.Any(e => e.Id == passwordResets.Id))
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
