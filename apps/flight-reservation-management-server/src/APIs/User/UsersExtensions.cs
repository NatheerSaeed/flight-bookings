using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class UsersExtensions
{
    public static Dtos.User ToDto(this Infrastructure.Models.UserDbModel model)
    {
        return new Dtos.User
        {
            AgencyProfilesItems = model.AgencyProfilesItems?.Select(x => x.Id).ToList(),
            AirlinesItems = model.AirlinesItems?.Select(x => x.Id).ToList(),
            ApiToken = model.ApiToken,
            BankPaymentsItems = model.BankPaymentsItems?.Select(x => x.Id).ToList(),
            CarBookingsItems = model.CarBookingsItems?.Select(x => x.Id).ToList(),
            CooperateCustomerProfilesItems = model
                .CooperateCustomerProfilesItems?.Select(x => x.Id)
                .ToList(),
            CreatedAt = model.CreatedAt,
            DeleteStatus = model.DeleteStatus,
            Email = model.Email,
            FirstName = model.FirstName,
            FlightBookingsItems = model.FlightBookingsItems?.Select(x => x.Id).ToList(),
            HotelBookingsItems = model.HotelBookingsItems?.Select(x => x.Id).ToList(),
            Id = model.Id,
            LastName = model.LastName,
            OnlinePaymentsItems = model.OnlinePaymentsItems?.Select(x => x.Id).ToList(),
            PackageBookingsItems = model.PackageBookingsItems?.Select(x => x.Id).ToList(),
            Password = model.Password,
            PayLatersItems = model.PayLatersItems?.Select(x => x.Id).ToList(),
            ProfileCompleteStatus = model.ProfileCompleteStatus,
            ProfilesItems = model.ProfilesItems?.Select(x => x.Id).ToList(),
            Roles = model.Roles,
            UpdatedAt = model.UpdatedAt,
            Username = model.Username,
            WalletLogsItems = model.WalletLogsItems?.Select(x => x.Id).ToList(),
            WalletsItems = model.WalletsItems?.Select(x => x.Id).ToList(),
        };
    }

    public static Infrastructure.Models.UserDbModel ToModel(
        this UserUpdateInput updateDto,
        UserWhereUniqueInput uniqueId
    )
    {
        var user = new Infrastructure.Models.UserDbModel
        {
            Id = uniqueId.Id,
            ApiToken = updateDto.ApiToken,
            DeleteStatus = updateDto.DeleteStatus,
            Email = updateDto.Email,
            FirstName = updateDto.FirstName,
            LastName = updateDto.LastName,
            ProfileCompleteStatus = updateDto.ProfileCompleteStatus
        };

        if (updateDto.CreatedAt != null)
        {
            user.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.Password != null)
        {
            user.Password = updateDto.Password;
        }
        if (updateDto.Roles != null)
        {
            user.Roles = updateDto.Roles;
        }
        if (updateDto.UpdatedAt != null)
        {
            user.UpdatedAt = updateDto.UpdatedAt.Value;
        }
        if (updateDto.Username != null)
        {
            user.Username = updateDto.Username;
        }

        return user;
    }
}
