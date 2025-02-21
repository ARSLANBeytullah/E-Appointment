using eAppointment.Domain.Entities;
using eAppointment.Domain.Repositories;
using eAppointmentServer.Infrastructure.Context;
using GenericRepository;

namespace eAppointmentServer.Infrastructure.Repositories;

internal sealed class DoctorRepository : Repository<Doctor, ApplicationDbContext>, IDoctorRepository
{
    public DoctorRepository(ApplicationDbContext context) : base(context)
    {
    }
}
