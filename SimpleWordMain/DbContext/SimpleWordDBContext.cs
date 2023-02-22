using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using SimpleWordModels;

namespace SimpleWordAPI.DBContext;



class SimpleWordDBContext : DbContext{
   // public DbSet<Word> Words {get; set; } 
    public DbSet<Collection> Collections {get; set; } 
    public DbSet<Example> Examples {get; set; } 
    public DbSet<Card> Cards {get; set; } 

    public DbSet<Translation> Translations {get; set; } 


    public SimpleWordDBContext(DbContextOptions<SimpleWordDBContext> options) : base(options){
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder){
       /* modelBuilder.Entity<Word>()
            .HasOne(word => word.Collection)
            .WithMany(collection => collection.Words)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Example>()
            .HasOne(example => example.Word)
            .WithMany(word => word.Examples)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Collection>().HasIndex(collection => collection.ShortName).IsUnique();*/
    }

}