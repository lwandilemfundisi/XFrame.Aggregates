﻿using XFrame.Aggregates.Events.AggregateEvents;
using XFrame.Ids;

namespace XFrame.Aggregates.Events
{
    public interface IDomainEventFactory
    {
        IDomainEvent Create(
            IAggregateEvent aggregateEvent,
            IMetadata metadata,
            string aggregateIdentity,
            int aggregateSequenceNumber);

        IDomainEvent<TAggregate, TIdentity> Create<TAggregate, TIdentity>(
            IAggregateEvent aggregateEvent,
            IMetadata metadata,
            TIdentity id,
            int aggregateSequenceNumber)
            where TAggregate : IAggregateRoot<TIdentity>
            where TIdentity : IIdentity;

        IDomainEvent<TAggregate, TIdentity> Upgrade<TAggregate, TIdentity>(
            IDomainEvent domainEvent,
            IAggregateEvent aggregateEvent)
            where TAggregate : IAggregateRoot<TIdentity>
            where TIdentity : IIdentity;
    }
}