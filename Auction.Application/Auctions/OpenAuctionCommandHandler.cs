using Auction.Application.Contracts.Auctions;
using Auction.Domain.Auctions;
using Auction.Domain.Auctions.Servicecs;
using MediatR;

namespace Auction.Application.Auctions
{
    public class OpenAuctionCommandHandler : IRequestHandler<OpenAuctionCommand>
    {
        private readonly IAuctionRepository auctionRepository;

        public OpenAuctionCommandHandler(IAuctionRepository auctionRepository)
        {
            this.auctionRepository = auctionRepository;
        }
        public async Task Handle(OpenAuctionCommand request, CancellationToken cancellationToken)
        {
            var auction = new Domain.Auctions.Auction(
                request.SellerId,
                request.StartingPrice,
                request.Product,
                request.EndDate);

            await auctionRepository.Create(auction);
        }
    }
}
