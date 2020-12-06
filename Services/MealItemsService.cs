using DiaSmartApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace DiaSmartApi.Services
{
    public class MealItemsService
    {
        private readonly IMongoCollection<MealItem> _mealItems;

        public MealItemsService(IMealItemsDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _mealItems = database.GetCollection<MealItem>(settings.MealItemsCollectionName);
        }

        public List<MealItem> Get() =>
            _mealItems.Find(mealItem => true).ToList();

        public MealItem Get(string id) =>
            _mealItems.Find<MealItem>(mealItem => mealItem.Id == id).FirstOrDefault();

        public MealItem Create(MealItem mealItem)
        {
            _mealItems.InsertOne(mealItem);
            return mealItem;
        }

        public void Update(string id, MealItem mealItemIn) =>
            _mealItems.ReplaceOne(mealItem => mealItem.Id == id, mealItemIn);

        public void Remove(MealItem mealItemIn) =>
            _mealItems.DeleteOne(mealItem => mealItem.Id == mealItemIn.Id);

        public void Remove(string id) => 
            _mealItems.DeleteOne(mealItem => mealItem.Id == id);
    }
}