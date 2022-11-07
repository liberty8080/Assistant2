using Assistant2.Dao;
using Assistant2.Models;
using Assistant2.Schedule;
using Assistant2.Services;
using Assistant2.Services.Announce;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "Policy2",
        corsPolicyBuilder =>
        {
            corsPolicyBuilder
                .WithOrigins("http://localhost:5000")
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

builder.Services.AddDbContext<AssistantDbContext>(
    options => options.UseSqlite("Data Source=assistant.db"));
builder.Services.AddScoped<IAnnounceService, ChanifyService>();
builder.Services.AddScoped<ChanifyService>();
// 定时任务
builder.Services.AddMagicScheduleJob();

var app = builder.Build();
// Configure the HTTP request pipeline.
app.UseCors("Policy2");
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
// 迁移配置
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<AssistantDbContext>();
    context.Database.Migrate();
}

app.Run();