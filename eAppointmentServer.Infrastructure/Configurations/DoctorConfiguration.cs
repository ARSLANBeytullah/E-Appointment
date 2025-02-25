﻿using eAppointment.Domain.Entities;
using eAppointment.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eAppointmentServer.Infrastructure.Configurations;

internal sealed class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.Property(p => p.FirstName).HasColumnType("varchar(50)");
            builder.Property(p => p.LastName).HasColumnType("varchar(50)");
        //builder.HasIndex(p => new { p.FirstName, p.LastName}).IsUnique();

        builder.Property(p => p.Department)
            .HasConversion(v => v.Value, v => DepartmentEnum.FromValue(v))
            .HasColumnName("Department");
    }
    }
