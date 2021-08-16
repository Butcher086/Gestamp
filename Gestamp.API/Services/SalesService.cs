using Gestamp.API.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestamp.API.Services
{
    public class SalesService
    {
        private readonly IMongoCollection<Sale> _sales;

        public SalesService(IGestampDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _sales = database.GetCollection<Sale>(settings.SalesCollectionName);
        }
        
        public async Task<List<Sale>> Get()
        {
            var datasales = await _sales.FindAsync(sale => true);
            var result = _sales.Find(sale => true).ToList();
            return result;
        }

    }
}
