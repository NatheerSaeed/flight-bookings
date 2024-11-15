using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class WalletsItemsExtensions
{
    public static Wallets ToDto(this WalletsDbModel model)
    {
        return new Wallets
        {
            Balance = model.Balance,
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
            User = model.UserId,
        };
    }

    public static WalletsDbModel ToModel(
        this WalletsUpdateInput updateDto,
        WalletsWhereUniqueInput uniqueId
    )
    {
        var wallets = new WalletsDbModel { Id = uniqueId.Id, Balance = updateDto.Balance };

        if (updateDto.CreatedAt != null)
        {
            wallets.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            wallets.UpdatedAt = updateDto.UpdatedAt.Value;
        }
        if (updateDto.User != null)
        {
            wallets.UserId = updateDto.User;
        }

        return wallets;
    }
}
