
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reprository.Core.Interfaces;
using Reprository.Core.Models;
using WAPIProject.DTO;

namespace WAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IUnitOfWorkRepository unitOfWorkRepository;
        public PaymentController(IUnitOfWorkRepository unitOfWorkRepository)
        {
            this.unitOfWorkRepository = unitOfWorkRepository;
        }

        [HttpPost("PaymentProcess")]
        public IActionResult PaymentProcess(string customerid)
        {

            if (ModelState.IsValid)
            {
                //ShoppingCart shoppingCart =await unitOfWorkRepository
                //    .ShoppingCart
                //    .FindAsync(s => s.CustomerId == customerid, new[] { "CartItems" });

                ShoppingCart shoppingCart =  unitOfWorkRepository
                    .ShoppingCart
                    .GetShoppingcart(customerid);
                double total = 0;
                foreach(var item in shoppingCart.CartItems)
                {
                    total += (double)item.MainProduct.PriceAfterDiscount;
                }

                Order order=new Order();
                order.CustomerId = customerid;
                order.OrderDate = DateTime.Now;
                order.TotalPrice = (decimal)total;//totalprice;
                order.shippingState = 0;
                order.ShoppingCartId = shoppingCart.Id;

                unitOfWorkRepository.Order.Add(order);

                shoppingCart.OrderId = order.Id;
                unitOfWorkRepository.ShoppingCart.Update(shoppingCart);

                Payment payment = new Payment();
                payment.CustomerId = customerid;
                payment.Amount = total;
                payment.PaymentMethod = 0;
                payment.PaymentDate=DateTime.Now;
                payment.OrderId = order.Id;

                unitOfWorkRepository.Payment.Add(payment);
                return new StatusCodeResult(StatusCodes.Status201Created);
            }
            return BadRequest(ModelState);
        }

        [HttpPost("ProfitCalculate")]
        public async Task<IActionResult> ProfitCalculate(string customerId)
        {
            if (ModelState.IsValid)
            {
                Admin admin=unitOfWorkRepository.Admin.GetAdmin();

                ShoppingCart shoppingCart = unitOfWorkRepository
                    .ShoppingCart
                    .GetShoppingcart(customerId);
                
                foreach (var item in shoppingCart.CartItems)
                {
                    Profit profit = new Profit();
                    profit.AdminId = admin.ApplicationUserId;
                    Vendor vendor= unitOfWorkRepository.CardItem.GetVendor(item.Id);
                    profit.VendorId = vendor.ApplicationUserId;
                    profit.MainProductId = item.MainProductId;
                    profit.ProfitDate = DateTime.Now;

                    CartItem cartitm =await unitOfWorkRepository.CardItem
                        .FindAsync(c => c.Id == item.Id, new[] { "MainProduct" });
                    double? price = cartitm.MainProduct.Price;
                    double? priceafterdiscount = cartitm.MainProduct.PriceAfterDiscount;

                    profit.AdminProfitValue = price.Value * 0.1;
                    admin.TotalProfit += profit.AdminProfitValue;

                    profit.VendorProfitValue = priceafterdiscount.Value - profit.AdminProfitValue;
                    vendor.TotalProfit += profit.VendorProfitValue;

                    unitOfWorkRepository.Profit.Add(profit);
                    unitOfWorkRepository.Admin.Update(admin);
                    unitOfWorkRepository.Vendor.Update(vendor);

                    MainProduct mainProduct = unitOfWorkRepository.Product.GetById(profit.MainProductId);
                    mainProduct.ProfitId = profit.Id;

                    unitOfWorkRepository.Product.Update(mainProduct);


                }
                return new StatusCodeResult(StatusCodes.Status201Created);



            }
            return BadRequest(ModelState);

        }
    }
}
