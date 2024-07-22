using Evently.Modules.Events.Application.Abstractions.Data;
using Evently.Modules.Events.Domain.Events;
using MediatR;

namespace Evently.Modules.Events.Application.Events.CreateEvent;

internal sealed class CreateEventCommandHandler(IUnitOfWork unitOfWork, IEventRepository eventRepository)
	: IRequestHandler<CreateEventCommand, Guid>
{
	public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
	{
		var @event = Event
			.Create(request.Title, request.Description, request.Location, request.StartAtUtc, request.EndAtUtc);

		eventRepository.Insert(@event);
		await unitOfWork.SaveChangesAsync(cancellationToken);

		return @event.Id;
	}
}
