using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class RolesExtensions
{
    public static Role ToDto(this RoleDbModel model)
    {
        return new Role
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static RoleDbModel ToModel(this RoleUpdateInput updateDto, RoleWhereUniqueInput uniqueId)
    {
        var role = new RoleDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            role.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            role.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return role;
    }
}
