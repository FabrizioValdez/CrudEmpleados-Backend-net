using Microsoft.EntityFrameworkCore; // <--- NO OLVIDES ESTE USING
using WebApplication1; // <--- ASEGÚRATE QUE SEA EL NAMESPACE DE TU AppDbContext

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// --- AGREGA ESTO AQUÍ ---
// Esto le dice al sistema: "Cuando alguien pida un AppDbContext, dáselo usando SQL Server con esta cadena"
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQL")));
// ------------------------

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// En Program.cs, antes de var app = builder.Build();
builder.Services.AddCors(options => {
    options.AddPolicy("NuevaPolitica", app => {
        app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});


// JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])
        )
    };
});

// Authorization
builder.Services.AddAuthorization();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
// Después de app.UseHttpsRedirection();
app.UseCors("NuevaPolitica");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();



app.Run();