using Microsoft.EntityFrameworkCore;
using TECH.Data.DatabaseEntity;
using TECH.Reponsitory;
using TECH.Service;
//using TECH.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc().AddJsonOptions(o =>
{
    o.JsonSerializerOptions.PropertyNamingPolicy = null;
    o.JsonSerializerOptions.DictionaryKeyPolicy = null;
});
builder.Services.AddControllers();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();

builder.Services.AddDbContext<DataBaseEntityContext>(options =>
{
    // Đọc chuỗi kết nối
    string connectstring = builder.Configuration.GetConnectionString("AppDbContext");
    options.UseSqlServer(connectstring);
});
builder.Services.AddScoped(typeof(IUnitOfWork), typeof(EFUnitOfWork));
builder.Services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));

builder.Services.AddScoped<IEmpRegisterRepository, EmpRegisterRepository>();

builder.Services.AddScoped<IEmpRegisterService, EmpRegisterService>();

//builder.Services.AddMemoryCache();

// Configure the HTTP request pipeline.
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "DangNhapEmploy",
      pattern: "/login-employ",
      defaults: new { controller = "Acount", action = "LoginEmployView" });
    endpoints.MapControllerRoute(
      name: "AboutUs",
      pattern: "/about-us",
      defaults: new { controller = "Home", action = "AboutUs" });
    endpoints.MapControllerRoute(
    name: "updateemployee",
    pattern: "/update-employee",
    defaults: new { controller = "Employee", action = "ViewEmployee" });

    endpoints.MapControllerRoute(
    name: "changepassword",
    pattern: "/change-password",
    defaults: new { controller = "Employee", action = "ChangePassWord" });

    endpoints.MapControllerRoute(
    name: "policydetails",
    pattern: "/policy-details",
    defaults: new { controller = "Home", action = "AboutUs" });

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");


});

app.Run();
