using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class ProfilesItemsExtensions
{
    public static Profiles ToDto(this ProfilesDbModel model)
    {
        return new Profiles
        {
            Address = model.Address,
            CreatedAt = model.CreatedAt,
            FirstName = model.FirstName,
            Gender = model.GenderId,
            Id = model.Id,
            OtherName = model.OtherName,
            PhoneNumber = model.PhoneNumber,
            Photo = model.Photo,
            SurName = model.SurName,
            Title = model.TitleId,
            UpdatedAt = model.UpdatedAt,
            User = model.UserId,
        };
    }

    public static ProfilesDbModel ToModel(
        this ProfileUpdateInput updateDto,
        ProfilesWhereUniqueInput uniqueId
    )
    {
        var profiles = new ProfilesDbModel
        {
            Id = uniqueId.Id,
            Address = updateDto.Address,
            FirstName = updateDto.FirstName,
            OtherName = updateDto.OtherName,
            PhoneNumber = updateDto.PhoneNumber,
            Photo = updateDto.Photo,
            SurName = updateDto.SurName
        };

        if (updateDto.CreatedAt != null)
        {
            profiles.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.Gender != null)
        {
            profiles.GenderId = updateDto.Gender;
        }
        if (updateDto.Title != null)
        {
            profiles.TitleId = updateDto.Title;
        }
        if (updateDto.UpdatedAt != null)
        {
            profiles.UpdatedAt = updateDto.UpdatedAt.Value;
        }
        if (updateDto.User != null)
        {
            profiles.UserId = updateDto.User;
        }

        return profiles;
    }
}
