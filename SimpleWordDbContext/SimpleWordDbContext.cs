using Microsoft.EntityFrameworkCore;
using SimpleWord.Models;

namespace SimpleWord.DBContext;

public abstract class SimpleWordDbContext: DbContext{
    public DbSet<Collection> Collections {get; set; } 
    public DbSet<Card> Cards {get; set; } 
    public DbSet<Translation> Translations {get; set; } 
    public DbSet<Example> Examples {get; set; } 


    public SimpleWordDbContext() : base(){

    }

    public SimpleWordDbContext(DbContextOptions options) : base(options){

    } 
}