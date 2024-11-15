using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IPasswordResetsItemsService
{
    /// <summary>
    /// Create one PasswordResets
    /// </summary>
    public Task<PasswordResets> CreatePasswordResets(PasswordResetsCreateInput passwordresets);

    /// <summary>
    /// Delete one PasswordResets
    /// </summary>
    public Task DeletePasswordResets(PasswordResetsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many PasswordResetsItems
    /// </summary>
    public Task<List<PasswordResets>> PasswordResetsItems(PasswordResetsFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about PasswordResets records
    /// </summary>
    public Task<MetadataDto> PasswordResetsItemsMeta(PasswordResetsFindManyArgs findManyArgs);

    /// <summary>
    /// Get one PasswordResets
    /// </summary>
    public Task<PasswordResets> PasswordResets(PasswordResetsWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one PasswordResets
    /// </summary>
    public Task UpdatePasswordResets(
        PasswordResetsWhereUniqueInput uniqueId,
        PasswordResetsUpdateInput updateDto
    );
}
