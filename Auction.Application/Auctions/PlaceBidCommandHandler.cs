using Auction.Application.Contracts.Auctions;
using Auction.Domain.Auctions.Servicecs;
using MediatR;

namespace Auction.Application.Auctions
{
    public class PlaceBidCommandHandler : IRequestHandler<PlaceBidCommand>
    {
        private readonly IAuctionRepository auctionRepository;

        public PlaceBidCommandHandler(IAuctionRepository auctionRepository)
        {
            this.auctionRepository = auctionRepository;
        }
        public async Task Handle(PlaceBidCommand request, CancellationToken cancellationToken)
        {
            var auction = await auctionRepository.GetById(request.AuctionId);

            auction.PlaceBid(request.BidderId, request.Amount);

            await auctionRepository.Update(auction);
        }
    }
}
