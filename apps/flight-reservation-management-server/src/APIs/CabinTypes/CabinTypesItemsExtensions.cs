using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class CabinTypesItemsExtensions
{
    public static CabinTypes ToDto(this CabinTypesDbModel model)
    {
        return new CabinTypes
        {
            CabinCode = model.CabinCode,
            CabinName = model.CabinName,
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static CabinTypesDbModel ToModel(
        this CabinTypeUpdateInput updateDto,
        CabinTypesWhereUniqueInput uniqueId
    )
    {
        var cabinTypes = new CabinTypesDbModel
        {
            Id = uniqueId.Id,
            CabinCode = updateDto.CabinCode,
            CabinName = updateDto.CabinName
        };

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
