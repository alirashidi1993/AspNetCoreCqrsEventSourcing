using Auction.Application.Contracts.Auctions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auction.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionsController : ControllerBase
    {
        private readonly ISender sender;

        public AuctionsController(ISender sender)
        {
            this.sender = sender;
        }
        [HttpPost]
        public async Task<IActionResult> CreateAuction(OpenAuctionCommand command)
        {
            await sender.Send(command);
            return Ok();
        }
        [HttpPost("{auctionId}/bids")]
        public async Task<IActionResult> PlaceBid(PlaceBidCommand command)
        {
            await sender.Send(command);
            return Ok();
        }
    }
}
