namespace Panier.Core.Exceptions;

public class ShoppingCartEmptyException: Exception
{
    public ShoppingCartEmptyException(string? message) : base(message)
    {
    }
}