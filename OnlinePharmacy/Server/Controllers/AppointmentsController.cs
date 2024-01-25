using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlinePharmacy.Server.Data;
using OnlinePharmacy.Server.IRepository;
using OnlinePharmacy.Server.Repository;
using OnlinePharmacy.Shared.Domain;

namespace OnlinePharmacy.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public AppointmentsController(ApplicationDbContext context)
        public AppointmentsController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Appointments
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments()
        public async Task<IActionResult> GetAppointments()
        {
            //if (_context.Appointments == null)
            //{
            //    return NotFound();
            //}
            //return await _context.Appointments.ToListAsync();
            var appointments = await _unitOfWork.Appointments.GetAll(includes: q => q.Include(x => x.Customer)); 
            return Ok(appointments);
        }

        // GET: api/Appointments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> GetAppointment(int id)
        {
            //if (_context.Appointments == null)
            //{
            //    return NotFound();
            //}
            //  var appointment = await _context.Appointments.FindAsync(id);
            var appointment = await _unitOfWork.Appointments.Get(q => q.Id == id);

            if (appointment == null)
            {
                return NotFound();
            }

            //  return appointment;
            return Ok(appointment);
        }

        // PUT: api/Appointments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppointment(int id, Appointment appointment)
        {
            if (id != appointment.Id)
            {
                return BadRequest();
            }

            //_context.Entry(appointment).State = EntityState.Modified;
            _unitOfWork.Appointments.Update(appointment);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!AppointmentExists(id))
                if (!await AppointmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Appointments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Appointment>> PostAppointment(Appointment appointment)
        {
            //if (_context.Appointments == null)
            //{
            //    return Problem("Entity set 'ApplicationDbContext.Appointments'  is null.");
            //}
            //  _context.Appointments.Add(appointment);
            //  await _context.SaveChangesAsync();
            await _unitOfWork.Appointments.Insert(appointment);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetAppointment", new { id = appointment.Id }, appointment);
        }

        // DELETE: api/Appointments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            //if (_context.Appointments == null)
            //{
            //    return NotFound();
            //}
            //var appointment = await _context.Appointments.FindAsync(id);
            var appointment = await _unitOfWork.Appointments.Get(q => q.Id == id);
            if (appointment == null)
            {
                return NotFound();
            }

            //_context.Appointments.Remove(appointment);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Appointments.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool AppointmentExists(int id)
        private async Task<bool> AppointmentExists(int id)
        {
            //return (_context.Appointments?.Any(e => e.Id == id)).GetValueOrDefault();
            var appointment = await _unitOfWork.Appointments.Get(q => q.Id == id);
            return appointment != null;
        }
    }
}
