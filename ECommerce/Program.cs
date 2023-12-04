using ECommerce.Data;
using ECommerce.Services;
using ECommerce.Services.Data;
using Microsoft.EntityFrameworkCore;
using NToastNotify;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages()
                .AddNToastNotifyToastr(new ToastrOptions()
                {
                    TimeOut = 5000,
                    ProgressBar = true,
                    PositionClass = ToastPositions.BottomRight
                });

builder.Services.AddTransient<IDatasetService, DatasetService>();

builder.Services.AddDbContext<DatasetDbContext>();

builder.Services.AddScoped<IDatasetService, DatasetService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

var context = new DatasetDbContext();

using (var scope = app.Services.CreateScope())
{
    var datasetService = scope.ServiceProvider.GetRequiredService<IDatasetService>();
    datasetService.InitializeData();
}

context.Database.Migrate();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.UseNToastNotify();

app.Run();
