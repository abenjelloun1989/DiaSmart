namespace DiaSmartApi.Models
{
    public class MealItemsDatabaseSettings : IMealItemsDatabaseSettings
    {        
        public string MealItemsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    
    public interface IMealItemsDatabaseSettings
    {
        string MealItemsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}