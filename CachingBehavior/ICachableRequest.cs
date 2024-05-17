namespace CachingBehavior;

public interface ICachableRequest
{
    string CacheKey { get; }
    bool ByPassCache { get; }
    string? CacheGroupKey { get; }
    TimeSpan? SlidingExpiration { get; }
}
