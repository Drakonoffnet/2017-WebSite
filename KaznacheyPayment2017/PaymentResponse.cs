using System;

namespace Kaznachey.KaznacheyPayment
{
    /// <summary>
    /// PaymentResponse represent information about payment processing
    /// </summary>
    public class PaymentResponse: BaseResponse
    {
        public PaymentResponse()
        {
            Currency = "UAH";
        }

        /// <summary>
        /// Order id 
        /// </summary>
        public Int32 OrderId { get; set; }

        /// <summary>
        /// Merchant internal payment id
        /// </summary>
        public String MerchantInternalPaymentId { get; set; }

        /// <summary>
        /// Merchant user internal id 
        /// </summary>
        public String MerchantInternalUserId { get; set; }

        /// <summary>
        /// Sum
        /// </summary>
        public Decimal Sum { get; set; }


        /// <summary>
        /// Sum of merchant order
        /// </summary>
        public Decimal OrderSum { get; set; }

        /// <summary>
        /// Currency
        /// </summary>
        public String Currency { get; set; }

        /// <summary>
        /// Custom merchant info
        /// </summary>
        public String CustomMerchantInfo { get; set; }

        /// <summary>
        /// Should be validated. Example:
        /// 
        ///        Request.ErrorCode.ToString(CultureInfo.InvariantCulture)
        ///              + Request.OrderId
        ///              + Request.MerchantInternalPaymentId
        ///              + Request.MerchantInternalUserId
        ///              + Request.OrderSum.ToString('N')
        ///              + Request.Sum.ToString('N')
        ///              + Request.Currency.ToUpper()
        ///              + Request.CustomMerchantInfo
        ///              + MerchantSecretKey.ToString().ToUpper();
        /// </summary>
        public String SignatureEx { get; set; }
    }
}
