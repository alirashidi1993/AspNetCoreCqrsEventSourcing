using MediatR;

namespace Auction.Application.Contracts.Auctions
{
    public class OpenAuctionCommand : IRequest
    {
        public Guid SellerId { get; set; }
        public long StartingPrice { get; set; }
        public string Product { get; set; }
        public DateTime EndDate { get; set;}
    }
}
