using Auction.Application.Auctions;
using Auction.Domain.Auctions.Servicecs;
using Auction.Domain.Contracts.Auctions;
using Auction.Infrastructure.Persistence.ES.Auctions;
using Autofac;
using EventStore.Client;
using Framework.Core;
using Framework.EventStore;
using Framework.Persistence.ES;
using MediatR.Extensions.Autofac.DependencyInjection;
using MediatR.Extensions.Autofac.DependencyInjection.Builder;

namespace Auction.Infrastructure.Config
{
    public class AuctionModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EventStoreDb>().As<IEventStore>().SingleInstance();
            builder.RegisterType<AuctionRepository>().As<IAuctionRepository>().SingleInstance();
            builder.RegisterType<AggregateFactory>().As<IAggregateFactory>().OwnedByLifetimeScope();
            builder.RegisterType<EventTypeResolver>().As<IEventTypeResolver>().SingleInstance()
                .OnActivated(a =>
                {
                    a.Instance.AddTypesFromAssembly(typeof(AuctionOpened).Assembly);
                });
            builder.Register((context) =>
            {
                var settings = EventStoreClientSettings.Create("esdb://eventstore:2113?tls=false");
                settings.OperationOptions.ThrowOnAppendFailure = false;
                var client = new EventStoreClient(settings);
                return client;

            }).SingleInstance();

            builder
                .RegisterGeneric(typeof(EventSourceRepository<>))
                .As(typeof(IEventSourceRepository<>)).SingleInstance();



            var configuration = MediatRConfigurationBuilder
             .Create(typeof(OpenAuctionCommandHandler).Assembly)
              .WithAllOpenGenericHandlerTypesRegistered()
               .WithRegistrationScope(RegistrationScope.Scoped)
                .Build();

            builder.RegisterMediatR(configuration);
        }
    }
}