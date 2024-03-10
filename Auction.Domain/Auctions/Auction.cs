using Auction.Domain.Contracts.Auctions;
using Framework.Domain;

namespace Auction.Domain.Auctions
{
    public partial class Auction : AggregateRoot
    {
        private Auction() { }

        public Auction(Guid sellerId, long startingPrice,
            string product, DateTime endDate)
        {
            if (endDate < DateTime.Now) throw new Exception("end date cant be past");
            Causes(new AuctionOpened(Id, sellerId, startingPrice, product, endDate));
        }
        public Guid SellerId { get; private set; }
        public long StartingPrice { get; private set; }
        public string Product { get; private set; }
        public DateTime EndDate { get; private set; }
        public WiningBid WiningBid { get; private set; }

        public void PlaceBid(Guid bidderId, long amount)
        {
            var maxBid = StartingPrice;
            if (!FirstBid()) maxBid = WiningBid.Amount;

            if (maxBid >= amount) throw new Exception("Invalid amount");
            if (SellerId == bidderId) throw new Exception("Invalid Bidder");

            Causes(new BidPlaced(Id, amount, bidderId));
        }

        private bool FirstBid()
        {
            return WiningBid == null;
        }
    }


}
