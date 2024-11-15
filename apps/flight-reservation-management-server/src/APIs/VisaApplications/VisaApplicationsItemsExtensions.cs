using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class VisaApplicationsItemsExtensions
{
    public static VisaApplications ToDto(this VisaApplicationsDbModel model)
    {
        return new VisaApplications
        {
            CreatedAt = model.CreatedAt,
            DestinationCountry = model.DestinationCountry,
            Email = model.Email,
            GivenName = model.GivenName,
            Id = model.Id,
            IpAddress = model.IpAddress,
            Phone = model.Phone,
            ResidenceCountry = model.ResidenceCountry,
            Surname = model.Surname,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static VisaApplicationsDbModel ToModel(
        this VisaApplicationUpdateInput updateDto,
        VisaApplicationsWhereUniqueInput uniqueId
    )
    {
        var visaApplications = new VisaApplicationsDbModel
        {
            Id = uniqueId.Id,
            DestinationCountry = updateDto.DestinationCountry,
            Email = updateDto.Email,
            GivenName = updateDto.GivenName,
            IpAddress = updateDto.IpAddress,
            Phone = updateDto.Phone,
            ResidenceCountry = updateDto.ResidenceCountry,
            Surname = updateDto.Surname
        };

        if (updateDto.CreatedAt != null)
        {
            visaApplications.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            visaApplications.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return visaApplications;
    }
}
