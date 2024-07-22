using Evently.Modules.Events.Domain.Abstractions.Errors;

namespace Evently.Modules.Events.Domain.Categories;

public static class CategoryErrors
{
	public static Error NotFound(Guid categoryId) =>
		Error.NotFound("Categories.NotFound", $"The category with the identifier {categoryId} was not found");

	public static Error AlreadyArchived =>
		Error.Problem("Categories.AlreadyArchived", "The category was already archived");
}
