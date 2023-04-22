using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reprository.Core.Interfaces;
using Reprository.Core.Models;
using System.Net.Sockets;
using System.Security.Claims;
using WAPIProject.DTO;

namespace WAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardItemController : ControllerBase
    {
        private readonly IUnitOfWorkRepository unitOfWorkRepository;
        public CardItemController(IUnitOfWorkRepository unitOfWorkRepository)
        {
            this.unitOfWorkRepository = unitOfWorkRepository;
        }

        [HttpPost("AddCardItem")]
        public async Task<IActionResult> AddCardItem(CardItemDTO cardItem)
        {

            if (ModelState.IsValid)
            {
                var shoppingCart = await unitOfWorkRepository.ShoppingCart.FindAsync(e => e.CustomerId == cardItem.customerId);
                CartItem item = new CartItem();
                item.Product_Quantity = cardItem.Product_Quantity;
                item.MainProductId = cardItem.MainProductId;
                item.ShoppingCartId = shoppingCart.Id;

                await unitOfWorkRepository.CardItem.AddAsync(item);

                return new StatusCodeResult(StatusCodes.Status201Created);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("Getlistofcard")]
        public async Task<IActionResult> GetlistofCards(string CustomerID)
        {
            var shoping = await unitOfWorkRepository.ShoppingCart.FindAsync(e => e.CustomerId == CustomerID,new[]{"CartItems"});
            List<CartItem> cartItems= shoping.CartItems.ToList();
            return Ok(cartItems);
        }
    }
    }
