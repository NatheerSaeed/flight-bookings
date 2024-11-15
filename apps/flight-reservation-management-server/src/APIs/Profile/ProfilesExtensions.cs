using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class ProfilesExtensions
{
    public static Profile ToDto(this ProfileDbModel model)
    {
        return new Profile
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static ProfileDbModel ToModel(
        this ProfileUpdateInput updateDto,
        ProfileWhereUniqueInput uniqueId
    )
    {
        var profile = new ProfileDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            profile.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            profile.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return profile;
    }
}
