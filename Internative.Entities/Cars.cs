using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Internative.Entities
{
    public class Cars
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Brand")]
        [JsonProperty("Brand")]
        public string Brand { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
