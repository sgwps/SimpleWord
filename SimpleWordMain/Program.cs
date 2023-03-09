using SimpleWordAPI.DBContext;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddDbContext<SimpleWordDBContext>(options => builder.Configuration.GetConnectionString("Sqlite"));
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddScoped<SimpleWordDBContext>( );
var app = builder.Build();
// ContextStaticClass._context = app.Services.GetService<SimpleWordDBContext>();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
