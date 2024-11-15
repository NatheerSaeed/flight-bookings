using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.Infrastructure;

public class FlightReservationManagementDbContext : DbContext
{
    public FlightReservationManagementDbContext(
        DbContextOptions<FlightReservationManagementDbContext> options
    )
        : base(options) { }

    public DbSet<PasswordResetsDbModel> PasswordResetsItems { get; set; }

    public DbSet<CarBookingsDbModel> CarBookingsItems { get; set; }

    public DbSet<HotelsDbModel> HotelsItems { get; set; }

    public DbSet<HotelBookingsDbModel> HotelBookingsItems { get; set; }

    public DbSet<AirportsDbModel> AirportsItems { get; set; }

    public DbSet<RolesDbModel> RolesItems { get; set; }

    public DbSet<TravelPackagesDbModel> TravelPackagesItems { get; set; }

    public DbSet<CabinTypesDbModel> CabinTypesItems { get; set; }

    public DbSet<EmailSubscribersDbModel> EmailSubscribersItems { get; set; }

    public DbSet<GoodToKnowsDbModel> GoodToKnowsItems { get; set; }

    public DbSet<GalleriesDbModel> GalleriesItems { get; set; }

    public DbSet<BanksDbModel> BanksItems { get; set; }

    public DbSet<OnlinePaymentsDbModel> OnlinePaymentsItems { get; set; }

    public DbSet<AirlinesDbModel> AirlinesItems { get; set; }

    public DbSet<PackageTypesDbModel> PackageTypesItems { get; set; }

    public DbSet<VatsDbModel> VatsItems { get; set; }

    public DbSet<BankPaymentsDbModel> BankPaymentsItems { get; set; }

    public DbSet<GendersDbModel> GendersItems { get; set; }

    public DbSet<BankDetailsDbModel> BankDetailsItems { get; set; }

    public DbSet<ProfilesDbModel> ProfilesItems { get; set; }

    public DbSet<SightSeeingsDbModel> SightSeeingsItems { get; set; }

    public DbSet<PayLatersDbModel> PayLatersItems { get; set; }

    public DbSet<PackageHotelsDbModel> PackageHotelsItems { get; set; }

    public DbSet<MarkdownsDbModel> MarkdownsItems { get; set; }

    public DbSet<AttractionsDbModel> AttractionsItems { get; set; }

    public DbSet<VisaApplicationsDbModel> VisaApplicationsItems { get; set; }

    public DbSet<PackageAttractionsDbModel> PackageAttractionsItems { get; set; }

    public DbSet<FlightDealsDbModel> FlightDealsItems { get; set; }

    public DbSet<PackageBookingsDbModel> PackageBookingsItems { get; set; }

    public DbSet<FlightBookingsDbModel> FlightBookingsItems { get; set; }

    public DbSet<TitlesDbModel> TitlesItems { get; set; }

    public DbSet<CooperateCustomerProfilesDbModel> CooperateCustomerProfilesItems { get; set; }

    public DbSet<PackagesDbModel> PackagesItems { get; set; }

    public DbSet<MarkupsDbModel> MarkupsItems { get; set; }

    public DbSet<CommentsDbModel> CommentsItems { get; set; }

    public DbSet<HotelDealsDbModel> HotelDealsItems { get; set; }

    public DbSet<WalletsDbModel> WalletsItems { get; set; }

    public DbSet<WalletLogsDbModel> WalletLogsItems { get; set; }

    public DbSet<WalletLogTypesDbModel> WalletLogTypesItems { get; set; }

    public DbSet<PackageCategoriesDbModel> PackageCategoriesItems { get; set; }

    public DbSet<VouchersDbModel> VouchersItems { get; set; }

    public DbSet<PackageFlightsDbModel> PackageFlightsItems { get; set; }

    public DbSet<AgencyProfilesDbModel> AgencyProfilesItems { get; set; }

    public DbSet<UserDbModel> Users { get; set; }
}
