using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlinePharmacy.Server.Data;
using OnlinePharmacy.Server.IRepository;
using OnlinePharmacy.Shared.Domain;

namespace OnlinePharmacy.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionItemsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PrescriptionItemsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/PrescriptionItems
        [HttpGet]
        public async Task<IActionResult> GetPrescriptionItems()
        {
            var prescriptionitems = await _unitOfWork.PrescriptionItems.GetAll(includes: q => q.Include(x => x.Product));
            return Ok(prescriptionitems);
        }

        // GET: api/PrescriptionItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPrescriptionItem(int id)
        {
            var prescriptionitem = await _unitOfWork.PrescriptionItems.Get(q => q.Id == id);

            if (prescriptionitem == null)
            {
                return NotFound();
            }

            //  return prescriptionitem;
            return Ok(prescriptionitem);
        }

        // PUT: api/PrescriptionItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrescriptionItem(int id, PrescriptionItem prescriptionitem)
        {
            if (id != prescriptionitem.Id)
            {
                return BadRequest();
            }

            _unitOfWork.PrescriptionItems.Update(prescriptionitem);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await PrescriptionItemExists(id))
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

        // POST: api/PrescriptionItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PrescriptionItem>> PostPrescriptionItem(PrescriptionItem prescriptionitem)
        {
            if (_unitOfWork.PrescriptionItems == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PrescriptionItems'  is null.");
            }

            await _unitOfWork.PrescriptionItems.Insert(prescriptionitem);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetPrescriptionItem", new { id = prescriptionitem.Id }, prescriptionitem);
        }

        // DELETE: api/PrescriptionItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrescriptionItem(int id)
        {
            if (_unitOfWork.PrescriptionItems == null)
            {
                return NotFound();
            }

            var prescription = await _unitOfWork.PrescriptionItems.Get(q => q.Id == id);
            if (prescription == null)
            {
                return NotFound();
            }

            await _unitOfWork.PrescriptionItems.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> PrescriptionItemExists(int id)
        {
            //return (_context.Prescriptions?.Any(e => e.Id == id)).GetValueOrDefault();
            var prescription = await _unitOfWork.PrescriptionItems.Get(q => q.Id == id);
            return prescription != null;
        }
    }
}
