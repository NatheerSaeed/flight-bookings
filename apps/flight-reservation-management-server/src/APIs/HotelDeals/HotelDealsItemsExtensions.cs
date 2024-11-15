using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class HotelDealsItemsExtensions
{
    public static HotelDeals ToDto(this HotelDealsDbModel model)
    {
        return new HotelDeals
        {
            Address = model.Address,
            City = model.City,
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            Information = model.Information,
            Name = model.Name,
            PackageField = model.PackageFieldId,
            StarRating = model.StarRating,
            StayDuration = model.StayDuration,
            StayEndDate = model.StayEndDate,
            StayStartDate = model.StayStartDate,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static HotelDealsDbModel ToModel(
        this HotelDealsUpdateInput updateDto,
        HotelDealsWhereUniqueInput uniqueId
    )
    {
        var hotelDeals = new HotelDealsDbModel
        {
            Id = uniqueId.Id,
            Address = updateDto.Address,
            City = updateDto.City,
            Information = updateDto.Information,
            Name = updateDto.Name,
            StarRating = updateDto.StarRating,
            StayDuration = updateDto.StayDuration,
            StayEndDate = updateDto.StayEndDate,
            StayStartDate = updateDto.StayStartDate
        };

        if (updateDto.CreatedAt != null)
        {
            hotelDeals.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.PackageField != null)
        {
            hotelDeals.PackageFieldId = updateDto.PackageField;
        }
        if (updateDto.UpdatedAt != null)
        {
            hotelDeals.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return hotelDeals;
    }
}
