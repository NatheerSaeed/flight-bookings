using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class RolesItemsServiceBase : IRolesItemsService
{
    protected readonly FlightReservationManagementDbContext _context;

    public RolesItemsServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Roles
    /// </summary>
    public async Task<Roles> CreateRoles(RolesCreateInput createDto)
    {
        var roles = new RolesDbModel
        {
            CreatedAt = createDto.CreatedAt,
            Description = createDto.Description,
            DisplayName = createDto.DisplayName,
            Name = createDto.Name,
            PermissionId = createDto.PermissionId,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            roles.Id = createDto.Id;
        }
        if (createDto.HotelsItems != null)
        {
            roles.HotelsItems = await _context
                .HotelsItems.Where(hotels =>
                    createDto.HotelsItems.Select(t => t.Id).Contains(hotels.Id)
                )
                .ToListAsync();
        }

        if (createDto.Role != null)
        {
            roles.Role = await _context
                .RolesItems.Where(roles => createDto.Role.Id == roles.Id)
                .FirstOrDefaultAsync();
        }

        if (createDto.RolesItems != null)
        {
            roles.RolesItems = await _context
                .RolesItems.Where(roles =>
                    createDto.RolesItems.Select(t => t.Id).Contains(roles.Id)
                )
                .ToListAsync();
        }

        _context.RolesItems.Add(roles);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<RolesDbModel>(roles.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Roles
    /// </summary>
    public async Task DeleteRoles(RolesWhereUniqueInput uniqueId)
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
    public async Task<List<Roles>> RolesItems(RolesFindManyArgs findManyArgs)
    {
        var rolesItems = await _context
            .RolesItems.Include(x => x.HotelsItems)
            .Include(x => x.Role)
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
    public async Task<MetadataDto> RolesItemsMeta(RolesFindManyArgs findManyArgs)
    {
        var count = await _context.RolesItems.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Roles
    /// </summary>
    public async Task<Roles> Roles(RolesWhereUniqueInput uniqueId)
    {
        var rolesItems = await this.RolesItems(
            new RolesFindManyArgs { Where = new RolesWhereInput { Id = uniqueId.Id } }
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
    public async Task UpdateRoles(RolesWhereUniqueInput uniqueId, RolesUpdateInput updateDto)
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

        if (updateDto.Role != null)
        {
            roles.Role = await _context
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
    public async Task ConnectHotelsItems(
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
    public async Task DisconnectHotelsItems(
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
    public async Task<List<Hotels>> FindHotelsItems(
        RolesWhereUniqueInput uniqueId,
        HotelsFindManyArgs rolesFindManyArgs
    )
    {
        var hotelsItems = await _context
            .HotelsItems.Where(m => m.RoleId == uniqueId.Id)
            .ApplyWhere(rolesFindManyArgs.Where)
            .ApplySkip(rolesFindManyArgs.Skip)
            .ApplyTake(rolesFindManyArgs.Take)
            .ApplyOrderBy(rolesFindManyArgs.SortBy)
            .ToListAsync();

        return hotelsItems.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple HotelsItems records for Roles
    /// </summary>
    public async Task UpdateHotelsItems(
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
    /// Get a role_ record for Roles
    /// </summary>
    public async Task<Roles> GetRole(RolesWhereUniqueInput uniqueId)
    {
        var roles = await _context
            .RolesItems.Where(roles => roles.Id == uniqueId.Id)
            .Include(roles => roles.Role)
            .FirstOrDefaultAsync();
        if (roles == null)
        {
            throw new NotFoundException();
        }
        return roles.Role.ToDto();
    }

    /// <summary>
    /// Connect multiple RolesItems records to Roles
    /// </summary>
    public async Task ConnectRolesItems(
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
    public async Task DisconnectRolesItems(
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
    public async Task<List<Roles>> FindRolesItems(
        RolesWhereUniqueInput uniqueId,
        RolesFindManyArgs rolesFindManyArgs
    )
    {
        var rolesItems = await _context
            .RolesItems.Where(m => m.RoleId == uniqueId.Id)
            .ApplyWhere(rolesFindManyArgs.Where)
            .ApplySkip(rolesFindManyArgs.Skip)
            .ApplyTake(rolesFindManyArgs.Take)
            .ApplyOrderBy(rolesFindManyArgs.SortBy)
            .ToListAsync();

        return rolesItems.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple RolesItems records for Roles
    /// </summary>
    public async Task UpdateRolesItems(
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
