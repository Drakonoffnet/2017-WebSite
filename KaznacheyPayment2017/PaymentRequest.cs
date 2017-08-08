using System;
using System.Collections.Generic;

namespace Kaznachey.KaznacheyPayment
{
    /// <summary>
    /// Represents request for creation payment
    /// </summary>
    public class PaymentRequest
    {
        public PaymentRequest()
        {
            Currency = "UAH";
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="selectedPaySystemId">Select payment system Id</param>
        public PaymentRequest(int selectedPaySystemId)
        {
            SelectedPaySystemId = selectedPaySystemId;
        }

        /// <summary>
        /// Select payment system Id
        /// </summary>
        public Int32 SelectedPaySystemId { get; set; }

        /// <summary>
        /// Currency (UAH, USD, RUB, EUR)
        /// </summary>
        public String Currency { get; set; }

        /// <summary>
        /// Language (RU, EN)
        /// </summary>
        public String Language { get; set; }

        /// <summary>
        /// Products list
        /// </summary>
        public List<Product> Products { get; set; }

        /// <summary>
        /// Represents payment detail
        /// </summary>
        public PaymentDetails PaymentDetail { get; set; }
    }
}
