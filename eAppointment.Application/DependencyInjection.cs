using Microsoft.Extensions.DependencyInjection;

namespace eAppointment.Application;

public static  class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
        });
        //services.AddAutoMapper(typeof(DependencyInjection).Assembly);
        //services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
        //services.AddGenericRepository();
        //services.AddScoped<IAppointmentRepository, AppointmentRepository>();
        //services.AddScoped<IDoctorRepository, DoctorRepository>();
        //services.AddScoped<IPatientRepository, PatientRepository>();
        //services.AddScoped<IAppointmentService, AppointmentService>();
        //services.AddScoped<IDoctorService, DoctorService>();
        //services.AddScoped<IPatientService, PatientService>();
        return services;
    }
}

