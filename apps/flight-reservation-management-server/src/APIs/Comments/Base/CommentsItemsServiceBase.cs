using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class CommentsItemsServiceBase : ICommentsItemsService
{
    protected readonly FlightReservationManagementDbContext _context;

    public CommentsItemsServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Comments
    /// </summary>
    public async Task<Comments> CreateComments(CommentsCreateInput createDto)
    {
        var comments = new CommentsDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            comments.Id = createDto.Id;
        }

        _context.CommentsItems.Add(comments);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<CommentsDbModel>(comments.Id);

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
    public async Task<List<Comments>> CommentsItems(CommentsFindManyArgs findManyArgs)
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
    public async Task<MetadataDto> CommentsItemsMeta(CommentsFindManyArgs findManyArgs)
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
            new CommentsFindManyArgs { Where = new CommentsWhereInput { Id = uniqueId.Id } }
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
        CommentsUpdateInput updateDto
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
