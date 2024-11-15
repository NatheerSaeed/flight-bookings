using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class AgencyProfilesItemsExtensions
{
    public static AgencyProfiles ToDto(this AgencyProfile model)
    {
        return new AgencyProfiles
        {
            CacRcNumber = model.CacRcNumber,
            CompanyAddress = model.CompanyAddress,
            CompanyContactPersonAddress = model.CompanyContactPersonAddress,
            CompanyContactPersonEmail = model.CompanyContactPersonEmail,
            CompanyContactPersonPhoneNumber = model.CompanyContactPersonPhoneNumber,
            CompanyEmail = model.CompanyEmail,
            CompanyName = model.CompanyName,
            CompanyPhoneNumber = model.CompanyPhoneNumber,
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
            User = model.UserId,
        };
    }

    public static AgencyProfile ToModel(
        this AgencyProfileUpdateInput updateDto,
        AgencyProfilesWhereUniqueInput uniqueId
    )
    {
        var agencyProfiles = new AgencyProfile
        {
            Id = uniqueId.Id,
            CacRcNumber = updateDto.CacRcNumber,
            CompanyAddress = updateDto.CompanyAddress,
            CompanyContactPersonAddress = updateDto.CompanyContactPersonAddress,
            CompanyContactPersonEmail = updateDto.CompanyContactPersonEmail,
            CompanyContactPersonPhoneNumber = updateDto.CompanyContactPersonPhoneNumber,
            CompanyEmail = updateDto.CompanyEmail,
            CompanyName = updateDto.CompanyName,
            CompanyPhoneNumber = updateDto.CompanyPhoneNumber
        };

        if (updateDto.CreatedAt != null)
        {
            agencyProfiles.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            agencyProfiles.UpdatedAt = updateDto.UpdatedAt.Value;
        }
        if (updateDto.User != null)
        {
            agencyProfiles.UserId = updateDto.User;
        }

        return agencyProfiles;
    }
}
