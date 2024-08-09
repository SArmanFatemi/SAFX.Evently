﻿using Evently.Common.Domain;
using Evently.Common.Domain.Errors;

namespace Evently.Modules.Ticketing.Application.Carts;

public static class CartErrors
{
    public static readonly Error Empty = Error.Problem("Carts.Empty", "The cart is empty");
}
