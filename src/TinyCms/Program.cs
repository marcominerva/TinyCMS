using StorageProviders.AzureStorage;
using StorageProviders.FileSystem;
using TinyCms.BusinessLayer.Services;
using TinyCms.BusinessLayer.Services.Interfaces;
using TinyCms.DataAccessLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddSqlContext(options =>
{
    options.ConnectionString = builder.Configuration.GetConnectionString("SqlConnection");
});

builder.Services.AddScoped<IPageService, PageService>();

var azureStorageConnectionString = builder.Configuration.GetConnectionString("AzureStorage");
var storageFolder = builder.Configuration.GetValue<string>("AppSettings:StorageFolder");
if (!string.IsNullOrWhiteSpace(azureStorageConnectionString))
{
    builder.Services.AddAzureStorage(options =>
    {
        options.ConnectionString = azureStorageConnectionString;
        options.ContainerName = storageFolder;
    });
}
else
{
    builder.Services.AddFileSystemStorage(options =>
    {
        options.SiteRootFolder = builder.Environment.WebRootPath;
        options.StorageFolder = storageFolder;
    });
}

var app = builder.Build();
app.UseHttpsRedirection();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");

    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/Index/{0}");

app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();

app.Run();
