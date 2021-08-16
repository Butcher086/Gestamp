using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Gestamp.API.Models
{
    public class Sale
    {        
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Region { get; set; }        
        public string Country { get; set; }        
        public string ItemType { get; set; }        
        public string SalesChannel { get; set; }        
        public string OrderPriority { get; set; }        
        public string OrderDate { get; set; }        
        public int OrderID { get; set; }        
        public string ShipDate { get; set; }        
        public int UnitsSold { get; set; }        
        public double UnitPrice { get; set; }        
        public double UnitCost { get; set; }        
        public double TotalRevenue { get; set; }        
        public double TotalCost { get; set; }        
        public double TotalProfit { get; set; }
    }
}
