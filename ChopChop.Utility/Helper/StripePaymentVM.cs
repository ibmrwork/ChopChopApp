using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expandly.Domain.Entities.ViewModels
{
    class StripePaymentVM
    {
        
    }

    public class StatusMessage
    {
        public bool IsSuccessful { get; set; }
        public int ErrorCode { get; set; }
        public string Message { get; set; }
        public object responseObj { get; set; }
        public long ReturnId { get; set; }
    }

    public class InvoicesListVM
    {
       // public List<StoreInvoiceVM> invoicesVM { get; set; }
        public int TotalRows { get; set; }
    }

    public class SelectedStripePlanProduct
    {
        public List<SelectedStripePlansVM> _SelectedStripePlanList { get; set; }
        public List<SelectedStripeProductVM> _SelectedStripeProductList { get; set; }
    }

    public class SelectedStripePlansVM
    {
        public string StripeId { get; set; }
        public string PlanId { get; set; }
        public int Quantity { get; set; }
    }
    public class SelectedStripeProductVM
    {
        public string SKU { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public int? ProductId { get; set; }
    }
    public class StripeChargeVM
    {
        public decimal? Amount { get; set; }
        public int? CurrencyId { get; set; }
        public int? FrequencyId { get; set; }
        public string Currency { get; set; }
        public string Frequency { get; set; }
        public string Description { get; set; }
        public string CustomerId { get; set; }
        public int? ApplicationFee { get; set; }
        public bool Capture { get; set; }
        public StripeCardDetailVM CardDetails { get; set; }
        public List<StripeCartVM> StripeCart { get; set; }
        public string EmailAddress { get; set; }
        public string Name { get; set; }
    }

    public class StripeCartVM
    {
        public int? PlanTableId { get; set; }
        public int? ProductId { get; set; }
        public string Heading { get; set; }
        public int? SelectedPlan { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? Total { get; set; }
        public DateTime? LastPaymentDate { get; set; }
        public DateTime? NextPaymentDate { get; set; }
    }

    public class StripeCardDetailVM
    {
        public string CouponId { get; set; }
        public string Number { get; set; }
        public int ExpirationYear { get; set; }
        public int ExpirationMonth { get; set; }
        public int AddressCountryId { get; set; }
        public string AddressCountry { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressCity { get; set; }
        public string AddressState { get; set; }
        public string AddressZip { get; set; }
        public string Name { get; set; }
        public string Cvc { get; set; }
    }

    public class StripeCustomerVM
    {
        public string CustomerId { get; set; }
        public string EmailAddress { get; set; }
        public string CustomerName { get; set; }
        public StripeCardDetailVM StripeCard { get; set; }
    }

    public class StripeSubscriptionVM
    {
        public string SubscriptionId { get; set; }
        public decimal? ApplicationFeePercent { get; set; }
        public bool CancelAtPeriodEnd { get; set; }
        public DateTime? CanceledAt { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? CurrentPeriodEnd { get; set; }
        public DateTime? CurrentPeriodStart { get; set; }
        public StripeCustomerVM Customer { get; set; }
        public string CustomerId { get; set; }
        public DateTime? EndedAt { get; set; }
        public int? Quantity { get; set; }
        public string Status { get; set; }
        public List<StripeSubscriptionItemVM> Items { get; set; }
        public StripeDiscountVM StripeDiscount { get; set; }
        public StripePlanVM StripePlan { get; set; }
        public decimal? TaxPercent { get; set; }
        public DateTime? TrialEnd { get; set; }
        public DateTime? TrialStart { get; set; }
        public string CouponId { get; set; }
    }

    public class StripeSubscriptionItemVM
    {
        public string StripeSubscriptionItemId { get; set; }
        public DateTime Created { get; set; }
        public string Object { get; set; }
        public StripePlanVM Plan { get; set; }
        public int Quantity { get; set; }
    }

    public class StripePlanVM
    {
        public string StripePlanId { get; set; }
        public decimal? Amount { get; set; }
        public string Currency { get; set; }
        public string Interval { get; set; }
        public string Name { get; set; }
        public string StatementDescriptor { get; set; }
        public int? TrialPeriodDays { get; set; }
    }

    public class StripeDiscountVM
    {
        public string StripeDiscountId { get; set; }
        public StripeCustomerVM Customer { get; set; }
        public string CustomerId { get; set; }
        public DateTime? End { get; set; }
        public string Object { get; set; }
        public DateTime? Start { get; set; }
        public StripeCouponVM StripeCoupon { get; set; }
        public StripeSubscriptionVM Subscription { get; set; }
        public string SubscriptionId { get; set; }
    }

    public class StripeCouponVM
    {
        public string StripeCouponId { get; set; }
        public decimal? AmountOff { get; set; }
        public DateTime Created { get; set; }
        public string Currency { get; set; }
        public string Duration { get; set; }
        public int? DurationInMonths { get; set; }
        public bool LiveMode { get; set; }
        public int? MaxRedemptions { get; set; }
        public string Object { get; set; }
        public int? PercentOff { get; set; }
        public DateTime? RedeemBy { get; set; }
        public int TimesRedeemed { get; set; }
        public bool Valid { get; set; }
    }


    public class StripeOrderVM
    {
        public int? ProductId { get; set; }
        public string StripeOrderId { get; set; }
        public decimal? Amount { get; set; }
        public decimal? AmountReturned { get; set; }
        public string Application { get; set; }
        public int? ApplicationFee { get; set; }
        public string ChargeId { get; set; }
        public DateTime Created { get; set; }
        public string Currency { get; set; }
        public string CustomerId { get; set; }
        public string Email { get; set; }
        public string ExternalCouponCode { get; set; }
        public bool LiveMode { get; set; }
        public Dictionary<string, string> Metadata { get; set; }
        public string Object { get; set; }
        public List<StripeOrderItemVM> OrderItems { get; set; }
        public string SelectedShippingMethod { get; set; }

        public string Status { get; set; }
        public DateTime Updated { get; set; }
        public string UpstreamId { get; set; }
        public StripeShippingVM Shipping { get; set; }
        public decimal? TaxRate { get; set; }
    }

    public class StripeShippingVM
    {
        public string StripeShippingId { get; set; }
        public StripeAddressVM Address { get; set; }
        public string Carrier { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string TrackingNumber { get; set; }
    }

    public class StripeAddressVM
    {
        public string StripeAddressId{get;set;}
        public string City { get; set; }
        public string Country { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string Town { get; set; }
    }

    public class StripeOrderItemVM
    {
        public string StripeOrderItemId { get; set; }
        public decimal? Amount { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
        public string Object { get; set; }
        public string Parent { get; set; }
        public int? Quantity { get; set; }
        public string Type { get; set; }
    }

    public class StripeErrorVM
    {
        public StripeResponseVM StripeResponse { get; set; }
        public string ChargeId { get; set; }
        public string Code { get; set; }
        public string DeclineCode { get; set; }
        public string Error { get; set; }
        public string ErrorDescription { get; set; }
        public string ErrorType { get; set; }
        public string Message { get; set; }
        public string Parameter { get; set; }
    }

    public class StripeResponseVM
    {
        public string ObjectJson { get; set; }
        public DateTime RequestDate { get; set; }
        public string RequestId { get; set; }
        public string ResponseJson { get; set; }
    }

    public class StripeEventVM
    {
        public string StripeEventId { get; set; }
        public DateTime? Created { get; set; }
        public string Data { get; set; }
        public bool LiveMode { get; set; }
        public int PendingWebhooks { get; set; }
        public string Request { get; set; }
        public string Type { get; set; }
        public string UserId { get; set; }
    }

    public class StripeWebhookVM
    {
        public StripeEventVM StripeEventVM { get; set; }
        public StripeInvoiceVM StripeInvoiceVM { get; set; }
        public StripeSubscriptionVM StripeSubscriptionVM { get; set; }
        public StripeChargeWebhookVM StripeChargeWebhookVM { get; set; }
        public StripeOrderVM StripeOrderVM { get; set; }
    }

    public class StripeInvoiceVM
    {
        public string StripeInvoiceId { get; set; }
        public decimal? AmountDue { get; set; }
        public decimal? ApplicationFee { get; set; }
        public int AttemptCount { get; set; }
        public bool Attempted { get; set; }
        public StripeChargeVM Charge { get; set; }
        public string StripeChargeId { get; set; }
        public bool? Closed { get; set; }
        public string Currency { get; set; }
        public StripeCustomerVM Customer { get; set; }
        public string CustomerId { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }
        public decimal? EndingBalance { get; set; }
        public bool? Forgiven { get; set; }
        public bool LiveMode { get; set; }
        public DateTime? NextPaymentAttempt { get; set; }
        public string Object { get; set; }
        public bool Paid { get; set; }
        public DateTime PeriodEnd { get; set; }
        public DateTime PeriodStart { get; set; }
        public string ReceiptNumber { get; set; }
        public decimal? StartingBalance { get; set; }
        public string StatementDescriptor { get; set; }
        public StripeDiscountVM StripeDiscount { get; set; }
        public List<StripeInvoiceLineItemVM> StripeInvoiceLineItems { get; set; }
        public string SubscriptionId { get; set; }
        public decimal? Subtotal { get; set; }
        public decimal? Tax { get; set; }
        public decimal? TaxPercent { get; set; }
        public decimal? Total { get; set; }
        public DateTime? WebhooksDeliveredAt { get; set; }
    }

    public class StripeInvoiceLineItemVM
    {
        public string StripeInvoiceLineItemId { get; set; }
        public decimal? Amount { get; set; }
        public string Currency { get; set; }
        public StripeCustomerVM Customer { get; set; }
        public string CustomerId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public StripeInvoiceVM Invoice { get; set; }
        public string InvoiceId { get; set; }
        public bool LiveMode { get; set; }
      
        public string Object { get; set; }
        public StripePlanVM Plan { get; set; }
        public bool Proration { get; set; }
        public int? Quantity { get; set; }
        public StripePeriodVM StripePeriod { get; set; }
        public string SubscriptionId { get; set; }
        public string Type { get; set; }

        public int? PlanPricingId { get; set; }
        public decimal? UnitPrice { get; set; }
    }

    public class StripePeriodVM
    {
        public string StripePeriodId{get;set;}
        public DateTime? End { get; set; }
        public DateTime? Start { get; set; }
    }

    public class StripeChargeWebhookVM
    {
        public string StripeChargeId{get;set;}
        public decimal Amount { get; set; }
        public decimal AmountRefunded { get; set; }
        public bool? Captured { get; set; }
        public DateTime Created { get; set; }
        public string Currency { get; set; }
        public string CustomerId { get; set; }
        public string Description { get; set; }
        public string FailureCode { get; set; }
        public string FailureMessage { get; set; }
        public string StripeInvoiceId { get; set; }
        public bool LiveMode { get; set; }
        public string StripeOrder { get; set; }
        public bool Paid { get; set; }
        public string ReceiptEmail { get; set; }
        public string ReceiptNumber { get; set; }
        public bool Refunded { get; set; }
     
        public string StatementDescriptor { get; set; }
        public string Status { get; set; }

        public string StripeCardId {get;set;}
        public string AddressCity { get; set; }
        public string AddressCountry { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressState { get; set; }
        public string AddressZip { get; set; }
      
        public string Brand { get; set; }
        public string Country { get; set; }
        public string CvcCheck { get; set; }
        public bool DefaultForCurrency { get; set; }
        public string DynamicLast4 { get; set; }
        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }
        public string Fingerprint { get; set; }
        public string Last4 { get; set; }
    }

    public class OrderTaxCallback
    {
        public OrderUpdateVM order_update { get; set; }
    }

    public class OrderUpdateVM
    {
       // public string order_id { get; set; }
        public List<OrderUpdateLineItem> items { get; set; }
        public List<StripeShippingMethodVM> shipping_methods { get; set; }
    }

    public class OrderUpdateLineItem
    {
        public string parent { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public int amount { get; set; }
        public string currency { get; set; }
    }

    public class StripeShippingMethodVM 
    {
        public string id { get; set; }
        public int amount { get; set; }
        public string currency { get; set; }
        public string description { get; set; }
    }
    public class stripeBillingPaging
    {
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
    }
   
}
