﻿using System.Data.Common;
using System.Reflection;
using Evently.Common.Infrastructure.Outbox;
using Evently.Modules.Ticketing.Application.Abstractions.Data;
using Evently.Modules.Ticketing.Domain.Customers;
using Evently.Modules.Ticketing.Domain.Events;
using Evently.Modules.Ticketing.Domain.Orders;
using Evently.Modules.Ticketing.Domain.Payments;
using Evently.Modules.Ticketing.Domain.Tickets;
using Evently.Modules.Ticketing.Infrastructure.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Evently.Modules.Ticketing.Infrastructure.Database;

public sealed class TicketingDbContext(DbContextOptions<TicketingDbContext> options)
	: DbContext(options), IUnitOfWork
{
	internal DbSet<Customer> Customers { get; set; }

	internal DbSet<Event> Events { get; set; }

	internal DbSet<TicketType> TicketTypes { get; set; }

	internal DbSet<Order> Orders { get; set; }

	internal DbSet<OrderItem> OrderItems { get; set; }

	internal DbSet<Ticket> Tickets { get; set; }

	internal DbSet<Payment> Payments { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.HasDefaultSchema(Schemas.Ticketing);

		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		
		modelBuilder.ApplyConfiguration(new OutboxMessageConfiguration());
		modelBuilder.ApplyConfiguration(new OutboxMessageConsumerConfiguration());
	}

	public async Task<DbTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
	{
		if (Database.CurrentTransaction is not null)
		{
			await Database.CurrentTransaction.DisposeAsync();
		}

		return (await Database.BeginTransactionAsync(cancellationToken)).GetDbTransaction();
	}
}
