using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IPasswordResetsService
{
    /// <summary>
    /// Create one PasswordReset
    /// </summary>
    public Task<PasswordReset> CreatePasswordReset(PasswordResetCreateInput passwordreset);

    /// <summary>
    /// Delete one PasswordReset
    /// </summary>
    public Task DeletePasswordReset(PasswordResetWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many PasswordResets
    /// </summary>
    public Task<List<PasswordReset>> PasswordResets(PasswordResetFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about PasswordReset records
    /// </summary>
    public Task<MetadataDto> PasswordResetsMeta(PasswordResetFindManyArgs findManyArgs);

    /// <summary>
    /// Get one PasswordReset
    /// </summary>
    public Task<PasswordReset> PasswordReset(PasswordResetWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one PasswordReset
    /// </summary>
    public Task UpdatePasswordReset(
        PasswordResetWhereUniqueInput uniqueId,
        PasswordResetUpdateInput updateDto
    );
}
