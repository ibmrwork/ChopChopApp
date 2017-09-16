using Expandly.Domain.Entities.ViewModels;
using Stripe;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;


namespace Expandly.Payment.StripeGateway
{
    public class StripeService
    {
        /// <summary>
        /// property for stripe secret key which is added in web.config under app settings
        /// </summary>
        public string StripeSecretKey { get; set; }

        /// <summary>
        /// set the stripe secret key
        /// </summary>
        public StripeService()
        {
            StripeSecretKey = ConfigurationManager.AppSettings["StripeSecretKey"].ToString();
        }
 
        /// <summary>
        /// creates the customer on stripe
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public StatusMessage CreateStripeCustomer(StripeCustomerVM customer)
        {
            StatusMessage obj = new StatusMessage();
            try
            {
                var myCustomer = new StripeCustomerCreateOptions();
                myCustomer.Email = customer.EmailAddress;
                myCustomer.Description = customer.CustomerName;
                myCustomer.SourceCard = new SourceCard();
                myCustomer.SourceCard.AddressCity = customer.StripeCard.AddressCity;
                myCustomer.SourceCard.AddressCountry = customer.StripeCard.AddressCountry;
                myCustomer.SourceCard.AddressLine1 = customer.StripeCard.AddressLine1;
                myCustomer.SourceCard.AddressLine2 = customer.StripeCard.AddressLine2;
                myCustomer.SourceCard.AddressState = customer.StripeCard.AddressState;
                myCustomer.SourceCard.AddressZip = customer.StripeCard.AddressZip;
                myCustomer.SourceCard.Capture = true;
                myCustomer.SourceCard.Cvc = customer.StripeCard.Cvc;
                myCustomer.SourceCard.ExpirationMonth = customer.StripeCard.ExpirationMonth;
                myCustomer.SourceCard.ExpirationYear = customer.StripeCard.ExpirationYear;
                myCustomer.SourceCard.Name = customer.StripeCard.Name;
                myCustomer.SourceCard.Number = customer.StripeCard.Number;
                

                var customerService = new StripeCustomerService();
                customerService.ApiKey = StripeSecretKey;
                StripeCustomer stripeCustomer = customerService.Create(myCustomer);
                var StripeCustomerId = stripeCustomer.Id;
                obj.IsSuccessful = true;
                obj.Message = StripeCustomerId;
                obj.responseObj = stripeCustomer;
            }
            catch (StripeException ex)
            {
                obj.IsSuccessful = false;
                obj.Message = ex.Message;
                obj.ErrorCode = (int)ex.HttpStatusCode;
                obj.responseObj = MapStripeError(ex.StripeError);
            }
            catch (Exception ex)
            {
                obj.IsSuccessful = false;
                obj.Message = ex.Message;
            }
            return obj;
        }

        /// <summary>
        /// updates the customer on stripe
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public StatusMessage UpdateStripeCustomer(StripeCustomerVM customer)
        {
            StatusMessage obj = new StatusMessage();
            try
            {
                var myCustomer = new StripeCustomerUpdateOptions();
                myCustomer.Email = customer.EmailAddress;
                myCustomer.Description = customer.CustomerName;
                myCustomer.SourceCard = new SourceCard();
                myCustomer.SourceCard.AddressCity = customer.StripeCard.AddressCity;
                myCustomer.SourceCard.AddressCountry = customer.StripeCard.AddressCountry;
                myCustomer.SourceCard.AddressLine1 = customer.StripeCard.AddressLine1;
                myCustomer.SourceCard.AddressLine2 = customer.StripeCard.AddressLine2;
                myCustomer.SourceCard.AddressState = customer.StripeCard.AddressState;
                myCustomer.SourceCard.AddressZip = customer.StripeCard.AddressZip;
                myCustomer.SourceCard.Capture = true;
                myCustomer.SourceCard.Cvc = customer.StripeCard.Cvc;
                myCustomer.SourceCard.ExpirationMonth = customer.StripeCard.ExpirationMonth;
                myCustomer.SourceCard.ExpirationYear = customer.StripeCard.ExpirationYear;
                myCustomer.SourceCard.Name = customer.StripeCard.Name;
                myCustomer.SourceCard.Number = customer.StripeCard.Number;
                var customerService = new StripeCustomerService();
                customerService.ApiKey = StripeSecretKey;
                StripeCustomer stripeCustomer = customerService.Update(customer.CustomerId, myCustomer);
                var StripeCustomerId = stripeCustomer.Id;
                obj.IsSuccessful = true;
                obj.Message = StripeCustomerId;
                obj.responseObj = stripeCustomer;
            }
            catch (StripeException ex)
            {
                obj.IsSuccessful = false;
                obj.Message = ex.Message;
                obj.ErrorCode = (int)ex.HttpStatusCode;
                obj.responseObj = MapStripeError(ex.StripeError);
            }
            catch (Exception ex)
            {
                obj.IsSuccessful = false;
                obj.Message = ex.Message;
            }
            return obj;
        }

        /// <summary>
        /// deletes the customer on stripe
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public StatusMessage DeleteStripeCustomer(string customerId)
        {
            StatusMessage obj = new StatusMessage();
            try
            {
                var customerService = new StripeCustomerService();
                StripeDeleted st = customerService.Delete(customerId);
                obj.IsSuccessful = st.Deleted;
                obj.Message = st.Id;
                obj.responseObj = st;
            }
            catch (StripeException ex)
            {
                obj.IsSuccessful = false;
                obj.Message = ex.Message;
                obj.ErrorCode = (int)ex.HttpStatusCode;
                obj.responseObj = MapStripeError(ex.StripeError);
            }
            catch (Exception ex)
            {
                obj.IsSuccessful = false;
                obj.Message = ex.Message;
            }
            return obj;
        }

