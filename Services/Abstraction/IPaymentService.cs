using VNPAY.NET.Models;

namespace PetManagementAPI.Services.Abstraction
{
    public interface IPaymentService
    {
        Task ProcessSuccessPayment(PaymentResult paymentResult);
        Task ProcessFailedPayment(PaymentResult paymentResult);
    }
}
