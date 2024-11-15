using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class PasswordResetsExtensions
{
    public static PasswordReset ToDto(this PasswordResetDbModel model)
    {
        return new PasswordReset
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static PasswordResetDbModel ToModel(
        this PasswordResetUpdateInput updateDto,
        PasswordResetWhereUniqueInput uniqueId
    )
    {
        var passwordReset = new PasswordResetDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            passwordReset.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            passwordReset.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return passwordReset;
    }
}
