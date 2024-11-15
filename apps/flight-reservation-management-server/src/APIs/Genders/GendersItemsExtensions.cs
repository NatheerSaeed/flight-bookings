using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class GendersItemsExtensions
{
    public static Genders ToDto(this Gender model)
    {
        return new Genders
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            ProfilesItems = model.ProfilesItems?.Select(x => x.Id).ToList(),
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static Gender ToModel(this GenderUpdateInput updateDto, GendersWhereUniqueInput uniqueId)
    {
        var genders = new Gender { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            genders.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            genders.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return genders;
    }
}
