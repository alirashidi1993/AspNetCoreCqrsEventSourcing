namespace Auction.Domain.Auctions.Servicecs
{
    public interface IAuctionRepository
    {
        Task Create(Auction auction);
        Task Update(Auction auction);
        Task<Auction> GetById(Guid Id);
    }
}
