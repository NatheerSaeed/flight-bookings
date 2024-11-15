using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface ICommentsService
{
    /// <summary>
    /// Create one Comments
    /// </summary>
    public Task<Comments> CreateComment(CommentCreateInput comments);

    /// <summary>
    /// Delete one Comments
    /// </summary>
    public Task DeleteComment(CommentsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many CommentsItems
    /// </summary>
    public Task<List<Comments>> CommentsItems(CommentFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Comments records
    /// </summary>
    public Task<MetadataDto> CommentsItemsMeta(CommentFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Comments
    /// </summary>
    public Task<Comments> Comments(CommentsWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Comments
    /// </summary>
    public Task UpdateComment(CommentsWhereUniqueInput uniqueId, CommentUpdateInput updateDto);
}
