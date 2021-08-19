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
        
        public async Task<List<Sale>> GetSales()
        {
            return await _sales.Find(sale => true).ToListAsync();            
        }

        public async Task<Sale> GetSale(string id)
        {
            return await _sales.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Sale>> GetSaleByItemType(string itemtype)
        {
            FilterDefinition<Sale> filter = Builders<Sale>.Filter.Eq(p => p.ItemType, itemtype);

            return await _sales.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Sale>> GetSaleByOrderDate(string orderdate)
        {
            FilterDefinition<Sale> filter = Builders<Sale>.Filter.Eq(p => p.OrderDate, orderdate);            
            return await _sales.Find(filter).ToListAsync();
        }

        public async Task CreateSale(Sale sale)
        {
            await _sales.InsertOneAsync(sale);
        }

        public async Task<bool> UpdateSale(Sale sale)
        {
            var result = await _sales.ReplaceOneAsync(filter: p => p.Id == sale.Id, replacement: sale);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public async Task<bool> DeleteSale(string id)
        {
            FilterDefinition<Sale> filter = Builders<Sale>.Filter.Eq(p => p.Id, id);

            DeleteResult result = await _sales.DeleteOneAsync(filter);

            return result.IsAcknowledged && result.DeletedCount > 0;
        }


    }
}
