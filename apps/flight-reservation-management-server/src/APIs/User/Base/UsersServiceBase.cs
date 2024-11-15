using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class UsersServiceBase : IUsersService
{
    protected readonly FlightReservationManagementDbContext _context;

    public UsersServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one User
    /// </summary>
    public async Task<Dtos.User> CreateUser(UserCreateInput inputDto)
    {
        var user = new Infrastructure.Models.UserDbModel
        {
            ApiToken = inputDto.ApiToken,
            CreatedAt = inputDto.CreatedAt,
            DeleteStatus = inputDto.DeleteStatus,
            Email = inputDto.Email,
            FirstName = inputDto.FirstName,
            LastName = inputDto.LastName,
            Password = inputDto.Password,
            ProfileCompleteStatus = inputDto.ProfileCompleteStatus,
            Roles = inputDto.Roles,
            UpdatedAt = inputDto.UpdatedAt,
            Username = inputDto.Username
        };

        if (inputDto.Id != null)
        {
            user.Id = inputDto.Id;
        }
        if (inputDto.AgencyProfilesItems != null)
        {
            user.AgencyProfilesItems = await _context
                .AgencyProfilesItems.Where(agencyProfiles =>
                    inputDto.AgencyProfilesItems.Select(t => t.Id).Contains(agencyProfiles.Id)
                )
                .ToListAsync();
        }

        if (inputDto.AirlinesItems != null)
        {
            user.AirlinesItems = await _context
                .AirlinesItems.Where(airlines =>
                    inputDto.AirlinesItems.Select(t => t.Id).Contains(airlines.Id)
                )
                .ToListAsync();
        }

        if (inputDto.BankPaymentsItems != null)
        {
            user.BankPaymentsItems = await _context
                .BankPaymentsItems.Where(bankPayments =>
                    inputDto.BankPaymentsItems.Select(t => t.Id).Contains(bankPayments.Id)
                )
                .ToListAsync();
        }

        if (inputDto.CarBookingsItems != null)
        {
            user.CarBookingsItems = await _context
                .CarBookingsItems.Where(carBookings =>
                    inputDto.CarBookingsItems.Select(t => t.Id).Contains(carBookings.Id)
                )
                .ToListAsync();
        }

        if (inputDto.CooperateCustomerProfilesItems != null)
        {
            user.CooperateCustomerProfilesItems = await _context
                .CooperateCustomerProfilesItems.Where(cooperateCustomerProfiles =>
                    inputDto
                        .CooperateCustomerProfilesItems.Select(t => t.Id)
                        .Contains(cooperateCustomerProfiles.Id)
                )
                .ToListAsync();
        }

        if (inputDto.FlightBookingsItems != null)
        {
            user.FlightBookingsItems = await _context
                .FlightBookingsItems.Where(flightBookings =>
                    inputDto.FlightBookingsItems.Select(t => t.Id).Contains(flightBookings.Id)
                )
                .ToListAsync();
        }

        if (inputDto.HotelBookingsItems != null)
        {
            user.HotelBookingsItems = await _context
                .HotelBookingsItems.Where(hotelBookings =>
                    inputDto.HotelBookingsItems.Select(t => t.Id).Contains(hotelBookings.Id)
                )
                .ToListAsync();
        }

        if (inputDto.OnlinePaymentsItems != null)
        {
            user.OnlinePaymentsItems = await _context
                .OnlinePaymentsItems.Where(onlinePayments =>
                    inputDto.OnlinePaymentsItems.Select(t => t.Id).Contains(onlinePayments.Id)
                )
                .ToListAsync();
        }

        if (inputDto.PackageBookingsItems != null)
        {
            user.PackageBookingsItems = await _context
                .PackageBookingsItems.Where(packageBookings =>
                    inputDto.PackageBookingsItems.Select(t => t.Id).Contains(packageBookings.Id)
                )
                .ToListAsync();
        }

        if (inputDto.PayLatersItems != null)
        {
            user.PayLatersItems = await _context
                .PayLatersItems.Where(payLaters =>
                    inputDto.PayLatersItems.Select(t => t.Id).Contains(payLaters.Id)
                )
                .ToListAsync();
        }

        if (inputDto.ProfilesItems != null)
        {
            user.ProfilesItems = await _context
                .ProfilesItems.Where(profiles =>
                    inputDto.ProfilesItems.Select(t => t.Id).Contains(profiles.Id)
                )
                .ToListAsync();
        }

        if (inputDto.WalletLogsItems != null)
        {
            user.WalletLogsItems = await _context
                .WalletLogsItems.Where(walletLogs =>
                    inputDto.WalletLogsItems.Select(t => t.Id).Contains(walletLogs.Id)
                )
                .ToListAsync();
        }

        if (inputDto.WalletsItems != null)
        {
            user.WalletsItems = await _context
                .WalletsItems.Where(wallets =>
                    inputDto.WalletsItems.Select(t => t.Id).Contains(wallets.Id)
                )
                .ToListAsync();
        }

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<Infrastructure.Models.UserDbModel>(user.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one User
    /// </summary>
    public async Task DeleteUser(UserWhereUniqueInput uniqueId)
    {
        var user = await _context.Users.FindAsync(uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Users
    /// </summary>
    public async Task<List<Dtos.User>> Users(UserFindManyArgs findManyArgs)
    {
        var users = await _context
            .Users.Include(x => x.HotelBookingsItems)
            .Include(x => x.CarBookingsItems)
            .Include(x => x.AirlinesItems)
            .Include(x => x.BankPaymentsItems)
            .Include(x => x.ProfilesItems)
            .Include(x => x.OnlinePaymentsItems)
            .Include(x => x.PayLatersItems)
            .Include(x => x.CooperateCustomerProfilesItems)
            .Include(x => x.WalletsItems)
            .Include(x => x.WalletLogsItems)
            .Include(x => x.PackageBookingsItems)
            .Include(x => x.FlightBookingsItems)
            .Include(x => x.AgencyProfilesItems)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return users.ConvertAll(user => user.ToDto());
    }

    /// <summary>
    /// Meta data about User records
    /// </summary>
    public async Task<MetadataDto> UsersMeta(UserFindManyArgs findManyArgs)
    {
        var count = await _context.Users.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one User
    /// </summary>
    public async Task<Dtos.User> User(UserWhereUniqueInput uniqueId)
    {
        var users = await this.Users(
            new UserFindManyArgs { Where = new UserWhereInput { Id = uniqueId.Id } }
        );
        var user = users.FirstOrDefault();
        if (user == null)
        {
            throw new NotFoundException();
        }

        return user;
    }

    /// <summary>
    /// Update one User
    /// </summary>
    public async Task UpdateUser(UserWhereUniqueInput uniqueId, UserUpdateInput updateDto)
    {
        var user = updateDto.ToModel(uniqueId);

        if (updateDto.AgencyProfilesItems != null)
        {
            user.AgencyProfilesItems = await _context
                .AgencyProfilesItems.Where(agencyProfiles =>
                    updateDto.AgencyProfilesItems.Select(t => t).Contains(agencyProfiles.Id)
                )
                .ToListAsync();
        }

        if (updateDto.AirlinesItems != null)
        {
            user.AirlinesItems = await _context
                .AirlinesItems.Where(airlines =>
                    updateDto.AirlinesItems.Select(t => t).Contains(airlines.Id)
                )
                .ToListAsync();
        }

        if (updateDto.BankPaymentsItems != null)
        {
            user.BankPaymentsItems = await _context
                .BankPaymentsItems.Where(bankPayments =>
                    updateDto.BankPaymentsItems.Select(t => t).Contains(bankPayments.Id)
                )
                .ToListAsync();
        }

        if (updateDto.CarBookingsItems != null)
        {
            user.CarBookingsItems = await _context
                .CarBookingsItems.Where(carBookings =>
                    updateDto.CarBookingsItems.Select(t => t).Contains(carBookings.Id)
                )
                .ToListAsync();
        }

        if (updateDto.CooperateCustomerProfilesItems != null)
        {
            user.CooperateCustomerProfilesItems = await _context
                .CooperateCustomerProfilesItems.Where(cooperateCustomerProfiles =>
                    updateDto
                        .CooperateCustomerProfilesItems.Select(t => t)
                        .Contains(cooperateCustomerProfiles.Id)
                )
                .ToListAsync();
        }

        if (updateDto.FlightBookingsItems != null)
        {
            user.FlightBookingsItems = await _context
                .FlightBookingsItems.Where(flightBookings =>
                    updateDto.FlightBookingsItems.Select(t => t).Contains(flightBookings.Id)
                )
                .ToListAsync();
        }

        if (updateDto.HotelBookingsItems != null)
        {
            user.HotelBookingsItems = await _context
                .HotelBookingsItems.Where(hotelBookings =>
                    updateDto.HotelBookingsItems.Select(t => t).Contains(hotelBookings.Id)
                )
                .ToListAsync();
        }

        if (updateDto.OnlinePaymentsItems != null)
        {
            user.OnlinePaymentsItems = await _context
                .OnlinePaymentsItems.Where(onlinePayments =>
                    updateDto.OnlinePaymentsItems.Select(t => t).Contains(onlinePayments.Id)
                )
                .ToListAsync();
        }

        if (updateDto.PackageBookingsItems != null)
        {
            user.PackageBookingsItems = await _context
                .PackageBookingsItems.Where(packageBookings =>
                    updateDto.PackageBookingsItems.Select(t => t).Contains(packageBookings.Id)
                )
                .ToListAsync();
        }

        if (updateDto.PayLatersItems != null)
        {
            user.PayLatersItems = await _context
                .PayLatersItems.Where(payLaters =>
                    updateDto.PayLatersItems.Select(t => t).Contains(payLaters.Id)
                )
                .ToListAsync();
        }

        if (updateDto.ProfilesItems != null)
        {
            user.ProfilesItems = await _context
                .ProfilesItems.Where(profiles =>
                    updateDto.ProfilesItems.Select(t => t).Contains(profiles.Id)
                )
                .ToListAsync();
        }

        if (updateDto.WalletLogsItems != null)
        {
            user.WalletLogsItems = await _context
                .WalletLogsItems.Where(walletLogs =>
                    updateDto.WalletLogsItems.Select(t => t).Contains(walletLogs.Id)
                )
                .ToListAsync();
        }

        if (updateDto.WalletsItems != null)
        {
            user.WalletsItems = await _context
                .WalletsItems.Where(wallets =>
                    updateDto.WalletsItems.Select(t => t).Contains(wallets.Id)
                )
                .ToListAsync();
        }

        _context.Entry(user).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Users.Any(e => e.Id == user.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }

    /// <summary>
    /// Connect multiple AgencyProfilesItems records to User
    /// </summary>
    public async Task ConnectAgencyProfilesSearchAsync(
        UserWhereUniqueInput uniqueId,
        AgencyProfilesWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Users.Include(x => x.AgencyProfilesItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .AgencyProfilesItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.AgencyProfilesItems);

        foreach (var child in childrenToConnect)
        {
            parent.AgencyProfilesItems.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple AgencyProfilesItems records from User
    /// </summary>
    public async Task DisconnectAgencyProfilesSearchAsync(
        UserWhereUniqueInput uniqueId,
        AgencyProfilesWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Users.Include(x => x.AgencyProfilesItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .AgencyProfilesItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.AgencyProfilesItems?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple AgencyProfilesItems records for User
    /// </summary>
    public async Task<List<AgencyProfiles>> FindAgencyProfilesSearchAsync(
        UserWhereUniqueInput uniqueId,
        AgencyProfileFindManyArgs userFindManyArgs
    )
    {
        var agencyProfilesItems = await _context
            .AgencyProfilesItems.Where(m => m.UserId == uniqueId.Id)
            .ApplyWhere(userFindManyArgs.Where)
            .ApplySkip(userFindManyArgs.Skip)
            .ApplyTake(userFindManyArgs.Take)
            .ApplyOrderBy(userFindManyArgs.SortBy)
            .ToListAsync();

        return agencyProfilesItems.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple AgencyProfilesItems records for User
    /// </summary>
    public async Task UpdateAgencyProfilesItem(
        UserWhereUniqueInput uniqueId,
        AgencyProfilesWhereUniqueInput[] childrenIds
    )
    {
        var user = await _context
            .Users.Include(t => t.AgencyProfilesItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .AgencyProfilesItems.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        user.AgencyProfilesItems = children;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple AirlinesItems records to User
    /// </summary>
    public async Task ConnectAirlinesSearchAsync(
        UserWhereUniqueInput uniqueId,
        AirlinesWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Users.Include(x => x.AirlinesItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .AirlinesItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.AirlinesItems);

        foreach (var child in childrenToConnect)
        {
            parent.AirlinesItems.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple AirlinesItems records from User
    /// </summary>
    public async Task DisconnectAirlinesSearchAsync(
        UserWhereUniqueInput uniqueId,
        AirlinesWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Users.Include(x => x.AirlinesItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .AirlinesItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.AirlinesItems?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple AirlinesItems records for User
    /// </summary>
    public async Task<List<Airlines>> FindAirlinesSearchAsync(
        UserWhereUniqueInput uniqueId,
        AirlineFindManyArgs userFindManyArgs
    )
    {
        var airlinesItems = await _context
            .AirlinesItems.Where(m => m.UserId == uniqueId.Id)
            .ApplyWhere(userFindManyArgs.Where)
            .ApplySkip(userFindManyArgs.Skip)
            .ApplyTake(userFindManyArgs.Take)
            .ApplyOrderBy(userFindManyArgs.SortBy)
            .ToListAsync();

        return airlinesItems.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple AirlinesItems records for User
    /// </summary>
    public async Task UpdateAirlinesItem(
        UserWhereUniqueInput uniqueId,
        AirlinesWhereUniqueInput[] childrenIds
    )
    {
        var user = await _context
            .Users.Include(t => t.AirlinesItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .AirlinesItems.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        user.AirlinesItems = children;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple BankPaymentsItems records to User
    /// </summary>
    public async Task ConnectBankPaymentsSearchAsync(
        UserWhereUniqueInput uniqueId,
        BankPaymentsWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Users.Include(x => x.BankPaymentsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .BankPaymentsItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.BankPaymentsItems);

        foreach (var child in childrenToConnect)
        {
            parent.BankPaymentsItems.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple BankPaymentsItems records from User
    /// </summary>
    public async Task DisconnectBankPaymentsSearchAsync(
        UserWhereUniqueInput uniqueId,
        BankPaymentsWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Users.Include(x => x.BankPaymentsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .BankPaymentsItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.BankPaymentsItems?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple BankPaymentsItems records for User
    /// </summary>
    public async Task<List<BankPayments>> FindBankPaymentsSearchAsync(
        UserWhereUniqueInput uniqueId,
        BankPaymentFindManyArgs userFindManyArgs
    )
    {
        var bankPaymentsItems = await _context
            .BankPaymentsItems.Where(m => m.UserId == uniqueId.Id)
            .ApplyWhere(userFindManyArgs.Where)
            .ApplySkip(userFindManyArgs.Skip)
            .ApplyTake(userFindManyArgs.Take)
            .ApplyOrderBy(userFindManyArgs.SortBy)
            .ToListAsync();

        return bankPaymentsItems.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple BankPaymentsItems records for User
    /// </summary>
    public async Task UpdateBankPaymentsItem(
        UserWhereUniqueInput uniqueId,
        BankPaymentsWhereUniqueInput[] childrenIds
    )
    {
        var user = await _context
            .Users.Include(t => t.BankPaymentsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .BankPaymentsItems.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        user.BankPaymentsItems = children;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple CarBookingsItems records to User
    /// </summary>
    public async Task ConnectCarBookingsSearchAsync(
        UserWhereUniqueInput uniqueId,
        CarBookingsWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Users.Include(x => x.CarBookingsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .CarBookingsItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.CarBookingsItems);

        foreach (var child in childrenToConnect)
        {
            parent.CarBookingsItems.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple CarBookingsItems records from User
    /// </summary>
    public async Task DisconnectCarBookingsSearchAsync(
        UserWhereUniqueInput uniqueId,
        CarBookingsWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Users.Include(x => x.CarBookingsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .CarBookingsItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.CarBookingsItems?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple CarBookingsItems records for User
    /// </summary>
    public async Task<List<CarBookings>> FindCarBookingsSearchAsync(
        UserWhereUniqueInput uniqueId,
        CarBookingFindManyArgs userFindManyArgs
    )
    {
        var carBookingsItems = await _context
            .CarBookingsItems.Where(m => m.UserId == uniqueId.Id)
            .ApplyWhere(userFindManyArgs.Where)
            .ApplySkip(userFindManyArgs.Skip)
            .ApplyTake(userFindManyArgs.Take)
            .ApplyOrderBy(userFindManyArgs.SortBy)
            .ToListAsync();

        return carBookingsItems.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple CarBookingsItems records for User
    /// </summary>
    public async Task UpdateCarBookingsItem(
        UserWhereUniqueInput uniqueId,
        CarBookingsWhereUniqueInput[] childrenIds
    )
    {
        var user = await _context
            .Users.Include(t => t.CarBookingsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .CarBookingsItems.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        user.CarBookingsItems = children;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple CooperateCustomerProfilesItems records to User
    /// </summary>
    public async Task ConnectCooperateCustomerProfilesSearchAsync(
        UserWhereUniqueInput uniqueId,
        CooperateCustomerProfilesWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Users.Include(x => x.CooperateCustomerProfilesItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .CooperateCustomerProfilesItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.CooperateCustomerProfilesItems);

        foreach (var child in childrenToConnect)
        {
            parent.CooperateCustomerProfilesItems.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple CooperateCustomerProfilesItems records from User
    /// </summary>
    public async Task DisconnectCooperateCustomerProfilesSearchAsync(
        UserWhereUniqueInput uniqueId,
        CooperateCustomerProfilesWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Users.Include(x => x.CooperateCustomerProfilesItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .CooperateCustomerProfilesItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.CooperateCustomerProfilesItems?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple CooperateCustomerProfilesItems records for User
    /// </summary>
    public async Task<List<CooperateCustomerProfiles>> FindCooperateCustomerProfilesSearchAsync(
        UserWhereUniqueInput uniqueId,
        CooperateCustomerProfileFindManyArgs userFindManyArgs
    )
    {
        var cooperateCustomerProfilesItems = await _context
            .CooperateCustomerProfilesItems.Where(m => m.UserId == uniqueId.Id)
            .ApplyWhere(userFindManyArgs.Where)
            .ApplySkip(userFindManyArgs.Skip)
            .ApplyTake(userFindManyArgs.Take)
            .ApplyOrderBy(userFindManyArgs.SortBy)
            .ToListAsync();

        return cooperateCustomerProfilesItems.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple CooperateCustomerProfilesItems records for User
    /// </summary>
    public async Task UpdateCooperateCustomerProfilesItem(
        UserWhereUniqueInput uniqueId,
        CooperateCustomerProfilesWhereUniqueInput[] childrenIds
    )
    {
        var user = await _context
            .Users.Include(t => t.CooperateCustomerProfilesItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .CooperateCustomerProfilesItems.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        user.CooperateCustomerProfilesItems = children;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple FlightBookingsItems records to User
    /// </summary>
    public async Task ConnectFlightBookingsSearchAsync(
        UserWhereUniqueInput uniqueId,
        FlightBookingsWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Users.Include(x => x.FlightBookingsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .FlightBookingsItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.FlightBookingsItems);

        foreach (var child in childrenToConnect)
        {
            parent.FlightBookingsItems.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple FlightBookingsItems records from User
    /// </summary>
    public async Task DisconnectFlightBookingsSearchAsync(
        UserWhereUniqueInput uniqueId,
        FlightBookingsWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Users.Include(x => x.FlightBookingsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .FlightBookingsItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.FlightBookingsItems?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple FlightBookingsItems records for User
    /// </summary>
    public async Task<List<FlightBookings>> FindFlightBookingsSearchAsync(
        UserWhereUniqueInput uniqueId,
        FlightBookingFindManyArgs userFindManyArgs
    )
    {
        var flightBookingsItems = await _context
            .FlightBookingsItems.Where(m => m.UserId == uniqueId.Id)
            .ApplyWhere(userFindManyArgs.Where)
            .ApplySkip(userFindManyArgs.Skip)
            .ApplyTake(userFindManyArgs.Take)
            .ApplyOrderBy(userFindManyArgs.SortBy)
            .ToListAsync();

        return flightBookingsItems.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple FlightBookingsItems records for User
    /// </summary>
    public async Task UpdateFlightBookingsItem(
        UserWhereUniqueInput uniqueId,
        FlightBookingsWhereUniqueInput[] childrenIds
    )
    {
        var user = await _context
            .Users.Include(t => t.FlightBookingsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .FlightBookingsItems.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        user.FlightBookingsItems = children;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple HotelBookingsItems records to User
    /// </summary>
    public async Task ConnectHotelBookingsSearchAsync(
        UserWhereUniqueInput uniqueId,
        HotelBookingsWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Users.Include(x => x.HotelBookingsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .HotelBookingsItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.HotelBookingsItems);

        foreach (var child in childrenToConnect)
        {
            parent.HotelBookingsItems.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple HotelBookingsItems records from User
    /// </summary>
    public async Task DisconnectHotelBookingsSearchAsync(
        UserWhereUniqueInput uniqueId,
        HotelBookingsWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Users.Include(x => x.HotelBookingsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .HotelBookingsItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.HotelBookingsItems?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple HotelBookingsItems records for User
    /// </summary>
    public async Task<List<HotelBookings>> FindHotelBookingsSearchAsync(
        UserWhereUniqueInput uniqueId,
        HotelBookingFindManyArgs userFindManyArgs
    )
    {
        var hotelBookingsItems = await _context
            .HotelBookingsItems.Where(m => m.UserId == uniqueId.Id)
            .ApplyWhere(userFindManyArgs.Where)
            .ApplySkip(userFindManyArgs.Skip)
            .ApplyTake(userFindManyArgs.Take)
            .ApplyOrderBy(userFindManyArgs.SortBy)
            .ToListAsync();

        return hotelBookingsItems.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple HotelBookingsItems records for User
    /// </summary>
    public async Task UpdateHotelBookingsItem(
        UserWhereUniqueInput uniqueId,
        HotelBookingsWhereUniqueInput[] childrenIds
    )
    {
        var user = await _context
            .Users.Include(t => t.HotelBookingsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .HotelBookingsItems.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        user.HotelBookingsItems = children;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple OnlinePaymentsItems records to User
    /// </summary>
    public async Task ConnectOnlinePaymentsSearchAsync(
        UserWhereUniqueInput uniqueId,
        OnlinePaymentsWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Users.Include(x => x.OnlinePaymentsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .OnlinePaymentsItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.OnlinePaymentsItems);

        foreach (var child in childrenToConnect)
        {
            parent.OnlinePaymentsItems.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple OnlinePaymentsItems records from User
    /// </summary>
    public async Task DisconnectOnlinePaymentsSearchAsync(
        UserWhereUniqueInput uniqueId,
        OnlinePaymentsWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Users.Include(x => x.OnlinePaymentsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .OnlinePaymentsItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.OnlinePaymentsItems?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple OnlinePaymentsItems records for User
    /// </summary>
    public async Task<List<OnlinePayments>> FindOnlinePaymentsSearchAsync(
        UserWhereUniqueInput uniqueId,
        OnlinePaymentFindManyArgs userFindManyArgs
    )
    {
        var onlinePaymentsItems = await _context
            .OnlinePaymentsItems.Where(m => m.UserId == uniqueId.Id)
            .ApplyWhere(userFindManyArgs.Where)
            .ApplySkip(userFindManyArgs.Skip)
            .ApplyTake(userFindManyArgs.Take)
            .ApplyOrderBy(userFindManyArgs.SortBy)
            .ToListAsync();

        return onlinePaymentsItems.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple OnlinePaymentsItems records for User
    /// </summary>
    public async Task UpdateOnlinePaymentsItem(
        UserWhereUniqueInput uniqueId,
        OnlinePaymentsWhereUniqueInput[] childrenIds
    )
    {
        var user = await _context
            .Users.Include(t => t.OnlinePaymentsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .OnlinePaymentsItems.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        user.OnlinePaymentsItems = children;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple PackageBookingsItems records to User
    /// </summary>
    public async Task ConnectPackageBookingsSearchAsync(
        UserWhereUniqueInput uniqueId,
        PackageBookingsWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Users.Include(x => x.PackageBookingsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .PackageBookingsItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.PackageBookingsItems);

        foreach (var child in childrenToConnect)
        {
            parent.PackageBookingsItems.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple PackageBookingsItems records from User
    /// </summary>
    public async Task DisconnectPackageBookingsSearchAsync(
        UserWhereUniqueInput uniqueId,
        PackageBookingsWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Users.Include(x => x.PackageBookingsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .PackageBookingsItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.PackageBookingsItems?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple PackageBookingsItems records for User
    /// </summary>
    public async Task<List<PackageBookings>> FindPackageBookingsSearchAsync(
        UserWhereUniqueInput uniqueId,
        PackageBookingFindManyArgs userFindManyArgs
    )
    {
        var packageBookingsItems = await _context
            .PackageBookingsItems.Where(m => m.UserId == uniqueId.Id)
            .ApplyWhere(userFindManyArgs.Where)
            .ApplySkip(userFindManyArgs.Skip)
            .ApplyTake(userFindManyArgs.Take)
            .ApplyOrderBy(userFindManyArgs.SortBy)
            .ToListAsync();

        return packageBookingsItems.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple PackageBookingsItems records for User
    /// </summary>
    public async Task UpdatePackageBookingsItem(
        UserWhereUniqueInput uniqueId,
        PackageBookingsWhereUniqueInput[] childrenIds
    )
    {
        var user = await _context
            .Users.Include(t => t.PackageBookingsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .PackageBookingsItems.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        user.PackageBookingsItems = children;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple PayLatersItems records to User
    /// </summary>
    public async Task ConnectPayLatersSearchAsync(
        UserWhereUniqueInput uniqueId,
        PayLatersWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Users.Include(x => x.PayLatersItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .PayLatersItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.PayLatersItems);

        foreach (var child in childrenToConnect)
        {
            parent.PayLatersItems.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple PayLatersItems records from User
    /// </summary>
    public async Task DisconnectPayLatersSearchAsync(
        UserWhereUniqueInput uniqueId,
        PayLatersWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Users.Include(x => x.PayLatersItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .PayLatersItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.PayLatersItems?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple PayLatersItems records for User
    /// </summary>
    public async Task<List<PayLaters>> FindPayLatersSearchAsync(
        UserWhereUniqueInput uniqueId,
        PayLaterFindManyArgs userFindManyArgs
    )
    {
        var payLatersItems = await _context
            .PayLatersItems.Where(m => m.UserId == uniqueId.Id)
            .ApplyWhere(userFindManyArgs.Where)
            .ApplySkip(userFindManyArgs.Skip)
            .ApplyTake(userFindManyArgs.Take)
            .ApplyOrderBy(userFindManyArgs.SortBy)
            .ToListAsync();

        return payLatersItems.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple PayLatersItems records for User
    /// </summary>
    public async Task UpdatePayLatersItem(
        UserWhereUniqueInput uniqueId,
        PayLatersWhereUniqueInput[] childrenIds
    )
    {
        var user = await _context
            .Users.Include(t => t.PayLatersItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .PayLatersItems.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        user.PayLatersItems = children;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple ProfilesItems records to User
    /// </summary>
    public async Task ConnectProfilesSearchAsync(
        UserWhereUniqueInput uniqueId,
        ProfilesWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Users.Include(x => x.ProfilesItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .ProfilesItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.ProfilesItems);

        foreach (var child in childrenToConnect)
        {
            parent.ProfilesItems.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple ProfilesItems records from User
    /// </summary>
    public async Task DisconnectProfilesSearchAsync(
        UserWhereUniqueInput uniqueId,
        ProfilesWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Users.Include(x => x.ProfilesItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .ProfilesItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.ProfilesItems?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple ProfilesItems records for User
    /// </summary>
    public async Task<List<Profiles>> FindProfilesSearchAsync(
        UserWhereUniqueInput uniqueId,
        ProfileFindManyArgs userFindManyArgs
    )
    {
        var profilesItems = await _context
            .ProfilesItems.Where(m => m.UserId == uniqueId.Id)
            .ApplyWhere(userFindManyArgs.Where)
            .ApplySkip(userFindManyArgs.Skip)
            .ApplyTake(userFindManyArgs.Take)
            .ApplyOrderBy(userFindManyArgs.SortBy)
            .ToListAsync();

        return profilesItems.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple ProfilesItems records for User
    /// </summary>
    public async Task UpdateProfilesItem(
        UserWhereUniqueInput uniqueId,
        ProfilesWhereUniqueInput[] childrenIds
    )
    {
        var user = await _context
            .Users.Include(t => t.ProfilesItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .ProfilesItems.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        user.ProfilesItems = children;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple WalletLogsItems records to User
    /// </summary>
    public async Task ConnectWalletLogsSearchAsync(
        UserWhereUniqueInput uniqueId,
        WalletLogsWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Users.Include(x => x.WalletLogsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .WalletLogsItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.WalletLogsItems);

        foreach (var child in childrenToConnect)
        {
            parent.WalletLogsItems.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple WalletLogsItems records from User
    /// </summary>
    public async Task DisconnectWalletLogsSearchAsync(
        UserWhereUniqueInput uniqueId,
        WalletLogsWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Users.Include(x => x.WalletLogsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .WalletLogsItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.WalletLogsItems?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple WalletLogsItems records for User
    /// </summary>
    public async Task<List<WalletLogs>> FindWalletLogsSearchAsync(
        UserWhereUniqueInput uniqueId,
        WalletLogFindManyArgs userFindManyArgs
    )
    {
        var walletLogsItems = await _context
            .WalletLogsItems.Where(m => m.UserId == uniqueId.Id)
            .ApplyWhere(userFindManyArgs.Where)
            .ApplySkip(userFindManyArgs.Skip)
            .ApplyTake(userFindManyArgs.Take)
            .ApplyOrderBy(userFindManyArgs.SortBy)
            .ToListAsync();

        return walletLogsItems.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple WalletLogsItems records for User
    /// </summary>
    public async Task UpdateWalletLogsItem(
        UserWhereUniqueInput uniqueId,
        WalletLogsWhereUniqueInput[] childrenIds
    )
    {
        var user = await _context
            .Users.Include(t => t.WalletLogsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .WalletLogsItems.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        user.WalletLogsItems = children;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple WalletsItems records to User
    /// </summary>
    public async Task ConnectWalletsSearchAsync(
        UserWhereUniqueInput uniqueId,
        WalletsWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Users.Include(x => x.WalletsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .WalletsItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.WalletsItems);

        foreach (var child in childrenToConnect)
        {
            parent.WalletsItems.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple WalletsItems records from User
    /// </summary>
    public async Task DisconnectWalletsSearchAsync(
        UserWhereUniqueInput uniqueId,
        WalletsWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Users.Include(x => x.WalletsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .WalletsItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.WalletsItems?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple WalletsItems records for User
    /// </summary>
    public async Task<List<Wallets>> FindWalletsSearchAsync(
        UserWhereUniqueInput uniqueId,
        WalletFindManyArgs userFindManyArgs
    )
    {
        var walletsItems = await _context
            .WalletsItems.Where(m => m.UserId == uniqueId.Id)
            .ApplyWhere(userFindManyArgs.Where)
            .ApplySkip(userFindManyArgs.Skip)
            .ApplyTake(userFindManyArgs.Take)
            .ApplyOrderBy(userFindManyArgs.SortBy)
            .ToListAsync();

        return walletsItems.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple WalletsItems records for User
    /// </summary>
    public async Task UpdateWalletsItem(
        UserWhereUniqueInput uniqueId,
        WalletsWhereUniqueInput[] childrenIds
    )
    {
        var user = await _context
            .Users.Include(t => t.WalletsItems)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .WalletsItems.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        user.WalletsItems = children;
        await _context.SaveChangesAsync();
    }
}
