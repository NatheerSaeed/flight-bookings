using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class TravelPackagesItemsExtensions
{
    public static TravelPackages ToDto(this TravelPackagesDbModel model)
    {
        return new TravelPackages
        {
            AdultPrice = model.AdultPrice,
            Attraction = model.Attraction,
            CategoryId = model.CategoryId,
            ChildPrice = model.ChildPrice,
            CreatedAt = model.CreatedAt,
            Flight = model.Flight,
            Hotel = model.Hotel,
            Id = model.Id,
            InfantPrice = model.InfantPrice,
            Information = model.Information,
            Name = model.Name,
            PhoneNumber = model.PhoneNumber,
            Status = model.Status,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static TravelPackagesDbModel ToModel(
        this TravelPackagesUpdateInput updateDto,
        TravelPackagesWhereUniqueInput uniqueId
    )
    {
        var travelPackages = new TravelPackagesDbModel
        {
            Id = uniqueId.Id,
            AdultPrice = updateDto.AdultPrice,
            Attraction = updateDto.Attraction,
            CategoryId = updateDto.CategoryId,
            ChildPrice = updateDto.ChildPrice,
            Flight = updateDto.Flight,
            Hotel = updateDto.Hotel,
            InfantPrice = updateDto.InfantPrice,
            Information = updateDto.Information,
            Name = updateDto.Name,
            PhoneNumber = updateDto.PhoneNumber,
            Status = updateDto.Status
        };

        if (updateDto.CreatedAt != null)
        {
            travelPackages.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            travelPackages.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return travelPackages;
    }
}
