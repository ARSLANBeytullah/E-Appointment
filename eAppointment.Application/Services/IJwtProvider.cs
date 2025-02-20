using eAppointment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAppointment.Application.Services
{
    public interface IJwtProvider
    {
        string GenerateToken(AppUser user);
    }
}