        /// <summary>
        /// gets the details of customer from stripe
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public StripeCustomer GetStripeCustomer(string customerId)
        { 
            StatusMessage obj = new StatusMessage();
            try
            {
                var customerService = new StripeCustomerService();
                var myCustomer = customerService.Get(customerId);
                return myCustomer;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

       /// <summary>
       /// creates the multiplan subscription on stripe
       /// </summary>
       /// <param name="StripeCustomerId"></param>
       /// <param name="couponId"></param>
       /// <param name="plans"></param>
       /// <param name="tax"></param>
       /// <returns></returns>
        public StatusMessage CreateStripeSubscription(string StripeCustomerId, string couponId , List<SelectedStripePlansVM> plans, decimal? tax)
        {
            StatusMessage obj = new StatusMessage();
            try
            {
                //TaxjarService _taxjar = new TaxjarService();
                var subscription = new StripeSubscriptionCreateOptions();
                //var sts = _taxjar.GetSalesTax(addressvm);
                //if (sts.IsSuccessful)
                //{
                //    subscription.TaxPercent = (decimal)sts.responseObj;
                //}
                //else
                //{
                //    return sts;
                //}
                StripeSubscriptionService subscriptionService = new StripeSubscriptionService(StripeSecretKey);
                subscription.CustomerId = StripeCustomerId;
                if (tax != null)
                {
                    subscription.TaxPercent = tax;
                }
                subscription.Items = new List<StripeSubscriptionItemOption>();
                foreach (var model in plans)
                {
                    StripeSubscriptionItemOption item = new StripeSubscriptionItemOption();
                    item.PlanId = model.PlanId;
                    item.Quantity = model.Quantity;
                    if (item.Quantity > 0)
                    {
                        subscription.Items.Add(item);
                    }
                }
           
                if (!string.IsNullOrEmpty(couponId))
                {
                    subscription.CouponId = couponId;
                }
                StripeSubscription custSub = subscriptionService.Create(StripeCustomerId, subscription);
                
                obj.IsSuccessful = true;
                obj.Message = custSub.Id;
                obj.responseObj = MapStripeSubscription(custSub, couponId);
            }
            catch (StripeException ex)
            {
                obj.IsSuccessful = false;
                obj.Message = ex.Message;
                obj.ErrorCode = (int)ex.HttpStatusCode;
                obj.responseObj = MapStripeError(ex.StripeError);
            }
            catch (Exception ex)
            {
                obj.IsSuccessful = false;
                obj.Message = ex.Message;
            }
            return obj;
        }

        /// <summary>
        /// updates the multiplan subscription on stripe
        /// </summary>
        /// <param name="StripeCustomerId"></param>
        /// <param name="StripeSubscriptionId"></param>
        /// <param name="couponId"></param>
        /// <param name="plans"></param>
        /// <param name="frequencyId"></param>
        /// <param name="tax"></param>
        /// <returns></returns>
        public StatusMessage UpdateStripeSubscription(string StripeCustomerId, string StripeSubscriptionId, string couponId, List<SelectedStripePlansVM> plans, int? frequencyId, decimal? tax)
        {
            StatusMessage obj = new StatusMessage();
            try
            {
                //TaxjarService _taxjar = new TaxjarService();
                //var sts = _taxjar.GetSalesTax(addressvm);

                var subscription = new StripeSubscriptionUpdateOptions();
                subscription.Items = new List<StripeSubscriptionItemUpdateOption>();
                //if (sts.IsSuccessful)
                //{
                //    subscription.TaxPercent = (decimal)sts.responseObj;
                //}
                //else
                //{
                //    return sts;
                //}
                foreach (var model in plans)
                {
                    StripeSubscriptionItemUpdateOption item = new StripeSubscriptionItemUpdateOption();
                    item.PlanId = model.PlanId;
                    item.Quantity = model.Quantity;
                    item.Id = model.StripeId;
                    if (model.Quantity == 0)
                    {
                        item.Deleted = true;
                    }
                    subscription.Items.Add(item);
                }
                StripeSubscriptionService subscriptionService = new StripeSubscriptionService(StripeSecretKey);
                StripeSubscription custSub = subscriptionService.Get(StripeSubscriptionId);
                subscription.Prorate = true;
                if (tax != null)
                {
                    subscription.TaxPercent = tax;
                }
                if (!string.IsNullOrEmpty(couponId))
                {
                    subscription.CouponId = couponId;
                }
                else
                {
                    subscription.CouponId = null;
                }
                custSub = subscriptionService.Update(StripeSubscriptionId, subscription);
                //if (frequencyId == 2)
                //{
                    StatusMessage inv = CreateInvoice(StripeCustomerId, custSub.Id, "");
                    if (inv.IsSuccessful)
                    {
                        StripeInvoiceVM vm = (StripeInvoiceVM)inv.responseObj;
                        PayInvoice(vm.StripeInvoiceId);
                    }
                //}
                obj.IsSuccessful = true;
                obj.Message = custSub.Id;
                obj.responseObj = MapStripeSubscription(custSub);
            }
            catch (StripeException ex)
            {
                obj.IsSuccessful = false;
                obj.Message = ex.Message;
                obj.ErrorCode = (int)ex.HttpStatusCode;
                obj.responseObj = MapStripeError(ex.StripeError);
            }
            catch (Exception ex)
            {
                obj.IsSuccessful = false;
                obj.Message = ex.Message;
            }
            return obj;
        }

        /// <summary>
        /// cancel the customer's subscription on stripe
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <param name="CancelAtPeriodEnd">false: immediately cancels the subscription, true: cancel the subscription at the end of its period</param>
        /// <returns></returns>
        public StatusMessage CancelStripeSubscription(string subscriptionId,bool CancelAtPeriodEnd)
        {
            StatusMessage obj = new StatusMessage();
            try
            {
                var subscriptionService = new StripeSubscriptionService(StripeSecretKey);
                StripeSubscription custSub = subscriptionService.Cancel(subscriptionId, CancelAtPeriodEnd);
                obj.IsSuccessful = true;
                obj.Message = custSub.Status;
                obj.responseObj = MapStripeSubscription(custSub); 
            }
            catch (StripeException ex)
            {
                obj.IsSuccessful = false;
                obj.Message = ex.Message;
                obj.ErrorCode = (int)ex.HttpStatusCode;
                obj.responseObj = MapStripeError(ex.StripeError);
            }
            catch (Exception ex)
            {
                obj.IsSuccessful = false;
                obj.Message = ex.Message;
            }
            return obj;
        }

        /// <summary>
        /// add the subscription item i.e. plan on stripe in existing subscription
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <param name="quantity"></param>
        /// <param name="planId"></param>
        /// <returns></returns>
        public StatusMessage CreateStripeSubscriptionItem(string subscriptionId, int quantity, string planId)
        {
            StatusMessage obj = new StatusMessage();
            try
            {
                var item = new StripeSubscriptionItemCreateOptions();
                item.SubscriptionId = subscriptionId;
                item.PlanId = planId;
                item.Quantity = quantity;
                var subscriptionItem = new StripeSubscriptionItemService(StripeSecretKey).Create(item);
                obj.IsSuccessful = true;
                obj.Message = subscriptionItem.Id;
                obj.responseObj = subscriptionItem;
            }
            catch (StripeException ex)
            {
                obj.IsSuccessful = false;
                obj.Message = ex.Message;
                obj.ErrorCode = (int)ex.HttpStatusCode;
                obj.responseObj = MapStripeError(ex.StripeError);
            }
            catch (Exception ex)
            {
                obj.IsSuccessful = false;
                obj.Message = ex.Message;
            }
            return obj;
        }

        /// <summary>
        /// updates the subscription item i.e. plan on stripe in exiting subscription
        /// </summary>
        /// <param name="subscriptionItemId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public StatusMessage UpdateStripeSubscriptionItem(string subscriptionItemId, int quantity)
        {
            StatusMessage obj = new StatusMessage();
            try
            {
                StripeSubscriptionItemUpdateOptions item = new StripeSubscriptionItemUpdateOptions { Quantity = quantity };
                StripeSubscriptionItem subscriptionItem = new StripeSubscriptionItemService(StripeSecretKey).Update(subscriptionItemId, item);
                obj.IsSuccessful = true;
                obj.Message = subscriptionItem.Id;
                obj.responseObj = subscriptionItem;
            }
            catch (StripeException ex)
            {
                obj.IsSuccessful = false;
                obj.Message = ex.Message;
                obj.ErrorCode = (int)ex.HttpStatusCode;
                obj.responseObj = MapStripeError(ex.StripeError);
            }
            catch (Exception ex)
            {
                obj.IsSuccessful = false;
                obj.Message = ex.Message;
            }
            return obj;
        }

        /// <summary>
        /// gets the detail of subscription from stripe
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <returns></returns>
        public StatusMessage GetStripeSubscription(string subscriptionId)
        { 
             StatusMessage obj = new StatusMessage();
             try
             {
                 var subscriptionService = new StripeSubscriptionService(StripeSecretKey);
                 StripeSubscription custSub = subscriptionService.Get(subscriptionId);
               
                 obj.IsSuccessful = true;
                 obj.Message = custSub.Id;
                 StripeSubscriptionVM vm = MapStripeSubscription(custSub);
                 obj.responseObj = vm;
             }
             catch (StripeException ex)
             {
                 obj.IsSuccessful = false;
                 obj.Message = ex.Message;
                 obj.ErrorCode = (int)ex.HttpStatusCode;
                 obj.responseObj = MapStripeError(ex.StripeError);
             }
             catch (Exception ex)
             {
                 obj.IsSuccessful = false;
                 obj.Message = ex.Message;
             }
            return obj;
        }

        /// <summary>
        /// mapping stripe subscription to expandly subscription view model
        /// </summary>
        /// <param name="custSub"></param>
        /// <param name="CouponId"></param>
        /// <returns></returns>
        private static StripeSubscriptionVM MapStripeSubscription(StripeSubscription custSub, string CouponId = null)
        {
            StripeSubscriptionVM vm = new StripeSubscriptionVM();
            vm.ApplicationFeePercent = custSub.ApplicationFeePercent;
            vm.CancelAtPeriodEnd = custSub.CancelAtPeriodEnd;
            vm.CanceledAt = custSub.CanceledAt;
            vm.Created = custSub.Created;
            vm.CurrentPeriodEnd = custSub.CurrentPeriodEnd;
            vm.CurrentPeriodStart = custSub.CurrentPeriodStart;
            vm.CustomerId = custSub.CustomerId;
            vm.EndedAt = custSub.EndedAt;
            vm.Items = new List<StripeSubscriptionItemVM>();
            if (custSub.Items != null)
            {
                foreach (var s in custSub.Items.Data)
                {
                    StripeSubscriptionItemVM itemvm = new StripeSubscriptionItemVM
                    {
                        Created = s.Created,
                        Object = s.Object,
                        Quantity = s.Quantity,
                        StripeSubscriptionItemId = s.Id,
                        Plan = new StripePlanVM
                        {
                            Amount = Convert.ToDecimal(s.Plan.Amount) / 100,
                            Currency = s.Plan.Currency,
                            Interval = s.Plan.Interval,
                            Name = s.Plan.Name,
                            StatementDescriptor = s.Plan.StatementDescriptor,
                            StripePlanId = s.Plan.Id,
                            TrialPeriodDays = s.Plan.TrialPeriodDays
                        }
                    };
                    vm.Items.Add(itemvm);
                }
            }
            vm.Quantity = custSub.Quantity;
            vm.Status = custSub.Status;
            if (custSub.StripeDiscount != null)
            {
                vm.StripeDiscount = new StripeDiscountVM
                {
                    CustomerId = custSub.StripeDiscount.CustomerId,
                    End = custSub.StripeDiscount.End,
                    Object = custSub.StripeDiscount.Object,
                    SubscriptionId = custSub.StripeDiscount.SubscriptionId,
                    StripeDiscountId = custSub.StripeDiscount.Id
                };
            }
            if (custSub.StripePlan != null)
            {
                vm.StripePlan = new StripePlanVM
                {
                    Amount = Convert.ToDecimal(custSub.StripePlan.Amount)/100,
                    Currency = custSub.StripePlan.Currency,
                    Interval = custSub.StripePlan.Interval,
                    Name = custSub.StripePlan.Name,
                    StatementDescriptor = custSub.StripePlan.StatementDescriptor,
                    StripePlanId = custSub.StripePlan.Id,
                    TrialPeriodDays = custSub.StripePlan.TrialPeriodDays
                };
            }
            vm.SubscriptionId = custSub.Id;
            vm.TaxPercent =Convert.ToDecimal( custSub.TaxPercent);
            vm.TrialEnd = custSub.TrialEnd;
            vm.TrialStart = custSub.TrialStart;
            if (!string.IsNullOrEmpty(CouponId))
            {
                vm.CouponId = CouponId;
            }
            if (custSub.StripeDiscount != null)
            {
                vm.StripeDiscount = new StripeDiscountVM
                {
                    StripeCoupon = new StripeCouponVM
                    {
                        StripeCouponId = custSub.StripeDiscount.StripeCoupon.Id
                    }
                };
            }
            return vm;
        }

        /// <summary>
        /// process the payment immediate
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public StatusMessage ProcessPayment(StripeChargeVM model)
        {
            StatusMessage obj = new StatusMessage();
            try
            {
                var myCharge = new StripeChargeCreateOptions();

                // always set these properties
                // convert the amount of £12.50 to pennies i.e. 1250
                myCharge.Amount = (int)(model.Amount * 100);
                myCharge.Currency = model.Currency;

                // set this if you want to
                myCharge.Description = model.Description;

                myCharge.SourceCard = new SourceCard()
                {
                    Number = model.CardDetails.Number,
                    ExpirationYear = model.CardDetails.ExpirationYear,
                    ExpirationMonth = model.CardDetails.ExpirationMonth,
                    AddressCountry = model.CardDetails.AddressCountry,              // optional
                    AddressLine1 = model.CardDetails.AddressLine1,                  // optional
                    AddressLine2 = model.CardDetails.AddressLine2,                  // optional
                    AddressCity = model.CardDetails.AddressCity,                    // optional
                    AddressState = model.CardDetails.AddressState,                  // optional
                    AddressZip = model.CardDetails.AddressZip,                      // optional
                    Name = model.CardDetails.Name,                                  // optional
                    Cvc = model.CardDetails.Cvc                                     // optional
                };

                // set this property if using a customer
                myCharge.CustomerId = model.CustomerId;

                // set this if you have your own application fees (you must have your application configured first within Stripe)
                //myCharge.ApplicationFee = 25;

                // (not required) set this to false if you don't want to capture the charge yet - requires you call capture later
                myCharge.Capture = true;

                var chargeService = new StripeChargeService(StripeSecretKey);
                StripeCharge stripeCharge = chargeService.Create(myCharge);
                obj.IsSuccessful = true;
                obj.Message = stripeCharge.Id;
                obj.responseObj = stripeCharge;
            }
            catch (StripeException ex)
            {
                obj.IsSuccessful = false;
                obj.Message = ex.Message;
                obj.ErrorCode = (int)ex.HttpStatusCode;
                obj.responseObj = MapStripeError(ex.StripeError);
            }
            catch (Exception ex)
            {
                obj.IsSuccessful = false;
                obj.Message = ex.Message;
            }
            return obj;
        }

        /// <summary>
        /// capture the charge
        /// </summary>
        /// <param name="ChargeId"></param>
        /// <returns></returns>
        public StatusMessage CaptureCharge(string ChargeId)
        {
            StatusMessage obj = new StatusMessage();
            try
            {
                var chargeService = new StripeChargeService();
                StripeCharge stripeCharge = chargeService.Capture(ChargeId);
                obj.IsSuccessful = true;
                obj.Message = stripeCharge.Id;
                obj.responseObj = stripeCharge;
            }
            catch (StripeException ex)
            {
                obj.IsSuccessful = false;
                obj.Message = ex.Message;
                obj.ErrorCode = (int)ex.HttpStatusCode;
                obj.responseObj = MapStripeError(ex.StripeError);
            }
            catch (Exception ex)
            {
                obj.IsSuccessful = false;
                obj.Message = ex.Message;
            }
            return obj;
        }

        /// <summary>
        /// gets details of an existing charge
        /// </summary>
        /// <param name="ChargeId"></param>
        /// <returns></returns>
        public StatusMessage RetrieveCharge(string ChargeId)
        {
            StatusMessage obj = new StatusMessage();
            try
            {
                var chargeService = new StripeChargeService();
                StripeCharge stripeCharge = chargeService.Get(ChargeId);
                obj.IsSuccessful = true;
                obj.Message = stripeCharge.Id;
                obj.responseObj = stripeCharge;
            }
            catch (StripeException ex)
            {
                obj.IsSuccessful = false;
                obj.Message = ex.Message;
                obj.ErrorCode = (int)ex.HttpStatusCode;
                obj.responseObj = MapStripeError(ex.StripeError);
            }
            catch (Exception ex)
            {
                obj.IsSuccessful = false;
                obj.Message = ex.Message;
            }
            return obj;

        }

        /// <summary>
        /// get all invoices of a customer
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public StatusMessage GetAllInvoicesByCustomerId(string customerId, DateTime? StartDate, DateTime? EndDate)
        {
            StatusMessage obj = new StatusMessage();
            try
            {
                var invoiceService = new StripeInvoiceService(StripeSecretKey);
                StripeInvoiceListOptions options = new StripeInvoiceListOptions();
                if (!string.IsNullOrEmpty(customerId))
                {
                    options.CustomerId = customerId;
                }
                if (StartDate != null && EndDate != null)
                {
                    options.Date = new StripeDateFilter { GreaterThanOrEqual = StartDate, LessThanOrEqual = EndDate };
                }
                else if (StartDate != null)
                {
                    options.Date = new StripeDateFilter { GreaterThanOrEqual = StartDate };
                }
                else if (EndDate != null)
                {
                    options.Date = new StripeDateFilter { LessThanOrEqual = EndDate };
                }
                IEnumerable<StripeInvoice> response = invoiceService.List(options);
                obj.IsSuccessful = true;
                obj.Message = "success";
                obj.responseObj = response;
            }
            catch (StripeException ex)
            {
                obj.IsSuccessful = false;
                obj.Message = ex.Message;
                obj.ErrorCode = (int)ex.HttpStatusCode;
                obj.responseObj = MapStripeError(ex.StripeError);
            }
            catch (Exception ex)
            {
                obj.IsSuccessful = false;
                obj.Message = ex.Message;
            }
            return obj;
        }

        /// <summary>
        /// gets the details of coupon from stripe
        /// </summary>
        /// <param name="couponId"></param>
        /// <returns></returns>
        public StatusMessage GetStripeCoupon(string couponId)
        {
            StatusMessage obj = new StatusMessage();
            try
            {
                var couponService = new StripeCouponService(StripeSecretKey);
                StripeCoupon response = couponService.Get(couponId);
                if (response != null)
                {
                    StripeCouponVM _StripeCouponVM = MapStripeCoupon(response);
                    obj.IsSuccessful = true;
                    obj.Message = "Coupon applied successfully";
                    obj.responseObj = _StripeCouponVM;
                }
            }
            catch (StripeException ex)
            {
                obj.IsSuccessful = false;
                obj.Message = ex.Message;
                obj.ErrorCode = (int)ex.HttpStatusCode;
                obj.responseObj = MapStripeError(ex.StripeError);
            }
            catch (Exception ex)
            {
                obj.IsSuccessful = false;
                obj.Message = ex.Message;
            }
            return obj;
        }

        /// <summary>
        /// maps the stripe coupon to expandly coupon view model
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private static StripeCouponVM MapStripeCoupon(StripeCoupon response)
        {
            StripeCouponVM _StripeCouponVM = new StripeCouponVM();
            _StripeCouponVM.AmountOff = response.AmountOff / 100 ;
            _StripeCouponVM.Created = response.Created;
            _StripeCouponVM.Currency = response.Currency;
            _StripeCouponVM.Duration = response.Duration;
            _StripeCouponVM.DurationInMonths = response.DurationInMonths;
            _StripeCouponVM.LiveMode = response.LiveMode;
            _StripeCouponVM.MaxRedemptions = response.MaxRedemptions;
            _StripeCouponVM.Object = response.Object;
            _StripeCouponVM.PercentOff = response.PercentOff;
            _StripeCouponVM.RedeemBy = response.RedeemBy;
            _StripeCouponVM.StripeCouponId = response.Id;
            _StripeCouponVM.TimesRedeemed = response.TimesRedeemed;
            _StripeCouponVM.Valid = response.Valid;
            return _StripeCouponVM;
        }

        /// <summary>
        /// gets the details of order from stripe
        /// </summary>
        /// <param name="StripeOrderId"></param>
        /// <returns></returns>
        public StatusMessage GetStripeOrder(string StripeOrderId)
        {
            StatusMessage obj = new StatusMessage();
            try
            {
                var orderService = new StripeOrderService(StripeSecretKey);
                StripeOrder ord = orderService.Get(StripeOrderId);
                obj.IsSuccessful = true;
                obj.Message = ord.Id;
                StripeOrderVM vm = MapStripeOrder(ord);
                obj.responseObj = vm;
            }
            catch (StripeException ex)
            {
                obj.IsSuccessful = false;
                obj.Message = ex.Message;
                obj.ErrorCode = (int)ex.HttpStatusCode;
                obj.responseObj = MapStripeError(ex.StripeError);
            }
            catch (Exception ex)
            {
                obj.IsSuccessful = false;
                obj.Message = ex.Message;
            }
            return obj;
        }

        /// <summary>
        /// creates the order on stripe
        /// </summary>
        /// <param name="stripeCustomerId"></param>
        /// <param name="card"></param>
        /// <param name="currency"></param>
        /// <param name="products"></param>
        /// <param name="tax"></param>
        /// <returns></returns>
        public StatusMessage CreateStripeOrder(string stripeCustomerId, StripeCardDetailVM card, string currency, List<SelectedStripeProductVM> products, decimal? tax)
        {
            StatusMessage obj = new StatusMessage();
            try
            {
                var orderService = new StripeOrderService(StripeSecretKey);
                StripeOrderCreateOptions order = new StripeOrderCreateOptions();
                order.CustomerId = stripeCustomerId;
                order.Currency = currency;
                
                //if (!string.IsNullOrEmpty(card.CouponId))
                //{
                //    StatusMessage couponObj = GetStripeCoupon(card.CouponId);
                //    if (couponObj.IsSuccessful)
                //    {
                //        StripeCouponVM vmc = (StripeCouponVM)couponObj.responseObj;
                //        if (vmc.Valid)
                //        {
                //            order.Coupon = card.CouponId;
                //        }
                //    }
                //}
                order.Coupon = card.CouponId;
                order.Items = new List<StripeOrderItemOptions>();
                foreach (var pro in products)
                {
                    StripeOrderItemOptions options = new StripeOrderItemOptions();
                    options.Parent = pro.SKU;
                    options.Quantity = pro.Quantity;
                    order.Items.Add(options);
                }
                var Shipping = new StripeShippingOptions();
                Shipping.Name = card.Name;
                Shipping.PostalCode = card.AddressZip;
                Shipping.State = card.AddressState;
                Shipping.Country = card.AddressCountry;
                Shipping.CityOrTown = card.AddressCity;
                Shipping.Line1 = card.AddressLine1;
                Shipping.Line2 = card.AddressLine2;
                order.Shipping = Shipping;
              
                StripeOrder stripeOrder = orderService.Create(order);
                stripeOrder = orderService.Pay(stripeOrder.Id, new StripeOrderPayOptions { CustomerId = stripeCustomerId });
                obj.IsSuccessful = true;
                obj.Message = stripeOrder.Id;
                StripeOrderVM vm = MapStripeOrder(stripeOrder);
                vm.TaxRate = tax;
                obj.responseObj = vm;
            }
            catch (StripeException ex)
            {
                obj.IsSuccessful = false;
                obj.Message = ex.Message;
                obj.ErrorCode = (int)ex.HttpStatusCode;
                obj.responseObj = MapStripeError(ex.StripeError);
            }
            catch (Exception ex)
            {
                obj.IsSuccessful = false;
                obj.Message = ex.Message;
            }
            return obj;
        }

        /// <summary>
        /// create the invoice on stripe
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="subscriptionId"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public StatusMessage CreateInvoice(string customerId, string subscriptionId, string description)
        {
            StatusMessage obj = new StatusMessage();
            try
            {
                var invoiceService = new StripeInvoiceService(StripeSecretKey);
                StripeInvoice response = invoiceService.Create(customerId, new StripeInvoiceCreateOptions { SubscriptionId = subscriptionId, Description = description  });
                obj.IsSuccessful = true;
                obj.Message = response.Id;
                StripeInvoiceVM vm = MapStripeInvoice(response);
                obj.responseObj = vm;
            }
            catch (StripeException ex)
            {
                obj.IsSuccessful = false;
                obj.Message = ex.Message;
                obj.ErrorCode = (int)ex.HttpStatusCode;
                obj.responseObj = MapStripeError(ex.StripeError);
            }
            catch (Exception ex)
            {
                obj.IsSuccessful = false;
                obj.Message = ex.Message;
            }
            return obj;
        }

        /// <summary>
        /// makes the payment against a invoice
        /// </summary>
        /// <param name="invoiceId"></param>
        /// <returns></returns>
        public StatusMessage PayInvoice(string invoiceId)
        {
            StatusMessage obj = new StatusMessage();
            try
            {
                var invoiceService = new StripeInvoiceService(StripeSecretKey);
                StripeInvoice response = invoiceService.Pay(invoiceId);
                obj.IsSuccessful = true;
                obj.Message = response.Id;
                StripeInvoiceVM vm = MapStripeInvoice(response);
                obj.responseObj = vm;
            }
            catch (StripeException ex)
            {
                obj.IsSuccessful = false;
                obj.Message = ex.Message;
                obj.ErrorCode = (int)ex.HttpStatusCode;
                obj.responseObj = MapStripeError(ex.StripeError);
            }
            catch (Exception ex)
            {
                obj.IsSuccessful = false;
                obj.Message = ex.Message;
            }
            return obj;
        }

        /// <summary>
        /// processes the webhook send by stripe while creating a order to get the tax for the particular country
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public StatusMessage ProcessStripeOrderRequest(string json)
        {
            StatusMessage msg = new StatusMessage();
            try
            {
                var _stripeOrder = Stripe.Mapper<StripeOrder>.MapFromJson(json);
                StripeOrderVM mappedOrder = MapStripeOrder(_stripeOrder);
                msg.IsSuccessful = true;
                msg.responseObj = mappedOrder;
            }
            catch (Exception ex)
            {
                msg.IsSuccessful = false;
                msg.Message = ex.Message;
            }
            return msg;

        }

        /// <summary>
        /// processes the webhook send by stripe whenever an event occurs on stripe
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public StatusMessage ProcessWebhookRequest(string json)
        {
            StatusMessage obj = new StatusMessage();
            StripeWebhookVM webvm = new StripeWebhookVM();
            try
            {
                StripeEvent stripeEvent = StripeEventUtility.ParseEvent(json);
                switch (stripeEvent.Type)
                {
                    case StripeEvents.ChargeCaptured:
                        var ChargeCaptured = Stripe.Mapper<StripeCharge>.MapFromJson(stripeEvent.Data.Object.ToString());
                        StripeChargeWebhookVM vmcapt = MapStripeCharge(ChargeCaptured);
                        webvm.StripeChargeWebhookVM = vmcapt;
                        break;
                    case StripeEvents.ChargeFailed:
                        var ChargeFailed = Stripe.Mapper<StripeCharge>.MapFromJson(stripeEvent.Data.Object.ToString());
                        StripeChargeWebhookVM vmfail = MapStripeCharge(ChargeFailed);
                         webvm.StripeChargeWebhookVM = vmfail;
                        break;
                    case StripeEvents.ChargePending:
                        var ChargePending = Stripe.Mapper<StripeCharge>.MapFromJson(stripeEvent.Data.Object.ToString());
                        StripeChargeWebhookVM vmpend = MapStripeCharge(ChargePending);
                         webvm.StripeChargeWebhookVM = vmpend;
                        break;
                    case StripeEvents.ChargeSucceeded:
                        var ChargeSucceeded = Stripe.Mapper<StripeCharge>.MapFromJson(stripeEvent.Data.Object.ToString());
                        StripeChargeWebhookVM vmsucc = MapStripeCharge(ChargeSucceeded);
                         webvm.StripeChargeWebhookVM = vmsucc;
                        break;
                    case StripeEvents.ChargeUpdated:
                        var ChargeUpdated = Stripe.Mapper<StripeCharge>.MapFromJson(stripeEvent.Data.Object.ToString());
                        StripeChargeWebhookVM vmupd = MapStripeCharge(ChargeUpdated);
                         webvm.StripeChargeWebhookVM = vmupd;
                        break;
                    case StripeEvents.CustomerDeleted:
                        var CustomerDeleted = Stripe.Mapper<StripeCustomer>.MapFromJson(stripeEvent.Data.Object.ToString());
                        break;
                    case StripeEvents.CustomerSubscriptionCreated:
                        var CustomerSubscriptionCreated = Stripe.Mapper<StripeSubscription>.MapFromJson(stripeEvent.Data.Object.ToString());
                        break;
                    case StripeEvents.CustomerSubscriptionDeleted:
                        var CustomerSubscriptionDeleted = Stripe.Mapper<StripeSubscription>.MapFromJson(stripeEvent.Data.Object.ToString());
                        StripeSubscriptionVM subs = MapStripeSubscription(CustomerSubscriptionDeleted);
                        webvm.StripeSubscriptionVM = subs;
                        break;
                    case StripeEvents.CustomerSubscriptionUpdated:
                        var CustomerSubscriptionUpdated = Stripe.Mapper<StripeSubscription>.MapFromJson(stripeEvent.Data.Object.ToString());
                        StripeSubscriptionVM subupd = MapStripeSubscription(CustomerSubscriptionUpdated);
                        webvm.StripeSubscriptionVM = subupd;
                        break;
                    case StripeEvents.InvoiceCreated:
                        var InvoiceCreated = Stripe.Mapper<StripeInvoice>.MapFromJson(stripeEvent.Data.Object.ToString());
                        StripeInvoiceVM invoicevm = MapStripeInvoice(InvoiceCreated);
                        webvm.StripeInvoiceVM = invoicevm;
                        break;
                    case StripeEvents.InvoiceUpdated:
                        var InvoiceUpdated = Stripe.Mapper<StripeInvoice>.MapFromJson(stripeEvent.Data.Object.ToString());
                        StripeInvoiceVM invoicevmup = MapStripeInvoice(InvoiceUpdated);
                        webvm.StripeInvoiceVM = invoicevmup;
                        break;
                    case StripeEvents.OrderPaymentFailed:
                        var OrderPaymentFailed = Stripe.Mapper<StripeOrder>.MapFromJson(stripeEvent.Data.Object.ToString());
                        break;
                    case StripeEvents.OrderUpdated:
                        var OrderUpdated = Stripe.Mapper<StripeOrder>.MapFromJson(stripeEvent.Data.Object.ToString());
                        StripeOrderVM ordervm = MapStripeOrder(OrderUpdated);
                        webvm.StripeOrderVM = ordervm;
                        break;
                    case StripeEvents.OrderPaymentSucceeded:
                        var OrderPaymentSucceeded = Stripe.Mapper<StripeOrder>.MapFromJson(stripeEvent.Data.Object.ToString());
                        StripeOrderVM orderpay = MapStripeOrder(OrderPaymentSucceeded);
                        webvm.StripeOrderVM = orderpay;
                        break;
                    case StripeEvents.OrderReturnCreated:
                        var OrderReturnCreated = Stripe.Mapper<StripeOrder>.MapFromJson(stripeEvent.Data.Object.ToString());
                        break;
                }
                obj.IsSuccessful = true;
                obj.Message = "success";
                StripeEventVM vm = MapStripeEvent(stripeEvent);
                webvm.StripeEventVM = vm;
                obj.responseObj = webvm;
            }
            catch (StripeException ex)
            {
                obj.IsSuccessful = false;
                obj.Message = ex.Message;
                obj.ErrorCode = (int)ex.HttpStatusCode;
                obj.responseObj = MapStripeError(ex.StripeError);
            }
            catch (Exception ex)
            {
                obj.IsSuccessful = false;
                obj.Message = ex.Message;
            }
            return obj;
        }

        /// <summary>
        /// maps the stripe order to expandly order view model
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private static StripeOrderVM MapStripeOrder(StripeOrder response)
        {
            StripeOrderVM _StripeOrderVM = new StripeOrderVM();
            _StripeOrderVM.StripeOrderId = response.Id;
            _StripeOrderVM.Amount = Convert.ToDecimal(response.Amount) / 100;
            _StripeOrderVM.AmountReturned = Convert.ToDecimal(response.AmountReturned) / 100;
            _StripeOrderVM.Application = response.Application;
            _StripeOrderVM.ApplicationFee = response.ApplicationFee;
            _StripeOrderVM.ChargeId = response.ChargeId;
            _StripeOrderVM.Created = response.Created;
            _StripeOrderVM.Currency = response.Currency;
            _StripeOrderVM.CustomerId = response.CustomerId;
            _StripeOrderVM.Email = response.Email;
            _StripeOrderVM.ExternalCouponCode = response.ExternalCouponCode;
            _StripeOrderVM.LiveMode = response.LiveMode;
            _StripeOrderVM.OrderItems = response.OrderItems.Select(x => new StripeOrderItemVM
            {
                Amount = Convert.ToDecimal(x.Amount) / 100,
                Currency = x.Currency,
                Description = x.Description,
                Object = x.Object,
                Parent = x.Parent,
                Quantity = x.Quantity,
                Type = x.Type,
            }).ToList();
            _StripeOrderVM.Shipping = new StripeShippingVM();
            _StripeOrderVM.Shipping.Address = new StripeAddressVM();
            if (response.Shipping != null && response.Shipping.Address != null)
            {
                _StripeOrderVM.Shipping.Address.Country = response.Shipping.Address.Country;
            }
            _StripeOrderVM.SelectedShippingMethod = response.SelectedShippingMethod;
            _StripeOrderVM.Status = response.Status;
            _StripeOrderVM.Updated = response.Updated;
            _StripeOrderVM.UpstreamId = response.UpstreamId;
            return _StripeOrderVM;
        }

        /// <summary>
        /// maps the stripe error to expandly error view model
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private static StripeErrorVM MapStripeError(StripeError error)
        {
            StripeErrorVM vm = new StripeErrorVM();
            vm.ChargeId = error.ChargeId;
            vm.Code = error.Code;
            vm.DeclineCode = error.DeclineCode;
            vm.Error = error.Error;
            vm.ErrorDescription = error.ErrorDescription;
            vm.ErrorType = error.ErrorType;
            vm.Message = error.Message;
            vm.Parameter = error.Parameter;
            vm.StripeResponse = new StripeResponseVM
            {
                ObjectJson = error.StripeResponse.ObjectJson,
                RequestDate = error.StripeResponse.RequestDate,
                RequestId = error.StripeResponse.RequestId,
                ResponseJson = error.StripeResponse.ResponseJson,
            };
            return vm;
        }

        /// <summary>
        /// maps the stripe Event to expandly Event view model
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private StripeEventVM MapStripeEvent(StripeEvent ev)
        {

            StripeEventVM vm = new StripeEventVM();
            try
            {
                vm.Created = ev.Created;
                vm.Data = ev.Data.Object.ToString();
                vm.LiveMode = ev.LiveMode;
                vm.PendingWebhooks = ev.PendingWebhooks;
                vm.Request = ev.Request;
                vm.StripeEventId = ev.Id;
                vm.Type = ev.Type;
                vm.UserId = ev.UserId;
                return vm;
            }
            catch (Exception ex)
            {
                vm.Data = "Exception in mapping stripeEvent" + ex.Message;
                return vm;
            }
        }

        /// <summary>
        /// maps the stripe invoice to expandly invoice view model
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private StripeInvoiceVM MapStripeInvoice(StripeInvoice model)
        {
            StripeInvoiceVM vm = new StripeInvoiceVM();
            vm.AmountDue = Convert.ToDecimal(model.AmountDue) /100;
            vm.ApplicationFee = Convert.ToDecimal(model.AmountDue) / 100;
            vm.AttemptCount = model.AttemptCount;
            vm.Attempted = model.Attempted;
            vm.StripeChargeId = model.ChargeId;
            vm.Closed = model.Closed;
            vm.Currency = model.Currency;
            vm.CustomerId = model.CustomerId;
            vm.Date = model.Date;
            vm.Description = model.Description;
            vm.EndingBalance = Convert.ToDecimal(model.EndingBalance) /100;
            vm.Forgiven = model.Forgiven;
            vm.LiveMode = model.LiveMode;
           
            vm.NextPaymentAttempt = model.NextPaymentAttempt;
            vm.Object = model.Object;
            vm.Paid = model.Paid;
            vm.PeriodEnd = model.PeriodEnd;
            vm.PeriodStart = model.PeriodStart;
            vm.ReceiptNumber = model.ReceiptNumber;
            vm.StartingBalance = Convert.ToDecimal(model.StartingBalance) /100;
            vm.StatementDescriptor = model.StatementDescriptor;
            vm.SubscriptionId = model.SubscriptionId;
            if (model.StripeDiscount != null)
            {
                vm.StripeDiscount = new StripeDiscountVM();
                vm.StripeDiscount.CustomerId = model.StripeDiscount.CustomerId;
                vm.StripeDiscount.End = model.StripeDiscount.End;
                vm.StripeDiscount.Object = model.StripeDiscount.Object;
                vm.StripeDiscount.Start = model.StripeDiscount.Start;
                if (model.StripeDiscount.StripeCoupon != null)
                {
                    vm.StripeDiscount.StripeCoupon = new StripeCouponVM { StripeCouponId = model.StripeDiscount.StripeCoupon.Id };
                }
                vm.StripeDiscount.StripeDiscountId = model.StripeDiscount.Id;
                vm.StripeDiscount.SubscriptionId = model.SubscriptionId;
            }
            vm.StripeInvoiceId = model.Id;
            if (model.StripeInvoiceLineItems.Data.Count > 0)
            {
                vm.StripeInvoiceLineItems = model.StripeInvoiceLineItems.Data.Select(x => new StripeInvoiceLineItemVM
                {
                    StripeInvoiceLineItemId = x.Id,
                    LiveMode = x.LiveMode,
                    Amount = Convert.ToDecimal(x.Amount) / 100,
                    Currency = x.Currency,
                    CustomerId = x.CustomerId,
                    Date = x.Date,
                    Description = x.Description,
                    InvoiceId = x.InvoiceId,
                    Plan = new StripePlanVM { StripePlanId = x.Plan.Id },
                    Proration = x.Proration,
                    Quantity = x.Quantity,
                    SubscriptionId = x.SubscriptionId,
                    Type = x.Type,
                    StripePeriod = x.StripePeriod != null ? new StripePeriodVM { End = x.StripePeriod.End, Start = x.StripePeriod.Start } : null
                }).ToList();
            }
            vm.SubscriptionId = model.SubscriptionId;
            vm.Subtotal = Convert.ToDecimal(model.Subtotal) / 100;
            vm.Tax = Convert.ToDecimal(model.Tax)/100;
            vm.TaxPercent = Convert.ToDecimal(model.TaxPercent);
            vm.Total = Convert.ToDecimal(model.Total)/100;
            vm.WebhooksDeliveredAt = model.WebhooksDeliveredAt;

            return vm;
        }

        /// <summary>
        /// maps the stripe charge to expandly charge view model
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private StripeChargeWebhookVM MapStripeCharge(StripeCharge model)
        {
            StripeChargeWebhookVM vm = new StripeChargeWebhookVM();
            if (model.Source != null)
            {
                if (model.Source.Card != null)
                {
                    vm.StripeCardId = model.Source.Card.Id;
                    vm.AddressCity = model.Source.Card.AddressCity;
                    vm.AddressCountry = model.Source.Card.AddressCountry;
                    vm.AddressLine1 = model.Source.Card.AddressLine1;
                    vm.AddressLine2 = model.Source.Card.AddressLine2;
                    vm.AddressState = model.Source.Card.AddressState;
                    vm.AddressZip = model.Source.Card.AddressZip;
                    vm.Country = model.Source.Card.Country;
                    vm.CvcCheck = model.Source.Card.CvcCheck;
                    vm.DefaultForCurrency = model.Source.Card.DefaultForCurrency;
                    vm.DynamicLast4 = model.Source.Card.DynamicLast4;
                    vm.ExpirationMonth = model.Source.Card.ExpirationMonth;
                    vm.ExpirationYear = model.Source.Card.ExpirationYear;
                    vm.Fingerprint = model.Source.Card.Fingerprint;
                    vm.Last4 = model.Source.Card.Last4;
                    vm.Brand = model.Source.Card.Brand;
                }
            }

            vm.Amount = Convert.ToDecimal(model.Amount) / 100;
            vm.AmountRefunded =Convert.ToDecimal( model.AmountRefunded) / 100;
            vm.Captured = model.Captured;
            vm.Created = model.Created;
            vm.CustomerId = model.CustomerId;
            vm.Description = model.Description;
            vm.FailureCode = model.FailureCode;
            vm.FailureMessage = model.FailureMessage;
            vm.StripeInvoiceId = model.InvoiceId;
            vm.LiveMode = model.LiveMode;
            vm.StripeOrder = model.Order;
            vm.Paid = model.Paid;
            vm.ReceiptEmail = model.ReceiptEmail;
            vm.ReceiptNumber = model.ReceiptNumber;
            vm.Refunded = model.Refunded;
            vm.StatementDescriptor = model.StatementDescriptor;
            vm.Status = model.Status;
            vm.Currency = model.Currency;
            vm.StripeChargeId = model.Id;
            return vm;
        }

    }
}
