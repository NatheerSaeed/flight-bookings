using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.Infrastructure;

public class FlightReservationManagementDbContext : DbContext
{
    public FlightReservationManagementDbContext(
        DbContextOptions<FlightReservationManagementDbContext> options
    )
        : base(options) { }

    public DbSet<Role> RolesItems { get; set; }

    public DbSet<PasswordReset> PasswordResetsItems { get; set; }

    public DbSet<Hotel> HotelsItems { get; set; }

    public DbSet<HotelBooking> HotelBookingsItems { get; set; }

    public DbSet<Airport> AirportsItems { get; set; }

    public DbSet<CarBooking> CarBookingsItems { get; set; }

    public DbSet<TravelPackage> TravelPackagesItems { get; set; }

    public DbSet<GoodToKnow> GoodToKnowsItems { get; set; }

    public DbSet<Gallerie> GalleriesItems { get; set; }

    public DbSet<Markdown> MarkdownsItems { get; set; }

    public DbSet<Bank> BanksItems { get; set; }

    public DbSet<Airline> AirlinesItems { get; set; }

    public DbSet<PackageType> PackageTypesItems { get; set; }

    public DbSet<Vat> VatsItems { get; set; }

    public DbSet<BankPayment> BankPaymentsItems { get; set; }

    public DbSet<Gender> GendersItems { get; set; }

    public DbSet<BankDetail> BankDetailsItems { get; set; }

    public DbSet<EmailSubscriber> EmailSubscribersItems { get; set; }

    public DbSet<Profile> ProfilesItems { get; set; }

    public DbSet<SightSeeing> SightSeeingsItems { get; set; }

    public DbSet<CabinType> CabinTypesItems { get; set; }

    public DbSet<OnlinePayment> OnlinePaymentsItems { get; set; }

    public DbSet<PayLater> PayLatersItems { get; set; }

    public DbSet<PackageHotel> PackageHotelsItems { get; set; }

    public DbSet<Attraction> AttractionsItems { get; set; }

    public DbSet<Comment> CommentsItems { get; set; }

    public DbSet<VisaApplication> VisaApplicationsItems { get; set; }

    public DbSet<Markup> MarkupsItems { get; set; }

    public DbSet<FlightDeal> FlightDealsItems { get; set; }

    public DbSet<Package> PackagesItems { get; set; }

    public DbSet<Voucher> VouchersItems { get; set; }

    public DbSet<CooperateCustomerProfile> CooperateCustomerProfilesItems { get; set; }

    public DbSet<Title> TitlesItems { get; set; }

    public DbSet<HotelDeal> HotelDealsItems { get; set; }

    public DbSet<Wallet> WalletsItems { get; set; }

    public DbSet<PackageAttraction> PackageAttractionsItems { get; set; }

    public DbSet<WalletLog> WalletLogsItems { get; set; }

    public DbSet<WalletLogType> WalletLogTypesItems { get; set; }

    public DbSet<PackageBooking> PackageBookingsItems { get; set; }

    public DbSet<FlightBooking> FlightBookingsItems { get; set; }

    public DbSet<PackageCategorie> PackageCategoriesItems { get; set; }

    public DbSet<PackageFlight> PackageFlightsItems { get; set; }

    public DbSet<AgencyProfile> AgencyProfilesItems { get; set; }

    public DbSet<UserDbModel> Users { get; set; }
}
