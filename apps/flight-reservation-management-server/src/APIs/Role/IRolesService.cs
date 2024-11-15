using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IRolesService
{
    /// <summary>
    /// Create one Role
    /// </summary>
    public Task<Role> CreateRole(RoleCreateInput role);

    /// <summary>
    /// Delete one Role
    /// </summary>
    public Task DeleteRole(RoleWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Roles
    /// </summary>
    public Task<List<Role>> Roles(RoleFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Role records
    /// </summary>
    public Task<MetadataDto> RolesMeta(RoleFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Role
    /// </summary>
    public Task<Role> Role(RoleWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Role
    /// </summary>
    public Task UpdateRole(RoleWhereUniqueInput uniqueId, RoleUpdateInput updateDto);
}
