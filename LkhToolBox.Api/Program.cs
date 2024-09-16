using Asp.Versioning;
using LkhToolBox.Application;
using LkhToolBox.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddApplication()
    .AddInfrastructure(builder.Configuration.GetConnectionString("SqlServer")!);

//添加版本控制
builder.Services.AddApiVersioning(x =>
{
    x.DefaultApiVersion = new Asp.Versioning.ApiVersion(1, 0);
    x.AssumeDefaultVersionWhenUnspecified = true;
    x.ReportApiVersions = true;
    x.ApiVersionReader = new MediaTypeApiVersionReader("api-version");
})
    .AddMvc();

//添加AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

