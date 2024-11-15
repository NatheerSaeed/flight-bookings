using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class WalletLogsItemsExtensions
{
    public static WalletLogs ToDto(this WalletLog model)
    {
        return new WalletLogs
        {
            Amount = model.Amount,
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            Status = model.Status,
            TypeId = model.TypeId,
            UpdatedAt = model.UpdatedAt,
            User = model.UserId,
        };
    }

    public static WalletLog ToModel(
        this WalletLogUpdateInput updateDto,
        WalletLogsWhereUniqueInput uniqueId
    )
    {
        var walletLogs = new WalletLog
        {
            Id = uniqueId.Id,
            Amount = updateDto.Amount,
            Status = updateDto.Status,
            TypeId = updateDto.TypeId
        };

        if (updateDto.CreatedAt != null)
        {
            walletLogs.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            walletLogs.UpdatedAt = updateDto.UpdatedAt.Value;
        }
        if (updateDto.User != null)
        {
            walletLogs.UserId = updateDto.User;
        }

        return walletLogs;
    }
}
