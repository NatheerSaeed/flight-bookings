using FlightReservationManagement.APIs;
using FlightReservationManagement.APIs.Common;
using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class UsersControllerBase : ControllerBase
{
    protected readonly IUsersService _service;

    public UsersControllerBase(IUsersService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one User
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<User>> CreateUser(UserCreateInput input)
    {
        var user = await _service.CreateUser(input);

        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }

    /// <summary>
    /// Delete one User
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteUser([FromRoute()] UserWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteUser(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Users
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<User>>> Users([FromQuery()] UserFindManyArgs filter)
    {
        return Ok(await _service.Users(filter));
    }

    /// <summary>
    /// Meta data about User records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> UsersMeta([FromQuery()] UserFindManyArgs filter)
    {
        return Ok(await _service.UsersMeta(filter));
    }

    /// <summary>
    /// Get one User
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<User>> GetUser([FromRoute()] UserWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.User(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one User
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateUser(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] UserUpdateInput userUpdateDto
    )
    {
        try
        {
            await _service.UpdateUser(uniqueId, userUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple AgencyProfilesItems records to User
    /// </summary>
    [HttpPost("{Id}/agencyProfilesItems")]
    public async Task<ActionResult> ConnectAgencyProfilesSearchAsync(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] AgencyProfilesWhereUniqueInput[] agencyProfilesItemsId
    )
    {
        try
        {
            await _service.ConnectAgencyProfilesSearchAsync(uniqueId, agencyProfilesItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple AgencyProfilesItems records from User
    /// </summary>
    [HttpDelete("{Id}/agencyProfilesItems")]
    public async Task<ActionResult> DisconnectAgencyProfilesSearchAsync(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] AgencyProfilesWhereUniqueInput[] agencyProfilesItemsId
    )
    {
        try
        {
            await _service.DisconnectAgencyProfilesSearchAsync(uniqueId, agencyProfilesItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple AgencyProfilesItems records for User
    /// </summary>
    [HttpGet("{Id}/agencyProfilesItems")]
    public async Task<ActionResult<List<AgencyProfiles>>> FindAgencyProfilesSearchAsync(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] AgencyProfileFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindAgencyProfilesSearchAsync(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple AgencyProfilesItems records for User
    /// </summary>
    [HttpPatch("{Id}/agencyProfilesItems")]
    public async Task<ActionResult> UpdateAgencyProfilesItem(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] AgencyProfilesWhereUniqueInput[] agencyProfilesItemsId
    )
    {
        try
        {
            await _service.UpdateAgencyProfilesItem(uniqueId, agencyProfilesItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple AirlinesItems records to User
    /// </summary>
    [HttpPost("{Id}/airlinesItems")]
    public async Task<ActionResult> ConnectAirlinesSearchAsync(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] AirlinesWhereUniqueInput[] airlinesItemsId
    )
    {
        try
        {
            await _service.ConnectAirlinesSearchAsync(uniqueId, airlinesItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple AirlinesItems records from User
    /// </summary>
    [HttpDelete("{Id}/airlinesItems")]
    public async Task<ActionResult> DisconnectAirlinesSearchAsync(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] AirlinesWhereUniqueInput[] airlinesItemsId
    )
    {
        try
        {
            await _service.DisconnectAirlinesSearchAsync(uniqueId, airlinesItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple AirlinesItems records for User
    /// </summary>
    [HttpGet("{Id}/airlinesItems")]
    public async Task<ActionResult<List<Airlines>>> FindAirlinesSearchAsync(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] AirlineFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindAirlinesSearchAsync(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple AirlinesItems records for User
    /// </summary>
    [HttpPatch("{Id}/airlinesItems")]
    public async Task<ActionResult> UpdateAirlinesItem(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] AirlinesWhereUniqueInput[] airlinesItemsId
    )
    {
        try
        {
            await _service.UpdateAirlinesItem(uniqueId, airlinesItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple BankPaymentsItems records to User
    /// </summary>
    [HttpPost("{Id}/bankPaymentsItems")]
    public async Task<ActionResult> ConnectBankPaymentsSearchAsync(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] BankPaymentsWhereUniqueInput[] bankPaymentsItemsId
    )
    {
        try
        {
            await _service.ConnectBankPaymentsSearchAsync(uniqueId, bankPaymentsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple BankPaymentsItems records from User
    /// </summary>
    [HttpDelete("{Id}/bankPaymentsItems")]
    public async Task<ActionResult> DisconnectBankPaymentsSearchAsync(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] BankPaymentsWhereUniqueInput[] bankPaymentsItemsId
    )
    {
        try
        {
            await _service.DisconnectBankPaymentsSearchAsync(uniqueId, bankPaymentsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple BankPaymentsItems records for User
    /// </summary>
    [HttpGet("{Id}/bankPaymentsItems")]
    public async Task<ActionResult<List<BankPayments>>> FindBankPaymentsSearchAsync(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] BankPaymentFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindBankPaymentsSearchAsync(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple BankPaymentsItems records for User
    /// </summary>
    [HttpPatch("{Id}/bankPaymentsItems")]
    public async Task<ActionResult> UpdateBankPaymentsItem(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] BankPaymentsWhereUniqueInput[] bankPaymentsItemsId
    )
    {
        try
        {
            await _service.UpdateBankPaymentsItem(uniqueId, bankPaymentsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple CarBookingsItems records to User
    /// </summary>
    [HttpPost("{Id}/carBookingsItems")]
    public async Task<ActionResult> ConnectCarBookingsSearchAsync(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] CarBookingsWhereUniqueInput[] carBookingsItemsId
    )
    {
        try
        {
            await _service.ConnectCarBookingsSearchAsync(uniqueId, carBookingsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple CarBookingsItems records from User
    /// </summary>
    [HttpDelete("{Id}/carBookingsItems")]
    public async Task<ActionResult> DisconnectCarBookingsSearchAsync(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] CarBookingsWhereUniqueInput[] carBookingsItemsId
    )
    {
        try
        {
            await _service.DisconnectCarBookingsSearchAsync(uniqueId, carBookingsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple CarBookingsItems records for User
    /// </summary>
    [HttpGet("{Id}/carBookingsItems")]
    public async Task<ActionResult<List<CarBookings>>> FindCarBookingsSearchAsync(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] CarBookingFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindCarBookingsSearchAsync(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple CarBookingsItems records for User
    /// </summary>
    [HttpPatch("{Id}/carBookingsItems")]
    public async Task<ActionResult> UpdateCarBookingsItem(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] CarBookingsWhereUniqueInput[] carBookingsItemsId
    )
    {
        try
        {
            await _service.UpdateCarBookingsItem(uniqueId, carBookingsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple CooperateCustomerProfilesItems records to User
    /// </summary>
    [HttpPost("{Id}/cooperateCustomerProfilesItems")]
    public async Task<ActionResult> ConnectCooperateCustomerProfilesSearchAsync(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] CooperateCustomerProfilesWhereUniqueInput[] cooperateCustomerProfilesItemsId
    )
    {
        try
        {
            await _service.ConnectCooperateCustomerProfilesSearchAsync(
                uniqueId,
                cooperateCustomerProfilesItemsId
            );
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple CooperateCustomerProfilesItems records from User
    /// </summary>
    [HttpDelete("{Id}/cooperateCustomerProfilesItems")]
    public async Task<ActionResult> DisconnectCooperateCustomerProfilesSearchAsync(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] CooperateCustomerProfilesWhereUniqueInput[] cooperateCustomerProfilesItemsId
    )
    {
        try
        {
            await _service.DisconnectCooperateCustomerProfilesSearchAsync(
                uniqueId,
                cooperateCustomerProfilesItemsId
            );
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple CooperateCustomerProfilesItems records for User
    /// </summary>
    [HttpGet("{Id}/cooperateCustomerProfilesItems")]
    public async Task<
        ActionResult<List<CooperateCustomerProfiles>>
    > FindCooperateCustomerProfilesSearchAsync(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] CooperateCustomerProfileFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindCooperateCustomerProfilesSearchAsync(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple CooperateCustomerProfilesItems records for User
    /// </summary>
    [HttpPatch("{Id}/cooperateCustomerProfilesItems")]
    public async Task<ActionResult> UpdateCooperateCustomerProfilesItem(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] CooperateCustomerProfilesWhereUniqueInput[] cooperateCustomerProfilesItemsId
    )
    {
        try
        {
            await _service.UpdateCooperateCustomerProfilesItem(
                uniqueId,
                cooperateCustomerProfilesItemsId
            );
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple FlightBookingsItems records to User
    /// </summary>
    [HttpPost("{Id}/flightBookingsItems")]
    public async Task<ActionResult> ConnectFlightBookingsSearchAsync(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] FlightBookingsWhereUniqueInput[] flightBookingsItemsId
    )
    {
        try
        {
            await _service.ConnectFlightBookingsSearchAsync(uniqueId, flightBookingsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple FlightBookingsItems records from User
    /// </summary>
    [HttpDelete("{Id}/flightBookingsItems")]
    public async Task<ActionResult> DisconnectFlightBookingsSearchAsync(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] FlightBookingsWhereUniqueInput[] flightBookingsItemsId
    )
    {
        try
        {
            await _service.DisconnectFlightBookingsSearchAsync(uniqueId, flightBookingsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple FlightBookingsItems records for User
    /// </summary>
    [HttpGet("{Id}/flightBookingsItems")]
    public async Task<ActionResult<List<FlightBookings>>> FindFlightBookingsSearchAsync(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] FlightBookingFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindFlightBookingsSearchAsync(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple FlightBookingsItems records for User
    /// </summary>
    [HttpPatch("{Id}/flightBookingsItems")]
    public async Task<ActionResult> UpdateFlightBookingsItem(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] FlightBookingsWhereUniqueInput[] flightBookingsItemsId
    )
    {
        try
        {
            await _service.UpdateFlightBookingsItem(uniqueId, flightBookingsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple HotelBookingsItems records to User
    /// </summary>
    [HttpPost("{Id}/hotelBookingsItems")]
    public async Task<ActionResult> ConnectHotelBookingsSearchAsync(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] HotelBookingsWhereUniqueInput[] hotelBookingsItemsId
    )
    {
        try
        {
            await _service.ConnectHotelBookingsSearchAsync(uniqueId, hotelBookingsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple HotelBookingsItems records from User
    /// </summary>
    [HttpDelete("{Id}/hotelBookingsItems")]
    public async Task<ActionResult> DisconnectHotelBookingsSearchAsync(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] HotelBookingsWhereUniqueInput[] hotelBookingsItemsId
    )
    {
        try
        {
            await _service.DisconnectHotelBookingsSearchAsync(uniqueId, hotelBookingsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple HotelBookingsItems records for User
    /// </summary>
    [HttpGet("{Id}/hotelBookingsItems")]
    public async Task<ActionResult<List<HotelBookings>>> FindHotelBookingsSearchAsync(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] HotelBookingFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindHotelBookingsSearchAsync(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple HotelBookingsItems records for User
    /// </summary>
    [HttpPatch("{Id}/hotelBookingsItems")]
    public async Task<ActionResult> UpdateHotelBookingsItem(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] HotelBookingsWhereUniqueInput[] hotelBookingsItemsId
    )
    {
        try
        {
            await _service.UpdateHotelBookingsItem(uniqueId, hotelBookingsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple OnlinePaymentsItems records to User
    /// </summary>
    [HttpPost("{Id}/onlinePaymentsItems")]
    public async Task<ActionResult> ConnectOnlinePaymentsSearchAsync(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] OnlinePaymentsWhereUniqueInput[] onlinePaymentsItemsId
    )
    {
        try
        {
            await _service.ConnectOnlinePaymentsSearchAsync(uniqueId, onlinePaymentsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple OnlinePaymentsItems records from User
    /// </summary>
    [HttpDelete("{Id}/onlinePaymentsItems")]
    public async Task<ActionResult> DisconnectOnlinePaymentsSearchAsync(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] OnlinePaymentsWhereUniqueInput[] onlinePaymentsItemsId
    )
    {
        try
        {
            await _service.DisconnectOnlinePaymentsSearchAsync(uniqueId, onlinePaymentsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple OnlinePaymentsItems records for User
    /// </summary>
    [HttpGet("{Id}/onlinePaymentsItems")]
    public async Task<ActionResult<List<OnlinePayments>>> FindOnlinePaymentsSearchAsync(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] OnlinePaymentFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindOnlinePaymentsSearchAsync(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple OnlinePaymentsItems records for User
    /// </summary>
    [HttpPatch("{Id}/onlinePaymentsItems")]
    public async Task<ActionResult> UpdateOnlinePaymentsItem(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] OnlinePaymentsWhereUniqueInput[] onlinePaymentsItemsId
    )
    {
        try
        {
            await _service.UpdateOnlinePaymentsItem(uniqueId, onlinePaymentsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple PackageBookingsItems records to User
    /// </summary>
    [HttpPost("{Id}/packageBookingsItems")]
    public async Task<ActionResult> ConnectPackageBookingsSearchAsync(
        [FromRoute()] UserWhereUniqueInput uniqueId,
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
    /// Disconnect multiple PackageBookingsItems records from User
    /// </summary>
    [HttpDelete("{Id}/packageBookingsItems")]
    public async Task<ActionResult> DisconnectPackageBookingsSearchAsync(
        [FromRoute()] UserWhereUniqueInput uniqueId,
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
    /// Find multiple PackageBookingsItems records for User
    /// </summary>
    [HttpGet("{Id}/packageBookingsItems")]
    public async Task<ActionResult<List<PackageBookings>>> FindPackageBookingsSearchAsync(
        [FromRoute()] UserWhereUniqueInput uniqueId,
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
    /// Update multiple PackageBookingsItems records for User
    /// </summary>
    [HttpPatch("{Id}/packageBookingsItems")]
    public async Task<ActionResult> UpdatePackageBookingsItem(
        [FromRoute()] UserWhereUniqueInput uniqueId,
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
    /// Connect multiple PayLatersItems records to User
    /// </summary>
    [HttpPost("{Id}/payLatersItems")]
    public async Task<ActionResult> ConnectPayLatersSearchAsync(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] PayLatersWhereUniqueInput[] payLatersItemsId
    )
    {
        try
        {
            await _service.ConnectPayLatersSearchAsync(uniqueId, payLatersItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple PayLatersItems records from User
    /// </summary>
    [HttpDelete("{Id}/payLatersItems")]
    public async Task<ActionResult> DisconnectPayLatersSearchAsync(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] PayLatersWhereUniqueInput[] payLatersItemsId
    )
    {
        try
        {
            await _service.DisconnectPayLatersSearchAsync(uniqueId, payLatersItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple PayLatersItems records for User
    /// </summary>
    [HttpGet("{Id}/payLatersItems")]
    public async Task<ActionResult<List<PayLaters>>> FindPayLatersSearchAsync(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] PayLaterFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindPayLatersSearchAsync(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple PayLatersItems records for User
    /// </summary>
    [HttpPatch("{Id}/payLatersItems")]
    public async Task<ActionResult> UpdatePayLatersItem(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] PayLatersWhereUniqueInput[] payLatersItemsId
    )
    {
        try
        {
            await _service.UpdatePayLatersItem(uniqueId, payLatersItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple ProfilesItems records to User
    /// </summary>
    [HttpPost("{Id}/profilesItems")]
    public async Task<ActionResult> ConnectProfilesSearchAsync(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] ProfilesWhereUniqueInput[] profilesItemsId
    )
    {
        try
        {
            await _service.ConnectProfilesSearchAsync(uniqueId, profilesItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple ProfilesItems records from User
    /// </summary>
    [HttpDelete("{Id}/profilesItems")]
    public async Task<ActionResult> DisconnectProfilesSearchAsync(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] ProfilesWhereUniqueInput[] profilesItemsId
    )
    {
        try
        {
            await _service.DisconnectProfilesSearchAsync(uniqueId, profilesItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple ProfilesItems records for User
    /// </summary>
    [HttpGet("{Id}/profilesItems")]
    public async Task<ActionResult<List<Profiles>>> FindProfilesSearchAsync(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] ProfileFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindProfilesSearchAsync(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple ProfilesItems records for User
    /// </summary>
    [HttpPatch("{Id}/profilesItems")]
    public async Task<ActionResult> UpdateProfilesItem(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] ProfilesWhereUniqueInput[] profilesItemsId
    )
    {
        try
        {
            await _service.UpdateProfilesItem(uniqueId, profilesItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple WalletLogsItems records to User
    /// </summary>
    [HttpPost("{Id}/walletLogsItems")]
    public async Task<ActionResult> ConnectWalletLogsSearchAsync(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] WalletLogsWhereUniqueInput[] walletLogsItemsId
    )
    {
        try
        {
            await _service.ConnectWalletLogsSearchAsync(uniqueId, walletLogsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple WalletLogsItems records from User
    /// </summary>
    [HttpDelete("{Id}/walletLogsItems")]
    public async Task<ActionResult> DisconnectWalletLogsSearchAsync(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] WalletLogsWhereUniqueInput[] walletLogsItemsId
    )
    {
        try
        {
            await _service.DisconnectWalletLogsSearchAsync(uniqueId, walletLogsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple WalletLogsItems records for User
    /// </summary>
    [HttpGet("{Id}/walletLogsItems")]
    public async Task<ActionResult<List<WalletLogs>>> FindWalletLogsSearchAsync(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] WalletLogFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindWalletLogsSearchAsync(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple WalletLogsItems records for User
    /// </summary>
    [HttpPatch("{Id}/walletLogsItems")]
    public async Task<ActionResult> UpdateWalletLogsItem(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] WalletLogsWhereUniqueInput[] walletLogsItemsId
    )
    {
        try
        {
            await _service.UpdateWalletLogsItem(uniqueId, walletLogsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple WalletsItems records to User
    /// </summary>
    [HttpPost("{Id}/walletsItems")]
    public async Task<ActionResult> ConnectWalletsSearchAsync(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] WalletsWhereUniqueInput[] walletsItemsId
    )
    {
        try
        {
            await _service.ConnectWalletsSearchAsync(uniqueId, walletsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple WalletsItems records from User
    /// </summary>
    [HttpDelete("{Id}/walletsItems")]
    public async Task<ActionResult> DisconnectWalletsSearchAsync(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] WalletsWhereUniqueInput[] walletsItemsId
    )
    {
        try
        {
            await _service.DisconnectWalletsSearchAsync(uniqueId, walletsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple WalletsItems records for User
    /// </summary>
    [HttpGet("{Id}/walletsItems")]
    public async Task<ActionResult<List<Wallets>>> FindWalletsSearchAsync(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] WalletFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindWalletsSearchAsync(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple WalletsItems records for User
    /// </summary>
    [HttpPatch("{Id}/walletsItems")]
    public async Task<ActionResult> UpdateWalletsItem(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] WalletsWhereUniqueInput[] walletsItemsId
    )
    {
        try
        {
            await _service.UpdateWalletsItem(uniqueId, walletsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
