namespace _2809
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Добавление служб для использования контроллеров с представлениями
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Настройка промежуточного ПО для обработки запросов
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // Настройка маршрутизации
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Matrix}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
