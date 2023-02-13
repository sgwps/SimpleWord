using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using SimpleWordModels;

namespace SimpleWordAPI.DBContext;

class SqliteDBContext : DbContext{

    public DbSet<Collection> Collections {get; set; } = null!;


    public SqliteDBContext(DbContextOptions<SqliteDBContext> options) : base(options){
    }


}