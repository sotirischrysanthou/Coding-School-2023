using CarServiceCenter.EF.Repositories;
using CarServiceCenter.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IEntityRepo<Car>, CarRepo>();
builder.Services.AddScoped<IEntityRepo<Customer>, CustomerRepo>();
builder.Services.AddScoped<IEntityRepo<Engineer>, EngineerRepo>();
builder.Services.AddScoped<IEntityRepo<Manager>, ManagerRepo>();
builder.Services.AddScoped<IEntityRepo<ServiceTask>, MockServiceTaskRepo>();
builder.Services.AddScoped<IEntityRepo<TransactionLine>, MockTransactionLineRepo>();
builder.Services.AddScoped<IEntityRepo<Transaction>, MockTransactionRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
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
