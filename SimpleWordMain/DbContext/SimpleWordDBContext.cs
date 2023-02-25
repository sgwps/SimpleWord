using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using SimpleWordModels;

namespace SimpleWordAPI.DBContext;



class SimpleWordDBContext : DbContext{
   // public DbSet<Word> Words {get; set; } 
    public DbSet<Collection> Collections {get; set; } 
    public DbSet<Example> Examples {get; set; } 
    public DbSet<Card> Cards {get; set; } 

    public DbSet<Translation> Translations {get; set; } 

    //public static SimpleWordDBContext context;

    public SimpleWordDBContext(DbContextOptions<SimpleWordDBContext> options) : base(options){
        Database.EnsureCreated();
        //context = this;
    }

    public SimpleWordDBContext() : base(){
        //context = this;

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
        //modelBuilder.Entity<Card>().HasOne(card => card.Collection).WithMany(collection => collection.Cards).HasForeignKey(card => card.CollectionForeignKey);
        //modelBuilder.Entity<Translation>().HasOne(translation => translation.Card).WithMany(card => card.Translations).HasForeignKey(translation => translation.CardForeignKey);
        //modelBuilder.Entity<Example>().HasOne(example => example.Translation).WithMany(translation => translation.Examples).HasForeignKey(example => example.TranslationForeignKey);

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
        //modelBuilder.Entity<Card>().Property(x => x.CollectionForeignKey).HasColumnName("collection_id");

        modelBuilder.Entity<Translation>().Property(x => x.Id).HasColumnName("id");
        modelBuilder.Entity<Translation>().Property(x => x.Value).HasColumnName("translation_value");
        modelBuilder.Entity<Translation>().Property(x => x.Comment).HasColumnName("comment");
        //modelBuilder.Entity<Translation>().Property(x => x.CardForeignKey).HasColumnName("card_id");

        modelBuilder.Entity<Example>().Property(x => x.Id).HasColumnName("id");
        //modelBuilder.Entity<Example>().Property(x => x.TranslationForeignKey).HasColumnName("translation_id");
        modelBuilder.Entity<Example>().Property(x => x.Origin).HasColumnName("origin");
        modelBuilder.Entity<Example>().Property(x => x.ExampleTranslation).HasColumnName("example_translation");
        modelBuilder.Entity<Example>().Property(x => x.Comment).HasColumnName("comment");
        modelBuilder.Entity<Example>().Property(x => x.Source).HasColumnName("source");


        
    }

}