using System;

namespace Kaznachey.KaznacheyPayment
{
    public interface IPaymentSystem
    {
        MerchantInfoResponse GetMerchantInformation();

        CreatePaymentResponse CreatePayment(PaymentRequest payment);

        Boolean ValidateResponse(PaymentResponse resp);
    }
}
