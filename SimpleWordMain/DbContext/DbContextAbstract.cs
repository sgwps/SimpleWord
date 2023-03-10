using Microsoft.EntityFrameworkCore;
using SimpleWordModels;

namespace SimpleWordAPI.DBContext;

public class SimpleWordDbContextAbstract : DbContext{
    public DbSet<Collection> Collections {get; set; } 
    public DbSet<Card> Cards {get; set; } 
    public DbSet<Translation> Translations {get; set; } 
    public DbSet<Example> Examples {get; set; } 
}