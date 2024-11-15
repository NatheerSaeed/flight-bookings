using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class WalletLogTypesItemsExtensions
{
    public static WalletLogTypes ToDto(this WalletLogType model)
    {
        return new WalletLogTypes
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            Name = model.Name,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static WalletLogType ToModel(
        this WalletLogTypeUpdateInput updateDto,
        WalletLogTypesWhereUniqueInput uniqueId
    )
    {
        var walletLogTypes = new WalletLogType { Id = uniqueId.Id, Name = updateDto.Name };

        if (updateDto.CreatedAt != null)
        {
            walletLogTypes.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            walletLogTypes.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return walletLogTypes;
    }
}
