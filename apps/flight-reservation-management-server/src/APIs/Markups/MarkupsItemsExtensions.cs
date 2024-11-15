using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class MarkupsItemsExtensions
{
    public static Markups ToDto(this Markup model)
    {
        return new Markups
        {
            CarMarkupType = model.CarMarkupType,
            CarMarkupValue = model.CarMarkupValue,
            CreatedAt = model.CreatedAt,
            FlightMarkupType = model.FlightMarkupType,
            FlightMarkupValue = model.FlightMarkupValue,
            HotelMarkupType = model.HotelMarkupType,
            HotelMarkupValue = model.HotelMarkupValue,
            Id = model.Id,
            PackageMarkupType = model.PackageMarkupType,
            PackageMarkupValue = model.PackageMarkupValue,
            Role = model.RoleId,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static Markup ToModel(this MarkupUpdateInput updateDto, MarkupsWhereUniqueInput uniqueId)
    {
        var markups = new Markup
        {
            Id = uniqueId.Id,
            CarMarkupType = updateDto.CarMarkupType,
            CarMarkupValue = updateDto.CarMarkupValue,
            FlightMarkupType = updateDto.FlightMarkupType,
            FlightMarkupValue = updateDto.FlightMarkupValue,
            HotelMarkupType = updateDto.HotelMarkupType,
            HotelMarkupValue = updateDto.HotelMarkupValue,
            PackageMarkupType = updateDto.PackageMarkupType,
            PackageMarkupValue = updateDto.PackageMarkupValue
        };

        if (updateDto.CreatedAt != null)
        {
            markups.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.Role != null)
        {
            markups.RoleId = updateDto.Role;
        }
        if (updateDto.UpdatedAt != null)
        {
            markups.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return markups;
    }
}
