using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class GoodToKnowsItemsExtensions
{
    public static GoodToKnows ToDto(this GoodToKnow model)
    {
        return new GoodToKnows
        {
            CancellationPrepayment = model.CancellationPrepayment,
            CheckIn = model.CheckIn,
            CheckOut = model.CheckOut,
            ChildrenBeds = model.ChildrenBeds,
            CreatedAt = model.CreatedAt,
            Groups = model.Groups,
            Id = model.Id,
            Internet = model.Internet,
            PackageField = model.PackageFieldId,
            Pets = model.Pets,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static GoodToKnow ToModel(
        this GoodToKnowUpdateInput updateDto,
        GoodToKnowsWhereUniqueInput uniqueId
    )
    {
        var goodToKnows = new GoodToKnow
        {
            Id = uniqueId.Id,
            CancellationPrepayment = updateDto.CancellationPrepayment,
            CheckIn = updateDto.CheckIn,
            CheckOut = updateDto.CheckOut,
            ChildrenBeds = updateDto.ChildrenBeds,
            Groups = updateDto.Groups,
            Internet = updateDto.Internet,
            Pets = updateDto.Pets
        };

        if (updateDto.CreatedAt != null)
        {
            goodToKnows.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.PackageField != null)
        {
            goodToKnows.PackageFieldId = updateDto.PackageField;
        }
        if (updateDto.UpdatedAt != null)
        {
            goodToKnows.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return goodToKnows;
    }
}
