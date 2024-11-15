using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IRolesService
{
    /// <summary>
    /// Create one Roles
    /// </summary>
    public Task<Roles> CreateRole(RoleCreateInput roles);

    /// <summary>
    /// Delete one Roles
    /// </summary>
    public Task DeleteRole(RolesWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many RolesItems
    /// </summary>
    public Task<List<Roles>> RolesSearchAsync(RoleFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Roles records
    /// </summary>
    public Task<MetadataDto> RolesItemsMeta(RoleFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Roles
    /// </summary>
    public Task<Roles> Roles(RolesWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Roles
    /// </summary>
    public Task UpdateRole(RolesWhereUniqueInput uniqueId, RoleUpdateInput updateDto);

    /// <summary>
    /// Connect multiple HotelsItems records to Roles
    /// </summary>
    public Task ConnectHotelsSearchAsync(
        RolesWhereUniqueInput uniqueId,
        HotelsWhereUniqueInput[] hotelsId
    );

    /// <summary>
    /// Disconnect multiple HotelsItems records from Roles
    /// </summary>
    public Task DisconnectHotelsSearchAsync(
        RolesWhereUniqueInput uniqueId,
        HotelsWhereUniqueInput[] hotelsId
    );

    /// <summary>
    /// Find multiple HotelsItems records for Roles
    /// </summary>
    public Task<List<Hotels>> FindHotelsSearchAsync(
        RolesWhereUniqueInput uniqueId,
        HotelFindManyArgs HotelFindManyArgs
    );

    /// <summary>
    /// Update multiple HotelsItems records for Roles
    /// </summary>
    public Task UpdateHotelsItem(RolesWhereUniqueInput uniqueId, HotelsWhereUniqueInput[] hotelsId);

    /// <summary>
    /// Connect multiple MarkupsItems records to Roles
    /// </summary>
    public Task ConnectMarkupsSearchAsync(
        RolesWhereUniqueInput uniqueId,
        MarkupsWhereUniqueInput[] markupsId
    );

    /// <summary>
    /// Disconnect multiple MarkupsItems records from Roles
    /// </summary>
    public Task DisconnectMarkupsSearchAsync(
        RolesWhereUniqueInput uniqueId,
        MarkupsWhereUniqueInput[] markupsId
    );

    /// <summary>
    /// Find multiple MarkupsItems records for Roles
    /// </summary>
    public Task<List<Markups>> FindMarkupsSearchAsync(
        RolesWhereUniqueInput uniqueId,
        MarkupFindManyArgs MarkupFindManyArgs
    );

    /// <summary>
    /// Update multiple MarkupsItems records for Roles
    /// </summary>
    public Task UpdateMarkupsItem(
        RolesWhereUniqueInput uniqueId,
        MarkupsWhereUniqueInput[] markupsId
    );

    /// <summary>
    /// Get a role_ record for Roles
    /// </summary>
    public Task<Roles> GetRole(RolesWhereUniqueInput uniqueId);

    /// <summary>
    /// Connect multiple RolesItems records to Roles
    /// </summary>
    public Task ConnectRolesSearchAsync(
        RolesWhereUniqueInput uniqueId,
        RolesWhereUniqueInput[] rolesId
    );

    /// <summary>
    /// Disconnect multiple RolesItems records from Roles
    /// </summary>
    public Task DisconnectRolesSearchAsync(
        RolesWhereUniqueInput uniqueId,
        RolesWhereUniqueInput[] rolesId
    );

    /// <summary>
    /// Find multiple RolesItems records for Roles
    /// </summary>
    public Task<List<Roles>> FindRolesSearchAsync(
        RolesWhereUniqueInput uniqueId,
        RoleFindManyArgs RoleFindManyArgs
    );

    /// <summary>
    /// Update multiple RolesItems records for Roles
    /// </summary>
    public Task UpdateRolesItem(RolesWhereUniqueInput uniqueId, RolesWhereUniqueInput[] rolesId);
}
