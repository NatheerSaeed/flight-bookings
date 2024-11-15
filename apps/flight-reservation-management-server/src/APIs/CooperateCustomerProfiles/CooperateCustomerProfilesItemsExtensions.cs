using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class CooperateCustomerProfilesItemsExtensions
{
    public static CooperateCustomerProfiles ToDto(this CooperateCustomerProfilesDbModel model)
    {
        return new CooperateCustomerProfiles
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static CooperateCustomerProfilesDbModel ToModel(
        this CooperateCustomerProfilesUpdateInput updateDto,
        CooperateCustomerProfilesWhereUniqueInput uniqueId
    )
    {
        var cooperateCustomerProfiles = new CooperateCustomerProfilesDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            cooperateCustomerProfiles.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            cooperateCustomerProfiles.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return cooperateCustomerProfiles;
    }
}
