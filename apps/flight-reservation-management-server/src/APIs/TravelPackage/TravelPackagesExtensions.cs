using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class TravelPackagesExtensions
{
    public static TravelPackage ToDto(this TravelPackageDbModel model)
    {
        return new TravelPackage
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static TravelPackageDbModel ToModel(
        this TravelPackageUpdateInput updateDto,
        TravelPackageWhereUniqueInput uniqueId
    )
    {
        var travelPackage = new TravelPackageDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            travelPackage.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            travelPackage.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return travelPackage;
    }
}
