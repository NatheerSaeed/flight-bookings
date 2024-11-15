using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class PackagesItemsExtensions
{
    public static Packages ToDto(this PackagesDbModel model)
    {
        return new Packages
        {
            AttractionsItems = model.AttractionsItems?.Select(x => x.Id).ToList(),
            CreatedAt = model.CreatedAt,
            FlightDealsItems = model.FlightDealsItems?.Select(x => x.Id).ToList(),
            HotelDealsItems = model.HotelDealsItems?.Select(x => x.Id).ToList(),
            Id = model.Id,
            PackageFlightsItems = model.PackageFlightsItems?.Select(x => x.Id).ToList(),
            PackageHotelsItems = model.PackageHotelsItems?.Select(x => x.Id).ToList(),
            SightSeeingsItems = model.SightSeeingsItems?.Select(x => x.Id).ToList(),
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static PackagesDbModel ToModel(
        this PackagesUpdateInput updateDto,
        PackagesWhereUniqueInput uniqueId
    )
    {
        var packages = new PackagesDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            packages.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            packages.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return packages;
    }
}
