using AkademiQMongoDb.Services.About1Services;
using AkademiQMongoDb.Services.About2Services;
using AkademiQMongoDb.Services.FeatureServices;
using AkademiQMongoDb.Services.OrderServices;
using AkademiQMongoDb.Services.ProductServices;
using AkademiQMongoDb.Services.SssServices;
using AkademiQMongoDb.Services.StoryVideoServices;
using AkademiQMongoDb.Services.SubscriberServices;
using AkademiQMongoDb.Services.TestimonialServices;
using AkademiQMongoDb.Settings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IFeatureService, FeatureService>();
builder.Services.AddScoped<IAbout1Service, About1Service>();
builder.Services.AddScoped<IAbout2Service, About2Service>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IStoryVideoService, StoryVideoService>();
builder.Services.AddScoped<ITestimonialService, TestimonialService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ISubscriberServices, SubscriberService>();
builder.Services.AddScoped<ISssService, SssService>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettingsKey"));
builder.Services.AddScoped<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});

var app = builder.Build();

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
