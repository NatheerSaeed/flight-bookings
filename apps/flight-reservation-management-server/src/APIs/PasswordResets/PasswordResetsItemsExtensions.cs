using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class PasswordResetsItemsExtensions
{
    public static PasswordResets ToDto(this PasswordResetsDbModel model)
    {
        return new PasswordResets
        {
            CreatedAt = model.CreatedAt,
            Email = model.Email,
            Id = model.Id,
            Token = model.Token,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static PasswordResetsDbModel ToModel(
        this PasswordResetsUpdateInput updateDto,
        PasswordResetsWhereUniqueInput uniqueId
    )
    {
        var passwordResets = new PasswordResetsDbModel
        {
            Id = uniqueId.Id,
            Email = updateDto.Email,
            Token = updateDto.Token
        };

        if (updateDto.CreatedAt != null)
        {
            passwordResets.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            passwordResets.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return passwordResets;
    }
}
