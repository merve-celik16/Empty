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
            //Web uygulamanýzý baþlatmak ve uygulama için gerekli ayarlarý ve yapýlandýrmalarý yönetir.
            var builder = WebApplication.CreateBuilder(args);

            
            builder.Services.AddControllersWithViews();//MVC mimarisini kullanarak hem Controller hem de View desteðini eklemesini saðlar.


            var app = builder.Build(); // Uygulama yapýlandýrmasýný tamamlar ve uygulama nesnesini (app) oluþturur

           
            if (!app.Environment.IsDevelopment()) // Uygulamanýn geliþtirme ortamýnda olup olmadýðýný kontrol eder
            {
                app.UseExceptionHandler("/Home/Error"); // Geliþtirme ortamýnda deðilse hata ayýklama sayfasý yerine özel hata sayfasýný kullanýr

                app.UseHsts();
            }

            app.UseHttpsRedirection(); //HTTP isteklerini otomatik olarak HTTPS'e yönlendirir
            app.UseStaticFiles(); // Uygulamanýn statik dosyalarý kullanmasýna izin verir

            app.UseRouting();// Uygulamanýn yönlendirme iþlemlerini kullanmasýna izin verir

            app.UseAuthorization();//

            app.MapControllerRoute( //  Routing konfigürasyonunu yapar.
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            // {controller=Home}: Varsayýlan olarak Home controller'ý çaðýrýr.
            //{ action = Index}: Varsayýlan olarak Index action metodunu çaðýrýr.
            //{ id ?}: Optional bir parametre olarak id'yi alýr.

            app.Run();// Uygulamayý çalýþtýrýr.
        }
    }
}


//Controller: Kullanýcý etkileþimlerini yönetir, model verilerini alýr ve uygun view'e yönlendirir.
//Action: Controller içindeki bir metottur, belirli bir görevi yerine getirir ve bir view'e yönlendirir.
//Model: Uygulama verilerini temsil eder.
//View: Kullanýcý arayüzünü oluþturur, model verilerini kullanarak dinamik içerik üretir.
//Razor: View'leri oluþturmak için kullanýlan bir sayfa düzenleme motoru.
//RazorView: Razor syntax ile oluþturulmuþ bir view dosyasý.
//wwwroot: Statik dosyalarýn(CSS, JavaScript, img) bulunduðu klasör.
//builder.Build(): Configuration ve service'lerin yapýlandýrýldýðý builder nesnesini kullanarak bir WebApplication oluþturur.
//app.Run(): Oluþturulan uygulamayý çalýþtýrýr ve HTTP isteklerini iþler.