# Dependency
 Created .net8

## Install
 Kurulum için bu kodu kullanın

  ```Csharp
  public class GetListExampleQuery : IRequest<GetListResponse<GetListExampleListItemDto>>,ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string CacheKey => $"GetListExampleQuery({PageRequest.PageIndex},{PageRequest.PageSize})";

    public bool ByPassCache { get; }

    public TimeSpan? SlidingExpiration { get; }

    public string CacheGroupKey => "GetListExamples";
}
 ```

 ```Csharp
 services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            configuration.AddOpenBehavior(typeof(CachingBehavior<,>));
        });
        return services;
 ```

 ```Csharp
 //install<PackageReference Include="Microsoft.Extensions.Caching.StackExchangeRedis" Version="8.0.5" />
 //kullanıma göre değişim yapılabilir
 builder.Services.AddDistributedMemoryCache(); //InMemory
 //builder.Services.AddStackExchangeRedisCache(opt=>opt.Configuration="localhost:6379");

            
 //appsettings
 //"CacheSettings": {
 //"SlidingExpiration": 2
 //},
 ```

 ```Csharp
  //cmd proje klasörü = docker run --name my-redis -p 6379:6379 -d redis
 ```

 ```Csharp
 // ICacheRemove
  public class CreateExampleCommand() :IRequest<CreatedExampleResponse>,ICacheRemoverRequest
{
    public string Name { get; set; }

    public string CacheKey => "";

    public bool ByPassCache => false;

    public string CacheGroupKey => "GetListExamples";
}
 ```

 ```Csharp
 services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            configuration.AddOpenBehavior(typeof(CachingBehavior<,>));
            configuration.AddOpenBehavior(typeof(CacheRemovingBehavior<,>));
        });
        return services;
 ```

 