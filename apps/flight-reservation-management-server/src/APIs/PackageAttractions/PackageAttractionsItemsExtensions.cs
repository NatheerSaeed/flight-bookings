using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class PackageAttractionsItemsExtensions
{
    public static PackageAttractions ToDto(this PackageAttraction model)
    {
        return new PackageAttractions
        {
            Address = model.Address,
            AttractionName = model.AttractionName,
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            PackageField = model.PackageFieldId,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static PackageAttraction ToModel(
        this PackageAttractionUpdateInput updateDto,
        PackageAttractionsWhereUniqueInput uniqueId
    )
    {
        var packageAttractions = new PackageAttraction
        {
            Id = uniqueId.Id,
            Address = updateDto.Address,
            AttractionName = updateDto.AttractionName
        };

        if (updateDto.CreatedAt != null)
        {
            packageAttractions.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.PackageField != null)
        {
            packageAttractions.PackageFieldId = updateDto.PackageField;
        }
        if (updateDto.UpdatedAt != null)
        {
            packageAttractions.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return packageAttractions;
    }
}
