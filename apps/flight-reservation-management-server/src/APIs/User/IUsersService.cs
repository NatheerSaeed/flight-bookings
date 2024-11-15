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
    public Task ConnectAgencyProfilesSearchAsync(
        UserWhereUniqueInput uniqueId,
        AgencyProfilesWhereUniqueInput[] agencyProfilesId
    );

    /// <summary>
    /// Disconnect multiple AgencyProfilesItems records from User
    /// </summary>
    public Task DisconnectAgencyProfilesSearchAsync(
        UserWhereUniqueInput uniqueId,
        AgencyProfilesWhereUniqueInput[] agencyProfilesId
    );

    /// <summary>
    /// Find multiple AgencyProfilesItems records for User
    /// </summary>
    public Task<List<AgencyProfiles>> FindAgencyProfilesSearchAsync(
        UserWhereUniqueInput uniqueId,
        AgencyProfileFindManyArgs AgencyProfileFindManyArgs
    );

    /// <summary>
    /// Update multiple AgencyProfilesItems records for User
    /// </summary>
    public Task UpdateAgencyProfilesItem(
        UserWhereUniqueInput uniqueId,
        AgencyProfilesWhereUniqueInput[] agencyProfilesId
    );

    /// <summary>
    /// Connect multiple AirlinesItems records to User
    /// </summary>
    public Task ConnectAirlinesSearchAsync(
        UserWhereUniqueInput uniqueId,
        AirlinesWhereUniqueInput[] airlinesId
    );

    /// <summary>
    /// Disconnect multiple AirlinesItems records from User
    /// </summary>
    public Task DisconnectAirlinesSearchAsync(
        UserWhereUniqueInput uniqueId,
        AirlinesWhereUniqueInput[] airlinesId
    );

    /// <summary>
    /// Find multiple AirlinesItems records for User
    /// </summary>
    public Task<List<Airlines>> FindAirlinesSearchAsync(
        UserWhereUniqueInput uniqueId,
        AirlineFindManyArgs AirlineFindManyArgs
    );

    /// <summary>
    /// Update multiple AirlinesItems records for User
    /// </summary>
    public Task UpdateAirlinesItem(
        UserWhereUniqueInput uniqueId,
        AirlinesWhereUniqueInput[] airlinesId
    );

    /// <summary>
    /// Connect multiple BankPaymentsItems records to User
    /// </summary>
    public Task ConnectBankPaymentsSearchAsync(
        UserWhereUniqueInput uniqueId,
        BankPaymentsWhereUniqueInput[] bankPaymentsId
    );

    /// <summary>
    /// Disconnect multiple BankPaymentsItems records from User
    /// </summary>
    public Task DisconnectBankPaymentsSearchAsync(
        UserWhereUniqueInput uniqueId,
        BankPaymentsWhereUniqueInput[] bankPaymentsId
    );

    /// <summary>
    /// Find multiple BankPaymentsItems records for User
    /// </summary>
    public Task<List<BankPayments>> FindBankPaymentsSearchAsync(
        UserWhereUniqueInput uniqueId,
        BankPaymentFindManyArgs BankPaymentFindManyArgs
    );

    /// <summary>
    /// Update multiple BankPaymentsItems records for User
    /// </summary>
    public Task UpdateBankPaymentsItem(
        UserWhereUniqueInput uniqueId,
        BankPaymentsWhereUniqueInput[] bankPaymentsId
    );

    /// <summary>
    /// Connect multiple CarBookingsItems records to User
    /// </summary>
    public Task ConnectCarBookingsSearchAsync(
        UserWhereUniqueInput uniqueId,
        CarBookingsWhereUniqueInput[] carBookingsId
    );

    /// <summary>
    /// Disconnect multiple CarBookingsItems records from User
    /// </summary>
    public Task DisconnectCarBookingsSearchAsync(
        UserWhereUniqueInput uniqueId,
        CarBookingsWhereUniqueInput[] carBookingsId
    );

    /// <summary>
    /// Find multiple CarBookingsItems records for User
    /// </summary>
    public Task<List<CarBookings>> FindCarBookingsSearchAsync(
        UserWhereUniqueInput uniqueId,
        CarBookingFindManyArgs CarBookingFindManyArgs
    );

    /// <summary>
    /// Update multiple CarBookingsItems records for User
    /// </summary>
    public Task UpdateCarBookingsItem(
        UserWhereUniqueInput uniqueId,
        CarBookingsWhereUniqueInput[] carBookingsId
    );

    /// <summary>
    /// Connect multiple CooperateCustomerProfilesItems records to User
    /// </summary>
    public Task ConnectCooperateCustomerProfilesSearchAsync(
        UserWhereUniqueInput uniqueId,
        CooperateCustomerProfilesWhereUniqueInput[] cooperateCustomerProfilesId
    );

    /// <summary>
    /// Disconnect multiple CooperateCustomerProfilesItems records from User
    /// </summary>
    public Task DisconnectCooperateCustomerProfilesSearchAsync(
        UserWhereUniqueInput uniqueId,
        CooperateCustomerProfilesWhereUniqueInput[] cooperateCustomerProfilesId
    );

    /// <summary>
    /// Find multiple CooperateCustomerProfilesItems records for User
    /// </summary>
    public Task<List<CooperateCustomerProfiles>> FindCooperateCustomerProfilesSearchAsync(
        UserWhereUniqueInput uniqueId,
        CooperateCustomerProfileFindManyArgs CooperateCustomerProfileFindManyArgs
    );

    /// <summary>
    /// Update multiple CooperateCustomerProfilesItems records for User
    /// </summary>
    public Task UpdateCooperateCustomerProfilesItem(
        UserWhereUniqueInput uniqueId,
        CooperateCustomerProfilesWhereUniqueInput[] cooperateCustomerProfilesId
    );

    /// <summary>
    /// Connect multiple FlightBookingsItems records to User
    /// </summary>
    public Task ConnectFlightBookingsSearchAsync(
        UserWhereUniqueInput uniqueId,
        FlightBookingsWhereUniqueInput[] flightBookingsId
    );

    /// <summary>
    /// Disconnect multiple FlightBookingsItems records from User
    /// </summary>
    public Task DisconnectFlightBookingsSearchAsync(
        UserWhereUniqueInput uniqueId,
        FlightBookingsWhereUniqueInput[] flightBookingsId
    );

    /// <summary>
    /// Find multiple FlightBookingsItems records for User
    /// </summary>
    public Task<List<FlightBookings>> FindFlightBookingsSearchAsync(
        UserWhereUniqueInput uniqueId,
        FlightBookingFindManyArgs FlightBookingFindManyArgs
    );

    /// <summary>
    /// Update multiple FlightBookingsItems records for User
    /// </summary>
    public Task UpdateFlightBookingsItem(
        UserWhereUniqueInput uniqueId,
        FlightBookingsWhereUniqueInput[] flightBookingsId
    );

    /// <summary>
    /// Connect multiple HotelBookingsItems records to User
    /// </summary>
    public Task ConnectHotelBookingsSearchAsync(
        UserWhereUniqueInput uniqueId,
        HotelBookingsWhereUniqueInput[] hotelBookingsId
    );

    /// <summary>
    /// Disconnect multiple HotelBookingsItems records from User
    /// </summary>
    public Task DisconnectHotelBookingsSearchAsync(
        UserWhereUniqueInput uniqueId,
        HotelBookingsWhereUniqueInput[] hotelBookingsId
    );

    /// <summary>
    /// Find multiple HotelBookingsItems records for User
    /// </summary>
    public Task<List<HotelBookings>> FindHotelBookingsSearchAsync(
        UserWhereUniqueInput uniqueId,
        HotelBookingFindManyArgs HotelBookingFindManyArgs
    );

    /// <summary>
    /// Update multiple HotelBookingsItems records for User
    /// </summary>
    public Task UpdateHotelBookingsItem(
        UserWhereUniqueInput uniqueId,
        HotelBookingsWhereUniqueInput[] hotelBookingsId
    );

    /// <summary>
    /// Connect multiple OnlinePaymentsItems records to User
    /// </summary>
    public Task ConnectOnlinePaymentsSearchAsync(
        UserWhereUniqueInput uniqueId,
        OnlinePaymentsWhereUniqueInput[] onlinePaymentsId
    );

    /// <summary>
    /// Disconnect multiple OnlinePaymentsItems records from User
    /// </summary>
    public Task DisconnectOnlinePaymentsSearchAsync(
        UserWhereUniqueInput uniqueId,
        OnlinePaymentsWhereUniqueInput[] onlinePaymentsId
    );

    /// <summary>
    /// Find multiple OnlinePaymentsItems records for User
    /// </summary>
    public Task<List<OnlinePayments>> FindOnlinePaymentsSearchAsync(
        UserWhereUniqueInput uniqueId,
        OnlinePaymentFindManyArgs OnlinePaymentFindManyArgs
    );

    /// <summary>
    /// Update multiple OnlinePaymentsItems records for User
    /// </summary>
    public Task UpdateOnlinePaymentsItem(
        UserWhereUniqueInput uniqueId,
        OnlinePaymentsWhereUniqueInput[] onlinePaymentsId
    );

    /// <summary>
    /// Connect multiple PackageBookingsItems records to User
    /// </summary>
    public Task ConnectPackageBookingsSearchAsync(
        UserWhereUniqueInput uniqueId,
        PackageBookingsWhereUniqueInput[] packageBookingsId
    );

    /// <summary>
    /// Disconnect multiple PackageBookingsItems records from User
    /// </summary>
    public Task DisconnectPackageBookingsSearchAsync(
        UserWhereUniqueInput uniqueId,
        PackageBookingsWhereUniqueInput[] packageBookingsId
    );

    /// <summary>
    /// Find multiple PackageBookingsItems records for User
    /// </summary>
    public Task<List<PackageBookings>> FindPackageBookingsSearchAsync(
        UserWhereUniqueInput uniqueId,
        PackageBookingFindManyArgs PackageBookingFindManyArgs
    );

    /// <summary>
    /// Update multiple PackageBookingsItems records for User
    /// </summary>
    public Task UpdatePackageBookingsItem(
        UserWhereUniqueInput uniqueId,
        PackageBookingsWhereUniqueInput[] packageBookingsId
    );

    /// <summary>
    /// Connect multiple PayLatersItems records to User
    /// </summary>
    public Task ConnectPayLatersSearchAsync(
        UserWhereUniqueInput uniqueId,
        PayLatersWhereUniqueInput[] payLatersId
    );

    /// <summary>
    /// Disconnect multiple PayLatersItems records from User
    /// </summary>
    public Task DisconnectPayLatersSearchAsync(
        UserWhereUniqueInput uniqueId,
        PayLatersWhereUniqueInput[] payLatersId
    );

    /// <summary>
    /// Find multiple PayLatersItems records for User
    /// </summary>
    public Task<List<PayLaters>> FindPayLatersSearchAsync(
        UserWhereUniqueInput uniqueId,
        PayLaterFindManyArgs PayLaterFindManyArgs
    );

    /// <summary>
    /// Update multiple PayLatersItems records for User
    /// </summary>
    public Task UpdatePayLatersItem(
        UserWhereUniqueInput uniqueId,
        PayLatersWhereUniqueInput[] payLatersId
    );

    /// <summary>
    /// Connect multiple ProfilesItems records to User
    /// </summary>
    public Task ConnectProfilesSearchAsync(
        UserWhereUniqueInput uniqueId,
        ProfilesWhereUniqueInput[] profilesId
    );

    /// <summary>
    /// Disconnect multiple ProfilesItems records from User
    /// </summary>
    public Task DisconnectProfilesSearchAsync(
        UserWhereUniqueInput uniqueId,
        ProfilesWhereUniqueInput[] profilesId
    );

    /// <summary>
    /// Find multiple ProfilesItems records for User
    /// </summary>
    public Task<List<Profiles>> FindProfilesSearchAsync(
        UserWhereUniqueInput uniqueId,
        ProfileFindManyArgs ProfileFindManyArgs
    );

    /// <summary>
    /// Update multiple ProfilesItems records for User
    /// </summary>
    public Task UpdateProfilesItem(
        UserWhereUniqueInput uniqueId,
        ProfilesWhereUniqueInput[] profilesId
    );

    /// <summary>
    /// Connect multiple WalletLogsItems records to User
    /// </summary>
    public Task ConnectWalletLogsSearchAsync(
        UserWhereUniqueInput uniqueId,
        WalletLogsWhereUniqueInput[] walletLogsId
    );

    /// <summary>
    /// Disconnect multiple WalletLogsItems records from User
    /// </summary>
    public Task DisconnectWalletLogsSearchAsync(
        UserWhereUniqueInput uniqueId,
        WalletLogsWhereUniqueInput[] walletLogsId
    );

    /// <summary>
    /// Find multiple WalletLogsItems records for User
    /// </summary>
    public Task<List<WalletLogs>> FindWalletLogsSearchAsync(
        UserWhereUniqueInput uniqueId,
        WalletLogFindManyArgs WalletLogFindManyArgs
    );

    /// <summary>
    /// Update multiple WalletLogsItems records for User
    /// </summary>
    public Task UpdateWalletLogsItem(
        UserWhereUniqueInput uniqueId,
        WalletLogsWhereUniqueInput[] walletLogsId
    );

    /// <summary>
    /// Connect multiple WalletsItems records to User
    /// </summary>
    public Task ConnectWalletsSearchAsync(
        UserWhereUniqueInput uniqueId,
        WalletsWhereUniqueInput[] walletsId
    );

    /// <summary>
    /// Disconnect multiple WalletsItems records from User
    /// </summary>
    public Task DisconnectWalletsSearchAsync(
        UserWhereUniqueInput uniqueId,
        WalletsWhereUniqueInput[] walletsId
    );

    /// <summary>
    /// Find multiple WalletsItems records for User
    /// </summary>
    public Task<List<Wallets>> FindWalletsSearchAsync(
        UserWhereUniqueInput uniqueId,
        WalletFindManyArgs WalletFindManyArgs
    );

    /// <summary>
    /// Update multiple WalletsItems records for User
    /// </summary>
    public Task UpdateWalletsItem(
        UserWhereUniqueInput uniqueId,
        WalletsWhereUniqueInput[] walletsId
    );
}
