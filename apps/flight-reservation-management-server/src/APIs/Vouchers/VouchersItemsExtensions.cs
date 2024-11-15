using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class VouchersItemsExtensions
{
    public static Vouchers ToDto(this VouchersDbModel model)
    {
        return new Vouchers
        {
            Amount = model.Amount,
            Code = model.Code,
            CreatedAt = model.CreatedAt,
            FlightBookingsItems = model.FlightBookingsItems?.Select(x => x.Id).ToList(),
            HotelBookingsItems = model.HotelBookingsItems?.Select(x => x.Id).ToList(),
            Id = model.Id,
            Status = model.Status,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static VouchersDbModel ToModel(
        this VouchersUpdateInput updateDto,
        VouchersWhereUniqueInput uniqueId
    )
    {
        var vouchers = new VouchersDbModel
        {
            Id = uniqueId.Id,
            Amount = updateDto.Amount,
            Code = updateDto.Code,
            Status = updateDto.Status
        };

        if (updateDto.CreatedAt != null)
        {
            vouchers.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            vouchers.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return vouchers;
    }
}
