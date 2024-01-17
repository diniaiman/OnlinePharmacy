using OnlinePharmacy.Shared.Domain;
using Microsoft.AspNetCore.Http;
using OnlinePharmacy.Server.IRepository;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePharmacy.Server.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save(HttpContext httpContext);
        IGenericRepository<Product> Products { get; }
        IGenericRepository<Appointment> Appointments { get; }
        IGenericRepository<Order> Orders { get; }
        IGenericRepository<Prescription> Prescriptions { get; }
        IGenericRepository<Staff> Staffs { get; }
        IGenericRepository<User> Users { get; }
    }
}