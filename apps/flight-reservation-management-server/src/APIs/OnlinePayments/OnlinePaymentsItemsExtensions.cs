using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class OnlinePaymentsItemsExtensions
{
    public static OnlinePayments ToDto(this OnlinePaymentsDbModel model)
    {
        return new OnlinePayments
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static OnlinePaymentsDbModel ToModel(
        this OnlinePaymentsUpdateInput updateDto,
        OnlinePaymentsWhereUniqueInput uniqueId
    )
    {
        var onlinePayments = new OnlinePaymentsDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            onlinePayments.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            onlinePayments.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return onlinePayments;
    }
}
