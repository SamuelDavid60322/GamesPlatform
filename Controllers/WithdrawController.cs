using Microsoft.AspNetCore.Mvc;
using PayoutsSdk.Payouts;
using PayoutsSdk.Core;
using PayPalHttp;
using Microsoft.AspNetCore.Authorization;
using GamesPlatform.Interfaces;
using GamesPlatform.Models;
using System.Security.Claims;
using System.Globalization;
using Azure.Core;
using PayPal.Api;
using HttpResponse = PayPalHttp.HttpResponse;

namespace GamesPlatform.Controllers
{
    [Authorize]
    public class WithdrawController : Controller
    {
        private readonly IWithdrawRepository _withdrawRepository;
        private readonly IWalletRepository _walletRepository;
        public WithdrawController(IWithdrawRepository withdrawRepository, IWalletRepository walletRepository)
        {
            _withdrawRepository = withdrawRepository;
            _walletRepository = walletRepository;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult Index(Withdraw withdrawMade)
        {
            string userID = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            decimal walletBalance = _walletRepository.GetBalance(userID);
            int walletId = _walletRepository.RetrieveWalletID(userID);
            if (walletId == 0)
            {
                ViewBag.ErrorMessage = "Add Some Funds to your account";
                return View();
            }
            withdrawMade.WalletID = walletId;
            if (withdrawMade.AmountTransfered < walletBalance && withdrawMade.AmountTransfered >= 5.00M)

            {
                string amountTransferred = withdrawMade.AmountTransfered.ToString();
                string email = withdrawMade.PayPalEmail;
                var response = CreatePayout(amountTransferred, email);
                HttpResponse createPayoutResponse = response.Result;
                var withdraw = createPayoutResponse.Result<CreatePayoutResponse>();
                withdrawMade.PayPalBatchID = withdraw.BatchHeader.PayoutBatchId;
                _walletRepository.SubtractFromWallet(userID, withdrawMade.AmountTransfered);
                _withdrawRepository.WithdrawMade(withdrawMade);
                ViewBag.SuccessMessage = "You have successfully transfered €" + amountTransferred + " to your PayPal account";

            }
            else
            {
                ViewBag.ErrorMessage = "We were unable to transfer funds into the PayPal account with the email provided. Do you have enough in your wallet?";
            }
            return View();
        }

        private static CreatePayoutRequest buildRequstbody(string amountTransferred, string email)
        {
            var request = new CreatePayoutRequest()
            {
                SenderBatchHeader = new SenderBatchHeader
                {
                    EmailMessage = "You have received a payout from Gamesino!: €" + amountTransferred,
                    EmailSubject = $"Gamesino Money Transferred Successfully!"
                },
                Items = new List<PayoutsSdk.Payouts.PayoutItem>(){
                    new PayoutsSdk.Payouts.PayoutItem(){
                        RecipientType="EMAIL",

                        Amount=new PayoutsSdk.Payouts.Currency(){
                            CurrencyCode="EUR",
                            Value=amountTransferred,
                         },
                        Receiver=email,

                    }
                }
            };
            return request;
        }


        public async static Task<HttpResponse> CreatePayout(string amountTransfered, string email)
        {
            Console.WriteLine("Creating payout with complete payload");

            try
            {
                PayoutsPostRequest request = new PayoutsPostRequest();
                request.RequestBody(buildRequstbody(amountTransfered, email));
                var response = await PayPalClient.client().Execute(request);
                var result = response.Result<CreatePayoutResponse>();
                return response;
            }
            catch (HttpException ex)
            {
                return null;
            }
        }
    }
}
