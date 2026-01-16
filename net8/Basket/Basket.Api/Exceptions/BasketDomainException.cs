namespace Basket.Api.Exceptions;

// Similar in function to the Catalog API's CatalogDomainException.
public class BasketDomainException : Exception
{
    public BasketDomainException()
    { }

    public BasketDomainException(string message)
        : base(message)
    { }

    public BasketDomainException(string message, Exception innerException)
        : base(message, innerException)
    { }
}
