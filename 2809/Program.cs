namespace _2809
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ���������� ����� ��� ������������� ������������ � ���������������
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // ��������� �������������� �� ��� ��������� ��������
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

            // ��������� �������������
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Matrix}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
