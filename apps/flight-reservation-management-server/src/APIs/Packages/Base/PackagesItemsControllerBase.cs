using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class PackagesControllerBase : ControllerBase
{
    protected readonly IPackagesService _service;

    public PackagesControllerBase(IPackagesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Packages
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Packages>> CreatePackage(PackageCreateInput input)
    {
        var packages = await _service.CreatePackage(input);

        return CreatedAtAction(nameof(Packages), new { id = packages.Id }, packages);
    }

    /// <summary>
    /// Delete one Packages
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeletePackage([FromRoute()] PackagesWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeletePackage(uniqueId);
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
    public async Task<ActionResult<List<Packages>>> PackagesSearchAsync(
        [FromQuery()] PackageFindManyArgs filter
    )
    {
        return Ok(await _service.PackagesSearchAsync(filter));
    }

    /// <summary>
    /// Meta data about Packages records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> PackagesItemsMeta(
        [FromQuery()] PackageFindManyArgs filter
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
    public async Task<ActionResult> UpdatePackage(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromQuery()] PackageUpdateInput packagesUpdateDto
    )
    {
        try
        {
            await _service.UpdatePackage(uniqueId, packagesUpdateDto);
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
    public async Task<ActionResult> ConnectAttractionsSearchAsync(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromQuery()] AttractionsWhereUniqueInput[] attractionsItemsId
    )
    {
        try
        {
            await _service.ConnectAttractionsSearchAsync(uniqueId, attractionsItemsId);
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
    public async Task<ActionResult> DisconnectAttractionsSearchAsync(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromBody()] AttractionsWhereUniqueInput[] attractionsItemsId
    )
    {
        try
        {
            await _service.DisconnectAttractionsSearchAsync(uniqueId, attractionsItemsId);
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
    public async Task<ActionResult<List<Attractions>>> FindAttractionsSearchAsync(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromQuery()] AttractionFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindAttractionsSearchAsync(uniqueId, filter));
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
    public async Task<ActionResult> UpdateAttractionsItem(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromBody()] AttractionsWhereUniqueInput[] attractionsItemsId
    )
    {
        try
        {
            await _service.UpdateAttractionsItem(uniqueId, attractionsItemsId);
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
    public async Task<ActionResult> ConnectFlightDealsSearchAsync(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromQuery()] FlightDealsWhereUniqueInput[] flightDealsItemsId
    )
    {
        try
        {
            await _service.ConnectFlightDealsSearchAsync(uniqueId, flightDealsItemsId);
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
    public async Task<ActionResult> DisconnectFlightDealsSearchAsync(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromBody()] FlightDealsWhereUniqueInput[] flightDealsItemsId
    )
    {
        try
        {
            await _service.DisconnectFlightDealsSearchAsync(uniqueId, flightDealsItemsId);
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
    public async Task<ActionResult<List<FlightDeals>>> FindFlightDealsSearchAsync(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromQuery()] FlightDealFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindFlightDealsSearchAsync(uniqueId, filter));
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
    public async Task<ActionResult> UpdateFlightDealsItem(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromBody()] FlightDealsWhereUniqueInput[] flightDealsItemsId
    )
    {
        try
        {
            await _service.UpdateFlightDealsItem(uniqueId, flightDealsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple GalleriesItems records to Packages
    /// </summary>
    [HttpPost("{Id}/galleriesItems")]
    public async Task<ActionResult> ConnectGalleriesSearchAsync(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromQuery()] GalleriesWhereUniqueInput[] galleriesItemsId
    )
    {
        try
        {
            await _service.ConnectGalleriesSearchAsync(uniqueId, galleriesItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple GalleriesItems records from Packages
    /// </summary>
    [HttpDelete("{Id}/galleriesItems")]
    public async Task<ActionResult> DisconnectGalleriesSearchAsync(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromBody()] GalleriesWhereUniqueInput[] galleriesItemsId
    )
    {
        try
        {
            await _service.DisconnectGalleriesSearchAsync(uniqueId, galleriesItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple GalleriesItems records for Packages
    /// </summary>
    [HttpGet("{Id}/galleriesItems")]
    public async Task<ActionResult<List<Galleries>>> FindGalleriesSearchAsync(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromQuery()] GallerieFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindGalleriesSearchAsync(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple GalleriesItems records for Packages
    /// </summary>
    [HttpPatch("{Id}/galleriesItems")]
    public async Task<ActionResult> UpdateGalleriesItem(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromBody()] GalleriesWhereUniqueInput[] galleriesItemsId
    )
    {
        try
        {
            await _service.UpdateGalleriesItem(uniqueId, galleriesItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple GoodToKnowsItems records to Packages
    /// </summary>
    [HttpPost("{Id}/goodToKnowsItems")]
    public async Task<ActionResult> ConnectGoodToKnowsSearchAsync(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromQuery()] GoodToKnowsWhereUniqueInput[] goodToKnowsItemsId
    )
    {
        try
        {
            await _service.ConnectGoodToKnowsSearchAsync(uniqueId, goodToKnowsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple GoodToKnowsItems records from Packages
    /// </summary>
    [HttpDelete("{Id}/goodToKnowsItems")]
    public async Task<ActionResult> DisconnectGoodToKnowsSearchAsync(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromBody()] GoodToKnowsWhereUniqueInput[] goodToKnowsItemsId
    )
    {
        try
        {
            await _service.DisconnectGoodToKnowsSearchAsync(uniqueId, goodToKnowsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple GoodToKnowsItems records for Packages
    /// </summary>
    [HttpGet("{Id}/goodToKnowsItems")]
    public async Task<ActionResult<List<GoodToKnows>>> FindGoodToKnowsSearchAsync(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromQuery()] GoodToKnowFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindGoodToKnowsSearchAsync(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple GoodToKnowsItems records for Packages
    /// </summary>
    [HttpPatch("{Id}/goodToKnowsItems")]
    public async Task<ActionResult> UpdateGoodToKnowsItem(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromBody()] GoodToKnowsWhereUniqueInput[] goodToKnowsItemsId
    )
    {
        try
        {
            await _service.UpdateGoodToKnowsItem(uniqueId, goodToKnowsItemsId);
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
    public async Task<ActionResult> ConnectHotelDealsSearchAsync(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromQuery()] HotelDealsWhereUniqueInput[] hotelDealsItemsId
    )
    {
        try
        {
            await _service.ConnectHotelDealsSearchAsync(uniqueId, hotelDealsItemsId);
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
    public async Task<ActionResult> DisconnectHotelDealsSearchAsync(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromBody()] HotelDealsWhereUniqueInput[] hotelDealsItemsId
    )
    {
        try
        {
            await _service.DisconnectHotelDealsSearchAsync(uniqueId, hotelDealsItemsId);
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
    public async Task<ActionResult<List<HotelDeals>>> FindHotelDealsSearchAsync(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromQuery()] HotelDealFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindHotelDealsSearchAsync(uniqueId, filter));
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
    public async Task<ActionResult> UpdateHotelDealsItem(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromBody()] HotelDealsWhereUniqueInput[] hotelDealsItemsId
    )
    {
        try
        {
            await _service.UpdateHotelDealsItem(uniqueId, hotelDealsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple PackageAttractionsItems records to Packages
    /// </summary>
    [HttpPost("{Id}/packageAttractionsItems")]
    public async Task<ActionResult> ConnectPackageAttractionsSearchAsync(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromQuery()] PackageAttractionsWhereUniqueInput[] packageAttractionsItemsId
    )
    {
        try
        {
            await _service.ConnectPackageAttractionsSearchAsync(
                uniqueId,
                packageAttractionsItemsId
            );
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple PackageAttractionsItems records from Packages
    /// </summary>
    [HttpDelete("{Id}/packageAttractionsItems")]
    public async Task<ActionResult> DisconnectPackageAttractionsSearchAsync(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromBody()] PackageAttractionsWhereUniqueInput[] packageAttractionsItemsId
    )
    {
        try
        {
            await _service.DisconnectPackageAttractionsSearchAsync(
                uniqueId,
                packageAttractionsItemsId
            );
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple PackageAttractionsItems records for Packages
    /// </summary>
    [HttpGet("{Id}/packageAttractionsItems")]
    public async Task<ActionResult<List<PackageAttractions>>> FindPackageAttractionsSearchAsync(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromQuery()] PackageAttractionFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindPackageAttractionsSearchAsync(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple PackageAttractionsItems records for Packages
    /// </summary>
    [HttpPatch("{Id}/packageAttractionsItems")]
    public async Task<ActionResult> UpdatePackageAttractionsItem(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromBody()] PackageAttractionsWhereUniqueInput[] packageAttractionsItemsId
    )
    {
        try
        {
            await _service.UpdatePackageAttractionsItem(uniqueId, packageAttractionsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple PackageBookingsItems records to Packages
    /// </summary>
    [HttpPost("{Id}/packageBookingsItems")]
    public async Task<ActionResult> ConnectPackageBookingsSearchAsync(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromQuery()] PackageBookingsWhereUniqueInput[] packageBookingsItemsId
    )
    {
        try
        {
            await _service.ConnectPackageBookingsSearchAsync(uniqueId, packageBookingsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple PackageBookingsItems records from Packages
    /// </summary>
    [HttpDelete("{Id}/packageBookingsItems")]
    public async Task<ActionResult> DisconnectPackageBookingsSearchAsync(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromBody()] PackageBookingsWhereUniqueInput[] packageBookingsItemsId
    )
    {
        try
        {
            await _service.DisconnectPackageBookingsSearchAsync(uniqueId, packageBookingsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple PackageBookingsItems records for Packages
    /// </summary>
    [HttpGet("{Id}/packageBookingsItems")]
    public async Task<ActionResult<List<PackageBookings>>> FindPackageBookingsSearchAsync(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromQuery()] PackageBookingFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindPackageBookingsSearchAsync(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple PackageBookingsItems records for Packages
    /// </summary>
    [HttpPatch("{Id}/packageBookingsItems")]
    public async Task<ActionResult> UpdatePackageBookingsItem(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromBody()] PackageBookingsWhereUniqueInput[] packageBookingsItemsId
    )
    {
        try
        {
            await _service.UpdatePackageBookingsItem(uniqueId, packageBookingsItemsId);
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
    public async Task<ActionResult> ConnectPackageFlightsSearchAsync(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromQuery()] PackageFlightsWhereUniqueInput[] packageFlightsItemsId
    )
    {
        try
        {
            await _service.ConnectPackageFlightsSearchAsync(uniqueId, packageFlightsItemsId);
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
    public async Task<ActionResult> DisconnectPackageFlightsSearchAsync(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromBody()] PackageFlightsWhereUniqueInput[] packageFlightsItemsId
    )
    {
        try
        {
            await _service.DisconnectPackageFlightsSearchAsync(uniqueId, packageFlightsItemsId);
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
    public async Task<ActionResult<List<PackageFlights>>> FindPackageFlightsSearchAsync(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromQuery()] PackageFlightFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindPackageFlightsSearchAsync(uniqueId, filter));
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
    public async Task<ActionResult> UpdatePackageFlightsItem(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromBody()] PackageFlightsWhereUniqueInput[] packageFlightsItemsId
    )
    {
        try
        {
            await _service.UpdatePackageFlightsItem(uniqueId, packageFlightsItemsId);
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
    public async Task<ActionResult> ConnectPackageHotelsSearchAsync(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromQuery()] PackageHotelsWhereUniqueInput[] packageHotelsItemsId
    )
    {
        try
        {
            await _service.ConnectPackageHotelsSearchAsync(uniqueId, packageHotelsItemsId);
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
    public async Task<ActionResult> DisconnectPackageHotelsSearchAsync(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromBody()] PackageHotelsWhereUniqueInput[] packageHotelsItemsId
    )
    {
        try
        {
            await _service.DisconnectPackageHotelsSearchAsync(uniqueId, packageHotelsItemsId);
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
    public async Task<ActionResult<List<PackageHotels>>> FindPackageHotelsSearchAsync(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromQuery()] PackageHotelFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindPackageHotelsSearchAsync(uniqueId, filter));
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
    public async Task<ActionResult> UpdatePackageHotelsItem(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromBody()] PackageHotelsWhereUniqueInput[] packageHotelsItemsId
    )
    {
        try
        {
            await _service.UpdatePackageHotelsItem(uniqueId, packageHotelsItemsId);
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
    public async Task<ActionResult> ConnectSightSeeingsSearchAsync(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromQuery()] SightSeeingsWhereUniqueInput[] sightSeeingsItemsId
    )
    {
        try
        {
            await _service.ConnectSightSeeingsSearchAsync(uniqueId, sightSeeingsItemsId);
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
    public async Task<ActionResult> DisconnectSightSeeingsSearchAsync(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromBody()] SightSeeingsWhereUniqueInput[] sightSeeingsItemsId
    )
    {
        try
        {
            await _service.DisconnectSightSeeingsSearchAsync(uniqueId, sightSeeingsItemsId);
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
    public async Task<ActionResult<List<SightSeeings>>> FindSightSeeingsSearchAsync(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromQuery()] SightSeeingFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindSightSeeingsSearchAsync(uniqueId, filter));
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
    public async Task<ActionResult> UpdateSightSeeingsItem(
        [FromRoute()] PackagesWhereUniqueInput uniqueId,
        [FromBody()] SightSeeingsWhereUniqueInput[] sightSeeingsItemsId
    )
    {
        try
        {
            await _service.UpdateSightSeeingsItem(uniqueId, sightSeeingsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
