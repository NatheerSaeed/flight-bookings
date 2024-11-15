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

        return CreatedAtAction(nameof(User), new { id = user.Id }, user);
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
    public async Task<ActionResult<User>> User([FromRoute()] UserWhereUniqueInput uniqueId)
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
    public async Task<ActionResult> ConnectAgencyProfilesItems(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] AgencyProfilesWhereUniqueInput[] agencyProfilesItemsId
    )
    {
        try
        {
            await _service.ConnectAgencyProfilesItems(uniqueId, agencyProfilesItemsId);
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
    public async Task<ActionResult> DisconnectAgencyProfilesItems(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] AgencyProfilesWhereUniqueInput[] agencyProfilesItemsId
    )
    {
        try
        {
            await _service.DisconnectAgencyProfilesItems(uniqueId, agencyProfilesItemsId);
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
    public async Task<ActionResult<List<AgencyProfiles>>> FindAgencyProfilesItems(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] AgencyProfilesFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindAgencyProfilesItems(uniqueId, filter));
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
    public async Task<ActionResult> UpdateAgencyProfilesItems(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] AgencyProfilesWhereUniqueInput[] agencyProfilesItemsId
    )
    {
        try
        {
            await _service.UpdateAgencyProfilesItems(uniqueId, agencyProfilesItemsId);
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
    public async Task<ActionResult> ConnectAirlinesItems(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] AirlinesWhereUniqueInput[] airlinesItemsId
    )
    {
        try
        {
            await _service.ConnectAirlinesItems(uniqueId, airlinesItemsId);
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
    public async Task<ActionResult> DisconnectAirlinesItems(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] AirlinesWhereUniqueInput[] airlinesItemsId
    )
    {
        try
        {
            await _service.DisconnectAirlinesItems(uniqueId, airlinesItemsId);
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
    public async Task<ActionResult<List<Airlines>>> FindAirlinesItems(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] AirlinesFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindAirlinesItems(uniqueId, filter));
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
    public async Task<ActionResult> UpdateAirlinesItems(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] AirlinesWhereUniqueInput[] airlinesItemsId
    )
    {
        try
        {
            await _service.UpdateAirlinesItems(uniqueId, airlinesItemsId);
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
    public async Task<ActionResult> ConnectBankPaymentsItems(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] BankPaymentsWhereUniqueInput[] bankPaymentsItemsId
    )
    {
        try
        {
            await _service.ConnectBankPaymentsItems(uniqueId, bankPaymentsItemsId);
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
    public async Task<ActionResult> DisconnectBankPaymentsItems(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] BankPaymentsWhereUniqueInput[] bankPaymentsItemsId
    )
    {
        try
        {
            await _service.DisconnectBankPaymentsItems(uniqueId, bankPaymentsItemsId);
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
    public async Task<ActionResult<List<BankPayments>>> FindBankPaymentsItems(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] BankPaymentsFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindBankPaymentsItems(uniqueId, filter));
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
    public async Task<ActionResult> UpdateBankPaymentsItems(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] BankPaymentsWhereUniqueInput[] bankPaymentsItemsId
    )
    {
        try
        {
            await _service.UpdateBankPaymentsItems(uniqueId, bankPaymentsItemsId);
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
    public async Task<ActionResult> ConnectCarBookingsItems(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] CarBookingsWhereUniqueInput[] carBookingsItemsId
    )
    {
        try
        {
            await _service.ConnectCarBookingsItems(uniqueId, carBookingsItemsId);
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
    public async Task<ActionResult> DisconnectCarBookingsItems(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] CarBookingsWhereUniqueInput[] carBookingsItemsId
    )
    {
        try
        {
            await _service.DisconnectCarBookingsItems(uniqueId, carBookingsItemsId);
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
    public async Task<ActionResult<List<CarBookings>>> FindCarBookingsItems(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] CarBookingsFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindCarBookingsItems(uniqueId, filter));
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
    public async Task<ActionResult> UpdateCarBookingsItems(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] CarBookingsWhereUniqueInput[] carBookingsItemsId
    )
    {
        try
        {
            await _service.UpdateCarBookingsItems(uniqueId, carBookingsItemsId);
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
    public async Task<ActionResult> ConnectCooperateCustomerProfilesItems(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] CooperateCustomerProfilesWhereUniqueInput[] cooperateCustomerProfilesItemsId
    )
    {
        try
        {
            await _service.ConnectCooperateCustomerProfilesItems(
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
    public async Task<ActionResult> DisconnectCooperateCustomerProfilesItems(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] CooperateCustomerProfilesWhereUniqueInput[] cooperateCustomerProfilesItemsId
    )
    {
        try
        {
            await _service.DisconnectCooperateCustomerProfilesItems(
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
    > FindCooperateCustomerProfilesItems(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] CooperateCustomerProfilesFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindCooperateCustomerProfilesItems(uniqueId, filter));
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
    public async Task<ActionResult> UpdateCooperateCustomerProfilesItems(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] CooperateCustomerProfilesWhereUniqueInput[] cooperateCustomerProfilesItemsId
    )
    {
        try
        {
            await _service.UpdateCooperateCustomerProfilesItems(
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
    public async Task<ActionResult> ConnectFlightBookingsItems(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] FlightBookingsWhereUniqueInput[] flightBookingsItemsId
    )
    {
        try
        {
            await _service.ConnectFlightBookingsItems(uniqueId, flightBookingsItemsId);
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
    public async Task<ActionResult> DisconnectFlightBookingsItems(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] FlightBookingsWhereUniqueInput[] flightBookingsItemsId
    )
    {
        try
        {
            await _service.DisconnectFlightBookingsItems(uniqueId, flightBookingsItemsId);
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
    public async Task<ActionResult<List<FlightBookings>>> FindFlightBookingsItems(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] FlightBookingsFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindFlightBookingsItems(uniqueId, filter));
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
    public async Task<ActionResult> UpdateFlightBookingsItems(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] FlightBookingsWhereUniqueInput[] flightBookingsItemsId
    )
    {
        try
        {
            await _service.UpdateFlightBookingsItems(uniqueId, flightBookingsItemsId);
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
    public async Task<ActionResult> ConnectHotelBookingsItems(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] HotelBookingsWhereUniqueInput[] hotelBookingsItemsId
    )
    {
        try
        {
            await _service.ConnectHotelBookingsItems(uniqueId, hotelBookingsItemsId);
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
    public async Task<ActionResult> DisconnectHotelBookingsItems(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] HotelBookingsWhereUniqueInput[] hotelBookingsItemsId
    )
    {
        try
        {
            await _service.DisconnectHotelBookingsItems(uniqueId, hotelBookingsItemsId);
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
    public async Task<ActionResult<List<HotelBookings>>> FindHotelBookingsItems(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] HotelBookingsFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindHotelBookingsItems(uniqueId, filter));
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
    public async Task<ActionResult> UpdateHotelBookingsItems(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] HotelBookingsWhereUniqueInput[] hotelBookingsItemsId
    )
    {
        try
        {
            await _service.UpdateHotelBookingsItems(uniqueId, hotelBookingsItemsId);
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
    public async Task<ActionResult> ConnectOnlinePaymentsItems(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] OnlinePaymentsWhereUniqueInput[] onlinePaymentsItemsId
    )
    {
        try
        {
            await _service.ConnectOnlinePaymentsItems(uniqueId, onlinePaymentsItemsId);
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
    public async Task<ActionResult> DisconnectOnlinePaymentsItems(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] OnlinePaymentsWhereUniqueInput[] onlinePaymentsItemsId
    )
    {
        try
        {
            await _service.DisconnectOnlinePaymentsItems(uniqueId, onlinePaymentsItemsId);
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
    public async Task<ActionResult<List<OnlinePayments>>> FindOnlinePaymentsItems(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] OnlinePaymentsFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindOnlinePaymentsItems(uniqueId, filter));
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
    public async Task<ActionResult> UpdateOnlinePaymentsItems(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] OnlinePaymentsWhereUniqueInput[] onlinePaymentsItemsId
    )
    {
        try
        {
            await _service.UpdateOnlinePaymentsItems(uniqueId, onlinePaymentsItemsId);
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
    public async Task<ActionResult> ConnectPackageBookingsItems(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] PackageBookingsWhereUniqueInput[] packageBookingsItemsId
    )
    {
        try
        {
            await _service.ConnectPackageBookingsItems(uniqueId, packageBookingsItemsId);
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
    public async Task<ActionResult> DisconnectPackageBookingsItems(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] PackageBookingsWhereUniqueInput[] packageBookingsItemsId
    )
    {
        try
        {
            await _service.DisconnectPackageBookingsItems(uniqueId, packageBookingsItemsId);
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
    public async Task<ActionResult<List<PackageBookings>>> FindPackageBookingsItems(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] PackageBookingsFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindPackageBookingsItems(uniqueId, filter));
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
    public async Task<ActionResult> UpdatePackageBookingsItems(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] PackageBookingsWhereUniqueInput[] packageBookingsItemsId
    )
    {
        try
        {
            await _service.UpdatePackageBookingsItems(uniqueId, packageBookingsItemsId);
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
    public async Task<ActionResult> ConnectPayLatersItems(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] PayLatersWhereUniqueInput[] payLatersItemsId
    )
    {
        try
        {
            await _service.ConnectPayLatersItems(uniqueId, payLatersItemsId);
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
    public async Task<ActionResult> DisconnectPayLatersItems(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] PayLatersWhereUniqueInput[] payLatersItemsId
    )
    {
        try
        {
            await _service.DisconnectPayLatersItems(uniqueId, payLatersItemsId);
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
    public async Task<ActionResult<List<PayLaters>>> FindPayLatersItems(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] PayLatersFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindPayLatersItems(uniqueId, filter));
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
    public async Task<ActionResult> UpdatePayLatersItems(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] PayLatersWhereUniqueInput[] payLatersItemsId
    )
    {
        try
        {
            await _service.UpdatePayLatersItems(uniqueId, payLatersItemsId);
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
    public async Task<ActionResult> ConnectProfilesItems(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] ProfilesWhereUniqueInput[] profilesItemsId
    )
    {
        try
        {
            await _service.ConnectProfilesItems(uniqueId, profilesItemsId);
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
    public async Task<ActionResult> DisconnectProfilesItems(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] ProfilesWhereUniqueInput[] profilesItemsId
    )
    {
        try
        {
            await _service.DisconnectProfilesItems(uniqueId, profilesItemsId);
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
    public async Task<ActionResult<List<Profiles>>> FindProfilesItems(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] ProfilesFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindProfilesItems(uniqueId, filter));
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
    public async Task<ActionResult> UpdateProfilesItems(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] ProfilesWhereUniqueInput[] profilesItemsId
    )
    {
        try
        {
            await _service.UpdateProfilesItems(uniqueId, profilesItemsId);
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
    public async Task<ActionResult> ConnectWalletLogsItems(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] WalletLogsWhereUniqueInput[] walletLogsItemsId
    )
    {
        try
        {
            await _service.ConnectWalletLogsItems(uniqueId, walletLogsItemsId);
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
    public async Task<ActionResult> DisconnectWalletLogsItems(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] WalletLogsWhereUniqueInput[] walletLogsItemsId
    )
    {
        try
        {
            await _service.DisconnectWalletLogsItems(uniqueId, walletLogsItemsId);
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
    public async Task<ActionResult<List<WalletLogs>>> FindWalletLogsItems(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] WalletLogsFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindWalletLogsItems(uniqueId, filter));
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
    public async Task<ActionResult> UpdateWalletLogsItems(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] WalletLogsWhereUniqueInput[] walletLogsItemsId
    )
    {
        try
        {
            await _service.UpdateWalletLogsItems(uniqueId, walletLogsItemsId);
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
    public async Task<ActionResult> ConnectWalletsItems(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] WalletsWhereUniqueInput[] walletsItemsId
    )
    {
        try
        {
            await _service.ConnectWalletsItems(uniqueId, walletsItemsId);
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
    public async Task<ActionResult> DisconnectWalletsItems(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] WalletsWhereUniqueInput[] walletsItemsId
    )
    {
        try
        {
            await _service.DisconnectWalletsItems(uniqueId, walletsItemsId);
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
    public async Task<ActionResult<List<Wallets>>> FindWalletsItems(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] WalletsFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindWalletsItems(uniqueId, filter));
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
    public async Task<ActionResult> UpdateWalletsItems(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] WalletsWhereUniqueInput[] walletsItemsId
    )
    {
        try
        {
            await _service.UpdateWalletsItems(uniqueId, walletsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
