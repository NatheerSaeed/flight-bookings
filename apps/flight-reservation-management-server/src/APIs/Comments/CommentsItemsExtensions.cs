using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class CommentsItemsExtensions
{
    public static Comments ToDto(this CommentsDbModel model)
    {
        return new Comments
        {
            Content = model.Content,
            CreatedAt = model.CreatedAt,
            Email = model.Email,
            Id = model.Id,
            Ip = model.Ip,
            Name = model.Name,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static CommentsDbModel ToModel(
        this CommentsUpdateInput updateDto,
        CommentsWhereUniqueInput uniqueId
    )
    {
        var comments = new CommentsDbModel
        {
            Id = uniqueId.Id,
            Content = updateDto.Content,
            Email = updateDto.Email,
            Ip = updateDto.Ip,
            Name = updateDto.Name
        };

        if (updateDto.CreatedAt != null)
        {
            comments.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            comments.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return comments;
    }
}
