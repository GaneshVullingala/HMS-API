using EcommerceApi.Data;
using EcommerceApi.Interfaces;
using EcommerceApi.Mappings;
using EcommerceApi.Models;
using EcommerceApi.Repositories;
using EcommerceApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var passwordHasher = new PasswordHasher<LoginInfo>();

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaulConnection")));
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IFrontDeskService, FrontDeskService>();
builder.Services.AddScoped<IFrontDeskRepository, FrontDeskRepository>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IGeneralRepostiory, GeneralRepostiory>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddAutoMapper(typeof(MappingProfile));


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
            ValidAudience = builder.Configuration["JwtSettings:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]))
        };
    });
builder.Services.AddAuthorization();
var app = builder.Build();


app.UseHttpsRedirection();
app.UseStaticFiles(); // <--- Enables wwwroot by default
// ✅ Add this section to serve /Uploads folder
var uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
if (!Directory.Exists(uploadsPath))
{
    Directory.CreateDirectory(uploadsPath);
}

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(uploadsPath),
    RequestPath = "/Uploads"
});

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ecommerce API V1");
    
});

app.UseCors("AllowAll");

app.UseDeveloperExceptionPage();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

//using (var scope = app.Services.CreateScope())
//{
//    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

//    // Ensure DB is created
//    db.Database.EnsureCreated();

//    // Check if admin already exists
//    if (!db.tblLoginInfo.Any(u => u.Role == "Admin"))
//    {
//        var GaneralinfoEntity = new GeneralInfo()
//        {
//            Roleid = 1,
//            FullName = "Admin",
//            Status = "Active",
//            CreatedOn = DateTime.Now
//        };
//        db.tblGeneralInfo.Add(GaneralinfoEntity);
//        db.SaveChanges();

//        var LoginInfoEntity = new LoginInfo()
//        {
//            Genid = GaneralinfoEntity.Genid,
//            Role = "Admin",
//            Phone = "9999999999",
//            Email = "admin@gmail.com",
//            Username = "Admin",
//            Password = passwordHasher.HashPassword(null, "Admin@123")
//        };
       
//        db.tblLoginInfo.Add(LoginInfoEntity);
//        db.SaveChanges();
//    }
//}


app.Run();
