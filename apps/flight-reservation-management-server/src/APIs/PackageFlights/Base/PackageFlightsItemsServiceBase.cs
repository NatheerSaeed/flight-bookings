using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using FlightReservationManagement.APIs.Extensions;
using FlightReservationManagement.Infrastructure;
using FlightReservationManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationManagement.APIs;

public abstract class PackageFlightsServiceBase : IPackageFlightsService
{
    protected readonly FlightReservationManagementDbContext _context;

    public PackageFlightsServiceBase(FlightReservationManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one PackageFlights
    /// </summary>
    public async Task<PackageFlights> CreatePackageFlight(PackageFlightCreateInput inputDto)
    {
        var packageFlights = new PackageFlight
        {
            Airline = inputDto.Airline,
            ArrivalDateTime = inputDto.ArrivalDateTime,
            CreatedAt = inputDto.CreatedAt,
            DepartureDateTime = inputDto.DepartureDateTime,
            FromLocation = inputDto.FromLocation,
            ToLocation = inputDto.ToLocation,
            UpdatedAt = inputDto.UpdatedAt
        };

        if (inputDto.Id != null)
        {
            packageFlights.Id = inputDto.Id;
        }
        if (inputDto.PackageField != null)
        {
            packageFlights.PackageField = await _context
                .PackagesItems.Where(packages => inputDto.PackageField.Id == packages.Id)
                .FirstOrDefaultAsync();
        }

        _context.PackageFlightsItems.Add(packageFlights);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<PackageFlight>(packageFlights.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one PackageFlights
    /// </summary>
    public async Task DeletePackageFlight(PackageFlightsWhereUniqueInput uniqueId)
    {
        var packageFlights = await _context.PackageFlightsItems.FindAsync(uniqueId.Id);
        if (packageFlights == null)
        {
            throw new NotFoundException();
        }

        _context.PackageFlightsItems.Remove(packageFlights);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many PackageFlightsItems
    /// </summary>
    public async Task<List<PackageFlights>> PackageFlightsSearchAsync(
        PackageFlightFindManyArgs findManyArgs
    )
    {
        var packageFlightsItems = await _context
            .PackageFlightsItems.Include(x => x.PackageField)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return packageFlightsItems.ConvertAll(packageFlights => packageFlights.ToDto());
    }

    /// <summary>
    /// Meta data about PackageFlights records
    /// </summary>
    public async Task<MetadataDto> PackageFlightsItemsMeta(PackageFlightFindManyArgs findManyArgs)
    {
        var count = await _context.PackageFlightsItems.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one PackageFlights
    /// </summary>
    public async Task<PackageFlights> PackageFlights(PackageFlightsWhereUniqueInput uniqueId)
    {
        var packageFlightsItems = await this.PackageFlightsSearchAsync(
            new PackageFlightFindManyArgs
            {
                Where = new PackageFlightWhereInput { Id = uniqueId.Id }
            }
        );
        var packageFlights = packageFlightsItems.FirstOrDefault();
        if (packageFlights == null)
        {
            throw new NotFoundException();
        }

        return packageFlights;
    }

    /// <summary>
    /// Update one PackageFlights
    /// </summary>
    public async Task UpdatePackageFlight(
        PackageFlightsWhereUniqueInput uniqueId,
        PackageFlightUpdateInput updateDto
    )
    {
        var packageFlights = updateDto.ToModel(uniqueId);

        if (updateDto.PackageField != null)
        {
            packageFlights.PackageField = await _context
                .PackagesItems.Where(packages => updateDto.PackageField == packages.Id)
                .FirstOrDefaultAsync();
        }

        _context.Entry(packageFlights).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.PackageFlightsItems.Any(e => e.Id == packageFlights.Id))
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
    /// Get a package_ record for PackageFlights
    /// </summary>
    public async Task<Packages> GetPackageField(PackageFlightsWhereUniqueInput uniqueId)
    {
        var packageFlights = await _context
            .PackageFlightsItems.Where(packageFlights => packageFlights.Id == uniqueId.Id)
            .Include(packageFlights => packageFlights.PackageField)
            .FirstOrDefaultAsync();
        if (packageFlights == null)
        {
            throw new NotFoundException();
        }
        return packageFlights.PackageField.ToDto();
    }
}
