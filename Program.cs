using factnet_back;
using factnet_back.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddCors(options =>
  {
    options.AddPolicy(
        "CorsPolicy",
        builder => builder.WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSqlServer<FacturationContext>("Data Source=DESKTOP-AGLEMT3;Initial Catalog=FacturationDB;user id=abcd;password=1234;Trusted_Connection=True;Persist Security Info=true;Trust Server Certificate=true");

builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IProveedorService, ProveedorService>();
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IFacturaService, FacturaService>();
builder.Services.AddScoped<IVentaService, VentaService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
//app.UseAuthorization();

app.MapControllers();

app.Run();
