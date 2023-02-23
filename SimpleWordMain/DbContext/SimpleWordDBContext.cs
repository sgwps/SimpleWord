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
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Collection>().HasKey(x => x.Id);
        modelBuilder.Entity<Collection>().ToTable("collections");
        modelBuilder.Entity<Collection>().HasIndex(collection => collection.LinkName).IsUnique();
        modelBuilder.Entity<Collection>().HasIndex(Collection => Collection.LinkName).Required();
        modelBuilder.Entity<Collection>().Property(x => x.Id).HasColumnName("id");

        modelBuilder.Entity<Collection>().HasIndex(Collection => Collection.SourceLanguage).Required();
        modelBuilder.Entity<Collection>().Property(x => x.SourceLanguage).HasColumnName("source language");

        modelBuilder.Entity<Collection>().HasIndex(Collection => Collection.DistanationLanguage).Required;
        modelBuilder.Entity<Collection>().Property(x => x.DistanationLanguage).HasColumnName("distanation language");

        modelBuilder.Entity<Collection>().HasIndex(Collection => Collection.Name).Required;
        modelBuilder.Entity<Collection>().Property(x => x.Name).HasColumnName("name");

        modelBuilder.Entity<Collection>().Property(x => x.Description).HasColumnName("description");

        modelBuilder.Entity<Collection>().Property(x => x.Author).HasColumnName("author");

        modelBuilder.Entity<Collection>().HasIndex(Collection => Collection.LinkName).IsUnique();
        modelBuilder.Entity<Collection>().HasIndex(Collection => Collection.LinkName).Required();
        modelBuilder.Entity<Collection>().Property(x => x.LinkName).HasColumnName("limk name");

        // Card:
        modelBuilder.Entity<Card>().ToTable("Card");
        modelBuilder.Entity<Card>().HasKey(x => x.Id); // хз нужно или нет, что делает HasKey?

        modelBuilder.Entity<Card>().Property(x => x.Id).HasColumnName("Id");

        modelBuilder.Entity<Card>().HasIndex(Card => Card.Word).Required();
        modelBuilder.Entity<Card>().Property(x => x.Word).HasColumnName("word");

        modelBuilder.Entity<Card>().HasOne(Card => Card.Collection).WithMany(Collection => Collection.Cards).HasForeignKey(Card => Card.CollectionForeignKey);

        modelBuilder.Entity<Card>().Property(x => x.Comment).HasColumnName("comment");

        modelBuilder.Entity<Card>().Property(x => x.CollectionForeignKey).HasColumnName("collection foreign key");

        modelBuilder.Entity<Card>().HasOne(Card => Card.Translation).WithOne(Translation => Translation.Id).HasColumnName("id");
        modelBuilder.Entity<Card>().HasOne(Card => Card.Translation).WithOne(Translation => Translation.Value).HasColumnName("value");
        modelBuilder.Entity<Card>().HasOne(Card => Card.Translation).WithOne(Translation => Translation.Commetn).HasColumnName("comment");

        modelBuilder.Entity<Card>().HasOne(Card => Card.Translation).WithOne(Translation => Translation.Examples).HasOne(Translation => Translation.Example).WithOne(Example => Example.Id).HasIndex(Example => Example.Id).Required();
        modelBuilder.Entity<Card>().HasOne(Card => Card.Translation).WithOne(Translation => Translation.Examples).HasOne(Translation => Translation.Example).WithOne(Example => Example.Id).Property(x => x.Id).HasColumnName("Id");

        modelBuilder.Entity<Card>().HasOne(Card => Card.Translation).WithOne(Translation => Translation.Examples).HasOne(Translation => Translation.Example).WithOne(Example => Example.Origin).HasIndex(Example => Example.Origin).Required();
        modelBuilder.Entity<Card>().HasOne(Card => Card.Translation).WithOne(Translation => Translation.Examples).HasOne(Translation => Translation.Example).WithOne(Example => Example.Origin).Property(x => x.Origin).HasColumnName("Origin");

        modelBuilder.Entity<Card>().HasOne(Card => Card.Translation).WithOne(Translation => Translation.Examples).HasOne(Translation => Translation.Example).WithOne(Example => Example.ExampleTranslation).HasIndex(Example => Example.ExampleTranslation).Required();
        modelBuilder.Entity<Card>().HasOne(Card => Card.Translation).WithOne(Translation => Translation.Examples).HasOne(Translation => Translation.Example).WithOne(Example => Example.ExampleTranslation).Property(x => x.ExampleTranslation).HasColumnName("ExapleTranslation");

        modelBuilder.Entity<Card>().HasOne(Card => Card.Translation).WithOne(Translation => Translation.Examples).HasOne(Translation => Translation.Example).WithOne(Example => Example.Comment).Property(x => x.Comment).HasColumnName("Comment");

        modelBuilder.Entity<Card>().HasOne(Card => Card.Translation).WithOne(Translation => Translation.Examples).HasOne(Translation => Translation.Example).WithOne(Example => Example.Source).Property(x => x.Source).HasColumnName("Source");

        // Example:
        modelBuilder.Entity<Example>().HasIndex(Example => Example.Id).Required();
        modelBuilder.Entity<Example>().Property(x => x.Id).HasColumnName("Id");

        modelBuilder.Entity<Example>().HasIndex(Example => Example.Origin).Required();
        modelBuilder.Entity<Example>().Property(x => x.Origin).HasColumnName("Origin");

        modelBuilder.Entity<Example>().HasIndex(Example => Example.ExampleTranslation).Required();
        modelBuilder.Entity<Example>().Property(x => x.ExampleTranslation).HasColumnName("Example Translation");

        modelBuilder.Entity<Example>().Property(x => x.Comment).HasColumnName("Comment");

        modelBuilder.Entity<Example>().Property(x => x.Source).HasColumnName("Source");

        // Translation:
        modelBuilder.Entity<Translation>().Property(x => x.Id).HasColumnName("Id");

        modelBuilder.Entity<Translation>().HasIndex(Translation => Translation.Value).Required();
        modelBuilder.Entity<Translation>().Property(x => x.Value).HasColumnName("Value");

        modelBuilder.Entity<Translation>().Property(x => x.Comment).HasColumnName("Comment");

        // Card in Translation:
        modelBuilder.Entity<Translation>().HasOne(Translation => Translation.Card).WithOne(Card => Card.Id).Property(x => x.Id).HasColumnName("Id");

        modelBuilder.Entity<Translation>().HasOne(Translation => Translation.Card).WithOne(Card => Card.Word).HasIndex(Card => Card.Word).Required();
        modelBuilder.Entity<Translation>().HasOne(Translation => Translation.Card).WithOne(Card => Card.Word).Property(x => x.Word).HasColumnName("Word");
        
        modelBuilder.Entity<Translation>().HasOne(Translation => Translation.Card).WithOne(Card => Card.Comment).Property(x => x.Comment).HasColumnName("Comment");

        // Example in Translation:
        modelBuilder.Entity<Translation>().HasMany(Translation => Translation.Examples).WithOne(Example => Example.Id).HasIndex(Example => Example.Id).Required();
        modelBuilder.Entity<Translation>().HasMany(Translation => Translation.Examples).WithOne(Example => Example.Id).Property(x => x.Id).HasColumnName("Id");

        modelBuilder.Entity<Translation>().HasMany(Translation => Translation.Examples).WithOne(Example => Example.Origin).HasIndex(Example => Example.Origin).Required();
        modelBuilder.Entity<Translation>().HasMany(Translation => Translation.Examples).WithOne(Example => Example.Origin).Property(x => x.Origin).HasColumnName("Origin");

        modelBuilder.Entity<Translation>().HasMany(Translation => Translation.Examples).WithOne(Example => Example.ExampleTranslation).HasIndex(Example => Example.ExampleTranslation).Required();
        modelBuilder.Entity<Translation>().HasMany(Translation => Translation.Examples).WithOne(Example => Example.ExampleTranslation).Property(x => x.ExampleTranslation).HasColumnName("Example Translation");

        modelBuilder.Entity<Translation>().HasMany(Translation => Translation.Examples).WithOne(Example => Example.Comment).Property(x => x.Comment).HasColumnName("Comment");

        modelBuilder.Entity<Translation>().HasMany(Translation => Translation.Examples).WithOne(Example => Example.Source).Property(x => x.Source).HasColumnName("Source");


        //  согласовать классы и таблицы
        // согласовать свойства и столбцы
        // поставить ограничения: required

        


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