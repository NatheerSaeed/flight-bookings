using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class VatsItemsExtensions
{
    public static Vats ToDto(this VatsDbModel model)
    {
        return new Vats
        {
            CarVatType = model.CarVatType,
            CarVatValue = model.CarVatValue,
            CreatedAt = model.CreatedAt,
            FlightVatType = model.FlightVatType,
            FlightVatValue = model.FlightVatValue,
            HotelVatType = model.HotelVatType,
            HotelVatValue = model.HotelVatValue,
            Id = model.Id,
            PackageVatType = model.PackageVatType,
            PackageVatValue = model.PackageVatValue,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static VatsDbModel ToModel(this VatsUpdateInput updateDto, VatsWhereUniqueInput uniqueId)
    {
        var vats = new VatsDbModel
        {
            Id = uniqueId.Id,
            CarVatType = updateDto.CarVatType,
            CarVatValue = updateDto.CarVatValue,
            FlightVatType = updateDto.FlightVatType,
            FlightVatValue = updateDto.FlightVatValue,
            HotelVatType = updateDto.HotelVatType,
            HotelVatValue = updateDto.HotelVatValue,
            PackageVatType = updateDto.PackageVatType,
            PackageVatValue = updateDto.PackageVatValue
        };

        if (updateDto.CreatedAt != null)
        {
            vats.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            vats.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return vats;
    }
}
