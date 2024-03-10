using MediatR;

namespace Auction.Application.Contracts.Auctions
{
    public class PlaceBidCommand:IRequest
    {
        public Guid AuctionId { get; set; }
        public long Amount { get; set; }
        public Guid BidderId { get; set; }
    }
}
