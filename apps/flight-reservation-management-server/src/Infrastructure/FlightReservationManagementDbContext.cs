using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.Infrastructure;

public class FlightReservationManagementDbContext : DbContext
{
    public FlightReservationManagementDbContext(
        DbContextOptions<FlightReservationManagementDbContext> options
    )
        : base(options) { }

    public DbSet<RolesDbModel> RolesItems { get; set; }

    public DbSet<PasswordResetsDbModel> PasswordResetsItems { get; set; }

    public DbSet<HotelsDbModel> HotelsItems { get; set; }

    public DbSet<HotelBookingsDbModel> HotelBookingsItems { get; set; }

    public DbSet<AirportsDbModel> AirportsItems { get; set; }

    public DbSet<CarBookingsDbModel> CarBookingsItems { get; set; }

    public DbSet<MarkdownsDbModel> MarkdownsItems { get; set; }

    public DbSet<AirlinesDbModel> AirlinesItems { get; set; }

    public DbSet<PackageTypesDbModel> PackageTypesItems { get; set; }

    public DbSet<GendersDbModel> GendersItems { get; set; }

    public DbSet<EmailSubscribersDbModel> EmailSubscribersItems { get; set; }

    public DbSet<ProfilesDbModel> ProfilesItems { get; set; }

    public DbSet<SightSeeingsDbModel> SightSeeingsItems { get; set; }

    public DbSet<CabinTypesDbModel> CabinTypesItems { get; set; }

    public DbSet<OnlinePaymentsDbModel> OnlinePaymentsItems { get; set; }

    public DbSet<PayLatersDbModel> PayLatersItems { get; set; }

    public DbSet<PackageHotelsDbModel> PackageHotelsItems { get; set; }

    public DbSet<TravelPackagesDbModel> TravelPackagesItems { get; set; }

    public DbSet<GoodToKnowsDbModel> GoodToKnowsItems { get; set; }

    public DbSet<GalleriesDbModel> GalleriesItems { get; set; }

    public DbSet<BanksDbModel> BanksItems { get; set; }

    public DbSet<VatsDbModel> VatsItems { get; set; }

    public DbSet<BankPaymentsDbModel> BankPaymentsItems { get; set; }

    public DbSet<BankDetailsDbModel> BankDetailsItems { get; set; }

    public DbSet<AttractionsDbModel> AttractionsItems { get; set; }

    public DbSet<CommentsDbModel> CommentsItems { get; set; }

    public DbSet<VisaApplicationsDbModel> VisaApplicationsItems { get; set; }

    public DbSet<FlightDealsDbModel> FlightDealsItems { get; set; }

    public DbSet<VouchersDbModel> VouchersItems { get; set; }

    public DbSet<CooperateCustomerProfilesDbModel> CooperateCustomerProfilesItems { get; set; }

    public DbSet<HotelDealsDbModel> HotelDealsItems { get; set; }

    public DbSet<PackageAttractionsDbModel> PackageAttractionsItems { get; set; }

    public DbSet<WalletLogsDbModel> WalletLogsItems { get; set; }

    public DbSet<PackageBookingsDbModel> PackageBookingsItems { get; set; }

    public DbSet<MarkupsDbModel> MarkupsItems { get; set; }

    public DbSet<PackagesDbModel> PackagesItems { get; set; }

    public DbSet<TitlesDbModel> TitlesItems { get; set; }

    public DbSet<WalletsDbModel> WalletsItems { get; set; }

    public DbSet<WalletLogTypesDbModel> WalletLogTypesItems { get; set; }

    public DbSet<FlightBookingsDbModel> FlightBookingsItems { get; set; }

    public DbSet<PackageCategoriesDbModel> PackageCategoriesItems { get; set; }

    public DbSet<PackageFlightsDbModel> PackageFlightsItems { get; set; }

    public DbSet<AgencyProfilesDbModel> AgencyProfilesItems { get; set; }

    public DbSet<UserDbModel> Users { get; set; }

    public DbSet<AgencyProfileDbModel> AgencyProfiles { get; set; }

    public DbSet<AirlineDbModel> Airlines { get; set; }

    public DbSet<MarkupDbModel> Markups { get; set; }

    public DbSet<BankDetailDbModel> BankDetails { get; set; }

    public DbSet<BankPaymentDbModel> BankPayments { get; set; }

    public DbSet<MarkdownDbModel> Markdowns { get; set; }

    public DbSet<HotelDealDbModel> HotelDeals { get; set; }

    public DbSet<HotelBookingDbModel> HotelBookings { get; set; }

    public DbSet<HotelDbModel> Hotels { get; set; }

    public DbSet<AirportDbModel> Airports { get; set; }

    public DbSet<AttractionDbModel> Attractions { get; set; }

    public DbSet<WalletLogDbModel> WalletLogs { get; set; }

    public DbSet<CooperateCustomerProfileDbModel> CooperateCustomerProfiles { get; set; }

    public DbSet<TravelPackageDbModel> TravelPackages { get; set; }

    public DbSet<TitleDbModel> Titles { get; set; }

    public DbSet<OnlinePaymentDbModel> OnlinePayments { get; set; }

    public DbSet<FlightBookingDbModel> FlightBookings { get; set; }

    public DbSet<PackageCategoryDbModel> PackageCategories { get; set; }

    public DbSet<SightSeeingDbModel> SightSeeings { get; set; }

    public DbSet<TravelLocationDbModel> TravelLocations { get; set; }

    public DbSet<RoleDbModel> Roles { get; set; }

    public DbSet<VoucherDbModel> Vouchers { get; set; }

    public DbSet<FlightDealDbModel> FlightDeals { get; set; }

    public DbSet<PackageBookingDbModel> PackageBookings { get; set; }

    public DbSet<PackageHotelDbModel> PackageHotels { get; set; }

    public DbSet<PackageFlightDbModel> PackageFlights { get; set; }

    public DbSet<CabinTypeDbModel> CabinTypes { get; set; }

    public DbSet<ProfileDbModel> Profiles { get; set; }

    public DbSet<VisaApplicationDbModel> VisaApplications { get; set; }

    public DbSet<CarBookingDbModel> CarBookings { get; set; }

    public DbSet<BankDbModel> Banks { get; set; }

    public DbSet<CommentDbModel> Comments { get; set; }

    public DbSet<PackageAttractionDbModel> PackageAttractions { get; set; }

    public DbSet<EmailSubscriberDbModel> EmailSubscribers { get; set; }

    public DbSet<GalleryDbModel> Galleries { get; set; }

    public DbSet<GoodToKnowDbModel> GoodToKnows { get; set; }

    public DbSet<PackageTypeDbModel> PackageTypes { get; set; }

    public DbSet<GenderDbModel> Genders { get; set; }

    public DbSet<PayLaterDbModel> PayLaters { get; set; }

    public DbSet<PackageModelDbModel> PackageModels { get; set; }

    public DbSet<PasswordResetDbModel> PasswordResets { get; set; }
}
