using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DiaSmartApi.Models
{
    public class MealItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    
        [BsonElement("Meal")]
        public DayMeal Meal { get; set; }

        [BsonElement("MealTime")]
        public DateTime MealTime { get; set; }

        [BsonElement("Carbo")]
        public double Carbo { get; set; }
        
        [BsonElement("Insulin")]
        public double Insulin { get; set; }
        
        [BsonElement("GluLevel")]
        public double GluLevel { get; set; }
        
        [BsonElement("Ratio")]
        public double Ratio { get; set; }
    }

    public enum DayMeal
    {
        Breakfast,
        Lunch,
        Dinner,
        Other
    }
}