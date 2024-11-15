using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class BanksItemsExtensions
{
    public static Banks ToDto(this BanksDbModel model)
    {
        return new Banks
        {
            BankDetailsItems = model.BankDetailsItems?.Select(x => x.Id).ToList(),
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            Name = model.Name,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static BanksDbModel ToModel(
        this BankUpdateInput updateDto,
        BanksWhereUniqueInput uniqueId
    )
    {
        var banks = new BanksDbModel { Id = uniqueId.Id, Name = updateDto.Name };

        if (updateDto.CreatedAt != null)
        {
            banks.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            banks.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return banks;
    }
}
