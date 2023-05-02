using BuberDinner.Domain.BillAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;

namespace BuberDinner.Domain.DinnerAggregate.Entities;

public sealed class Reservation : AggregateRoot<ReservationId>
{
    public int GuestCount { get; }
    public ReservationStatus ReservationStatus { get; }
    public GuestId GuestId { get; }
    public BillId BillId { get; }
    public DateTime ArrivalDateTime { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    public Reservation(ReservationId id, int guestCount, ReservationStatus reservationStatus, GuestId guestId, BillId billId, DateTime arrivalDateTime,
        DateTime createdDateTime, DateTime updatedDateTime)
        : base(id)
    {
        GuestCount = guestCount;
        ReservationStatus = reservationStatus;
        GuestId = guestId;
        BillId = billId;
        ArrivalDateTime = arrivalDateTime;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Reservation Create(
         int guestCount,
         ReservationStatus
        reservationStatus,
         GuestId guestId,
         BillId billId,
         DateTime arrivalDateTime)
    {
        return new(
            ReservationId.CreateUnique(),
            guestCount,
            reservationStatus,
            guestId,
            billId,
            arrivalDateTime,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}