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
            Email = model.Email,
            Id = model.Id,
            IpAddress = model.IpAddress,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static EmailSubscribersDbModel ToModel(
        this EmailSubscriberUpdateInput updateDto,
        EmailSubscribersWhereUniqueInput uniqueId
    )
    {
        var emailSubscribers = new EmailSubscribersDbModel
        {
            Id = uniqueId.Id,
            Email = updateDto.Email,
            IpAddress = updateDto.IpAddress
        };

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
