using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class MarkdownsExtensions
{
    public static Markdown ToDto(this MarkdownDbModel model)
    {
        return new Markdown
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static MarkdownDbModel ToModel(
        this MarkdownUpdateInput updateDto,
        MarkdownWhereUniqueInput uniqueId
    )
    {
        var markdown = new MarkdownDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            markdown.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            markdown.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return markdown;
    }
}
