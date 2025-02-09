using PetManagementAPI.Enums;
using PetManagementAPI.Models;
using PetManagementAPI.Repositories.Abstraction;
using PetManagementAPI.Services.Abstraction;
using VNPAY.NET.Models;

namespace PetManagementAPI.Services.Implementation
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IOrderService _orderService;

        public PaymentService(IPaymentRepository paymentRepository, IOrderService orderService)
        {
            _paymentRepository = paymentRepository;
            _orderService = orderService;
        }

        public async Task ProcessFailedPayment(PaymentResult paymentResult)
        {
            // Update order status to failed
            var orderId = Guid.Parse(paymentResult.Description);
            await _orderService.UpdateOrderStatus(orderId, (byte)OrderStatus.PaymentFailed);
        }

        public async Task ProcessSuccessPayment(PaymentResult paymentResult)
        {
            // Create a new payment record in the database
            var payment = new Payment
            {
                Id = paymentResult.PaymentId.ToString(),
                PaymentDate = paymentResult.Timestamp,
                PaymentMethod = paymentResult.PaymentMethod
            };

            await _paymentRepository.Create(payment);

            // Update order status to paid
            var orderId = Guid.Parse(paymentResult.Description);
            var order = await _orderService.UpdateOrderStatus(orderId, (byte)OrderStatus.Paid);

            order.OrderDate = DateTime.Now;

            // Link payment to order
            order.PaymentId = payment.Id;

            await _orderService.ProcessAfterPlaceOrder(order);
        }
    }
}
