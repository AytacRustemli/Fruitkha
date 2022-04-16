using DataAccess;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Services.Abstract;
using Services.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectingString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<FruitkhaDbContext>
    (options => options.UseSqlServer(connectingString));




builder.Services.AddDefaultIdentity<User>().AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<FruitkhaDbContext>();



builder.Services.AddScoped<ICategoryManager, CategoryManager>();
builder.Services.AddScoped<IProductManager, ProductManager>();
builder.Services.AddScoped<INewManager, NewManager>();
builder.Services.AddScoped<IOrganicManager, OrganicManager>();
builder.Services.AddScoped<IFreeManager,FreeManager>();
builder.Services.AddScoped<IDealManager, DealManager>();
builder.Services.AddScoped<IOwnerManager, OwnerManager>();
builder.Services.AddScoped<ISaleManager, SaleManager>();
builder.Services.AddScoped<ICommentManager, CommentManager>();
builder.Services.AddScoped<ISinceManager, SinceManager>();
builder.Services.AddScoped<IPhotoManager, PhotoManager>();


builder.Services.ConfigureApplicationCookie(option =>
{
    option.LoginPath = "/admin/auth/login";
    option.AccessDeniedPath = "/admin/auth/login";
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

app.UseAuthentication();

app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
