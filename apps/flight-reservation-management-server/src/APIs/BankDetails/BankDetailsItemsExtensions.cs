using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class BankDetailsItemsExtensions
{
    public static BankDetails ToDto(this BankDetail model)
    {
        return new BankDetails
        {
            AccountName = model.AccountName,
            AccountNumber = model.AccountNumber,
            Bank = model.BankId,
            BankBranch = model.BankBranch,
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            IfscCode = model.IfscCode,
            Pan = model.Pan,
            Status = model.Status,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static BankDetail ToModel(
        this BankDetailUpdateInput updateDto,
        BankDetailsWhereUniqueInput uniqueId
    )
    {
        var bankDetails = new BankDetail
        {
            Id = uniqueId.Id,
            AccountName = updateDto.AccountName,
            AccountNumber = updateDto.AccountNumber,
            BankBranch = updateDto.BankBranch,
            IfscCode = updateDto.IfscCode,
            Pan = updateDto.Pan,
            Status = updateDto.Status
        };

        if (updateDto.Bank != null)
        {
            bankDetails.BankId = updateDto.Bank;
        }
        if (updateDto.CreatedAt != null)
        {
            bankDetails.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            bankDetails.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return bankDetails;
    }
}
