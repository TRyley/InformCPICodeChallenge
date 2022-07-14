using InformCPI.Server.BusinessLogic;
using InformCPI.Server.BusinessLogic.Interfaces;
using InformCPI.Server.IncomingPorts;
using InformCPI.Server.OutgoingPorts;
using InformCPI.Server.PrimaryAdapters;
using InformCPI.Server.SecondaryAdapters;

var builder = WebApplication.CreateBuilder(args);
var corsString = "myCorsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsString,
                      policy =>
                      {
                      policy
                          .AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IEditContactsLogic, EditContactsLogic>();
builder.Services.AddScoped<IGetContactsLogic, GetContactsLogic>();

builder.Services.AddScoped<IDatabaseReader, DatabaseAdapter>();
builder.Services.AddScoped<IDatabaseWriter, DatabaseAdapter>();

builder.Services.AddScoped<IEditContacts, ContactsAdapter>();
builder.Services.AddScoped<IGetContacts, ContactsAdapter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(corsString);

app.UseAuthorization();

app.MapControllers();

app.Run();
