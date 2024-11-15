using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class CabinTypesItemsExtensions
{
    public static CabinTypes ToDto(this CabinTypesDbModel model)
    {
        return new CabinTypes
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static CabinTypesDbModel ToModel(
        this CabinTypesUpdateInput updateDto,
        CabinTypesWhereUniqueInput uniqueId
    )
    {
        var cabinTypes = new CabinTypesDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            cabinTypes.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            cabinTypes.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return cabinTypes;
    }
}
