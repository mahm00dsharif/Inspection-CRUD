using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inspection.Data;

namespace Inspection.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InspectionsController : ControllerBase
    {
        private readonly DataContext _context;

        public InspectionsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Inspections
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Inspection>>> Getinspections()
        {
          if (_context.inspections == null)
          {
              return NotFound();
          }
            return await _context.inspections.ToListAsync();
        }

        // GET: api/Inspections/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Inspection>> GetInspection(int id)
        {
          if (_context.inspections == null)
          {
              return NotFound();
          }
            var inspection = await _context.inspections.FindAsync(id);

            if (inspection == null)
            {
                return NotFound();
            }

            return inspection;
        }

        // PUT: api/Inspections/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInspection(int id, Models.Inspection inspection)
        {
            if (id != inspection.Id)
            {
                return BadRequest();
            }

            _context.Entry(inspection).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InspectionExists(id))
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

        // POST: api/Inspections
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Models.Inspection>> PostInspection(Models.Inspection inspection)
        {
          if (_context.inspections == null)
          {
              return Problem("Entity set 'DataContext.inspections'  is null.");
          }
            _context.inspections.Add(inspection);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInspection", new { id = inspection.Id }, inspection);
        }

        // DELETE: api/Inspections/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInspection(int id)
        {
            if (_context.inspections == null)
            {
                return NotFound();
            }
            var inspection = await _context.inspections.FindAsync(id);
            if (inspection == null)
            {
                return NotFound();
            }

            _context.inspections.Remove(inspection);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InspectionExists(int id)
        {
            return (_context.inspections?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
