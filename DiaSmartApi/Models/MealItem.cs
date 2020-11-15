using System;

namespace DiaSmartApi.Models
{
    public class MealItem
    {
        public long Id { get; set; }
        public DayMeal Meal { get; set; }
        public DateTime MealTime { get; set; }
        public double Carbo { get; set; }
        public double Insulin { get; set; }
        public double GluLevel { get; set; }
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