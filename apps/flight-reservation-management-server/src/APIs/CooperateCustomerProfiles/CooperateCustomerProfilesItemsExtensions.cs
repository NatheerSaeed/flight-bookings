using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class CooperateCustomerProfilesItemsExtensions
{
    public static CooperateCustomerProfiles ToDto(this CooperateCustomerProfilesDbModel model)
    {
        return new CooperateCustomerProfiles
        {
            CompanyAddress = model.CompanyAddress,
            CompanyCacRcNumber = model.CompanyCacRcNumber,
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

    public static CooperateCustomerProfilesDbModel ToModel(
        this CooperateCustomerProfilesUpdateInput updateDto,
        CooperateCustomerProfilesWhereUniqueInput uniqueId
    )
    {
        var cooperateCustomerProfiles = new CooperateCustomerProfilesDbModel
        {
            Id = uniqueId.Id,
            CompanyAddress = updateDto.CompanyAddress,
            CompanyCacRcNumber = updateDto.CompanyCacRcNumber,
            CompanyContactPersonAddress = updateDto.CompanyContactPersonAddress,
            CompanyContactPersonEmail = updateDto.CompanyContactPersonEmail,
            CompanyContactPersonPhoneNumber = updateDto.CompanyContactPersonPhoneNumber,
            CompanyEmail = updateDto.CompanyEmail,
            CompanyName = updateDto.CompanyName,
            CompanyPhoneNumber = updateDto.CompanyPhoneNumber
        };

        if (updateDto.CreatedAt != null)
        {
            cooperateCustomerProfiles.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            cooperateCustomerProfiles.UpdatedAt = updateDto.UpdatedAt.Value;
        }
        if (updateDto.User != null)
        {
            cooperateCustomerProfiles.UserId = updateDto.User;
        }

        return cooperateCustomerProfiles;
    }
}
