using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class EmailSubscribersItemsExtensions
{
    public static EmailSubscribers ToDto(this EmailSubscribersDbModel model)
    {
        return new EmailSubscribers
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static EmailSubscribersDbModel ToModel(
        this EmailSubscribersUpdateInput updateDto,
        EmailSubscribersWhereUniqueInput uniqueId
    )
    {
        var emailSubscribers = new EmailSubscribersDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            emailSubscribers.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            emailSubscribers.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return emailSubscribers;
    }
}
