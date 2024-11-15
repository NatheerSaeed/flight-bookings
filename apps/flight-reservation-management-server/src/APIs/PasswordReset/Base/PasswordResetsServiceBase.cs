using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class PasswordResetsServiceBase : IPasswordResetsService
{
    protected readonly FlightReservationManagementDbContext _context;

    public PasswordResetsServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one PasswordReset
    /// </summary>
    public async Task<PasswordReset> CreatePasswordReset(PasswordResetCreateInput createDto)
    {
        var passwordReset = new PasswordResetDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            passwordReset.Id = createDto.Id;
        }

        _context.PasswordResets.Add(passwordReset);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<PasswordResetDbModel>(passwordReset.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one PasswordReset
    /// </summary>
    public async Task DeletePasswordReset(PasswordResetWhereUniqueInput uniqueId)
    {
        var passwordReset = await _context.PasswordResets.FindAsync(uniqueId.Id);
        if (passwordReset == null)
        {
            throw new NotFoundException();
        }

        _context.PasswordResets.Remove(passwordReset);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many PasswordResets
    /// </summary>
    public async Task<List<PasswordReset>> PasswordResets(PasswordResetFindManyArgs findManyArgs)
    {
        var passwordResets = await _context
            .PasswordResets.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return passwordResets.ConvertAll(passwordReset => passwordReset.ToDto());
    }

    /// <summary>
    /// Meta data about PasswordReset records
    /// </summary>
    public async Task<MetadataDto> PasswordResetsMeta(PasswordResetFindManyArgs findManyArgs)
    {
        var count = await _context.PasswordResets.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one PasswordReset
    /// </summary>
    public async Task<PasswordReset> PasswordReset(PasswordResetWhereUniqueInput uniqueId)
    {
        var passwordResets = await this.PasswordResets(
            new PasswordResetFindManyArgs
            {
                Where = new PasswordResetWhereInput { Id = uniqueId.Id }
            }
        );
        var passwordReset = passwordResets.FirstOrDefault();
        if (passwordReset == null)
        {
            throw new NotFoundException();
        }

        return passwordReset;
    }

    /// <summary>
    /// Update one PasswordReset
    /// </summary>
    public async Task UpdatePasswordReset(
        PasswordResetWhereUniqueInput uniqueId,
        PasswordResetUpdateInput updateDto
    )
    {
        var passwordReset = updateDto.ToModel(uniqueId);

        _context.Entry(passwordReset).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.PasswordResets.Any(e => e.Id == passwordReset.Id))
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
