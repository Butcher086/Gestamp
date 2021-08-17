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
        [BsonElement("Item Type")]
        public string ItemType { get; set; }
        [BsonElement("Sales Channel")]
        public string SalesChannel { get; set; }
        [BsonElement("Order Priority")]
        public string OrderPriority { get; set; }
        [BsonElement("Order Date")]
        public string OrderDate { get; set; }
        [BsonElement("Order ID")]
        public int OrderID { get; set; }
        [BsonElement("Ship Date")]
        public string ShipDate { get; set; }
        [BsonElement("Units Sold")]
        public int UnitsSold { get; set; }
        [BsonElement("Unit Price")]
        public double UnitPrice { get; set; }
        [BsonElement("Unit Cost")]
        public double UnitCost { get; set; }
        [BsonElement("Total Revenue")]
        public double TotalRevenue { get; set; }
        [BsonElement("Total Cost")]
        public double TotalCost { get; set; }
        [BsonElement("Total Profit")]
        public double TotalProfit { get; set; }
    }
}
