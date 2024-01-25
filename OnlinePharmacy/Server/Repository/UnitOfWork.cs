using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlinePharmacy.Server.Data;
using OnlinePharmacy.Server.IRepository;
using OnlinePharmacy.Server.Models;
using OnlinePharmacy.Server.Repository;
using OnlinePharmacy.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OnlinePharmacy.Server.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IGenericRepository<Product> _products;
        private IGenericRepository<Appointment> _appointments;
        private IGenericRepository<Order> _orders;
        private IGenericRepository<Prescription> _prescriptions;
        private IGenericRepository<Staff> _staffs;
        private IGenericRepository<Customer> _customers;


        private UserManager<ApplicationUser> _userManager;

        public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IGenericRepository<Product> Products
            => _products ??= new GenericRepository<Product>(_context);
        public IGenericRepository<Appointment> Appointments
            => _appointments ??= new GenericRepository<Appointment>(_context);
        public IGenericRepository<Order> Orders
            => _orders ??= new GenericRepository<Order>(_context);
        public IGenericRepository<Prescription> Prescriptions
            => _prescriptions ??= new GenericRepository<Prescription>(_context);
        public IGenericRepository<Staff> Staffs
            => _staffs ??= new GenericRepository<Staff>(_context);
        public IGenericRepository<Customer> Customers
            => _customers ??= new GenericRepository<Customer>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save(HttpContext httpContext)
        {
            //To be implemented
            string user = "System";

            var entries = _context.ChangeTracker.Entries()
                .Where(q => q.State == EntityState.Modified ||
                    q.State == EntityState.Added);

            foreach (var entry in entries)
            {
                ((BaseDomainModel)entry.Entity).DateUpdated = DateTime.Now;
                ((BaseDomainModel)entry.Entity).UpdatedBy = user;
                if (entry.State == EntityState.Added)
                {
                    ((BaseDomainModel)entry.Entity).DateCreated = DateTime.Now;
                    ((BaseDomainModel)entry.Entity).CreatedBy = user;
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}