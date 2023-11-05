using Persistance.Context;
using Application.Services;
using Application.Mapping;
using Application.Interfaces;
using Persistance.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DriverContext>();
builder.Services.AddHttpClient();
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
builder.Services.AddApplicationServices();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(ICourseRepository), typeof(EfCourseRepository));

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error/Index");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePages();
app.UseStatusCodePagesWithRedirects("/Error/Index/");
app.UseExceptionHandler("/Error/Index");
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
