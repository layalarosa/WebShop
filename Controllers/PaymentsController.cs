using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Stripe;
using Stripe.Checkout;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<PaymentsController> _logger;

        public PaymentsController(IConfiguration configuration, ShoppingCart shoppingCart, IOrderRepository orderRepository, ILogger<PaymentsController> logger)
        {
            _configuration = configuration;
            _shoppingCart = shoppingCart;
            _orderRepository = orderRepository;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult CreateCheckoutSession()
        {
            var secretKey = _configuration["Stripe:SecretKey"];
            if (string.IsNullOrEmpty(secretKey))
            {
                // Not configured yet
                return BadRequest("Stripe secret key is not configured. Set Stripe:SecretKey in configuration or environment.");
            }

            StripeConfiguration.ApiKey = secretKey;

            var items = _shoppingCart.GetShoppingCartItems();

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                Mode = "payment",
                SuccessUrl = Url.Action("CheckoutComplete", "Order", null, Request.Scheme) + "?session_id={CHECKOUT_SESSION_ID}",
                CancelUrl = Url.Action("Index", "ShoppingCart", null, Request.Scheme),
                LineItems = new List<SessionLineItemOptions>()
            };

            foreach (var line in items)
            {
                options.LineItems.Add(new SessionLineItemOptions
                {
                    Quantity = line.Amount,
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = (long)(line.Game.Price * 100),
                        Currency = "usd",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = line.Game.Name,
                        }
                    }
                });
            }

            var service = new SessionService();
            var session = service.Create(options);

            // At this point, you should create an Order in your system in Pending state and store session.Id in PaymentProviderId.
            // Do not mark the order as paid until receiving the webhook event confirming payment.

            return Redirect(session.Url);
        }

        [HttpPost]
        [Route("payments/webhook")]
        public async Task<IActionResult> Webhook()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
            var webhookSecret = _configuration["Stripe:WebhookSecret"];
            try
            {
                var stripeEvent = EventUtility.ConstructEvent(json, Request.Headers["Stripe-Signature"], webhookSecret);

                if (stripeEvent.Type == Events.CheckoutSessionCompleted)
                {
                    var session = stripeEvent.Data.Object as Session;
                    // TODO: find Order by session.Id stored in PaymentProviderId and mark as paid, then fulfill items (generate download tokens, decrement stock)
                    _logger.LogInformation("Stripe checkout session completed: {SessionId}", session.Id);
                }

                return Ok();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error processing Stripe webhook");
                return BadRequest();
            }
        }
    }
}
