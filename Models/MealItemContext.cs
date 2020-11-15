using Microsoft.EntityFrameworkCore;

namespace DiaSmartApi.Models
{
    public class MealItemContext : DbContext
    {
        public MealItemContext(DbContextOptions<MealItemContext> options): base(options)
        {
        }

        public DbSet<MealItem> MealItems { get; set; }
        
    }
}