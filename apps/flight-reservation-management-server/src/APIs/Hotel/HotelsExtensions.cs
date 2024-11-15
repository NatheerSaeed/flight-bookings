using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class HotelsExtensions
{
    public static Hotel ToDto(this HotelDbModel model)
    {
        return new Hotel
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static HotelDbModel ToModel(
        this HotelUpdateInput updateDto,
        HotelWhereUniqueInput uniqueId
    )
    {
        var hotel = new HotelDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            hotel.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            hotel.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return hotel;
    }
}
