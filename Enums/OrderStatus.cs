namespace PetManagementAPI.Enums
{
    public enum OrderStatus
    {
        Pending,
        PendingPayment,
        Paid,
        PaymentFailed,
        Processing,
        Shipping,
        Delivered,
        Cancelled
    }
}
