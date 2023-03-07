using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Rss_Reader_BackEnd.Context;
using Rss_Reader_BackEnd.Middlewares;
using Rss_Reader_BackEnd.Repositories;
using Rss_Reader_BackEnd.Repositories.Impl;
using Rss_Reader_BackEnd.Services;
using Rss_Reader_BackEnd.Services.Impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RepositoryContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("RssReaderConnection")));

builder.Services.AddScoped<IItemService,ItemService>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddAutoMapper(typeof(Program));

//builder.Services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        }));


builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);


var app = builder.Build();

app.UseCors("MyPolicy");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();