using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class PackageCategoriesItemsExtensions
{
    public static PackageCategories ToDto(this PackageCategoriesDbModel model)
    {
        return new PackageCategories
        {
            Category = model.Category,
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            Status = model.Status,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static PackageCategoriesDbModel ToModel(
        this PackageCategorieUpdateInput updateDto,
        PackageCategoriesWhereUniqueInput uniqueId
    )
    {
        var packageCategories = new PackageCategoriesDbModel
        {
            Id = uniqueId.Id,
            Category = updateDto.Category,
            Status = updateDto.Status
        };

        if (updateDto.CreatedAt != null)
        {
            packageCategories.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            packageCategories.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return packageCategories;
    }
}
