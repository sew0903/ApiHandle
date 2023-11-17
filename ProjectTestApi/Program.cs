var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//Add Memory Cache
builder.Services.AddMemoryCache();

builder.Services.AddAuthentication(Microsoft
    .AspNetCore
    .Authentication
    .Cookies
    .CookieAuthenticationDefaults
    .AuthenticationScheme)
       .AddCookie(options =>
       {
           options.LoginPath = "/Home/Index";
           options.AccessDeniedPath = "/Account/AccessDenied";
       });

//builder.Services.AddAuthentication().AddGoogle(googleOptions =>
//{
//    googleOptions.ClientId = builder.Configuration.GetSection("GoogleAuthSettings")
//.GetValue<string>("ClientId");
//    googleOptions.ClientSecret = builder.Configuration.GetSection("GoogleAuthSettings")
//.GetValue<string>("ClientSecret");
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePages(async context =>
{
    if (context.HttpContext.Response.StatusCode == StatusCodes.Status404NotFound)
    {
        context.HttpContext.Response.ContentType = "text/html";
        await context.HttpContext.Response.WriteAsync("<html><body><h1>Page Not Found</h1></body></html>");
    }
});
//app.UseExceptionHandler("/Home/Error");
//app.UseStatusCodePagesWithReExecute("/Home/Error/{0}");
//app.UseHsts();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
