using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class PackageTypesItemsExtensions
{
    public static PackageTypes ToDto(this PackageType model)
    {
        return new PackageTypes
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            Status = model.Status,
            TypeField = model.TypeField,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static PackageType ToModel(
        this PackageTypeUpdateInput updateDto,
        PackageTypesWhereUniqueInput uniqueId
    )
    {
        var packageTypes = new PackageType
        {
            Id = uniqueId.Id,
            Status = updateDto.Status,
            TypeField = updateDto.TypeField
        };

        if (updateDto.CreatedAt != null)
        {
            packageTypes.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            packageTypes.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return packageTypes;
    }
}
