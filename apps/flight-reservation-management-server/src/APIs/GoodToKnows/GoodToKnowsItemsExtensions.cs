using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class GoodToKnowsItemsExtensions
{
    public static GoodToKnows ToDto(this GoodToKnowsDbModel model)
    {
        return new GoodToKnows
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static GoodToKnowsDbModel ToModel(
        this GoodToKnowsUpdateInput updateDto,
        GoodToKnowsWhereUniqueInput uniqueId
    )
    {
        var goodToKnows = new GoodToKnowsDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            goodToKnows.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            goodToKnows.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return goodToKnows;
    }
}
