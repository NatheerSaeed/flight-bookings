using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class AttractionsItemsExtensions
{
    public static Attractions ToDto(this AttractionsDbModel model)
    {
        return new Attractions
        {
            Address = model.Address,
            City = model.City,
            CreatedAt = model.CreatedAt,
            Date = model.Date,
            Id = model.Id,
            Information = model.Information,
            Name = model.Name,
            PackageField = model.PackageFieldId,
            SightSeeingsItems = model.SightSeeingsItems?.Select(x => x.Id).ToList(),
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static AttractionsDbModel ToModel(
        this AttractionsUpdateInput updateDto,
        AttractionsWhereUniqueInput uniqueId
    )
    {
        var attractions = new AttractionsDbModel
        {
            Id = uniqueId.Id,
            Address = updateDto.Address,
            City = updateDto.City,
            Date = updateDto.Date,
            Information = updateDto.Information,
            Name = updateDto.Name
        };

        if (updateDto.CreatedAt != null)
        {
            attractions.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.PackageField != null)
        {
            attractions.PackageFieldId = updateDto.PackageField;
        }
        if (updateDto.UpdatedAt != null)
        {
            attractions.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return attractions;
    }
}
