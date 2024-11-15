using FlightReservationManagement.APIs;

namespace FlightReservationManagement;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IAgencyProfilesItemsService, AgencyProfilesItemsService>();
        services.AddScoped<IAirlinesItemsService, AirlinesItemsService>();
        services.AddScoped<IAirportsItemsService, AirportsItemsService>();
        services.AddScoped<IAttractionsItemsService, AttractionsItemsService>();
        services.AddScoped<IBankDetailsItemsService, BankDetailsItemsService>();
        services.AddScoped<IBankPaymentsItemsService, BankPaymentsItemsService>();
        services.AddScoped<IBanksItemsService, BanksItemsService>();
        services.AddScoped<ICabinTypesItemsService, CabinTypesItemsService>();
        services.AddScoped<ICarBookingsItemsService, CarBookingsItemsService>();
        services.AddScoped<ICommentsItemsService, CommentsItemsService>();
        services.AddScoped<ICooperateCustomerProfilesItemsService, CooperateCustomerProfilesItemsService>();
        services.AddScoped<IEmailSubscribersItemsService, EmailSubscribersItemsService>();
        services.AddScoped<IFlightBookingsItemsService, FlightBookingsItemsService>();
        services.AddScoped<IFlightDealsItemsService, FlightDealsItemsService>();
        services.AddScoped<IGalleriesItemsService, GalleriesItemsService>();
        services.AddScoped<IGendersItemsService, GendersItemsService>();
        services.AddScoped<IGoodToKnowsItemsService, GoodToKnowsItemsService>();
        services.AddScoped<IHotelBookingsItemsService, HotelBookingsItemsService>();
        services.AddScoped<IHotelDealsItemsService, HotelDealsItemsService>();
        services.AddScoped<IHotelsItemsService, HotelsItemsService>();
        services.AddScoped<IMarkdownsItemsService, MarkdownsItemsService>();
        services.AddScoped<IMarkupsItemsService, MarkupsItemsService>();
        services.AddScoped<IOnlinePaymentsItemsService, OnlinePaymentsItemsService>();
        services.AddScoped<IPackageAttractionsItemsService, PackageAttractionsItemsService>();
        services.AddScoped<IPackageBookingsItemsService, PackageBookingsItemsService>();
        services.AddScoped<IPackageCategoriesItemsService, PackageCategoriesItemsService>();
        services.AddScoped<IPackageFlightsItemsService, PackageFlightsItemsService>();
        services.AddScoped<IPackageHotelsItemsService, PackageHotelsItemsService>();
        services.AddScoped<IPackagesItemsService, PackagesItemsService>();
        services.AddScoped<IPackageTypesItemsService, PackageTypesItemsService>();
        services.AddScoped<IPasswordResetsItemsService, PasswordResetsItemsService>();
        services.AddScoped<IPayLatersItemsService, PayLatersItemsService>();
        services.AddScoped<IProfilesItemsService, ProfilesItemsService>();
        services.AddScoped<IRolesItemsService, RolesItemsService>();
        services.AddScoped<ISightSeeingsItemsService, SightSeeingsItemsService>();
        services.AddScoped<ITitlesItemsService, TitlesItemsService>();
        services.AddScoped<ITravelPackagesItemsService, TravelPackagesItemsService>();
        services.AddScoped<IUsersService, UsersService>();
        services.AddScoped<IVatsItemsService, VatsItemsService>();
        services.AddScoped<IVisaApplicationsItemsService, VisaApplicationsItemsService>();
        services.AddScoped<IVouchersItemsService, VouchersItemsService>();
        services.AddScoped<IWalletLogsItemsService, WalletLogsItemsService>();
        services.AddScoped<IWalletLogTypesItemsService, WalletLogTypesItemsService>();
        services.AddScoped<IWalletsItemsService, WalletsItemsService>();
    }
}
