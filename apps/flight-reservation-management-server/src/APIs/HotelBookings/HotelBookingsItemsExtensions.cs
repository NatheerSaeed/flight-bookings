using FlightReservationManagement.APIs.Dtos;
using FlightReservationManagement.Infrastructure.Models;

namespace FlightReservationManagement.APIs.Extensions;

public static class HotelBookingsItemsExtensions
{
    public static HotelBookings ToDto(this HotelBookingsDbModel model)
    {
        return new HotelBookings
        {
            AdultGuest = model.AdultGuest,
            BaseAmount = model.BaseAmount,
            CancellationStatus = model.CancellationStatus,
            CheckInDate = model.CheckInDate,
            CheckOutDate = model.CheckOutDate,
            ChildGuest = model.ChildGuest,
            CreatedAt = model.CreatedAt,
            ExpiryDate = model.ExpiryDate,
            Guarantee = model.Guarantee,
            HotelChainCode = model.HotelChainCode,
            HotelCityCode = model.HotelCityCode,
            HotelCode = model.HotelCode,
            HotelContextCode = model.HotelContextCode,
            HotelName = model.HotelName,
            Id = model.Id,
            Markdown = model.Markdown,
            Markup = model.Markup,
            PaymentStatus = model.PaymentStatus,
            Pnr = model.Pnr,
            PnrRequestResponse = model.PnrRequestResponse,
            RatePlanCode = model.RatePlanCode,
            Reference = model.Reference,
            ReservationStatus = model.ReservationStatus,
            RoomBookingCode = model.RoomBookingCode,
            TotalAmount = model.TotalAmount,
            UpdatedAt = model.UpdatedAt,
            User = model.UserId,
            Vat = model.Vat,
            Voucher = model.VoucherId,
            VoucherAmount = model.VoucherAmount,
        };
    }

    public static HotelBookingsDbModel ToModel(
        this HotelBookingsUpdateInput updateDto,
        HotelBookingsWhereUniqueInput uniqueId
    )
    {
        var hotelBookings = new HotelBookingsDbModel
        {
            Id = uniqueId.Id,
            AdultGuest = updateDto.AdultGuest,
            BaseAmount = updateDto.BaseAmount,
            CancellationStatus = updateDto.CancellationStatus,
            CheckInDate = updateDto.CheckInDate,
            CheckOutDate = updateDto.CheckOutDate,
            ChildGuest = updateDto.ChildGuest,
            ExpiryDate = updateDto.ExpiryDate,
            Guarantee = updateDto.Guarantee,
            HotelChainCode = updateDto.HotelChainCode,
            HotelCityCode = updateDto.HotelCityCode,
            HotelCode = updateDto.HotelCode,
            HotelContextCode = updateDto.HotelContextCode,
            HotelName = updateDto.HotelName,
            Markdown = updateDto.Markdown,
            Markup = updateDto.Markup,
            PaymentStatus = updateDto.PaymentStatus,
            Pnr = updateDto.Pnr,
            PnrRequestResponse = updateDto.PnrRequestResponse,
            RatePlanCode = updateDto.RatePlanCode,
            Reference = updateDto.Reference,
            ReservationStatus = updateDto.ReservationStatus,
            RoomBookingCode = updateDto.RoomBookingCode,
            TotalAmount = updateDto.TotalAmount,
            Vat = updateDto.Vat,
            VoucherAmount = updateDto.VoucherAmount
        };

        if (updateDto.CreatedAt != null)
        {
            hotelBookings.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            hotelBookings.UpdatedAt = updateDto.UpdatedAt.Value;
        }
        if (updateDto.User != null)
        {
            hotelBookings.UserId = updateDto.User;
        }
        if (updateDto.Voucher != null)
        {
            hotelBookings.VoucherId = updateDto.Voucher;
        }

        return hotelBookings;
    }
}
