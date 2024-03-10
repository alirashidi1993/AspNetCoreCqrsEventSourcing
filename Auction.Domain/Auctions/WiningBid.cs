namespace Auction.Domain.Auctions
{
    public class WiningBid
    {
        public WiningBid(Guid bidderId, long bidAmount)
        {
            BidderId = bidderId;
            Amount = bidAmount;
        }

        public Guid BidderId { get; }
        public long Amount { get; }
    }
}
