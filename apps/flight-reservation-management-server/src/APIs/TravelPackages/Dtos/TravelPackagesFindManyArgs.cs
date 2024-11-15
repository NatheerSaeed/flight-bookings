using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class TravelPackagesFindManyArgs
    : FindManyInput<TravelPackages, TravelPackagesWhereInput> { }
