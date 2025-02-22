using eAppointment.Application.Services;
using eAppointment.Domain.Entities;
using eAppointment.Domain.Repositories;
using eAppointmentServer.Infrastructure.Context;
using eAppointmentServer.Infrastructure.Repositories;
using eAppointmentServer.Infrastructure.Services;
using GenericRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace eAppointmentServer.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(optionsAction: options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("SqlServer"));
        });

        services.AddIdentity<AppUser, AppRole>(action =>
        {
            action.Password.RequiredLength = 3;
            action.Password.RequireUppercase = false;
            action.Password.RequireLowercase = false;
            action.Password.RequireNonAlphanumeric = false;
            action.Password.RequireDigit = false;
        }).AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddScoped<IUnitOfWork>(srv => srv.GetRequiredService<ApplicationDbContext>());

        services.Scan( action => //Yazılacak bütün servislerin dipendency injection işlemlerini gerçekleştirir. Interface'ler büyük ı harfi ile başladığı sürece otomatik olarak tanımlar.
        {
                action
                .FromAssemblies(typeof(DependencyInjection).Assembly) //DI' ı bu katmanda(Infrastructor) katmanında gerçekleştir.
                .AddClasses(publicOnly: false) //sadece public class'larda mı uygulansını false yaptım ki farklı access modifier'larda dahil olsun diye.
                .UsingRegistrationStrategy(registrationStrategy: RegistrationStrategy.Skip)//halihazırda DI uygulanmış servisleri geç. Yeni ekleceklere müdahalede bulun.
                .AsImplementedInterfaces()
                .WithScopedLifetime();
        });

        //services.AddScoped<IAppointmentRepository, AppointmentRepository>();
        //services.AddScoped<IDoctorRepository, DoctorRepository>();
        //services.AddScoped<IPatientRepository, PatientRepository>();

        //services.AddScoped<IJwtProvider, JwtProvider>();
        return services;
    }

}