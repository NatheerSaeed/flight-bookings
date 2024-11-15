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
        services.AddScoped<IAgencyProfilesService, AgencyProfilesService>();
        services.AddScoped<IAirlinesService, AirlinesService>();
        services.AddScoped<IAirlinesService, AirlinesService>();
        services.AddScoped<IAirportsService, AirportsService>();
        services.AddScoped<IAirportsService, AirportsService>();
        services.AddScoped<IAttractionsService, AttractionsService>();
        services.AddScoped<IAttractionsService, AttractionsService>();
        services.AddScoped<IBanksService, BanksService>();
        services.AddScoped<IBankDetailsService, BankDetailsService>();
        services.AddScoped<IBankDetailsService, BankDetailsService>();
        services.AddScoped<IBankPaymentsService, BankPaymentsService>();
        services.AddScoped<IBankPaymentsService, BankPaymentsService>();
        services.AddScoped<IBanksService, BanksService>();
        services.AddScoped<ICabinTypesService, CabinTypesService>();
        services.AddScoped<ICabinTypesService, CabinTypesService>();
        services.AddScoped<ICarBookingsService, CarBookingsService>();
        services.AddScoped<ICarBookingsService, CarBookingsService>();
        services.AddScoped<ICommentsService, CommentsService>();
        services.AddScoped<ICommentsService, CommentsService>();
        services.AddScoped<ICooperateCustomerProfilesService, CooperateCustomerProfilesService>();
        services.AddScoped<ICooperateCustomerProfilesService, CooperateCustomerProfilesService>();
        services.AddScoped<IEmailSubscribersService, EmailSubscribersService>();
        services.AddScoped<IEmailSubscribersService, EmailSubscribersService>();
        services.AddScoped<IFlightBookingsService, FlightBookingsService>();
        services.AddScoped<IFlightBookingsService, FlightBookingsService>();
        services.AddScoped<IFlightDealsService, FlightDealsService>();
        services.AddScoped<IFlightDealsService, FlightDealsService>();
        services.AddScoped<IGalleriesService, GalleriesService>();
        services.AddScoped<IGalleriesService, GalleriesService>();
        services.AddScoped<IGendersService, GendersService>();
        services.AddScoped<IGendersService, GendersService>();
        services.AddScoped<IGoodToKnowsService, GoodToKnowsService>();
        services.AddScoped<IGoodToKnowsService, GoodToKnowsService>();
        services.AddScoped<IHotelsService, HotelsService>();
        services.AddScoped<IHotelBookingsService, HotelBookingsService>();
        services.AddScoped<IHotelBookingsService, HotelBookingsService>();
        services.AddScoped<IHotelDealsService, HotelDealsService>();
        services.AddScoped<IHotelDealsService, HotelDealsService>();
        services.AddScoped<IHotelsService, HotelsService>();
        services.AddScoped<IMarkdownsService, MarkdownsService>();
        services.AddScoped<IMarkdownsService, MarkdownsService>();
        services.AddScoped<IMarkupsService, MarkupsService>();
        services.AddScoped<IMarkupsService, MarkupsService>();
        services.AddScoped<IOnlinePaymentsService, OnlinePaymentsService>();
        services.AddScoped<IOnlinePaymentsService, OnlinePaymentsService>();
        services.AddScoped<IPackageAttractionsService, PackageAttractionsService>();
        services.AddScoped<IPackageAttractionsService, PackageAttractionsService>();
        services.AddScoped<IPackageBookingsService, PackageBookingsService>();
        services.AddScoped<IPackageBookingsService, PackageBookingsService>();
        services.AddScoped<IPackageCategoriesService, PackageCategoriesService>();
        services.AddScoped<IPackageCategoriesService, PackageCategoriesService>();
        services.AddScoped<IPackageFlightsService, PackageFlightsService>();
        services.AddScoped<IPackageFlightsService, PackageFlightsService>();
        services.AddScoped<IPackageHotelsService, PackageHotelsService>();
        services.AddScoped<IPackageHotelsService, PackageHotelsService>();
        services.AddScoped<IPackageModelsService, PackageModelsService>();
        services.AddScoped<IPackagesService, PackagesService>();
        services.AddScoped<IPackageTypesService, PackageTypesService>();
        services.AddScoped<IPackageTypesService, PackageTypesService>();
        services.AddScoped<IPasswordResetsService, PasswordResetsService>();
        services.AddScoped<IPasswordResetsService, PasswordResetsService>();
        services.AddScoped<IPayLatersService, PayLatersService>();
        services.AddScoped<IPayLatersService, PayLatersService>();
        services.AddScoped<IProfilesService, ProfilesService>();
        services.AddScoped<IProfilesService, ProfilesService>();
        services.AddScoped<IRolesService, RolesService>();
        services.AddScoped<IRolesService, RolesService>();
        services.AddScoped<ISightSeeingsService, SightSeeingsService>();
        services.AddScoped<ISightSeeingsService, SightSeeingsService>();
        services.AddScoped<ITitlesService, TitlesService>();
        services.AddScoped<ITitlesService, TitlesService>();
        services.AddScoped<ITravelLocationsService, TravelLocationsService>();
        services.AddScoped<ITravelPackagesService, TravelPackagesService>();
        services.AddScoped<ITravelPackagesService, TravelPackagesService>();
        services.AddScoped<IUsersService, UsersService>();
        services.AddScoped<IVatsService, VatsService>();
        services.AddScoped<IVisaApplicationsService, VisaApplicationsService>();
        services.AddScoped<IVisaApplicationsService, VisaApplicationsService>();
        services.AddScoped<IVouchersService, VouchersService>();
        services.AddScoped<IVouchersService, VouchersService>();
        services.AddScoped<IWalletLogsService, WalletLogsService>();
        services.AddScoped<IWalletLogsService, WalletLogsService>();
        services.AddScoped<IWalletLogTypesService, WalletLogTypesService>();
        services.AddScoped<IWalletsService, WalletsService>();
    }
}
