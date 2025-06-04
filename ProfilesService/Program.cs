using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure database context
var connectionString = builder.Configuration.GetConnectionString("ProfilesContext");
builder.Services.AddDbContext<ProfilesService.Shared.Infrastructure.Persistence.EFC.Configuration.ProfilesContext>(
    options => options.UseMySQL(connectionString));

// Register repositories
builder.Services.AddScoped<ProfilesService.Domain.Repositories.ICustomerRepository, 
    ProfilesService.Infrastructure.Persistence.EFC.Repositories.CustomerRepository>();
builder.Services.AddScoped<ProfilesService.Domain.Repositories.IHotelRepository, 
    ProfilesService.Infrastructure.Persistence.EFC.Repositories.HotelRepository>();
builder.Services.AddScoped<ProfilesService.Domain.Repositories.IProviderRepository, 
    ProfilesService.Infrastructure.Persistence.EFC.Repositories.ProviderRepository>();

// Register Command Services
builder.Services.AddScoped<ProfilesService.Domain.Services.Customer.ICustomerCommandService, 
    ProfilesService.Application.Internal.CommandService.CustomerCommandService>();
builder.Services.AddScoped<ProfilesService.Domain.Services.Hotel.IHotelCommandService, 
    ProfilesService.Application.Internal.CommandService.HotelCommandService>();
builder.Services.AddScoped<ProfilesService.Domain.Services.Provider.IProviderCommandService, 
    ProfilesService.Application.Internal.CommandService.ProviderCommandService>();

// Register Query Services
builder.Services.AddScoped<ProfilesService.Domain.Services.Customer.ICustomerQueryService, 
    ProfilesService.Application.Internal.QueryService.CustomerQueryService>();
builder.Services.AddScoped<ProfilesService.Domain.Services.Hotel.IHotelQueryService, 
    ProfilesService.Application.Internal.QueryService.HotelQueryService>();
builder.Services.AddScoped<ProfilesService.Domain.Services.Provider.IProviderQueryService, 
    ProfilesService.Application.Internal.QueryService.ProviderQueryService>();

// Register Unit of Work if needed
builder.Services.AddScoped<ProfilesService.Shared.Domain.Repositories.IUnitOfWork, 
    ProfilesService.Shared.Infrastructure.Persistence.EFC.Repositories.UnitOfWork>();

var app = builder.Build();
// Add after var app = builder.Build(); but before app.UseSwagger()
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ProfilesService.Shared.Infrastructure.Persistence.EFC.Configuration.ProfilesContext>();
    dbContext.Database.EnsureCreated();
}
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