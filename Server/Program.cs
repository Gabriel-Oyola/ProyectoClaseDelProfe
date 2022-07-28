using MatriculaBD.Data;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;

//En esta Primera parte se va construir que va tener mi programa 
//En la variable builder vamos a tener los servios que estan cargados por origen 
//Y lo va poner dentro de una variable app 
var builder = WebApplication.CreateBuilder(args);
    //↓↓↓
    //Constructor de relaciones
// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
var conn = builder.Configuration.GetConnectionString("conn"); //Al builder le damos la instruccion que lea
                                                              //esta conexion de "conn"

//La conexion a la base de datos viene desde el appsettings.json

builder.Services.AddDbContext<BDContext1>(opciones => opciones.UseSqlServer(conn)); //Construye un servicio adicionandole el DbContext que va ser de tipo
                                                                                   //BDContext y le vamos a pasar el conexion string a traves de una opcion

var app = builder.Build();                                                                


//En esta segunda párte estaría la configuracion de la variable app 
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

//Aca se ejecuta el arranque de la aplicacion 
app.Run();
