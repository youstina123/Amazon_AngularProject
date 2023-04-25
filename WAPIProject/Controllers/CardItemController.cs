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
                ShoppingCart shoppingCart = await unitOfWorkRepository
                    .ShoppingCart
                    .FindAsync(s => s.CustomerId == cardItem.customerId,null);
                CartItem item = new CartItem();
                item.Product_Quantity = cardItem.Product_Quantity;
                item.MainProductId = cardItem.MainProductId;
                item.ShoppingCartId = shoppingCart.Id;

                await unitOfWorkRepository.CardItem.AddAsync(item);

                MainProduct mainProduct = unitOfWorkRepository.Product.GetById(cardItem.MainProductId);
                mainProduct.CartItemId = item.Id;

                unitOfWorkRepository.Product.Update(mainProduct);
                return new StatusCodeResult(StatusCodes.Status201Created);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("Getlistofcard")]
        public async Task<IActionResult> GetlistofCardsAsync(string CustomerID)
        {
            int id=unitOfWorkRepository.ShoppingCart.GetCustomerID(CustomerID);

            return Ok(unitOfWorkRepository
                .CardItem
                .FindAll(c => c.ShoppingCartId == id));
        }
    }
    }
