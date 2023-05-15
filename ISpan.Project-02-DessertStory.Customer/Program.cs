using ISpan.Project_02_DessertStory.Customer.Models.ApiKey;
using ISpan.Project_02_DessertStory.Customer.Models.EF;
using ISpan.Project_02_DessertStory.Customer.Models.Repos;
using ISpan.Project_02_DessertStory.Customer.Models.Services;
using ISpan.Project_02_DessertStory.Customer.Models.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ISpan.Project_02_DessertStory.Customer.Hubs;
using System.Configuration;
using Microsoft.AspNetCore.Mvc;
using System;
using NuGet.Common;
using System.Text.Encodings.Web;
using System.Text.Unicode;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews()
    .AddSessionStateTempDataProvider();

builder.Services.AddDbContext<iSpanDessertShop2023MarchContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SweetStoryConnection")));

builder.Services.AddSignalR();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(60 * 60 * 24 * 7);
});

builder.Services.AddHttpContextAccessor();

builder.Services.AddTransient<ISellerProducts, SellerProductsRepository>();
builder.Services.AddTransient<SellerProductsService>();

builder.Services.Configure<TinyMCEConfiguration>(builder.Configuration.GetSection("TinyMCE"));
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddSingleton<HtmlEncoder>(
    HtmlEncoder.Create(allowedRanges: new[] {
        UnicodeRanges.BasicLatin, UnicodeRanges.CjkUnifiedIdeographs }));
builder.Services.AddScoped<ISellerService,SellerService>();

//send email
builder.Services.Configure<GmailApiConfig>(builder.Configuration.GetSection("GmailApiConfig"));
builder.Services.AddScoped<IEmailService, EmailService>();

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
app.UseSession();
app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    //app.MapControllerRoute(
    //    name: "authenticate",
    //    pattern: "authenticate/{token}",
    //    defaults: new { controller = "Sellerhome", action = "Authenticate" });

    app.MapControllerRoute(
    name: "default",
    //pattern: "{controller=Products}/{action=Index}/{id?}");
    //pattern: "{controller=StoreSetting}/{action=List}/{id=20000000}");
    pattern: "{controller=Home}/{action=Index}/{id?}");
    //pattern: "{controller=User}/{action=Register}/{id?}");
    endpoints.MapHub<ChatHub>("/chatHub");


});


app.Run();
