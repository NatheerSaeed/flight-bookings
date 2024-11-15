using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class TitlesItemsExtensions
{
    public static Titles ToDto(this TitlesDbModel model)
    {
        return new Titles
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            ProfilesItems = model.ProfilesItems?.Select(x => x.Id).ToList(),
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static TitlesDbModel ToModel(
        this TitlesUpdateInput updateDto,
        TitlesWhereUniqueInput uniqueId
    )
    {
        var titles = new TitlesDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            titles.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            titles.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return titles;
    }
}
