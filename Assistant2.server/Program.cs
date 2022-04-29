using Assistant2.Dao;
using Assistant2.Schedule;
using Assistant2.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AssistantDbContext>(
    options=>options.UseSqlite("Data Source=assistant.db"));
builder.Services.AddScoped<IAnnounceService, ChanifyService>();
// 定时任务
builder.Services.AddMagicScheduleJob();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
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