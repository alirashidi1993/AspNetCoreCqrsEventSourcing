using Auction.Domain.Contracts.Auctions;
using Framework.Domain;

namespace Auction.Domain.Auctions
{
    public partial class Auction
    {
        public override void Apply(DomainEvent @event)
        {
            When((dynamic)@event);
        }
        public void When(BidPlaced @event)
        {
            WiningBid = new WiningBid(@event.BidderId, @event.Amount);
        }
        public void When(AuctionOpened @event)
        {
            Id = @event.Id;
            SellerId = @event.SellerId;
            StartingPrice = @event.StartingPrice;
            Product = @event.Product;
            EndDate = @event.EndDate;
        }
    }
}
