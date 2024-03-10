using Framework.Domain;

namespace Auction.Domain.Contracts.Auctions
{
    public class AuctionOpened : DomainEvent
    {

        public AuctionOpened(Guid id, Guid sellerId, long startingPrice, string product, DateTime endDate)
        {
            Id = id;
            SellerId = sellerId;
            StartingPrice = startingPrice;
            Product = product;
            EndDate = endDate;
        }

        public Guid Id { get; }
        public Guid SellerId { get; }
        public long StartingPrice { get; }
        public string Product { get; }
        public DateTime EndDate { get; }
    }
}
