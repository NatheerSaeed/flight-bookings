using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;

namespace FlightReservationManagement.APIs;

public interface IUsersService
{
    /// <summary>
    /// Create one User
    /// </summary>
    public Task<User> CreateUser(UserCreateInput user);

    /// <summary>
    /// Delete one User
    /// </summary>
    public Task DeleteUser(UserWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Users
    /// </summary>
    public Task<List<User>> Users(UserFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about User records
    /// </summary>
    public Task<MetadataDto> UsersMeta(UserFindManyArgs findManyArgs);

    /// <summary>
    /// Get one User
    /// </summary>
    public Task<User> User(UserWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one User
    /// </summary>
    public Task UpdateUser(UserWhereUniqueInput uniqueId, UserUpdateInput updateDto);

    /// <summary>
    /// Connect multiple AgencyProfilesItems records to User
    /// </summary>
    public Task ConnectAgencyProfilesItems(
        UserWhereUniqueInput uniqueId,
        AgencyProfilesWhereUniqueInput[] agencyProfilesId
    );

    /// <summary>
    /// Disconnect multiple AgencyProfilesItems records from User
    /// </summary>
    public Task DisconnectAgencyProfilesItems(
        UserWhereUniqueInput uniqueId,
        AgencyProfilesWhereUniqueInput[] agencyProfilesId
    );

    /// <summary>
    /// Find multiple AgencyProfilesItems records for User
    /// </summary>
    public Task<List<AgencyProfiles>> FindAgencyProfilesItems(
        UserWhereUniqueInput uniqueId,
        AgencyProfilesFindManyArgs AgencyProfilesFindManyArgs
    );

    /// <summary>
    /// Update multiple AgencyProfilesItems records for User
    /// </summary>
    public Task UpdateAgencyProfilesItems(
        UserWhereUniqueInput uniqueId,
        AgencyProfilesWhereUniqueInput[] agencyProfilesId
    );

    /// <summary>
    /// Connect multiple AirlinesItems records to User
    /// </summary>
    public Task ConnectAirlinesItems(
        UserWhereUniqueInput uniqueId,
        AirlinesWhereUniqueInput[] airlinesId
    );

    /// <summary>
    /// Disconnect multiple AirlinesItems records from User
    /// </summary>
    public Task DisconnectAirlinesItems(
        UserWhereUniqueInput uniqueId,
        AirlinesWhereUniqueInput[] airlinesId
    );

    /// <summary>
    /// Find multiple AirlinesItems records for User
    /// </summary>
    public Task<List<Airlines>> FindAirlinesItems(
        UserWhereUniqueInput uniqueId,
        AirlinesFindManyArgs AirlinesFindManyArgs
    );

    /// <summary>
    /// Update multiple AirlinesItems records for User
    /// </summary>
    public Task UpdateAirlinesItems(
        UserWhereUniqueInput uniqueId,
        AirlinesWhereUniqueInput[] airlinesId
    );

    /// <summary>
    /// Connect multiple BankPaymentsItems records to User
    /// </summary>
    public Task ConnectBankPaymentsItems(
        UserWhereUniqueInput uniqueId,
        BankPaymentsWhereUniqueInput[] bankPaymentsId
    );

    /// <summary>
    /// Disconnect multiple BankPaymentsItems records from User
    /// </summary>
    public Task DisconnectBankPaymentsItems(
        UserWhereUniqueInput uniqueId,
        BankPaymentsWhereUniqueInput[] bankPaymentsId
    );

    /// <summary>
    /// Find multiple BankPaymentsItems records for User
    /// </summary>
    public Task<List<BankPayments>> FindBankPaymentsItems(
        UserWhereUniqueInput uniqueId,
        BankPaymentsFindManyArgs BankPaymentsFindManyArgs
    );

    /// <summary>
    /// Update multiple BankPaymentsItems records for User
    /// </summary>
    public Task UpdateBankPaymentsItems(
        UserWhereUniqueInput uniqueId,
        BankPaymentsWhereUniqueInput[] bankPaymentsId
    );

    /// <summary>
    /// Connect multiple HotelBookingsItems records to User
    /// </summary>
    public Task ConnectHotelBookingsItems(
        UserWhereUniqueInput uniqueId,
        HotelBookingsWhereUniqueInput[] hotelBookingsId
    );

    /// <summary>
    /// Disconnect multiple HotelBookingsItems records from User
    /// </summary>
    public Task DisconnectHotelBookingsItems(
        UserWhereUniqueInput uniqueId,
        HotelBookingsWhereUniqueInput[] hotelBookingsId
    );

    /// <summary>
    /// Find multiple HotelBookingsItems records for User
    /// </summary>
    public Task<List<HotelBookings>> FindHotelBookingsItems(
        UserWhereUniqueInput uniqueId,
        HotelBookingsFindManyArgs HotelBookingsFindManyArgs
    );

    /// <summary>
    /// Update multiple HotelBookingsItems records for User
    /// </summary>
    public Task UpdateHotelBookingsItems(
        UserWhereUniqueInput uniqueId,
        HotelBookingsWhereUniqueInput[] hotelBookingsId
    );

    /// <summary>
    /// Connect multiple PayLatersItems records to User
    /// </summary>
    public Task ConnectPayLatersItems(
        UserWhereUniqueInput uniqueId,
        PayLatersWhereUniqueInput[] payLatersId
    );

    /// <summary>
    /// Disconnect multiple PayLatersItems records from User
    /// </summary>
    public Task DisconnectPayLatersItems(
        UserWhereUniqueInput uniqueId,
        PayLatersWhereUniqueInput[] payLatersId
    );

    /// <summary>
    /// Find multiple PayLatersItems records for User
    /// </summary>
    public Task<List<PayLaters>> FindPayLatersItems(
        UserWhereUniqueInput uniqueId,
        PayLatersFindManyArgs PayLatersFindManyArgs
    );

    /// <summary>
    /// Update multiple PayLatersItems records for User
    /// </summary>
    public Task UpdatePayLatersItems(
        UserWhereUniqueInput uniqueId,
        PayLatersWhereUniqueInput[] payLatersId
    );

    /// <summary>
    /// Connect multiple ProfilesItems records to User
    /// </summary>
    public Task ConnectProfilesItems(
        UserWhereUniqueInput uniqueId,
        ProfilesWhereUniqueInput[] profilesId
    );

    /// <summary>
    /// Disconnect multiple ProfilesItems records from User
    /// </summary>
    public Task DisconnectProfilesItems(
        UserWhereUniqueInput uniqueId,
        ProfilesWhereUniqueInput[] profilesId
    );

    /// <summary>
    /// Find multiple ProfilesItems records for User
    /// </summary>
    public Task<List<Profiles>> FindProfilesItems(
        UserWhereUniqueInput uniqueId,
        ProfilesFindManyArgs ProfilesFindManyArgs
    );

    /// <summary>
    /// Update multiple ProfilesItems records for User
    /// </summary>
    public Task UpdateProfilesItems(
        UserWhereUniqueInput uniqueId,
        ProfilesWhereUniqueInput[] profilesId
    );

    /// <summary>
    /// Connect multiple WalletLogsItems records to User
    /// </summary>
    public Task ConnectWalletLogsItems(
        UserWhereUniqueInput uniqueId,
        WalletLogsWhereUniqueInput[] walletLogsId
    );

    /// <summary>
    /// Disconnect multiple WalletLogsItems records from User
    /// </summary>
    public Task DisconnectWalletLogsItems(
        UserWhereUniqueInput uniqueId,
        WalletLogsWhereUniqueInput[] walletLogsId
    );

    /// <summary>
    /// Find multiple WalletLogsItems records for User
    /// </summary>
    public Task<List<WalletLogs>> FindWalletLogsItems(
        UserWhereUniqueInput uniqueId,
        WalletLogsFindManyArgs WalletLogsFindManyArgs
    );

    /// <summary>
    /// Update multiple WalletLogsItems records for User
    /// </summary>
    public Task UpdateWalletLogsItems(
        UserWhereUniqueInput uniqueId,
        WalletLogsWhereUniqueInput[] walletLogsId
    );

    /// <summary>
    /// Connect multiple WalletsItems records to User
    /// </summary>
    public Task ConnectWalletsItems(
        UserWhereUniqueInput uniqueId,
        WalletsWhereUniqueInput[] walletsId
    );

    /// <summary>
    /// Disconnect multiple WalletsItems records from User
    /// </summary>
    public Task DisconnectWalletsItems(
        UserWhereUniqueInput uniqueId,
        WalletsWhereUniqueInput[] walletsId
    );

    /// <summary>
    /// Find multiple WalletsItems records for User
    /// </summary>
    public Task<List<Wallets>> FindWalletsItems(
        UserWhereUniqueInput uniqueId,
        WalletsFindManyArgs WalletsFindManyArgs
    );

    /// <summary>
    /// Update multiple WalletsItems records for User
    /// </summary>
    public Task UpdateWalletsItems(
        UserWhereUniqueInput uniqueId,
        WalletsWhereUniqueInput[] walletsId
    );
}