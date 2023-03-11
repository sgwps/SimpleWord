using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using SimpleWord.Models;

namespace SimpleWord.DBContext;



public class PostgreSQLContext : SimpleWordDbContext{



    public PostgreSQLContext(DbContextOptions<PostgreSQLContext> options) : base(options){
        Database.EnsureCreated();
    }

    public PostgreSQLContext() : base(){

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .EnableSensitiveDataLogging()
            .UseNpgsql(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING"));
            
    }


   

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        base.OnModelCreating(modelBuilder);

        // согласование таблиц и моделей
        modelBuilder.Entity<Collection>().ToTable("collections");
        modelBuilder.Entity<Card>().ToTable("cards");
        modelBuilder.Entity<Translation>().ToTable("translations");
        modelBuilder.Entity<Example>().ToTable("examples");

        // согласование связей между таблицами
        modelBuilder.Entity<Card>().HasOne(card => card.Collection).WithMany(collection => collection.Cards);
        modelBuilder.Entity<Translation>().HasOne(translation => translation.Card).WithMany(card => card.Translations);
        modelBuilder.Entity<Example>().HasOne(example => example.Translation).WithMany(translation => translation.Examples);

        // согласование первичных ключей
        modelBuilder.Entity<Collection>().HasKey(x => x.Id);
        modelBuilder.Entity<Card>().HasKey(x => x.Id);
        modelBuilder.Entity<Translation>().HasKey(x => x.Id);
        modelBuilder.Entity<Example>().HasKey(x => x.Id);


        //согласование свойств и столбцов
        modelBuilder.Entity<Collection>().Property(x => x.Id).HasColumnName("id");
        modelBuilder.Entity<Collection>().Property(x => x.SourceLanguage).HasColumnName("source_language");
        modelBuilder.Entity<Collection>().Property(x => x.DistanationLanguage).HasColumnName("destination_language");
        modelBuilder.Entity<Collection>().Property(x => x.Name).HasColumnName("title");
        modelBuilder.Entity<Collection>().Property(x => x.Description).HasColumnName("collection_description");
        modelBuilder.Entity<Collection>().Property(x => x.Author).HasColumnName("author");
        modelBuilder.Entity<Collection>().Property(x => x.LinkName).HasColumnName("link_name");

        modelBuilder.Entity<Card>().Property(x => x.Id).HasColumnName("id");
        modelBuilder.Entity<Card>().Property(x => x.Word).HasColumnName("word");
        modelBuilder.Entity<Card>().Property(x => x.Comment).HasColumnName("comment");
        modelBuilder.Entity<Card>().Property(x => x.CollectionId).HasColumnName("collection_id");

        modelBuilder.Entity<Translation>().Property(x => x.Id).HasColumnName("id");
        modelBuilder.Entity<Translation>().Property(x => x.Value).HasColumnName("translation_value");
        modelBuilder.Entity<Translation>().Property(x => x.Comment).HasColumnName("comment");
        modelBuilder.Entity<Translation>().Property(x => x.CardId).HasColumnName("card_id");

        modelBuilder.Entity<Example>().Property(x => x.Id).HasColumnName("id");
        modelBuilder.Entity<Example>().Property(x => x.TranslationId).HasColumnName("translation_id");
        modelBuilder.Entity<Example>().Property(x => x.Origin).HasColumnName("origin");
        modelBuilder.Entity<Example>().Property(x => x.ExampleTranslation).HasColumnName("example_translation");
        modelBuilder.Entity<Example>().Property(x => x.Comment).HasColumnName("comment");
        modelBuilder.Entity<Example>().Property(x => x.Source).HasColumnName("source");


        
    }

}