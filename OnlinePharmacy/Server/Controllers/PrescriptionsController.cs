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
    public class PrescriptionsController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public PrescriptionsController(ApplicationDbContext context)
        public PrescriptionsController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Prescriptions
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Prescription>>> GetPrescriptions()
        public async Task<IActionResult> GetPrescriptions()
        {
            //if (_context.Prescriptions == null)
            //{
            //    return NotFound();
            //}
            //return await _context.Prescriptions.ToListAsync();
            var prescriptions = await _unitOfWork.Prescriptions.GetAll();
            return Ok(prescriptions);
        }

        // GET: api/Prescriptions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Prescription>> GetPrescription(int id)
        {
            //if (_context.Prescriptions == null)
            //{
            //    return NotFound();
            //}
            //  var prescription = await _context.Prescriptions.FindAsync(id);
            var prescription = await _unitOfWork.Prescriptions.Get(q => q.Id == id);

            if (prescription == null)
            {
                return NotFound();
            }

          //  return prescription;
          return Ok(prescription);
        }

        // PUT: api/Prescriptions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrescription(int id, Prescription prescription)
        {
            if (id != prescription.Id)
            {
                return BadRequest();
            }

            //_context.Entry(prescription).State = EntityState.Modified;
            _unitOfWork.Prescriptions.Update(prescription);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!PrescriptionExists(id))
                if (!await PrescriptionExists(id))
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

        // POST: api/Prescriptions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Prescription>> PostPrescription(Prescription prescription)
        {
            //if (_context.Prescriptions == null)
            //{
            //    return Problem("Entity set 'ApplicationDbContext.Prescriptions'  is null.");
            //}
            //  _context.Prescriptions.Add(prescription);
            //  await _context.SaveChangesAsync();
            await _unitOfWork.Prescriptions.Insert(prescription);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetPrescription", new { id = prescription.Id }, prescription);
        }

        // DELETE: api/Prescriptions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrescription(int id)
        {
            //if (_context.Prescriptions == null)
            //{
            //    return NotFound();
            //}
            //var prescription = await _context.Prescriptions.FindAsync(id);
            var prescription = await _unitOfWork.Prescriptions.Get(q => q.Id == id);
            if (prescription == null)
            {
                return NotFound();
            }

            //_context.Prescriptions.Remove(prescription);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Prescriptions.Delete(id);
            await _unitOfWork.Save(HttpContext);    

            return NoContent();
        }

        //private bool PrescriptionExists(int id)
        private async Task<bool> PrescriptionExists(int id)
        {
            //return (_context.Prescriptions?.Any(e => e.Id == id)).GetValueOrDefault();
            var prescription = await _unitOfWork.Prescriptions.Get(q => q.Id == id);
            return prescription != null;
        }
    }
}
