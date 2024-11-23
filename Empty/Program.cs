using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Reflection.Metadata;

namespace Empty
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Web uygulaman�z� ba�latmak ve uygulama i�in gerekli ayarlar� ve yap�land�rmalar� y�netir.
            var builder = WebApplication.CreateBuilder(args);

            
            builder.Services.AddControllersWithViews();//MVC mimarisini kullanarak hem Controller hem de View deste�ini eklemesini sa�lar.


            var app = builder.Build(); // Uygulama yap�land�rmas�n� tamamlar ve uygulama nesnesini (app) olu�turur

           
            if (!app.Environment.IsDevelopment()) // Uygulaman�n geli�tirme ortam�nda olup olmad���n� kontrol eder
            {
                app.UseExceptionHandler("/Home/Error"); // Geli�tirme ortam�nda de�ilse hata ay�klama sayfas� yerine �zel hata sayfas�n� kullan�r

                app.UseHsts();
            }

            app.UseHttpsRedirection(); //HTTP isteklerini otomatik olarak HTTPS'e y�nlendirir
            app.UseStaticFiles(); // Uygulaman�n statik dosyalar� kullanmas�na izin verir

            app.UseRouting();// Uygulaman�n y�nlendirme i�lemlerini kullanmas�na izin verir

            app.UseAuthorization();//

            app.MapControllerRoute( //  Routing konfig�rasyonunu yapar.
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            // {controller=Home}: Varsay�lan olarak Home controller'� �a��r�r.
            //{ action = Index}: Varsay�lan olarak Index action metodunu �a��r�r.
            //{ id ?}: Optional bir parametre olarak id'yi al�r.

            app.Run();// Uygulamay� �al��t�r�r.
        }
    }
}


//Controller: Kullan�c� etkile�imlerini y�netir, model verilerini al�r ve uygun view'e y�nlendirir.
//Action: Controller i�indeki bir metottur, belirli bir g�revi yerine getirir ve bir view'e y�nlendirir.
//Model: Uygulama verilerini temsil eder.
//View: Kullan�c� aray�z�n� olu�turur, model verilerini kullanarak dinamik i�erik �retir.
//Razor: View'leri olu�turmak i�in kullan�lan bir sayfa d�zenleme motoru.
//RazorView: Razor syntax ile olu�turulmu� bir view dosyas�.
//wwwroot: Statik dosyalar�n(CSS, JavaScript, img) bulundu�u klas�r.
//builder.Build(): Configuration ve service'lerin yap�land�r�ld��� builder nesnesini kullanarak bir WebApplication olu�turur.
//app.Run(): Olu�turulan uygulamay� �al��t�r�r ve HTTP isteklerini i�ler.