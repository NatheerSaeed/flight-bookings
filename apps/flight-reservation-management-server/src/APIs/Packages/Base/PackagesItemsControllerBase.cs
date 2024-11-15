using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class PackagesItemsControllerBase : ControllerBase
{
    protected readonly IPackagesItemsService _service;

    public PackagesItemsControllerBase(IPackagesItemsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Packages
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Packages>> CreatePackages(PackagesCreateInput input)
    {
        var packages = await _service.CreatePackages(input);

        return CreatedAtAction(nameof(Packages), new { id = packages.Id }, packages);
    }

    /// <summary>
    /// Delete one Packages
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeletePackages([FromRoute()] PackagesWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeletePackages(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many PackagesItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Packages>>> PackagesItems(
        [FromQuery()] PackagesFindManyArgs filter
    )
    {
        return Ok(await _service.PackagesItems(filter));
    }

    /// <summary>
    /// Meta data about Packages records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> PackagesItemsMeta(
        [FromQuery()] PackagesFindManyArgs filter
    )
    {
        return Ok(await _service.PackagesItemsMeta(filter));
    }

    /// <summary>
    /// Get one Packages
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Packages>> Packages(
        [FromRoute()] PackagesWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Packages(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Packages
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdatePackages(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromQuery()] PackagesUpdateInput packagesUpdateDto
    )
    {
        try
        {
            await _service.UpdatePackages(uniqueId, packagesUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple AttractionsItems records to Packages
    /// </summary>
    [HttpPost("{Id}/attractionsItems")]
    public async Task<ActionResult> ConnectAttractionsItems(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromQuery()] AttractionsWhereUniqueInput[] attractionsItemsId
    )
    {
        try
        {
            await _service.ConnectAttractionsItems(uniqueId, attractionsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple AttractionsItems records from Packages
    /// </summary>
    [HttpDelete("{Id}/attractionsItems")]
    public async Task<ActionResult> DisconnectAttractionsItems(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromBody()] AttractionsWhereUniqueInput[] attractionsItemsId
    )
    {
        try
        {
            await _service.DisconnectAttractionsItems(uniqueId, attractionsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple AttractionsItems records for Packages
    /// </summary>
    [HttpGet("{Id}/attractionsItems")]
    public async Task<ActionResult<List<Attractions>>> FindAttractionsItems(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromQuery()] AttractionsFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindAttractionsItems(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple AttractionsItems records for Packages
    /// </summary>
    [HttpPatch("{Id}/attractionsItems")]
    public async Task<ActionResult> UpdateAttractionsItems(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromBody()] AttractionsWhereUniqueInput[] attractionsItemsId
    )
    {
        try
        {
            await _service.UpdateAttractionsItems(uniqueId, attractionsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple FlightDealsItems records to Packages
    /// </summary>
    [HttpPost("{Id}/flightDealsItems")]
    public async Task<ActionResult> ConnectFlightDealsItems(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromQuery()] FlightDealsWhereUniqueInput[] flightDealsItemsId
    )
    {
        try
        {
            await _service.ConnectFlightDealsItems(uniqueId, flightDealsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple FlightDealsItems records from Packages
    /// </summary>
    [HttpDelete("{Id}/flightDealsItems")]
    public async Task<ActionResult> DisconnectFlightDealsItems(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromBody()] FlightDealsWhereUniqueInput[] flightDealsItemsId
    )
    {
        try
        {
            await _service.DisconnectFlightDealsItems(uniqueId, flightDealsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple FlightDealsItems records for Packages
    /// </summary>
    [HttpGet("{Id}/flightDealsItems")]
    public async Task<ActionResult<List<FlightDeals>>> FindFlightDealsItems(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromQuery()] FlightDealsFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindFlightDealsItems(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple FlightDealsItems records for Packages
    /// </summary>
    [HttpPatch("{Id}/flightDealsItems")]
    public async Task<ActionResult> UpdateFlightDealsItems(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromBody()] FlightDealsWhereUniqueInput[] flightDealsItemsId
    )
    {
        try
        {
            await _service.UpdateFlightDealsItems(uniqueId, flightDealsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple HotelDealsItems records to Packages
    /// </summary>
    [HttpPost("{Id}/hotelDealsItems")]
    public async Task<ActionResult> ConnectHotelDealsItems(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromQuery()] HotelDealsWhereUniqueInput[] hotelDealsItemsId
    )
    {
        try
        {
            await _service.ConnectHotelDealsItems(uniqueId, hotelDealsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple HotelDealsItems records from Packages
    /// </summary>
    [HttpDelete("{Id}/hotelDealsItems")]
    public async Task<ActionResult> DisconnectHotelDealsItems(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromBody()] HotelDealsWhereUniqueInput[] hotelDealsItemsId
    )
    {
        try
        {
            await _service.DisconnectHotelDealsItems(uniqueId, hotelDealsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple HotelDealsItems records for Packages
    /// </summary>
    [HttpGet("{Id}/hotelDealsItems")]
    public async Task<ActionResult<List<HotelDeals>>> FindHotelDealsItems(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromQuery()] HotelDealsFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindHotelDealsItems(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple HotelDealsItems records for Packages
    /// </summary>
    [HttpPatch("{Id}/hotelDealsItems")]
    public async Task<ActionResult> UpdateHotelDealsItems(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromBody()] HotelDealsWhereUniqueInput[] hotelDealsItemsId
    )
    {
        try
        {
            await _service.UpdateHotelDealsItems(uniqueId, hotelDealsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple PackageFlightsItems records to Packages
    /// </summary>
    [HttpPost("{Id}/packageFlightsItems")]
    public async Task<ActionResult> ConnectPackageFlightsItems(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromQuery()] PackageFlightsWhereUniqueInput[] packageFlightsItemsId
    )
    {
        try
        {
            await _service.ConnectPackageFlightsItems(uniqueId, packageFlightsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple PackageFlightsItems records from Packages
    /// </summary>
    [HttpDelete("{Id}/packageFlightsItems")]
    public async Task<ActionResult> DisconnectPackageFlightsItems(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromBody()] PackageFlightsWhereUniqueInput[] packageFlightsItemsId
    )
    {
        try
        {
            await _service.DisconnectPackageFlightsItems(uniqueId, packageFlightsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple PackageFlightsItems records for Packages
    /// </summary>
    [HttpGet("{Id}/packageFlightsItems")]
    public async Task<ActionResult<List<PackageFlights>>> FindPackageFlightsItems(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromQuery()] PackageFlightsFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindPackageFlightsItems(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple PackageFlightsItems records for Packages
    /// </summary>
    [HttpPatch("{Id}/packageFlightsItems")]
    public async Task<ActionResult> UpdatePackageFlightsItems(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromBody()] PackageFlightsWhereUniqueInput[] packageFlightsItemsId
    )
    {
        try
        {
            await _service.UpdatePackageFlightsItems(uniqueId, packageFlightsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple PackageHotelsItems records to Packages
    /// </summary>
    [HttpPost("{Id}/packageHotelsItems")]
    public async Task<ActionResult> ConnectPackageHotelsItems(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromQuery()] PackageHotelsWhereUniqueInput[] packageHotelsItemsId
    )
    {
        try
        {
            await _service.ConnectPackageHotelsItems(uniqueId, packageHotelsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple PackageHotelsItems records from Packages
    /// </summary>
    [HttpDelete("{Id}/packageHotelsItems")]
    public async Task<ActionResult> DisconnectPackageHotelsItems(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromBody()] PackageHotelsWhereUniqueInput[] packageHotelsItemsId
    )
    {
        try
        {
            await _service.DisconnectPackageHotelsItems(uniqueId, packageHotelsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple PackageHotelsItems records for Packages
    /// </summary>
    [HttpGet("{Id}/packageHotelsItems")]
    public async Task<ActionResult<List<PackageHotels>>> FindPackageHotelsItems(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromQuery()] PackageHotelsFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindPackageHotelsItems(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple PackageHotelsItems records for Packages
    /// </summary>
    [HttpPatch("{Id}/packageHotelsItems")]
    public async Task<ActionResult> UpdatePackageHotelsItems(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromBody()] PackageHotelsWhereUniqueInput[] packageHotelsItemsId
    )
    {
        try
        {
            await _service.UpdatePackageHotelsItems(uniqueId, packageHotelsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple SightSeeingsItems records to Packages
    /// </summary>
    [HttpPost("{Id}/sightSeeingsItems")]
    public async Task<ActionResult> ConnectSightSeeingsItems(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromQuery()] SightSeeingsWhereUniqueInput[] sightSeeingsItemsId
    )
    {
        try
        {
            await _service.ConnectSightSeeingsItems(uniqueId, sightSeeingsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple SightSeeingsItems records from Packages
    /// </summary>
    [HttpDelete("{Id}/sightSeeingsItems")]
    public async Task<ActionResult> DisconnectSightSeeingsItems(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromBody()] SightSeeingsWhereUniqueInput[] sightSeeingsItemsId
    )
    {
        try
        {
            await _service.DisconnectSightSeeingsItems(uniqueId, sightSeeingsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple SightSeeingsItems records for Packages
    /// </summary>
    [HttpGet("{Id}/sightSeeingsItems")]
    public async Task<ActionResult<List<SightSeeings>>> FindSightSeeingsItems(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromQuery()] SightSeeingsFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindSightSeeingsItems(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple SightSeeingsItems records for Packages
    /// </summary>
    [HttpPatch("{Id}/sightSeeingsItems")]
    public async Task<ActionResult> UpdateSightSeeingsItems(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromBody()] SightSeeingsWhereUniqueInput[] sightSeeingsItemsId
    )
    {
        try
        {
            await _service.UpdateSightSeeingsItems(uniqueId, sightSeeingsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
