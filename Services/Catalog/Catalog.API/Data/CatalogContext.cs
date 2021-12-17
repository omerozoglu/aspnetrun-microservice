using Catalog.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration confugration)
        {
            var client = new MongoClient(confugration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(confugration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Products = database.GetCollection<Product>(confugration.GetValue<string>("DatabaseSettings:CollectionName"));

            CatalogContextSeed.SeedData(Products);
        }
        public IMongoCollection<Product> Products { get; }
    }
}
