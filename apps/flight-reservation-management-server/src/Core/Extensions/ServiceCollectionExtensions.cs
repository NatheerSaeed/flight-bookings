using FlightReservationManagement.APIs;

namespace FlightReservationManagement;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IAgencyProfilesService, AgencyProfilesService>();
        services.AddScoped<IAirlinesService, AirlinesService>();
        services.AddScoped<IAirportsService, AirportsService>();
        services.AddScoped<IAttractionsService, AttractionsService>();
        services.AddScoped<IBankDetailsService, BankDetailsService>();
        services.AddScoped<IBankPaymentsService, BankPaymentsService>();
        services.AddScoped<IBanksService, BanksService>();
        services.AddScoped<ICabinTypesService, CabinTypesService>();
        services.AddScoped<ICarBookingsService, CarBookingsService>();
        services.AddScoped<ICommentsService, CommentsService>();
        services.AddScoped<IEmailSubscribersService, EmailSubscribersService>();
        services.AddScoped<IFlightBookingsService, FlightBookingsService>();
        services.AddScoped<IFlightDealsService, FlightDealsService>();
        services.AddScoped<IGalleriesService, GalleriesService>();
        services.AddScoped<IGendersService, GendersService>();
        services.AddScoped<IGoodToKnowsService, GoodToKnowsService>();
        services.AddScoped<IHotelBookingsService, HotelBookingsService>();
        services.AddScoped<IHotelDealsService, HotelDealsService>();
        services.AddScoped<IHotelsService, HotelsService>();
        services.AddScoped<IMarkdownsService, MarkdownsService>();
        services.AddScoped<IMarkupsService, MarkupsService>();
        services.AddScoped<IOnlinePaymentsService, OnlinePaymentsService>();
        services.AddScoped<IPackageAttractionsService, PackageAttractionsService>();
        services.AddScoped<IPackageBookingsService, PackageBookingsService>();
        services.AddScoped<IPackageCategoriesService, PackageCategoriesService>();
        services.AddScoped<IPackageFlightsService, PackageFlightsService>();
        services.AddScoped<IPackageHotelsService, PackageHotelsService>();
        services.AddScoped<IPackagesService, PackagesService>();
        services.AddScoped<IPackageTypesService, PackageTypesService>();
        services.AddScoped<IPasswordResetsService, PasswordResetsService>();
        services.AddScoped<IPayLatersService, PayLatersService>();
        services.AddScoped<IProfilesService, ProfilesService>();
        services.AddScoped<IRolesService, RolesService>();
        services.AddScoped<ISightSeeingsService, SightSeeingsService>();
        services.AddScoped<ITitlesService, TitlesService>();
        services.AddScoped<ITravelPackagesService, TravelPackagesService>();
        services.AddScoped<IUsersService, UsersService>();
        services.AddScoped<IVatsService, VatsService>();
        services.AddScoped<IVisaApplicationsService, VisaApplicationsService>();
        services.AddScoped<IVouchersService, VouchersService>();
        services.AddScoped<IWalletLogsService, WalletLogsService>();
        services.AddScoped<IWalletLogTypesService, WalletLogTypesService>();
        services.AddScoped<IWalletsService, WalletsService>();
        services.AddScoped<ICooperateCustomerProfilesService, CooperateCustomerProfilesService>();
    }
}
