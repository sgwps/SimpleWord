using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using SimpleWordModels;

namespace SimpleWordAPI.DBContext;

class SqliteDBContext : DbContext{

    public DbSet<Collection> Collections {get; set; } 
    public DbSet<Card> Cards {get; set; } 
    public DbSet<Translation> Translations {get; set; } 
    public DbSet<Example> Examples {get; set; } 


    public SqliteDBContext(DbContextOptions<SqliteDBContext> options) : base(options){
    }

    public SqliteDBContext() : base(){
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source=TestData/data.sqlite;");
    }



}