namespace CachingBehavior;

public interface ICacheRemoverRequest
{
    string? CacheKey { get; }
    bool ByPassCache { get; }
    string? CacheGroupKey { get; }
}
