using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class HotelsItemsExtensions
{
    public static Hotels ToDto(this HotelsDbModel model)
    {
        return new Hotels
        {
            CarMarkupType = model.CarMarkupType,
            CarMarkupValue = model.CarMarkupValue,
            Code = model.Code,
            CreatedAt = model.CreatedAt,
            FlightMarkupType = model.FlightMarkupType,
            FlightMarkupValue = model.FlightMarkupValue,
            HotelMarkupType = model.HotelMarkupType,
            HotelMarkupValue = model.HotelMarkupValue,
            IcaoCode = model.IcaoCode,
            Id = model.Id,
            Name = model.Name,
            PackageMarkupType = model.PackageMarkupType,
            PackageMarkupValue = model.PackageMarkupValue,
            Role = model.RoleId,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static HotelsDbModel ToModel(
        this HotelsUpdateInput updateDto,
        HotelsWhereUniqueInput uniqueId
    )
    {
        var hotels = new HotelsDbModel
        {
            Id = uniqueId.Id,
            CarMarkupType = updateDto.CarMarkupType,
            CarMarkupValue = updateDto.CarMarkupValue,
            Code = updateDto.Code,
            FlightMarkupType = updateDto.FlightMarkupType,
            FlightMarkupValue = updateDto.FlightMarkupValue,
            HotelMarkupType = updateDto.HotelMarkupType,
            HotelMarkupValue = updateDto.HotelMarkupValue,
            IcaoCode = updateDto.IcaoCode,
            Name = updateDto.Name,
            PackageMarkupType = updateDto.PackageMarkupType,
            PackageMarkupValue = updateDto.PackageMarkupValue
        };

        if (updateDto.CreatedAt != null)
        {
            hotels.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.Role != null)
        {
            hotels.RoleId = updateDto.Role;
        }
        if (updateDto.UpdatedAt != null)
        {
            hotels.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return hotels;
    }
}
