var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add MailSettings configuration to the application so it can be injected 
builder.Services.Configure<ITCOnsultantWebsite.Models.MailSettings>(
    builder.Configuration.GetSection("MailSettings")
);

// Add SiteSettings configuration to the application so it can be injected
builder.Services.Configure<ITCOnsultantWebsite.Models.SiteSettings>(
    builder.Configuration.GetSection("SiteSettings")
);

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
