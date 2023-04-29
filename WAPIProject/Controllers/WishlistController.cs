using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reprository.Core.Interfaces;
using Reprository.Core.Models;
using WAPIProject.DTO;

namespace WAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistController : ControllerBase
    {
        private readonly IUnitOfWorkRepository unitOfWorkRepository;
        public WishlistController(IUnitOfWorkRepository unitOfWorkRepository)
        {
            this.unitOfWorkRepository = unitOfWorkRepository;
        }

        [HttpGet("GetWishlist")]
        public IActionResult GetWishlist()
        {
            return Ok(unitOfWorkRepository.Wishlist.FindAll(new[] { "MainProduct" }));
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetWishlistbyID(int id)
        {

            return Ok(await unitOfWorkRepository.Wishlist.FindAsync(m => m.Id == id, new[] { "MainProduct" }));
        }

        [HttpPost("AddWishlist")]
        public async Task<IActionResult> AddWishlist(WishlistDTO NewWishcard)
        {

            if (ModelState.IsValid)
            {
                Wishlist wishlist = new Wishlist();
                wishlist.Product_Quantity = NewWishcard.Product_Quantity;
                wishlist.MainProductId= NewWishcard.MainProductId;
                wishlist.CustomerId = NewWishcard.CustomerId;

               await unitOfWorkRepository.Wishlist.AddAsync(wishlist);

                return new StatusCodeResult(StatusCodes.Status201Created);
            }
            return BadRequest(ModelState);

        }
    }
}
