using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class CommentsServiceBase : ICommentsService
{
    protected readonly FlightReservationManagementDbContext _context;

    public CommentsServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Comments
    /// </summary>
    public async Task<Comments> CreateComments(CommentCreateInput inputDto)
    {
        var comments = new Comment
        {
            Content = inputDto.Content,
            CreatedAt = inputDto.CreatedAt,
            Email = inputDto.Email,
            Ip = inputDto.Ip,
            Name = inputDto.Name,
            UpdatedAt = inputDto.UpdatedAt
        };

        if (inputDto.Id != null)
        {
            comments.Id = inputDto.Id;
        }

        _context.CommentsItems.Add(comments);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<Comment>(comments.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Comments
    /// </summary>
    public async Task DeleteComments(CommentsWhereUniqueInput uniqueId)
    {
        var comments = await _context.CommentsItems.FindAsync(uniqueId.Id);
        if (comments == null)
        {
            throw new NotFoundException();
        }

        _context.CommentsItems.Remove(comments);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many CommentsItems
    /// </summary>
    public async Task<List<Comments>> CommentsItems(CommentFindManyArgs findManyArgs)
    {
        var commentsItems = await _context
            .CommentsItems.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return commentsItems.ConvertAll(comments => comments.ToDto());
    }

    /// <summary>
    /// Meta data about Comments records
    /// </summary>
    public async Task<MetadataDto> CommentsItemsMeta(CommentFindManyArgs findManyArgs)
    {
        var count = await _context.CommentsItems.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Comments
    /// </summary>
    public async Task<Comments> Comments(CommentsWhereUniqueInput uniqueId)
    {
        var commentsItems = await this.CommentsItems(
            new CommentFindManyArgs { Where = new CommentWhereInput { Id = uniqueId.Id } }
        );
        var comments = commentsItems.FirstOrDefault();
        if (comments == null)
        {
            throw new NotFoundException();
        }

        return comments;
    }

    /// <summary>
    /// Update one Comments
    /// </summary>
    public async Task UpdateComments(
        CommentsWhereUniqueInput uniqueId,
        CommentUpdateInput updateDto
    )
    {
        var comments = updateDto.ToModel(uniqueId);

        _context.Entry(comments).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.CommentsItems.Any(e => e.Id == comments.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
