using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class FlightDealsItemsExtensions
{
    public static FlightDeals ToDto(this FlightDeal model)
    {
        return new FlightDeals
        {
            Airline = model.Airline,
            Cabin = model.Cabin,
            CreatedAt = model.CreatedAt,
            Date = model.Date,
            Destination = model.Destination,
            Id = model.Id,
            Information = model.Information,
            Origin = model.Origin,
            PackageField = model.PackageFieldId,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static FlightDeal ToModel(
        this FlightDealUpdateInput updateDto,
        FlightDealsWhereUniqueInput uniqueId
    )
    {
        var flightDeals = new FlightDeal
        {
            Id = uniqueId.Id,
            Airline = updateDto.Airline,
            Cabin = updateDto.Cabin,
            Date = updateDto.Date,
            Destination = updateDto.Destination,
            Information = updateDto.Information,
            Origin = updateDto.Origin
        };

        if (updateDto.CreatedAt != null)
        {
            flightDeals.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.PackageField != null)
        {
            flightDeals.PackageFieldId = updateDto.PackageField;
        }
        if (updateDto.UpdatedAt != null)
        {
            flightDeals.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return flightDeals;
    }
}
