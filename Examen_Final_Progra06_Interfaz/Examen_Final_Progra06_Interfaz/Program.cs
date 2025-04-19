using Examen_Final_Progra06_Interfaz.Servicios.Departments;
using Examen_Final_Progra06_Interfaz.Servicios.ProductReviews;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IsrvDepartments, srvDepartments>();
builder.Services.AddScoped<IsrvPReviews, srvPReviews>();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
