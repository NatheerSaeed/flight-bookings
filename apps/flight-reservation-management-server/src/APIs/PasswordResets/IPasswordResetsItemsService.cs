using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IPasswordResetsService
{
    /// <summary>
    /// Create one PasswordResets
    /// </summary>
    public Task<PasswordResets> CreatePasswordReset(PasswordResetCreateInput passwordresets);

    /// <summary>
    /// Delete one PasswordResets
    /// </summary>
    public Task DeletePasswordReset(PasswordResetsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many PasswordResetsItems
    /// </summary>
    public Task<List<PasswordResets>> PasswordResetsSearchAsync(
        PasswordResetFindManyArgs findManyArgs
    );

    /// <summary>
    /// Meta data about PasswordResets records
    /// </summary>
    public Task<MetadataDto> PasswordResetsItemsMeta(PasswordResetFindManyArgs findManyArgs);

    /// <summary>
    /// Get one PasswordResets
    /// </summary>
    public Task<PasswordResets> PasswordResets(PasswordResetsWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one PasswordResets
    /// </summary>
    public Task UpdatePasswordReset(
        PasswordResetsWhereUniqueInput uniqueId,
        PasswordResetUpdateInput updateDto
    );
}
