using Framework.Domain;

namespace Auction.Domain.Contracts.Auctions
{
    public class BidPlaced : DomainEvent
    {
        public BidPlaced(Guid auctionId, long amount, Guid bidderId)
        {
            AuctionId = auctionId;
            Amount = amount;
            BidderId = bidderId;
        }

        public Guid AuctionId { get; }
        public long Amount { get; }
        public Guid BidderId { get; }
    }
}
