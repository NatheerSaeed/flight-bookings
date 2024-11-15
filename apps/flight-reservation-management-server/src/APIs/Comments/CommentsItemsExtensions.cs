using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class CommentsItemsExtensions
{
    public static Comments ToDto(this CommentsDbModel model)
    {
        return new Comments
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static CommentsDbModel ToModel(
        this CommentsUpdateInput updateDto,
        CommentsWhereUniqueInput uniqueId
    )
    {
        var comments = new CommentsDbModel { Id = uniqueId.Id };

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
