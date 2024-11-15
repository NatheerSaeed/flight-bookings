using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class RolesServiceBase : IRolesService
{
    protected readonly FlightReservationManagementDbContext _context;

    public RolesServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Roles
    /// </summary>
    public async Task<Roles> CreateRole(RoleCreateInput inputDto)
    {
        var roles = new Role
        {
            CreatedAt = inputDto.CreatedAt,
            Description = inputDto.Description,
            DisplayName = inputDto.DisplayName,
            Name = inputDto.Name,
            PermissionId = inputDto.PermissionId,
            UpdatedAt = inputDto.UpdatedAt
        };

        if (inputDto.Id != null)
        {
            roles.Id = inputDto.Id;
        }
        if (inputDto.HotelsItems != null)
        {
            roles.HotelsItems = await _context
                .HotelsItems.Where(hotels =>
                    inputDto.HotelsItems.Select(t => t.Id).Contains(hotels.Id)
                )
                .ToListAsync();
        }

        if (inputDto.MarkupsItems != null)
        {
            roles.MarkupsItems = await _context
                .MarkupsItems.Where(markups =>
                    inputDto.MarkupsItems.Select(t => t.Id).Contains(markups.Id)
                )
                .ToListAsync();
        }

        if (inputDto.Role != null)
        {
            roles.ContainerRole = await _context
                .RolesItems.Where(roles => inputDto.Role.Id == roles.Id)
                .FirstOrDefaultAsync();
        }

        if (inputDto.RolesItems != null)
        {
            roles.RolesItems = await _context
                .RolesItems.Where(roles => inputDto.RolesItems.Select(t => t.Id).Contains(roles.Id))
                .ToListAsync();
        }

        _context.RolesItems.Add(roles);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<Role>(roles.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Roles
    /// </summary>
    public async Task DeleteRole(RolesWhereUniqueInput uniqueId)
    {
        var roles = await _context.RolesItems.FindAsync(uniqueId.Id);
        if (roles == null)
        {
            throw new NotFoundException();
        }

        _context.RolesItems.Remove(roles);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many RolesItems
    /// </summary>
    public async Task<List<Roles>> RolesSearchAsync(RoleFindManyArgs findManyArgs)
    {
        var rolesItems = await _context
            .RolesItems.Include(x => x.ContainerRole)
            .Include(x => x.HotelsItems)
            .Include(x => x.MarkupsItems)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return rolesItems.ConvertAll(roles => roles.ToDto());
    }

    /// <summary>
    /// Meta data about Roles records
    /// </summary>
    public async Task<MetadataDto> RolesItemsMeta(RoleFindManyArgs findManyArgs)
    {
        var count = await _context.RolesItems.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Roles
    /// </summary>
    public async Task<Roles> Roles(RolesWhereUniqueInput uniqueId)
    {
        var rolesItems = await this.RolesSearchAsync(
            new RoleFindManyArgs { Where = new RoleWhereInput { Id = uniqueId.Id } }
        );
        var roles = rolesItems.FirstOrDefault();
        if (roles == null)
        {
            throw new NotFoundException();
        }

        return roles;
    }

    /// <summary>
    /// Update one Roles
    /// </summary>
    public async Task UpdateRole(RolesWhereUniqueInput uniqueId, RoleUpdateInput updateDto)
    {
        var roles = updateDto.ToModel(uniqueId);

        if (updateDto.HotelsItems != null)
        {
            roles.HotelsItems = await _context
                .HotelsItems.Where(hotels =>
                    updateDto.HotelsItems.Select(t => t).Contains(hotels.Id)
                )
                .ToListAsync();
        }

        if (updateDto.MarkupsItems != null)
        {
            roles.MarkupsItems = await _context
                .MarkupsItems.Where(markups =>
                    updateDto.MarkupsItems.Select(t => t).Contains(markups.Id)
                )
                .ToListAsync();
        }

        if (updateDto.Role != null)
        {
            roles.ContainerRole = await _context
                .RolesItems.Where(roles => updateDto.Role == roles.Id)
                .FirstOrDefaultAsync();
        }

        if (updateDto.RolesItems != null)
        {
            roles.RolesItems = await _context
                .RolesItems.Where(roles => updateDto.RolesItems.Select(t => t).Contains(roles.Id))
                .ToListAsync();
        }

        _context.Entry(roles).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.RolesItems.Any(e => e.Id == roles.Id))
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
    /// Connect multiple HotelsItems records to Roles
    /// </summary>
    public async Task ConnectHotelsSearchAsync(
        RolesWhereUniqueInput uniqueId,
        HotelsWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .RolesItems.Include(x => x.HotelsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .HotelsItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.HotelsItems);

        foreach (var child in childrenToConnect)
        {
            parent.HotelsItems.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple HotelsItems records from Roles
    /// </summary>
    public async Task DisconnectHotelsSearchAsync(
        RolesWhereUniqueInput uniqueId,
        HotelsWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .RolesItems.Include(x => x.HotelsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .HotelsItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.HotelsItems?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple HotelsItems records for Roles
    /// </summary>
    public async Task<List<Hotels>> FindHotelsSearchAsync(
        RolesWhereUniqueInput uniqueId,
        HotelFindManyArgs roleFindManyArgs
    )
    {
        var hotelsItems = await _context
            .HotelsItems.Where(m => m.RoleId == uniqueId.Id)
            .ApplyWhere(roleFindManyArgs.Where)
            .ApplySkip(roleFindManyArgs.Skip)
            .ApplyTake(roleFindManyArgs.Take)
            .ApplyOrderBy(roleFindManyArgs.SortBy)
            .ToListAsync();

        return hotelsItems.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple HotelsItems records for Roles
    /// </summary>
    public async Task UpdateHotelsItem(
        RolesWhereUniqueInput uniqueId,
        HotelsWhereUniqueInput[] childrenIds
    )
    {
        var roles = await _context
            .RolesItems.Include(t => t.HotelsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (roles == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .HotelsItems.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        roles.HotelsItems = children;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple MarkupsItems records to Roles
    /// </summary>
    public async Task ConnectMarkupsSearchAsync(
        RolesWhereUniqueInput uniqueId,
        MarkupsWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .RolesItems.Include(x => x.MarkupsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .MarkupsItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.MarkupsItems);

        foreach (var child in childrenToConnect)
        {
            parent.MarkupsItems.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple MarkupsItems records from Roles
    /// </summary>
    public async Task DisconnectMarkupsSearchAsync(
        RolesWhereUniqueInput uniqueId,
        MarkupsWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .RolesItems.Include(x => x.MarkupsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .MarkupsItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.MarkupsItems?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple MarkupsItems records for Roles
    /// </summary>
    public async Task<List<Markups>> FindMarkupsSearchAsync(
        RolesWhereUniqueInput uniqueId,
        MarkupFindManyArgs roleFindManyArgs
    )
    {
        var markupsItems = await _context
            .MarkupsItems.Where(m => m.RoleId == uniqueId.Id)
            .ApplyWhere(roleFindManyArgs.Where)
            .ApplySkip(roleFindManyArgs.Skip)
            .ApplyTake(roleFindManyArgs.Take)
            .ApplyOrderBy(roleFindManyArgs.SortBy)
            .ToListAsync();

        return markupsItems.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple MarkupsItems records for Roles
    /// </summary>
    public async Task UpdateMarkupsItem(
        RolesWhereUniqueInput uniqueId,
        MarkupsWhereUniqueInput[] childrenIds
    )
    {
        var roles = await _context
            .RolesItems.Include(t => t.MarkupsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (roles == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .MarkupsItems.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        roles.MarkupsItems = children;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Get a role_ record for Roles
    /// </summary>
    public async Task<Roles> GetRole(RolesWhereUniqueInput uniqueId)
    {
        var roles = await _context
            .RolesItems.Where(roles => roles.Id == uniqueId.Id)
            .Include(roles => roles.ContainerRole)
            .FirstOrDefaultAsync();
        if (roles == null)
        {
            throw new NotFoundException();
        }
        return roles.ContainerRole.ToDto();
    }

    /// <summary>
    /// Connect multiple RolesItems records to Roles
    /// </summary>
    public async Task ConnectRolesSearchAsync(
        RolesWhereUniqueInput uniqueId,
        RolesWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .RolesItems.Include(x => x.RolesItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .RolesItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.RolesItems);

        foreach (var child in childrenToConnect)
        {
            parent.RolesItems.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple RolesItems records from Roles
    /// </summary>
    public async Task DisconnectRolesSearchAsync(
        RolesWhereUniqueInput uniqueId,
        RolesWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .RolesItems.Include(x => x.RolesItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .RolesItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.RolesItems?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple RolesItems records for Roles
    /// </summary>
    public async Task<List<Roles>> FindRolesSearchAsync(
        RolesWhereUniqueInput uniqueId,
        RoleFindManyArgs roleFindManyArgs
    )
    {
        var rolesItems = await _context
            .RolesItems.Where(m => m.RoleId == uniqueId.Id)
            .ApplyWhere(roleFindManyArgs.Where)
            .ApplySkip(roleFindManyArgs.Skip)
            .ApplyTake(roleFindManyArgs.Take)
            .ApplyOrderBy(roleFindManyArgs.SortBy)
            .ToListAsync();

        return rolesItems.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple RolesItems records for Roles
    /// </summary>
    public async Task UpdateRolesItem(
        RolesWhereUniqueInput uniqueId,
        RolesWhereUniqueInput[] childrenIds
    )
    {
        var roles = await _context
            .RolesItems.Include(t => t.RolesItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (roles == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .RolesItems.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        roles.RolesItems = children;
        await _context.SaveChangesAsync();
    }
}
