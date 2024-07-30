namespace Catalog.Api.Exceptions;

/// <summary>
/// CatalogDomainException is used to indicate exceptions relevant to our domain. Domain exceptions are intercepted and handled by the <see cref="Filters.HttpGlobalExceptionFilter"/>.
/// </summary>
public class CatalogDomainException : Exception
{
    public CatalogDomainException()
    { }

    public CatalogDomainException(string message)
        : base(message)
    { }

    public CatalogDomainException(string message, Exception innerException)
        : base(message, innerException)
    { }
}
