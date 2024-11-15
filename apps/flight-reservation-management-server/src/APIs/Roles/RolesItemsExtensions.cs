using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class RolesItemsExtensions
{
    public static Roles ToDto(this RolesDbModel model)
    {
        return new Roles
        {
            CreatedAt = model.CreatedAt,
            Description = model.Description,
            DisplayName = model.DisplayName,
            HotelsItems = model.HotelsItems?.Select(x => x.Id).ToList(),
            Id = model.Id,
            MarkupsItems = model.MarkupsItems?.Select(x => x.Id).ToList(),
            Name = model.Name,
            PermissionId = model.PermissionId,
            Role = model.RoleId,
            RolesItems = model.RolesItems?.Select(x => x.Id).ToList(),
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static RolesDbModel ToModel(
        this RolesUpdateInput updateDto,
        RolesWhereUniqueInput uniqueId
    )
    {
        var roles = new RolesDbModel
        {
            Id = uniqueId.Id,
            Description = updateDto.Description,
            DisplayName = updateDto.DisplayName,
            Name = updateDto.Name,
            PermissionId = updateDto.PermissionId
        };

        if (updateDto.CreatedAt != null)
        {
            roles.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.Role != null)
        {
            roles.RoleId = updateDto.Role;
        }
        if (updateDto.UpdatedAt != null)
        {
            roles.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return roles;
    }
}
