using FluentValidation;
using MediatR;

namespace Evently.Modules.Events.Application.Events.CreateEvent;

public sealed record CreateEventCommand(
	string Title,
	string Description,
	string Location,
	DateTime StartAtUtc,
	DateTime? EndAtUtc) : IRequest<Guid>;

internal sealed class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
{
	public CreateEventCommandValidator()
	{
		RuleFor(c => c.Title).NotEmpty();
		RuleFor(c => c.Description).NotEmpty();
		RuleFor(c => c.Location).NotEmpty();
		RuleFor(c => c.StartAtUtc).NotEmpty();
		RuleFor(c => c.EndAtUtc).GreaterThanOrEqualTo(c => c.StartAtUtc).When(c => c.EndAtUtc.HasValue);
	}
}
