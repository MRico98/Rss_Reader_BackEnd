using Microsoft.EntityFrameworkCore;
using Rss_Reader_BackEnd.Context;
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

builder.Services.AddDbContext<RepositoryContext>(o => o.UseInMemoryDatabase("rss_reader"));

builder.Services.AddScoped<IItemService,ItemService>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

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

app.Run();
