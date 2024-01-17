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
    public class StaffsController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public StaffsController(ApplicationDbContext context)
        public StaffsController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Staffs
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Staff>>> GetStaffs()
        public async Task<IActionResult> GetStaffs()
        {
            //if (_context.Staffs == null)
            //{
            //    return NotFound();
            //}
            //return await _context.Staffs.ToListAsync();
            var staffs = await _unitOfWork.Staffs.GetAll();
            return Ok(staffs);
        }

        // GET: api/Staffs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Staff>> GetStaff(int id)
        {
            //if (_context.Staffs == null)
            //{
            //    return NotFound();
            //}
            //  var staff = await _context.Staffs.FindAsync(id);
            var staff = await _unitOfWork.Staffs.Get(q => q.Id == id);

            if (staff == null)
            {
                return NotFound();
            }

            //  return staff;
            return Ok(staff);
        }

        // PUT: api/Staffs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaff(int id, Staff staff)
        {
            if (id != staff.Id)
            {
                return BadRequest();
            }

            //_context.Entry(staff).State = EntityState.Modified;
            _unitOfWork.Staffs.Update(staff);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!StaffExists(id))
                if (!await StaffExists(id))
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

        // POST: api/Staffs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Staff>> PostStaff(Staff staff)
        {
            //if (_context.Staffs == null)
            //{
            //    return Problem("Entity set 'ApplicationDbContext.Staffs'  is null.");
            //}
            //  _context.Staffs.Add(staff);
            //  await _context.SaveChangesAsync();
            await _unitOfWork.Staffs.Insert(staff);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetStaff", new { id = staff.Id }, staff);
        }

        // DELETE: api/Staffs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            //if (_context.Staffs == null)
            //{
            //    return NotFound();
            //}
            //var staff = await _context.Staffs.FindAsync(id);
            var staff = await _unitOfWork.Staffs.Get(q => q.Id == id);
            if (staff == null)
            {
                return NotFound();
            }

            //_context.Staffs.Remove(staff);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Staffs.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool StaffExists(int id)
        private async Task<bool> StaffExists(int id)
        {
            //return (_context.Staffs?.Any(e => e.Id == id)).GetValueOrDefault();
            var staff = await _unitOfWork.Staffs.Get(q => q.Id == id);
            return staff != null;
        }
    }
}
