using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SimpleWord.Models;

namespace SimpleWord.DBContext;


public class SqliteDBContext : SimpleWordDbContext{

    


    public SqliteDBContext(DbContextOptions<SqliteDBContext> options) : base(options){
    }

    public SqliteDBContext() : base(){
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source=TestData/data.sqlite;");
    }




}