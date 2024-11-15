using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class PackageFlightsItemsExtensions
{
    public static PackageFlights ToDto(this PackageFlightsDbModel model)
    {
        return new PackageFlights
        {
            Airline = model.Airline,
            ArrivalDateTime = model.ArrivalDateTime,
            CreatedAt = model.CreatedAt,
            DepartureDateTime = model.DepartureDateTime,
            FromLocation = model.FromLocation,
            Id = model.Id,
            PackageField = model.PackageFieldId,
            ToLocation = model.ToLocation,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static PackageFlightsDbModel ToModel(
        this PackageFlightsUpdateInput updateDto,
        PackageFlightsWhereUniqueInput uniqueId
    )
    {
        var packageFlights = new PackageFlightsDbModel
        {
            Id = uniqueId.Id,
            Airline = updateDto.Airline,
            ArrivalDateTime = updateDto.ArrivalDateTime,
            DepartureDateTime = updateDto.DepartureDateTime,
            FromLocation = updateDto.FromLocation,
            ToLocation = updateDto.ToLocation
        };

        if (updateDto.CreatedAt != null)
        {
            packageFlights.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.PackageField != null)
        {
            packageFlights.PackageFieldId = updateDto.PackageField;
        }
        if (updateDto.UpdatedAt != null)
        {
            packageFlights.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return packageFlights;
    }
}
