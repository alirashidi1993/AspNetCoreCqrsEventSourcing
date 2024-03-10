using Auction.Domain.Auctions.Servicecs;
using Framework.Core;

namespace Auction.Infrastructure.Persistence.ES.Auctions
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly IEventSourceRepository<Domain.Auctions.Auction> eventSourceRepository;

        public AuctionRepository(IEventSourceRepository<Domain.Auctions.Auction> eventSourceRepository)
        {
            this.eventSourceRepository = eventSourceRepository;
        }
        public Task Create(Domain.Auctions.Auction auction)
        {
            return eventSourceRepository.AppendEvents(auction);
        }

        public Task<Domain.Auctions.Auction> GetById(Guid id)
        {
            return eventSourceRepository.GetById(id);
        }

        public Task Update(Domain.Auctions.Auction auction)
        {
            return eventSourceRepository.AppendEvents(auction);
        }
    }
}
