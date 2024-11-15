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
    public async Task<User> CreateUser(UserCreateInput createDto)
    {
        var user = new UserDbModel
        {
            ApiToken = createDto.ApiToken,
            CreatedAt = createDto.CreatedAt,
            DeleteStatus = createDto.DeleteStatus,
            Email = createDto.Email,
            FirstName = createDto.FirstName,
            LastName = createDto.LastName,
            Password = createDto.Password,
            ProfileCompleteStatus = createDto.ProfileCompleteStatus,
            Roles = createDto.Roles,
            UpdatedAt = createDto.UpdatedAt,
            Username = createDto.Username
        };

        if (createDto.Id != null)
        {
            user.Id = createDto.Id;
        }
        if (createDto.AgencyProfilesItems != null)
        {
            user.AgencyProfilesItems = await _context
                .AgencyProfilesItems.Where(agencyProfiles =>
                    createDto.AgencyProfilesItems.Select(t => t.Id).Contains(agencyProfiles.Id)
                )
                .ToListAsync();
        }

        if (createDto.AirlinesItems != null)
        {
            user.AirlinesItems = await _context
                .AirlinesItems.Where(airlines =>
                    createDto.AirlinesItems.Select(t => t.Id).Contains(airlines.Id)
                )
                .ToListAsync();
        }

        if (createDto.BankPaymentsItems != null)
        {
            user.BankPaymentsItems = await _context
                .BankPaymentsItems.Where(bankPayments =>
                    createDto.BankPaymentsItems.Select(t => t.Id).Contains(bankPayments.Id)
                )
                .ToListAsync();
        }

        if (createDto.HotelBookingsItems != null)
        {
            user.HotelBookingsItems = await _context
                .HotelBookingsItems.Where(hotelBookings =>
                    createDto.HotelBookingsItems.Select(t => t.Id).Contains(hotelBookings.Id)
                )
                .ToListAsync();
        }

        if (createDto.PayLatersItems != null)
        {
            user.PayLatersItems = await _context
                .PayLatersItems.Where(payLaters =>
                    createDto.PayLatersItems.Select(t => t.Id).Contains(payLaters.Id)
                )
                .ToListAsync();
        }

        if (createDto.ProfilesItems != null)
        {
            user.ProfilesItems = await _context
                .ProfilesItems.Where(profiles =>
                    createDto.ProfilesItems.Select(t => t.Id).Contains(profiles.Id)
                )
                .ToListAsync();
        }

        if (createDto.WalletLogsItems != null)
        {
            user.WalletLogsItems = await _context
                .WalletLogsItems.Where(walletLogs =>
                    createDto.WalletLogsItems.Select(t => t.Id).Contains(walletLogs.Id)
                )
                .ToListAsync();
        }

        if (createDto.WalletsItems != null)
        {
            user.WalletsItems = await _context
                .WalletsItems.Where(wallets =>
                    createDto.WalletsItems.Select(t => t.Id).Contains(wallets.Id)
                )
                .ToListAsync();
        }

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<UserDbModel>(user.Id);

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
    public async Task<List<User>> Users(UserFindManyArgs findManyArgs)
    {
        var users = await _context
            .Users.Include(x => x.HotelBookingsItems)
            .Include(x => x.AirlinesItems)
            .Include(x => x.BankPaymentsItems)
            .Include(x => x.ProfilesItems)
            .Include(x => x.PayLatersItems)
            .Include(x => x.WalletsItems)
            .Include(x => x.WalletLogsItems)
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
    public async Task<User> User(UserWhereUniqueInput uniqueId)
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

        if (updateDto.HotelBookingsItems != null)
        {
            user.HotelBookingsItems = await _context
                .HotelBookingsItems.Where(hotelBookings =>
                    updateDto.HotelBookingsItems.Select(t => t).Contains(hotelBookings.Id)
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
    public async Task ConnectAgencyProfilesItems(
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
    public async Task DisconnectAgencyProfilesItems(
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
    public async Task<List<AgencyProfiles>> FindAgencyProfilesItems(
        UserWhereUniqueInput uniqueId,
        AgencyProfilesFindManyArgs userFindManyArgs
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
    public async Task UpdateAgencyProfilesItems(
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
    public async Task ConnectAirlinesItems(
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
    public async Task DisconnectAirlinesItems(
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
    public async Task<List<Airlines>> FindAirlinesItems(
        UserWhereUniqueInput uniqueId,
        AirlinesFindManyArgs userFindManyArgs
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
    public async Task UpdateAirlinesItems(
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
    public async Task ConnectBankPaymentsItems(
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
    public async Task DisconnectBankPaymentsItems(
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
    public async Task<List<BankPayments>> FindBankPaymentsItems(
        UserWhereUniqueInput uniqueId,
        BankPaymentsFindManyArgs userFindManyArgs
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
    public async Task UpdateBankPaymentsItems(
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
    /// Connect multiple HotelBookingsItems records to User
    /// </summary>
    public async Task ConnectHotelBookingsItems(
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
    public async Task DisconnectHotelBookingsItems(
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
    public async Task<List<HotelBookings>> FindHotelBookingsItems(
        UserWhereUniqueInput uniqueId,
        HotelBookingsFindManyArgs userFindManyArgs
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
    public async Task UpdateHotelBookingsItems(
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
    /// Connect multiple PayLatersItems records to User
    /// </summary>
    public async Task ConnectPayLatersItems(
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
    public async Task DisconnectPayLatersItems(
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
    public async Task<List<PayLaters>> FindPayLatersItems(
        UserWhereUniqueInput uniqueId,
        PayLatersFindManyArgs userFindManyArgs
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
    public async Task UpdatePayLatersItems(
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
    public async Task ConnectProfilesItems(
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
    public async Task DisconnectProfilesItems(
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
    public async Task<List<Profiles>> FindProfilesItems(
        UserWhereUniqueInput uniqueId,
        ProfilesFindManyArgs userFindManyArgs
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
    public async Task UpdateProfilesItems(
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
    public async Task ConnectWalletLogsItems(
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
    public async Task DisconnectWalletLogsItems(
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
    public async Task<List<WalletLogs>> FindWalletLogsItems(
        UserWhereUniqueInput uniqueId,
        WalletLogsFindManyArgs userFindManyArgs
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
    public async Task UpdateWalletLogsItems(
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
    public async Task ConnectWalletsItems(
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
    public async Task DisconnectWalletsItems(
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
    public async Task<List<Wallets>> FindWalletsItems(
        UserWhereUniqueInput uniqueId,
        WalletsFindManyArgs userFindManyArgs
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
    public async Task UpdateWalletsItems(
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
