using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class PackageHotelsItemsExtensions
{
    public static PackageHotels ToDto(this PackageHotelsDbModel model)
    {
        return new PackageHotels
        {
            Address = model.Address,
            CreatedAt = model.CreatedAt,
            GalleryId = model.GalleryId,
            HotelInfo = model.HotelInfo,
            HotelLocation = model.HotelLocation,
            HotelName = model.HotelName,
            HotelStarRating = model.HotelStarRating,
            Id = model.Id,
            PackageField = model.PackageFieldId,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static PackageHotelsDbModel ToModel(
        this PackageHotelUpdateInput updateDto,
        PackageHotelsWhereUniqueInput uniqueId
    )
    {
        var packageHotels = new PackageHotelsDbModel
        {
            Id = uniqueId.Id,
            Address = updateDto.Address,
            GalleryId = updateDto.GalleryId,
            HotelInfo = updateDto.HotelInfo,
            HotelLocation = updateDto.HotelLocation,
            HotelName = updateDto.HotelName,
            HotelStarRating = updateDto.HotelStarRating
        };

        if (updateDto.CreatedAt != null)
        {
            packageHotels.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.PackageField != null)
        {
            packageHotels.PackageFieldId = updateDto.PackageField;
        }
        if (updateDto.UpdatedAt != null)
        {
            packageHotels.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return packageHotels;
    }
}
