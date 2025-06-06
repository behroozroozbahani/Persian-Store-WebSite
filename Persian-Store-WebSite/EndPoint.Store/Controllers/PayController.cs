﻿using Dto.Payment;
using EndPoint.Site.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store_Website.Application.Services.Carts;
using Store_Website.Application.Services.Fainances.Commands.AddRequestPay;
using Store_Website.Application.Services.Fainances.Queries.GetRequestPayService;
using Store_Website.Application.Services.Orders.Commands.AddNewOrder;
using System;
using System.Threading.Tasks;
using ZarinPal.Class;

namespace EndPoint.Site.Controllers
{
    [Authorize]
    public class PayController : Controller
    {
        private readonly IAddRequestPayService _addRequestPayService;
        private readonly ICartService _cartService;
        private readonly CookiesManeger _cookiesManeger;
        private readonly Payment _payment;
        private readonly Authority _authority;
        private readonly Transactions _transactions;
        private readonly IGetRequestPayService _getRequestPayService;
        private readonly IAddNewOrderService _addNewOrderService;
        private readonly IConfiguration _configuration;

        private readonly string merchantId;

        public PayController(IConfiguration configuration,
            IAddRequestPayService addRequestPayService
            , ICartService cartService
            , IGetRequestPayService getRequestPayService
            , IAddNewOrderService addNewOrderService

             )
        {
            _addRequestPayService = addRequestPayService;
            _cartService = cartService;
            _cookiesManeger = new CookiesManeger();
            var expose = new Expose();
            _payment = expose.CreatePayment();
            _authority = expose.CreateAuthority();
            _transactions = expose.CreateTransactions();
            _getRequestPayService = getRequestPayService;
            _addNewOrderService = addNewOrderService;
            _configuration = configuration;
            merchantId = _configuration["ZarinpalMerchantId"];
        }
        public async Task<IActionResult> Index()
        {
            long? UserId = ClaimUtility.GetUserId(User);
            var cart = _cartService.GetMyCart(_cookiesManeger.GetBrowserId(HttpContext), UserId);
            if (cart.Data.SumAmount > 0)
            {
                var requestPay = _addRequestPayService.Execute(cart.Data.SumAmount, UserId.Value);
                // ارسال در گاه پرداخت

                var result = await _payment.Request(new DtoRequest()
                {
                    Mobile = "09121112222",
                    //CallbackUrl = $"https://localhost:7191/Pay/Verify?guid={requestPay.Data.guid}",
                    CallbackUrl = Url.Action(nameof(Verify), "pay", Request.Scheme),
                    Description = "پرداخت فاکتور شماره:" + requestPay.Data.RequestPayId,
                    Email = requestPay.Data.Email,
                    Amount = requestPay.Data.Amount,
                    MerchantId = merchantId
                }, Payment.Mode.sandbox);

                return Redirect($"https://sandbox.zarinpal.com/pg/StartPay/{result.Authority}");
            }
            else
            {
                return RedirectToAction("Index", "Cart");
            }
        }

        public async Task<IActionResult> Verify(Guid guid, string authority, string status)
        {
            var requestPay = _getRequestPayService.Execute(guid);

            var verification = await _payment.Verification(new DtoVerification
            {
                Amount = requestPay.Data.Amount,
                MerchantId = merchantId,
                Authority = authority
            }, Payment.Mode.sandbox);

            //var client = new RestClient("https://www.zarinpal.com/pg/rest/WebGate/PaymentVerification.json");
            //client.Timeout = -1;
            //var request = new RestRequest(Method.POST);
            //request.AddHeader("Content-Type", "application/json");
            //request.AddParameter("application/json", $"{{\"MerchantID\" :\"{merchendId}\",\"Authority\":\"{Authority}\",\"Amount\":\"{10000}\"}}", ParameterType.RequestBody);
            //IRestResponse response = client.Execute(request);
            //VerificationPayResultDto verification = JsonConvert.DeserializeObject<VerificationPayResultDto>(response.Content);
            long? UserId = ClaimUtility.GetUserId(User);
            var cart = _cartService.GetMyCart(_cookiesManeger.GetBrowserId(HttpContext), UserId);

            if (verification.Status == 100)
            {
                _addNewOrderService.Execute(new RequestAddNewOrderSericeDto
                {
                    CartId = cart.Data.CartId,
                    UserId = UserId.Value,
                    RequestPayId = requestPay.Data.Id
                });

                //redirect to orders
                return RedirectToAction("Index", "Orders");
            }
            else
            {

            }

            return View();
        }
    }

    public class VerificationPayResultDto
    {
        public int Status { get; set; }
        public long RefID { get; set; }
    }
}
