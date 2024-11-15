using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class FlightBookingsItemsExtensions
{
    public static FlightBookings ToDto(this FlightBookingsDbModel model)
    {
        return new FlightBookings
        {
            CancelTicketStatus = model.CancelTicketStatus,
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            IssueTicketStatus = model.IssueTicketStatus,
            ItineraryAmount = model.ItineraryAmount,
            Markdown = model.Markdown,
            Markup = model.Markup,
            PaymentStatus = model.PaymentStatus,
            Pnr = model.Pnr,
            PnrRequestResponse = model.PnrRequestResponse,
            Reference = model.Reference,
            TicketTimeLimit = model.TicketTimeLimit,
            TotalAmount = model.TotalAmount,
            UpdatedAt = model.UpdatedAt,
            User = model.UserId,
            Vat = model.Vat,
            VoidTicketStatus = model.VoidTicketStatus,
            Voucher = model.VoucherId,
            VoucherAmount = model.VoucherAmount,
        };
    }

    public static FlightBookingsDbModel ToModel(
        this FlightBookingUpdateInput updateDto,
        FlightBookingsWhereUniqueInput uniqueId
    )
    {
        var flightBookings = new FlightBookingsDbModel
        {
            Id = uniqueId.Id,
            CancelTicketStatus = updateDto.CancelTicketStatus,
            IssueTicketStatus = updateDto.IssueTicketStatus,
            ItineraryAmount = updateDto.ItineraryAmount,
            Markdown = updateDto.Markdown,
            Markup = updateDto.Markup,
            PaymentStatus = updateDto.PaymentStatus,
            Pnr = updateDto.Pnr,
            PnrRequestResponse = updateDto.PnrRequestResponse,
            Reference = updateDto.Reference,
            TicketTimeLimit = updateDto.TicketTimeLimit,
            TotalAmount = updateDto.TotalAmount,
            Vat = updateDto.Vat,
            VoidTicketStatus = updateDto.VoidTicketStatus,
            VoucherAmount = updateDto.VoucherAmount
        };

        if (updateDto.CreatedAt != null)
        {
            flightBookings.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            flightBookings.UpdatedAt = updateDto.UpdatedAt.Value;
        }
        if (updateDto.User != null)
        {
            flightBookings.UserId = updateDto.User;
        }
        if (updateDto.Voucher != null)
        {
            flightBookings.VoucherId = updateDto.Voucher;
        }

        return flightBookings;
    }
}
