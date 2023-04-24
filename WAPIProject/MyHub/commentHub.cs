using Microsoft.AspNetCore.SignalR;
using Reprository.Core.Interfaces;
using Reprository.Core.Models;
using Reprository.EF.Repositories;

namespace WAPIProject.MyHub
{
    public class commentHub:Hub
    {
        private readonly IUnitOfWorkRepository unitOfWorkRepository;

        public commentHub(IUnitOfWorkRepository _unitOfWorkRepository)
        {
            this.unitOfWorkRepository = unitOfWorkRepository;
        }
        public async Task SendMessage(string userId, string message ,int productID)
        {
            await Clients.All.SendAsync("ReceiveMessage", userId, message, productID);
            Review review = new Review();
            review.CustomerId = userId;
            review.Comment = message;
            review.CommentDate = DateTime.Now;
            review.MainProductId = productID;


            await unitOfWorkRepository.Review.AddAsync(review);           
        }
    }
}
